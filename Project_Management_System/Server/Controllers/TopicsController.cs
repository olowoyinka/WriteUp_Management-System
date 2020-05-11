﻿using AutoMapper;
using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.ViewModelResponse;
using EndPoint.v1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Management_System.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TopicsController : ControllerBase
    {
        private readonly ITopics _topicsService;

        private readonly IMapper _mapper;

        public TopicsController(ITopics topicsService,
                IMapper mapper)
        {
            _topicsService = topicsService;
            _mapper = mapper;
        }


        [HttpPost(APIRoute.Topics.Create)]
        public async Task<IActionResult> Create([FromBody] TopicsRequest topicsRequest)
        {
            var topics = await _topicsService.CreateAsync(topicsRequest, GetUserId());

            if (!topics)
            {
                return BadRequest(new
                {
                    Error = "The  Name Already Exist"
                });
            }

            return Ok(new { 
                  Status = "The Topic is Created"
            });

        }

        [HttpGet(APIRoute.Topics.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var topics = await _topicsService.GetAllAsync(GetUserId());

            if (topics == null)
            {
                return BadRequest(new
                {
                    Error = "No Record of Topics"
                });
            }

            return Ok(_mapper.Map<List<TopicsResponse>>(topics));
        }

        [HttpGet(APIRoute.Topics.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid topicsId)
        {
            var topics = await _topicsService.GetByIdAsync(topicsId, GetUserId());

            if (topics == null)
            {
                return BadRequest(new
                {
                    Error = "The  Name Doesn't Exist"
                });
            }

            return Ok(_mapper.Map<TopicsResponse>(topics));
        }

        [HttpPut(APIRoute.Topics.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid topicsId, [FromBody] TopicsRequest topicsRequest)
        {
            var topics = await _topicsService.UpdateAsync(topicsId, topicsRequest, GetUserId());

            if (!topics)
            {
                return BadRequest(new
                {
                    Error = "The  Name Doesn't Exist"
                });
            }

            return Ok(new
            {
                Status = "The Topic is Updated"
            });
        }


        [HttpDelete(APIRoute.Topics.DeleteById)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid topicsId)
        {
            var topics = await _topicsService.DeleteAsync(topicsId, GetUserId());

            if (!topics)
            {
                return BadRequest(new
                {
                    Error = "The  Name Doesn't Exist"
                });
            }

            return Ok( new { 
                Status = "Topic Deleted"
            });
        }

        private string GetUserId()
        {
            return HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
        }
    }
}