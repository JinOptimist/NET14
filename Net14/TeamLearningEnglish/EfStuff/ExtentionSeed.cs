using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.EfStuff.Repository;
using System.IO;
using TeamLearningEnglish.Models;
using System.Text;

namespace TeamLearningEnglish.EfStuff
{
    public static class ExtentionSeed
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                SeedWord(scope);
                SeedBook(scope);
            }

            return host;
        }
        private static void SeedWord(IServiceScope scope)
        {
            var wordsRepository = scope.ServiceProvider.GetService<WordsRepository>();

            if (!wordsRepository.Any())
            {
                var words = new List<WordDbModel>()
                {
                    new WordDbModel
                    {
                        EnglishWord = "car",
                        RussianWord = "машина",
                        Rating = 20
                    },
                    new WordDbModel
                    {
                        EnglishWord = "house",
                        RussianWord = "дом",
                        Rating = 41
                    },
                    new WordDbModel
                    {
                        EnglishWord = "message",
                        RussianWord = "сообщение",
                        Rating = 5
                    },
                    new WordDbModel
                    {
                        EnglishWord = "get",
                        RussianWord = "получить",
                        Rating = 32
                    },
                };
                wordsRepository.SaveList(words);
            }
        }
        private static void SeedBook(IServiceScope scope)
        {
            var bookRepository = scope.ServiceProvider.GetService<BooksRepository>();

            if (!bookRepository.Any())
            {
                string[] text = File.ReadAllLines($"wwwroot/books/HarryPotter.txt");
                var bookDbModel = new BookDbModel{ Name = "Harry Potter" };

                var stringBuilder = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    stringBuilder.Append(text[i]);
                }
                bookDbModel.Text = stringBuilder.ToString();

                bookRepository.Save(bookDbModel);
            }
        }

    }

}
