using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.Services.Enums;
using Net14.Web.Models;
using AutoMapper;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Xceed.Document.NET;
using Xceed.Words.NET;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using Microsoft.AspNetCore.SignalR;
using Net14.Web.SignalRHubs;
using Net14.Web.Models.SocialModels.DataModels;

namespace Net14.Web.Services
{
    [AutoRegister]
    public class ReportsService
    {
        private UserService _userService;
        private IMapper _mapper;
        private IWebHostEnvironment _webHostEnvironment;
        private SocialFileRepository _socialFileRepository;
        private SocialGroupRepository _socialGroupRepository;
        private IHubContext<ReportHub> _hubContext;
        private int completedPages = 0;


        const string _fontStyle = "Times New Roman";
        const int _fontSize = 25;
        const Alignment _alignment = Alignment.center;
        const float _indentationAfter = 30;
        public ReportsService(UserService userService,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment,
            SocialFileRepository socialFileRepository,
            SocialGroupRepository socialGroupRepository,
            IHubContext<ReportHub> hubContext) 
        {
            _userService = userService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _socialFileRepository = socialFileRepository;
            _socialGroupRepository = socialGroupRepository;
            _hubContext = hubContext;
            
        }

        public bool GetUserReport(UserReportModel user, string path, int reportId, CancellationToken token) 
        {
            if (token.IsCancellationRequested) 
            {
                return false;
            }
            var doc = DocX.Create(path); //create docx word document

            doc.AddHeaders(); //add header (optional)
            doc.AddFooters(); //add footer in this document (optional code)

            // Force the first page to have a different Header and Footer.
            doc.DifferentFirstPage = true;

            doc.Footers.First.InsertParagraph("Page ").AppendPageNumber(PageNumberFormat.normal).Append(" of ").AppendPageCount(PageNumberFormat.normal); // add footer with page number


            UserInfo(doc, user, reportId, token);
            if (token.IsCancellationRequested)
            {
                return false;
            }
            UsersFriends(doc, user, reportId, token);
            if (token.IsCancellationRequested)
            {
                return false;
            }
            UsersGroups(doc, user, reportId, token);
            if (token.IsCancellationRequested)
            {
                return false;
            }
            UsersFiles(doc, user, reportId, token);
            if (token.IsCancellationRequested)
            {
                return false;
            }
            UserMessages(doc, user, reportId, token);



            doc.Save(); // save changes to file
            return true;

        }

        private void UserInfo(DocX doc, UserReportModel user, int reportId, CancellationToken token) 
        {
            if (token.IsCancellationRequested) 
            {
                return;
            }
            var userInfo = doc.InsertParagraph();

            userInfo.Append("User Info")
                .Font(_fontStyle)
                .FontSize(_fontSize)
                .Bold()
                .AppendLine($"{user.FirstName} {user.LastName}")
                .AppendLine($"{user.Country}, {user.City}");

            userInfo.Alignment = _alignment;
            userInfo.InsertPageBreakAfterSelf();
            Thread.Sleep(2000);

            completedPages++;

            _hubContext.Clients.User(user.Id.ToString()).SendAsync("Progress_Update", completedPages, reportId);

        }

        private void UsersFriends(DocX doc, UserReportModel user, int reportId, CancellationToken token) 
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            var userFriends = doc.InsertParagraph();

            userFriends.Append("User Friends")
                .Font(_fontStyle)
                .FontSize(_fontSize)
                .Bold();

            userFriends.InsertPageBreakAfterSelf();

            userFriends.Alignment = _alignment;

            user.Friends.ForEach(friend =>
                userFriends.AppendLine(friend.FirstName + " " + friend.LastName));

            Thread.Sleep(2000);
            completedPages++;
            _hubContext.Clients.User(user.Id.ToString()).SendAsync("Progress_Update", completedPages, reportId);

        }

        private void UsersGroups(DocX doc, UserReportModel user, int reportId, CancellationToken token) 
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            var userGroups = doc.InsertParagraph();

            userGroups.Append("User Groups")
                .Font(_fontStyle)
                .FontSize(_fontSize)
                .Bold();

            userGroups.Alignment = _alignment;

            userGroups.InsertPageBreakAfterSelf();


            user.Groups.ForEach(group =>
                userGroups.AppendLine(group.Name + "  " + group.MemberCount + " members"));

            Thread.Sleep(2000);
            completedPages++;
            _hubContext.Clients.User(user.Id.ToString()).SendAsync("Progress_Update", completedPages, reportId);


        }

        private void UsersFiles(DocX doc, UserReportModel user, int reportId, CancellationToken token) 
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            var userFilesSec = doc.InsertParagraph();

            userFilesSec.Append("User Files")
                .Font(_fontStyle)
                .FontSize(_fontSize)
                .Bold();

            userFilesSec.Alignment = Alignment.center;

            userFilesSec.InsertPageBreakAfterSelf();

            user.Files.ForEach(file =>
                userFilesSec.AppendLine(file.Name + "  " + file.Url));

            Thread.Sleep(2000);
            completedPages++;
            _hubContext.Clients.User(user.Id.ToString()).SendAsync("Progress_Update", completedPages, reportId);


        }

        private void UserMessages(DocX doc, UserReportModel user, int reportId, CancellationToken token) 
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            var userMessagesSec = doc.InsertParagraph();

            userMessagesSec.Append("User Messages")
                .Font(_fontStyle)
                .FontSize(_fontSize)
                .Bold();

            userMessagesSec.Alignment = Alignment.center;

            userMessagesSec.AppendLine("Total sending: " + user.SentMessagesCount);
            userMessagesSec.AppendLine("Total recieving: " + user.RecievedMessagesCount);

            Thread.Sleep(2000);
            completedPages++;
            _hubContext.Clients.User(user.Id.ToString()).SendAsync("Progress_Update", completedPages, reportId);

        }

    }
}
