using System;
using System.Collections.Generic;

namespace TamagotchiGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tamagotchi!");

            Tamagotchi myTama = new Tamagotchi(); //skapa en ny instans av Tamagotchi 

            Console.WriteLine("Please choose a name for your Tamagotchi!");
            myTama.SetName(Console.ReadLine());

            Console.WriteLine($"Great! {myTama.GetName()} is a beautiful name!");

            List<Activity> activities = new List<Activity>() //skapa en lista med olika aktiviteter som användaren kan utföra med Tamagotchi
            {
                new Activity("Teach a new word", (tamagotchi) =>
                {
                    Console.WriteLine("What word?");
                    string word = Console.ReadLine();
                    tamagotchi.Teach(word);
                }),
                new Activity("Talk to Tamagotchi", (tamagotchi) =>
                {
                    tamagotchi.Hi();
                }),
                new Activity("Feed Tamagotchi", (tamagotchi) =>
                {
                    tamagotchi.Feed();
                }),
                new Activity("Do nothing", (tamagotchi) =>
                {
                    Console.WriteLine("Doing nothing...");
                })
            };

            while (myTama.GetAlive()) //loopa tills tamagotchi dör
            {
                Console.Clear(); //rensa konsolfönstret och skriv ut Tamagotchis status 
                myTama.PrintStats();
                Console.WriteLine("Now what do you want to do?");
                
                for (int i = 0; i < activities.Count; i++) // visa de olika aktiviteter 

                {
                    Console.WriteLine($"{i + 1}. {activities[i].Name}");
                }

                string input = Console.ReadLine(); // läser användarens val av aktivitet 
                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= activities.Count)
                {
                    activities[choice - 1].Perform(myTama); //utför den valda aktiviteten
                }
                else
                {
                    Console.WriteLine("Invalid choice!"); //felhantering om man skriver inte ett nummer 
                }

                myTama.Tick(); //uppdaterar Tamagotchins tillstånd för varje iteration av loopen 
            }

            Console.WriteLine($"OH NO! {myTama.GetName()} is dead!"); 
            Console.WriteLine("Press ENTER to quit");
            Console.ReadLine();
        }
    }
}
