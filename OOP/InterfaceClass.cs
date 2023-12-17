namespace OOP
{
    class Dev : IDev
    {
        // This class must have this property since it accepted the contract with IDev
        public string Developer { get; set; }

        // This class can also have any other properties and methods needed to make it serve its business purpose
        public string Language { get; set; }


        public Dev()
        {
            Developer = "Marcelo";
            Language = "C#";
        }
        public Dev(string developer, string language)
        {
            Developer = developer;
            Language = language;
        }


        // This class must have these methods since it accepted the contract with IContract
        public void Code()
        {
            Console.WriteLine($"{Developer} likes to code in {Language}");
        }

        public void DrinkCoffee()
        {
            Console.WriteLine($"{Developer} is drinking coffee");
        }

        public void JoinDaily()
        {
            Console.WriteLine($"Time for another daily meeting :D");
        }
    }
}