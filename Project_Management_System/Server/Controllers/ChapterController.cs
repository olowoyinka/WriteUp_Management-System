using AutoMapper;
using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using EndPoint.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Management_System.Server.Helpers;
using Project_Management_System.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ChapterController : ControllerBase
    {
        private readonly IChapter _chapterService;

        private readonly IMapper _mapper;

        public ChapterController(IChapter chapterService,
                    IMapper mapper)
        {
            _chapterService = chapterService;
            _mapper = mapper;
        }

        [HttpPost(APIRoute.Chapter.Create)]
        public async Task<IActionResult> Create([FromRoute] Guid topicsId, [FromBody] ChapterRequest chapterRequest)
        {
            var chapter = await _chapterService.CreateAsync(chapterRequest, GetUserId(), topicsId);

            if (!chapter)
            {
                return Ok(new AuthResponse
                {
                    Error = "The Name Already Exist"
                });
            }

            return Ok(new AuthResponse
            {
                Token = "The chapter is Created"
            });

        }


        [HttpGet(APIRoute.Chapter.GetAll)]
        public async Task<IActionResult> GetAll([FromRoute] Guid topicsId, [FromQuery] PaginationRequest pagination, [FromQuery] string name)
        {
            var chapter =  _chapterService.GetChapterAllAsync(GetUserId(), topicsId, name);

            if (chapter == null)
            {
                return BadRequest(new
                {
                    Error = "No Record of Chapter"
                });
            }

            await HttpContext.InsertPaginationParameterInResponse(chapter, pagination.QuantityPerPage);

            var returnResult = await chapter.Paginate(pagination).ToListAsync();

            return Ok(_mapper.Map<List<ChapterResponse>>(returnResult));
        }


        [HttpGet(APIRoute.Chapter.GetById)]
        public async Task<IActionResult> Get([FromRoute] Guid topicsId, [FromRoute] Guid chatperId)
        {
            var chapter = await _chapterService.GetChapterIdAsync(GetUserId(), chatperId, topicsId);

            if (chapter == null)
            {
                return BadRequest(new
                {
                    Error = "The  Name Doesn't Exist"
                });
            }

            return Ok(_mapper.Map<ChapterResponse>(chapter));
        }

        [HttpPut(APIRoute.Chapter.Update)]
        public async Task<IActionResult> Update([FromBody]ChapterRequest chapterRequest,[FromRoute] Guid topicsId,
                                                            [FromRoute] Guid chatperId)
        {
            var chapter = await _chapterService.EditAsync(chapterRequest, GetUserId(), topicsId, chatperId);

            if (!chapter)
            {
                return Ok(new AuthResponse
                {
                    Error = "The Name Already Exist"
                });
            }

            return Ok(new AuthResponse
            {
                Token = "The Chapter is Updated"
            });
        }

        [HttpDelete(APIRoute.Chapter.DeletedById)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid topicsId, [FromRoute] Guid chapterId)
        {
            var chapter = await _chapterService.DeleteChapterAsync(GetUserId(), topicsId, chapterId);

            if (!chapter)
            {
                return BadRequest(new
                {
                    Error = "The  Name Doesn't Exist"
                });
            }

            return Ok(new
            {
                Status = "Chapter Deleted"
            });
        }


        private string GetUserId()
        {
            return HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
        }
    }
}
