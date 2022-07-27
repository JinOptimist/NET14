using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamLearningEnglish.EfStuff.DbModels;
using TeamLearningEnglish.EfStuff.Repository;
using System.IO;
using TeamLearningEnglish.Models;
using System.Text;
using static TeamLearningEnglish.Models.EnglishLevel;
using System;
using static TeamLearningEnglish.Models.Role;

namespace TeamLearningEnglish.EfStuff
{
    public static class ExtentionSeed
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                SeedUser(scope);
                SeedFolder(scope);
                SeedBook(scope);
            }

            return host;
        }
        private static void SeedUser(IServiceScope scope)
        {
            var userRepository = scope.ServiceProvider.GetService<UserRepository>();
            if (!userRepository.Any())
            {
                var users = new List<UserDbModel>()
                {
                    new UserDbModel
                    {
                        FirstName = "admin",
                        LastName = "admin",
                        Age = 22,
                        EnglishLevel = Level.Advanced,
                        Email = "admin",
                        Password = "admin",
                        BirthDate = new DateTime(2000,01,22),
                        SiteRole = Roles.Admin 
                    },
                    new UserDbModel
                    {
                        FirstName = "Кирилл",
                        LastName = "Перепечкин",
                        Age = 20,
                        EnglishLevel = Level.Intermidiate,
                        Email = "perepechkin_2002@mail.ru",
                        Password = "12345678",
                        BirthDate = new DateTime(2002,01,22),
                        SiteRole = Roles.User
                    },
                    new UserDbModel
                    {
                        FirstName = "Анастасия",
                        LastName = "Кузьмиченок",
                        Age = 19,
                        EnglishLevel = Level.Elementary,
                        Email = "kyzmichenok_2002@mail.ru",
                        Password = "12345678",
                        BirthDate = new DateTime(2002,12,17),
                        SiteRole = Roles.User
                    },

                };

                userRepository.SaveList(users);
            }
        }
        private static void SeedFolder(IServiceScope scope)
        {
            var folderRepository = scope.ServiceProvider.GetService<FolderWordRepository>();

            if (!folderRepository.Any())
            {
                var folders = new List<FolderWordDbModel>()
                {
                    new FolderWordDbModel
                    {
                        Name = "Глаголы",
                        Words = new List<WordDbModel>
                        {
                            new WordDbModel
                            {
                                EnglishWord = "translate",
                                RussianWord = "переводить"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "must",
                                RussianWord = "должен"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "talk",
                                RussianWord = "говорить"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "meet",
                                RussianWord = "встретить"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "take",
                                RussianWord = "брать"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "repeat",
                                RussianWord = "повторять"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "begin",
                                RussianWord = "начать"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "get up",
                                RussianWord = "вставать"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "support",
                                RussianWord = "поддерживать"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "share",
                                RussianWord = "делиться"
                            },
                        }
                    },
                    new FolderWordDbModel
                    {
                        Name = "Транспорт",
                        Words = new List<WordDbModel>
                        {
                            new WordDbModel
                            {
                                EnglishWord = "motorbike",
                                RussianWord = "моцоцикл"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "skateboard",
                                RussianWord = "скейтборд"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "car",
                                RussianWord = "автомобиль"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "crane",
                                RussianWord = "кран"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "van",
                                RussianWord = "фургон"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "subway",
                                RussianWord = "метро"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "rocket",
                                RussianWord = "ракета"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "school bus",
                                RussianWord = "школьный автобус"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "truck",
                                RussianWord = "грузовик"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "bike",
                                RussianWord = "велосипед"
                            },
                        }
                    },
                    new FolderWordDbModel
                    {
                        Name = "Страны",
                        Words = new List<WordDbModel>
                        {
                            new WordDbModel
                            {
                                EnglishWord = "Cuba",
                                RussianWord = "Куба"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "The UK",
                                RussianWord = "Соединённое Королевство"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "Kazakhstan",
                                RussianWord = "Казахстан"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "Ukraine",
                                RussianWord = "Украина"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "Poland",
                                RussianWord = "Польша"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "Israel",
                                RussianWord = "Израиль"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "America",
                                RussianWord = "Америка"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "Argentina",
                                RussianWord = "Аргентина"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "Spain",
                                RussianWord = "Испания"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "Belarus",
                                RussianWord = "Беларусь"
                            },
                        }
                    },
                    new FolderWordDbModel
                    {
                        Name = "Прилагательные",
                        Words = new List<WordDbModel>
                        {
                            new WordDbModel
                            {
                                EnglishWord = "popular",
                                RussianWord = "популярный"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "little",
                                RussianWord = "маленький"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "cheap",
                                RussianWord = "дешёвый"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "expansive",
                                RussianWord = "дорогой"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "other",
                                RussianWord = "другие"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "sure",
                                RussianWord = "уверен"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "correct",
                                RussianWord = "правильный"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "simple",
                                RussianWord = "простой"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "young",
                                RussianWord = "молодой"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "poor",
                                RussianWord = "бедный"
                            },
                        }
                    },
                    new FolderWordDbModel
                    {
                        Name = "Хобби",
                        Words = new List<WordDbModel>
                        {
                            new WordDbModel
                            {
                                EnglishWord = "music",
                                RussianWord = "музыка"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "books",
                                RussianWord = "книги"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "cinema",
                                RussianWord = "кино"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "swimming",
                                RussianWord = "плавание"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "travelling",
                                RussianWord = "путешествие"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "dancing",
                                RussianWord = "танцы"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "fishing",
                                RussianWord = "рыбалка"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "reading",
                                RussianWord = "чтение"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "basketball",
                                RussianWord = "баскетбал"
                            },
                            new WordDbModel
                            {
                                EnglishWord = "free time",
                                RussianWord = "свободное время"
                            },
                        }
                    },
                };
                folderRepository.SaveList(folders);
            }
        }
        private static void SeedBook(IServiceScope scope)
        {
            var bookRepository = scope.ServiceProvider.GetService<BooksRepository>();

            if (!bookRepository.Any())
            {
                string[] text = File.ReadAllLines($"wwwroot/books/HarryPotter.txt");
                var bookDbModel = new BookDbModel { Name = "Harry Potter" };

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
