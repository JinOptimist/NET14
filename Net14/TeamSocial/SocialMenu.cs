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
            new string[] { "users", "All users in SocialWeb"}

        };

        private static readonly Tuple<string, Action<Social, string>>[] _commands = new Tuple<string, Action<Social, string>>[]
        {
            new Tuple<string, Action<Social,string>>("reg", MenuRegistration),
            new Tuple<string, Action<Social,string>>("sing", MenuAutorization),
            new Tuple<string, Action<Social, string>>("exit", ExitFromSocialWeb),
            new Tuple<string, Action<Social, string>>("users", AllUsers)
        };


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

            social.Autorization(email, password);
            Console.WriteLine();
            var drawer = new SocialDrawer();
            drawer.DrawAProfile(social.users.SingleOrDefault(user =>
            user.Email == email
            &&
            user.Password == password));

            

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

            social.Registration(FirstName, LastName, Email, Age, Password);
            var drawer = new SocialDrawer();
            drawer.DrawAProfile(social.users.Single(user =>
            user.Email == Email
            &&
            user.Password == Password));


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
