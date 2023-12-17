namespace OOP
{
    // 1. Classes and Objects and 2. Inheritance
    class SuperClass : IDisposable
    {
        // 3. Encapsulation
        // public: Access isn't restricted.
        // protected: Access is limited to the containing class or types derived from the containing class.
        // private: Access is limited to the containing type.
        // file: The declared type is only visible in the current source file. File scoped types are generally used for source generators.
        // internal: Access is limited to the current assembly (compiled code).
        // protected internal: Access is limited to the current assembly or types derived from the containing class.
        // private protected: Access is limited to the containing class or types derived from the containing class within the current assembly.
        public Guid Id { get; set; }
        public string Name { get; set; }
        protected string Password { get; set; }


        // 4. Polymorphism
        // Method overload -> same method name with different arguments to do the same thing
        public SuperClass()
        {
            Id = Guid.NewGuid();
            Name = "This is a Test A";
            Password = "Password777#$!";
        }


        public SuperClass(Guid id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }


        public void Dispose()
        {
            Console.WriteLine("> Disposing object");
        }


        // 4. Polymorphism
        // Method override -> same method name with same arguments to do different thing
        // Allowing subclasses to implement their versions of the base function, the base methods must be virtual
        public virtual void ChangeName(string name)
        {
            Name = name.Replace(" ", "_");
        }


        public string GetPassword()
        {
            return Password;
        }
    }
}