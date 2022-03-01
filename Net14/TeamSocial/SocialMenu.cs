using System;
using System.Collections.Generic;
using System.Text;
using SocialWeb;
using System.Linq;

namespace TeamSocial
{
    public class SocialMenu
    {
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";
        private static bool _isRunning = true;


        private static readonly string[][] HelpMessages = new string[][]
        {
            new string[] { "reg", "Registration in SocialWeb" },
            new string[] { "sing", "Autorization in SocialWeb" },
            new string[] { "exit", "Exit from SocialWeb"},
            new string[] { "users", "All users in SocialWeb"},
            new string[] { "fw", "Friends wall" },
            new string[] { "pwall", "Post wall" },

        };

        private static readonly Tuple<string, Action<Social, string>>[] _commands = new Tuple<string, Action<Social, string>>[]
        {
            new Tuple<string, Action<Social,string>>("reg", MenuRegistration),
            new Tuple<string, Action<Social,string>>("sing", MenuAutorization),
            new Tuple<string, Action<Social, string>>("exit", ExitFromSocialWeb),
            new Tuple<string, Action<Social, string>>("users", AllUsers),
            new Tuple<string, Action<Social, string>>("fw", ShowFriendsWall),
            new Tuple<string, Action<Social, string>>("pwall", ShowWall)
        };

        private static void ShowFriendsWall(Social social, string arg2) //На эту функцию можно не обращать внимание, она всего лишь подтверждает то,
                                                                        //что добавление и удаление друзей работает  
        {
            var drawer = new SocialDrawer();
            var admin = social.Registration("Admin", "Admin", "Admin@mail.ru", 50, "12345", "Moscow", "Russia");
            admin.wallOffriends.social = social;
            while (true)
            {
                drawer.DrawAProfile(admin);
                Console.WriteLine($"Friends of {admin.FirstName}\n");
                if (admin.friends.Count == 0)
                {
                    Console.WriteLine("\tThere's no friend yet");
                }
                else
                {
                    foreach (User friend in admin.wallOffriends.GetFriends())// Если у админа есть друзья, то показать их
                    {
                        Console.WriteLine("\t" + friend.FirstName + " ---- " + friend.Email);
                        Console.WriteLine($"\t\tFriends of {friend.FirstName}");
                        foreach (User friendsOffriend in friend.friends)
                        {
                            Console.WriteLine($"\t\t\t{friendsOffriend.FirstName} ---- {friendsOffriend.Email}");
                        }
                        //Показать друзей у друзей админа, чтобы удостверится что операция двусторонняя 
                    }
                }
                Console.WriteLine("\nTo add to friends press 'a' or press 'd' to delete friend or 'r' to see recomendation or 'x' to exit");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.KeyChar == 'a')//Добавляем друзей
                {
                    Console.WriteLine("Available users:\n");
                    foreach (User user in social.users.Where(user => user.Email != admin.Email && !admin.friends.Contains(user)))
                    {
                        Console.WriteLine($"{user.FirstName} ---- {user.Email}");
                    }
                    Console.WriteLine("For adding user to frineds enter his e-mail");
                    var a = Console.ReadLine();
                    var potentionalFriend = social.users.SingleOrDefault(user => user.Email == a);
                    if (potentionalFriend != null)
                    {
                        admin.wallOffriends.AddFriendByEmail(a);
                        Console.WriteLine($"\nUser {potentionalFriend.FirstName} with email {potentionalFriend.Email} was found and added to friens");

                    }
                    else
                    {
                        Console.WriteLine("\nUser was't found");
                    }

                }
                else if (key.KeyChar == 'r') //Рекомендации
                {
                    var rec = admin.wallOffriends.RecomendationOfFriends();
                    Console.WriteLine("Your recomendation: ");
                    foreach (User user in rec) 
                    {
                        Console.WriteLine($"\t{user.FirstName}, {user.Email}, {user.Country}, {user.City}, {user.Age}");
                    }
                    Console.ReadKey(true);
                }
                else if (key.KeyChar == 'd')//Удаляем друзей
                {
                    Console.WriteLine("Friends available to delete:");
                    foreach (User user in admin.wallOffriends.GetFriends())
                    {
                        Console.WriteLine($"\t{user.FirstName} ---- {user.Email}");
                    }
                    Console.WriteLine("For deleting friend enter his email:");
                    var emailToDelete = Console.ReadLine();
                    var userToDel = admin.friends.SingleOrDefault(user =>
                    user.Email == emailToDelete);
                    if (userToDel == null)
                    {
                        Console.WriteLine("There's no such friend in admins frined");
                    }
                    else
                    {
                        admin.wallOffriends.DeleteFromFriendsByEmail(emailToDelete);
                        Console.WriteLine($"User {userToDel.FirstName} was deleted from friends");
                    }
                    continue;
                }
                else if (key.KeyChar == 'x')//Выход в SocialMenu
                {
                    Start();
                }

            }


        }

