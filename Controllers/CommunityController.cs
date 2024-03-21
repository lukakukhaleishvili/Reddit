using Microsoft.AspNetCore.Mvc;
using Reddit.Dtos;
using System.Collections.Generic;

namespace Reddit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommunityController : ControllerBase
    {
        private readonly ICommunityService _communityService;


        public CommunityController(ICommunityService communityService)
        {
            _communityService = communityService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Community>> Get()
        {
            var communities = _communityService.GetAllCommunities();
            return Ok(communities);
        }


        [HttpGet("{id}")]
        public ActionResult<Community> GetAction(int id)
        {
            var community = _communityService.GetCommunitiesById(id);
            if (community == null)
            {
                return NotFound();
            }
            return OK(community);
        }



        [HttpPost]
        public ActionResult<Community> Post([FromBody] Community community)
        {
            _communityService.PostCommunity(community);
            return CreatedAtAction(nameof(Get), new { id = community.ComunityId }, community);
        }


        [HttpDelete("{id}")]
        public IActionResult Delate(int id)
        {
            var communityToDelete = _communityService.GetCommunitiesById(id);
            if (communityToDelete == null)
            {
                return NotFound();
            }
            _communityService.DeleteCommunity(id);
            return NoContent();
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Community community)
        {
            if (id != community.ComunityId)
            {
                return BadRequest();
            }
            _communityService.UpdateCommunity(community);
            retunr NoContent();
        }
    }


}
