using AuthApiTest.Data;
using AuthApiTest.Models;
using AuthApiTest.Utilities;
using Microsoft.EntityFrameworkCore;

namespace AuthApiTest.Services
{
    public class IssueService : IIssueService
    {

        private readonly IssueDbContext _issueDbContext;

        public IssueService(IssueDbContext issueDbContext) => _issueDbContext = issueDbContext;

        public async Task<IEnumerable<Issue>> GetAllIssues()
        {
            return await _issueDbContext.Issues.ToListAsync();
        }

        public async Task<ResponseHelper<Issue>> GetIssueById(int id)
        {
            var issue = await _issueDbContext.Issues.FindAsync(id);
            if (issue == null)
            {
                return new ResponseHelper<Issue>
                {
                    ResponseObject = null,
                    Message = "Issue not found"
                };
            }

            return new ResponseHelper<Issue>
            {
                ResponseObject = issue,
                Message = "Issue found"
            };

        }

        public async Task<ResponseHelper<Issue>> CreateIssue(Issue issue)
        {
            await _issueDbContext.Issues.AddAsync(issue);
            await _issueDbContext.SaveChangesAsync();

            return new ResponseHelper<Issue>
            {
                ResponseObject = issue,
                Message = "Issue created successfully"
            };
        }

        public async Task<ResponseHelper<Issue>> UpdateIssue(int id, Issue issue)
        {
            if (id != issue.Id)
            {
                return new ResponseHelper<Issue>
                {
                    ResponseObject = null,
                    Message = "Issue not found"
                };
            }

            _issueDbContext.Entry(issue).State = EntityState.Modified;
            await _issueDbContext.SaveChangesAsync();

            return new ResponseHelper<Issue>
            {
                ResponseObject = issue,
                Message = "Issue updated successfully"
            };
        }


        public async Task<ResponseHelper<Issue>> DeleteIssue(int id)
        {
            var issue = await _issueDbContext.Issues.FindAsync(id);
            if (issue == null)
            {
                return new ResponseHelper<Issue>
                {
                    ResponseObject = null,
                    Message = "Issue not found"
                };
            }

            _issueDbContext.Issues.Remove(issue);
            await _issueDbContext.SaveChangesAsync();
            return new ResponseHelper<Issue>
            {
                ResponseObject = issue,
                Message = "Issue deleted successfully"
            };
        }
    }
}


