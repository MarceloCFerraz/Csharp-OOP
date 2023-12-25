namespace OOP
{
    // 2. Inheritance
    // Only simple inheritance is allowed in C# (inherit from a single base class)
    class ChildrenClass : SuperClass
    {

        public ChildrenClass(Guid id, string name, string password) : base(id, name, password) { }

        // 4. Polymorphism
        // Method overload -> same method name with different arguments to do the same thing
        public ChildrenClass() : base(
            Guid.NewGuid(),
            "This is a Test B",
            "Password777#$!"
        )
        { }

        // 4. Polymorphism
        // Method override -> same method name with same arguments to do different thing
        public override void ChangeName(string name)
        {
            this.Name = name.Replace(" ", "-");
        }


        // A non-static class can contain static methods. The static method is callable on a class even when no instance of the class has been created. The static member is always accessed by the class name, not the instance name.
        public static void TestStaticMethod(int number)
        {
            Console.WriteLine($"This is a static method inside a non-static class. Here is a number for you: {number * 7}");
        }
    }
}