using System;
using System.Collections.Generic;
using System.Threading;

internal class ProblematicProblem
{
    internal class Program
    {
        int userAge;
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string userWantsGenerate = Console.ReadLine();
            cont = (userWantsGenerate == "yes");
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge;
            string input = Console.ReadLine();
            if (int.TryParse(input, out userAge))
            {
            }
            else
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            string userWantsSeeList = Console.ReadLine().ToLower();
            bool seeList = (userWantsSeeList == "sure");
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                string wannaSeeMore = Console.ReadLine().ToLower();
                bool addToList = (wannaSeeMore == "yes");
                Console.WriteLine();
                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    string exitAddingActivites = Console.ReadLine().ToLower();
                    addToList = (exitAddingActivites != "no");
                }
            }
            Random rng = new Random();
            while (cont)
            {
               
                Console.Write("Connecting to the database");
              for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
              for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
              if (userAge < 21 && randomActivity == "Wine Tasting")
                 {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                 }
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                string doTheyWantARedo = Console.ReadLine().ToLower();
                cont = (doTheyWantARedo == "Keep");
                if (doTheyWantARedo == "redo") 
                    {
                    bool exit = true;
                    while (exit)
                    {
                        randomNumber = rng.Next(activities.Count);
                        Console.WriteLine($"Alright you picky turd.  How about {randomActivity}? Will this be okay or are you going to cry again?  Keep/Redo: ");
                        randomActivity = activities[randomNumber];
                        string pickyPerson = Console.ReadLine().ToLower();
                        exit = (pickyPerson != "keep"); 
                    }
                }
            }
        }
    }
}