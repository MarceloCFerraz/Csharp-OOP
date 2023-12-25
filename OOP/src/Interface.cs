namespace OOP
{
    // Interfaces often compared to contracts and are crucial to clean code and to code maintainability.
    // An interface exists to list the core of a class, i.e. properties and methods a class should have
    // Interfaces usually doesn't have any implementation for their methods (although C# allows that), as they exist only to serve as a contract that tells developers what needs to be implemented in order to make the class fit the application. The implementation itself can vary depending on the classes that inherits from it.
    // As a naming standard, we should always name interfaces with a starting capital 'I' followed by the interface name with a capital initial letter as exemplified below.
    interface IDev
    {
        // Any class that inherits from this interface MUST have this property
        public string Developer { get; set; }

        // Any class that inherits from this interface MUST have these methods
        // The implementation of methods is a responsability of the subclasses that inherits this interface
        void Code();
        void DrinkCoffee();
        void JoinDaily();
    }
}