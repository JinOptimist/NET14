using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models.SocialModels;
using System.Collections.Generic;

namespace Net14.Web.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private IssueForToDoRepository _issueForToDoRepository;
        private IMapper _mapper;

        public ToDoListController(IssueForToDoRepository issueForToDoRepository, IMapper mapper)
        {
            _issueForToDoRepository = issueForToDoRepository;
            _mapper = mapper;
        }

        public List<IssuesForToDoViewModel> GetIssues() 
            => _mapper.Map<List<IssuesForToDoViewModel>>(_issueForToDoRepository.GetAll()); 
        
        
    }
}
