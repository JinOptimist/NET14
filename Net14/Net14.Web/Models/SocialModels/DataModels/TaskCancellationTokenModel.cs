using Net14.Web.EfStuff.DbModel.SocialDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Net14.Web.Models.SocialModels.DataModels
{
    public class TaskCancellationTokenModel
    {
        public int ReportId { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }

    }
}
