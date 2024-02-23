 public class Tamagotchi
    {
        private int hunger; //instansvariabler för Tamagotchins tillstånd
        private int boredom;
        private List<string> words = new List<string>() {"Hewwo"};
        private bool isAlive;
        private Random generator;
        private string name;

        public Tamagotchi() //konstruktorn för att skapa en ny Tamagotchi

        {
            generator = new Random();
            isAlive = true;
        }

        public void Feed()
        {
            Console.WriteLine($" [{name}] eats and becomes less hungry");
            hunger -= 2;
            if (hunger < 0)
            {
                hunger = 0;
            }
        }

  
public void Hi()
{
   
    if (words.Count > 0)
    {
       
        string randomWord = words[generator.Next(words.Count)];
        
        Console.WriteLine($" [{name}] says: {randomWord}");
        ReduceBoredom();
    }
    else
    {
        Console.WriteLine($" [{name}] has nothing to say!");
    }
}
        public void Teach(string word)
        {
            Console.WriteLine($" [{name}] learns: {word}");
            words.Add(word);
            ReduceBoredom();
        }

        public void Tick()
        {
            hunger++;
            boredom++;
            if (hunger > 10 || boredom > 10)
            {
                isAlive = false;
            }
        }

        public void PrintStats()
        {
            Console.WriteLine($"Name: {name} || Hunger: {hunger} || Boredom: {boredom} || Vocabulary: {words.Count} words");
        }

        public bool GetAlive()
        {
            return isAlive;
        }

        public void ReduceBoredom()
        {
            Console.WriteLine($" [{name}] is now less bored!");

            boredom -= 2;
            if (boredom < 0)
            {
                boredom = 0;
            }
        }

        public void SetName(string newName) //metod för att ställa in Tamagotchins namn

        {
            name = newName;
        }

        public string GetName() //metod för att hämta Tamagotchins namn

        {
            return name;
        }
    }