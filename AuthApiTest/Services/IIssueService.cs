using AuthApiTest.Models;
using AuthApiTest.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace AuthApiTest.Services
{
    public interface IIssueService
    {
        public Task<IEnumerable<Issue>> GetAllIssues();
        public Task<ResponseHelper<Issue>> GetIssueById(int id);
        public Task<ResponseHelper<Issue>> CreateIssue([FromBody] Issue issue);
        public Task<ResponseHelper<Issue>> UpdateIssue(int id, [FromBody] Issue issue);
        public Task<ResponseHelper<Issue>> DeleteIssue(int id);
    }
}
