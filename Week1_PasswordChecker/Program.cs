using System;

using System.Collections.Generic;

using System.Linq;



namespace Week2PasswordRegistration

{

    class Program
    {
        static void Main(string[] args)
        {
            bool goOn = true;
            Dictionary<string, string> mainDictionary = new Dictionary<string, string>();

            while (goOn == true)
            {
                Console.WriteLine("Welcome to the Password Registration game!");
                Console.WriteLine("Let's start with a USERNAME, which requires the following:\n");
                Console.WriteLine("\t--Length of 7-12 characters\n\t--At least 5 letters\n\t--At least one number\n\t--Must not contain a forbidden word.");
                string username = ValidateUsername();
                usernames.Add(username);

                Console.WriteLine("\nGreat username!\nNow let's create a password for your account. The password will require the following:");
                Console.WriteLine("\tOne uppercase letter\n\tOne lowercase letter\n\tOne number\n\t7-12 characters\n\tOne of the following characters: ! @ # $ % ^ & *");
                Console.WriteLine("Please enter your password here: ");

                string password = ValidatePassword();
                passwords.Add(password);

                Console.WriteLine();
                goOn = Continue();
            }

        }

        //if lists are 'public static' outside of main, they can be altered
        //via any method within the namespace.
        //e.g. Program.passwords.Add(etc...);

        //List<string> passwords = new List<string>() { "Password123", "ABC123" };
        //List<string> usernames = new List<string>() { "User1", "User2", "User3" };

        public static List<string> passwords = new List<string>() { "Password123", "ABC123" };
        public static List<string> usernames = new List<string>() { "User1", "User2", "User3" };

        static string CreateUsername()
        {
            Console.WriteLine("Enter your username here: ");
            string username = Console.ReadLine();
            return username;
        }

        //VALIDATE USERNAME METHOD
        static string ValidateUsername()
        {
            string username = CreateUsername();
            //check for number
            if (!username.Any(char.IsDigit))
            {
                Console.WriteLine("Your username must contain at least one number.");
                Console.WriteLine();
                ValidateUsername();
            }
            //check for length
            else if (username.Length < 7 || username.Length > 12)
            {
                Console.WriteLine("Your username must be between 7-12 characters long");
                Console.WriteLine();
                ValidateUsername();
            }
            //check for five letters
            else if (username.Any(char.IsLetter))
            {
                if (username.Length < 5)
                {
                    Console.WriteLine("Your username must contain at least 5 letters");
                    Console.WriteLine();
                    ValidateUsername();
                }
            }
            return username;
        }

        static string CreatePassword()
        {
            string password = Console.ReadLine();
            return password;
        }

        static string ValidatePassword()
        {
            string password = CreatePassword();
            if (!password.Any(char.IsUpper))
            {
                Console.WriteLine("Your password must contain an uppercase character.");
                ValidatePassword();
            }
            else if (!password.Any(char.IsLower))
            {
                Console.WriteLine("Your password must contain a lowercase character.");
                ValidatePassword();
            }
            else if (!password.Any(char.IsDigit))
            {
                Console.WriteLine("Your password must contain at least one digit.");
                ValidatePassword();
            }
            else if (!password.Any(char.IsLetter))
            {
                Console.WriteLine("Your password must contain at least one letter.");
                ValidatePassword();
            }
            else if (password.Length < 7 || password.Length > 12)
            {
                Console.WriteLine("Your password must be between 7 and 12 characters long.");
                ValidatePassword();
            }
            else if (!password.Contains("!") || !password.Contains("@") || !password.Contains("#") || !password.Contains("$") || !password.Contains("%") || !password.Contains("^") || !password.Contains("&") || !password.Contains("*"))
            {
                Console.WriteLine("Your password must contain at least one of these characters: ! @ # $ % ^ & *");
                ValidatePassword();
            }
            else
            {
                Console.WriteLine("We've saved your password!");
                passwords.Add(password);
            }
            return password;
        }

        static void PrintUsernames()
        {
            foreach (string password in passwords)
            {
                Console.WriteLine(password);
            }
        }

        static bool Continue()
        {
            Console.WriteLine("Would you like to continue?\n[y]es/[n]o");
            string input = Console.ReadLine();
            if (input == "y" || input == "yes")
            {
                return true;
            }
            else if (input == "n" || input == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Sorry, I didn't understand that.");
                Continue();
            }
            return true;
        }

    }

}

