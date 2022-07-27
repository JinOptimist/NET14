using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.Models;

namespace TeamLearningEnglish.EfStuff.Repository
{
    public class FolderWordRepository : BaseRepository<FolderWordDbModel>
    {
        public FolderWordRepository(WebDbContext webContext):base(webContext)
        {
        }

        public FolderWordDbModel GetByName(string folderName)
        {
            return _dbSet.SingleOrDefault(folder => folder.Name == folderName);
        }
    }
}
