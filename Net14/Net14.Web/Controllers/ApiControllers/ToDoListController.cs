using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
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
        private FoldersForToDoRepository _foldersForToDoRepository;
        private IMapper _mapper;

        public ToDoListController(
            IssueForToDoRepository issueForToDoRepository,
            FoldersForToDoRepository foldersForToDoRepository,
            IMapper mapper)
        {
            _issueForToDoRepository = issueForToDoRepository;
            _foldersForToDoRepository = foldersForToDoRepository;
            _mapper = mapper;
        }

        public List<IssuesForToDoViewModel> GetIssues()
            => _mapper.Map<List<IssuesForToDoViewModel>>(_issueForToDoRepository.GetAll());

        
        public List<FoldersForToDoViewModel> GetFolders()
            => _mapper.Map<List<FoldersForToDoViewModel>>(_foldersForToDoRepository.GetAll());
        public bool AddIssue(string issue)
        {
            var dbModel = new IssuesForToDo()
            {
                Text = issue,
            };

            _issueForToDoRepository.Save(dbModel);

            return true;
        }
        
        
    }
}