        private static void ShowWall(Social social, string arg2)
        {
            var drawer = new SocialDrawer();
            //Load User's for create PostWall
            var empty = social.Registration("Andrew", "Jacobson", "AndJac@mail.ru", 25, "12345", "Minsk", "Belarus");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"PostWall of TeamSocial\n");
                PostWall PostWall = new PostWall();
                PostWall.CreatePostWall(empty);

                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.KeyChar == 'x')//Выход в SocialMenu
                {
                    Start();
                }

            }

        }


        public static void Start() 
        {
            Console.Clear();
            var socialBuilder = new SocialBuilder();
            var social = socialBuilder.BuildSocial();
            Console.WriteLine("Welcome to SocailWeb!\n");
            ShowCommands();

            do
            {
                Console.WriteLine(HintMessage);
                Console.Write("> ");
                string[] inputs = Console.ReadLine()?.Split(' ', 2);
                const int commandIndex = 0;
                string command = inputs[commandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(HintMessage);
                    continue;
                }

                int index = Array.FindIndex(_commands, 0, _commands.Length, i
                    => i.Item1.Equals(command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    const int parametersIndex = 1;
                    string parameters = inputs.Length > 1 ? inputs[parametersIndex] : string.Empty;
                    _commands[index].Item2(social, parameters);
                }
                else
                {
                    PrintMissedCommandInfo(command);
                }
            }
            while (_isRunning);
        }

        private static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }

        private static void MenuAutorization(Social social,string message)
        {
            Console.WriteLine("Log in for Social\n");
            Console.Write("Enter your email: ");
            var email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                Console.Write("*");
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }
            Console.WriteLine();

            var user = social.Autorization(email, password);//метод авторизации вернет найденного пользователя. Однако, этот метод может не найти пользователя и вернуть null. Поэтому:
            if (user == null) 
            {
                Console.WriteLine("Wrong password or Email");
                Console.ReadKey();
                MenuAutorization(social, message);
            }
            var drawer = new SocialDrawer();
            drawer.DrawAProfile(user); // рисуем профиль

            

        }
    
        private static void MenuRegistration(Social social, string message) 
        {
            
            Console.WriteLine("Sign up for Social\n");

            Console.Write("Your first name: ");
            var FirstName = Console.ReadLine();

            Console.Write("Your last name: ");
            var LastName = Console.ReadLine();

            Console.Write("Your Email: ");
            var Email = Console.ReadLine();

            Console.Write("Your age: ");
            var Age = Int32.Parse(Console.ReadLine());

            Console.Write("Enter your password: ");

            string Password = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                Console.Write("*");
                if (key.Key == ConsoleKey.Enter)
                    break;
                Password += key.KeyChar;
            }
            Console.WriteLine();

            var user =  social.Registration(FirstName, LastName, Email, Age, Password); // метод регистарции вернет зарегистрированного пользователя 
            var drawer = new SocialDrawer();
            drawer.DrawAProfile(user); // После регистрации отрисовывается профиль

        }

        private static void AllUsers(Social social, string message)
        {
            Console.Clear();
            Console.WriteLine("\t All users\n");
            var drawer = new SocialDrawer();
            drawer.DrawAllUsers(social);
            
        }


        private static void ShowCommands()
        {
            for (int i = 0; i < HelpMessages.Length; i++)
            {
                for (int j = 0; j < HelpMessages[i].Length; j++)
                {
                    Console.Write($"\t * {HelpMessages[i][j],-10}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void ExitFromSocialWeb(Social arg1, string arg2)
        {
            Console.WriteLine("Exit from SocialWeb\n");
            _isRunning = false;
        }



    }
}
