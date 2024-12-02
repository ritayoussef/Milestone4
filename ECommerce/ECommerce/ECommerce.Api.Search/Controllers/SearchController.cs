using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
/*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by:   Rita Youssef - 2124602
* Date: 		1st December 2024
* Class Name: 	SearchController.cs
* Description:  This class does an http post call by interacting with ISearchService to retrieve search results based on a search term.
* Time for Task:	10 hours
    */

namespace ECommerce.Api.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;
        public SearchController(ISearchService searchService) 
        {
            this.searchService = searchService;
        }
        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm term)
        {
            var result = await searchService.SearchAsync(term.CustomerId);
            if (result.IsSuccess)
            {
                return Ok(result.SearchResults);
            }
            return NotFound();
        }


    }
}
