using AuthApiTest.Models;
using AuthApiTest.NewFolder;
using Microsoft.AspNetCore.Mvc;

namespace AuthApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;
        public IssueController(IIssueService issueService) => _issueService = issueService;

        [HttpGet]
        public async Task<IEnumerable<Issue>> GetAllIssues()
        {
            return await _issueService.GetAllIssues();
        }

        [HttpGet("{id:int}", Name = "GetIssueById")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIssueById(int id)
        {
            var issue = await _issueService.GetIssueById(id);

            return issue.ResponseObject == null ? NotFound() : Ok(issue);
        }

        [HttpPost("createIssue")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateIssue([FromBody] Issue issue)
        {
            var res = await _issueService.CreateIssue(issue);

            return CreatedAtAction(nameof(GetIssueById), new { id = issue.Id }, res);
        }

        [HttpPut("updateIssue/{id:int}")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateIssue(int id, [FromBody] Issue issue)
        {
            var res = await _issueService.UpdateIssue(id, issue);

            return res.ResponseObject == null ? NotFound(res) : Ok(res);
        }

        [HttpDelete("deleteIssue/{id:int}")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            var res = await _issueService.DeleteIssue(id);

            return res.ResponseObject == null ? NotFound(new
            {
                message = res.Message
            }) : Ok(new
            {
                message = res.Message
            });
        }
    }
}
