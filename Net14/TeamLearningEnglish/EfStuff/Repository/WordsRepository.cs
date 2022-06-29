using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class WordsRepository : BaseRepository<WordDbModel>
    {
        public WordsRepository(WebDbContext webContext) : base(webContext)
        {
        }
    }
}
