﻿using BlazorComponents.Server.DataModel;
using BlazorComponents.Shared;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Radzen;

namespace BlazorComponents.Server.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("CorsPolicy")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors(int skip = 0, int take = 5)
        {
            try
            {
                return Ok(await _authorRepository.GetAll(skip, take));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error fetching data");
            }
        }

        //[HttpGet]
        //public async Task<ActionResult> GetAuthors(int skip = 0, int take = 5)
        //{
        //    try
        //    {
        //        var result = await _authorRepository.GetAll(skip, take);
        //        return Ok(result);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error fetching data");
        //    }
        //}

        //[HttpGet]
        //public async Task<ActionResult> GetCount()
        //{
        //    try
        //    {
        //        return Ok(await _authorRepository.GetCount());
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error fetching data");
        //    }
        //}

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            try
            {
                var result = await _authorRepository.GetAuthor(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error fetching data");
            }
        }
    }
}
