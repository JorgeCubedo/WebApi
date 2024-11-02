using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public IActionResult GetAuthors()
        {
            try
            {
                var authors = _authorService.GetAuthors();
                if (authors != null)
                {
                    if (authors.Count != 0) 
                        return Ok(authors);

                    return NoContent();
                }

                return NotFound();

                
            }
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] Author author)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }
    }
}
