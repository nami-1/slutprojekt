 public class Activity //klassen som representerar en aktivitet som användaren kan utföra med Tamagotchi 
    {
        public string Name { get; set; } // namn på aktiviteten
        public Action<Tamagotchi> Perform { get; set; } // metoden för att utföra aktiviteten

        public Activity(string name, Action<Tamagotchi> perform) //konstruktor för att skapa en ny aktivitet med ett namn och en utförandemetod
        {
            Name = name;
            Perform = perform;
        }
    }