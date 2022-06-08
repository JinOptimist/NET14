using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
using Net14.Web.Models.SocialModels;
using Net14.Web.Services;
using System.Collections.Generic;

namespace Net14.Web.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private IssueForToDoRepository _issueForToDoRepository;
        private FoldersForToDoRepository _foldersForToDoRepository;
        private UserService _userService;
        private IMapper _mapper;

        public ToDoListController(
            IssueForToDoRepository issueForToDoRepository,
            FoldersForToDoRepository foldersForToDoRepository,
            IMapper mapper, 
            UserService userService)
        {
            _issueForToDoRepository = issueForToDoRepository;
            _foldersForToDoRepository = foldersForToDoRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public List<IssuesForToDoViewModel> GetIssues()
            => _mapper.Map<List<IssuesForToDoViewModel>>(_issueForToDoRepository.GetAll());

        public List<FoldersForToDoViewModel> GetFolders()
            => _mapper.Map<List<FoldersForToDoViewModel>>(_foldersForToDoRepository.GetAll());

        public IssuesForToDoViewModel CreateIssue(IssuesForToDo issue)
        {
            _issueForToDoRepository.Save(issue);
            var viewModel = _mapper.Map<IssuesForToDoViewModel>(issue);
            return viewModel;

        }
        public bool RemoveIssue(int id)
        {
            _issueForToDoRepository.Remove(id);
            return true;
        }
        public SocialUserViewModel GetUser()
        {
            var user = _mapper.Map<SocialUserViewModel>(_userService.GetCurrent());
            return user;
        }



    }
}
