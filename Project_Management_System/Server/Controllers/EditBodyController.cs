using AutoMapper;
using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using EndPoint.v1;
using Microsoft.AspNetCore.Mvc;
using Project_Management_System.Server.Interfaces;
using System;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class EditBodyController : ControllerBase
    {
        private readonly IEditBody _editBodyService;

        private readonly IMapper _mapper;

        public EditBodyController(IEditBody editBodyService,
                    IMapper mapper)
        {
            _editBodyService = editBodyService;
            _mapper = mapper;
        }


        [HttpGet(APIRoute.EditBody.GetById)]
        public async Task<IActionResult> Get([FromRoute] Guid topicsId, [FromRoute] Guid chatperId)
        {
            var chapter = await _editBodyService.GetChapterBodyIdAsync(GetUserId(), chatperId, topicsId);

            if (chapter == null)
            {
                return BadRequest(new
                {
                    Error = "The  Name Doesn't Exist"
                });
            }

            return Ok(_mapper.Map<ChapterByIdResponse>(chapter));
        }


        [HttpPost(APIRoute.EditBody.UpdateBody)]
        public async Task<IActionResult> UpdateBody([FromBody]ChapterEditRequest chapterRequest, [FromRoute] Guid topicsId,
                                                    [FromRoute] Guid chatperId)
        {
            var chapter = await _editBodyService.EditBodyAsync(chapterRequest, GetUserId(), topicsId, chatperId);

            if (!chapter)
            {
                return Ok(new AuthResponse
                {
                    Error = "The Name Already Exist"
                });
            }

            return Ok(new AuthResponse
            {
                Token = "The Chapter Body is Updated"
            });
        }


        private string GetUserId()
        {
            return HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
        }
    }
}
