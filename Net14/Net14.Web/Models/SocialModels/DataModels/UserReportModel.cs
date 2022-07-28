using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net14.Web.Models.SocialModels.DataModels
{
    public class UserReportModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public List<ReportFriendModel> Friends { get; set; }
        public List<ReportGroupModel> Groups { get; set; }
        public List<ReportFileModel> Files { get; set; }
        public int SentMessagesCount { get; set; }
        public int RecievedMessagesCount { get; set; }



    }
}
