using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SomeApi.Controllers
{
    public class BooksController : ControllerBase
    {

        [HttpPost("books")]
        public ActionResult AddABook([FromBody] PostBookRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = new GetBookResponse(request.Title, request.Author, request.NumberOfPages, new Random().Next(300, 1545));
                return Ok(response);
            } else
            {
                return BadRequest(ModelState);
            }
        }

    }

    public record PostBookRequest(
        [Required]
        string Title,
        [Required]
        string Author,
        [Range(1,1000)]
        int NumberOfPages
        );

    public record GetBookResponse(string Title, string Author, int NumberOfPages, int Id );
    
}
