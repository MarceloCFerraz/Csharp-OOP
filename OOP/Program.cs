namespace OOP
{
    class Program
    {
        public static void Main(string[] args)
        {
            // 1. Classes and Objects

            // Classes inicializes reference type objects
            // Structs inicializes value type objects
            var test0 = new SuperClass(
                id: Guid.NewGuid(),
                name: "Test 0",
                password: "Pass!230"
            );
            var test1 = new ChildrenClass();

            // 4. Polymorphism
            // Method overload -> same method name with different arguments to do the same thing
            var test = new SuperClass();

            // 2. Inheritance and 3. Encapsulation

            // 'Password' can only be accessed from within SuperClass' object methods
            // or from methods from any subclasses that inherits from 'SuperClass' such as methods from 'ChildrenClass'

            // This line throws an error
            // Console.WriteLine(test1.Password);

            // This line doesn't
            Console.WriteLine(test1.GetPassword());

            // This line doesn't either (test0 is a 'ChildrenClass' object, and 'ChildrenClass' inherits methods and properties from 'SuperClass')
            Console.WriteLine(test0.GetPassword());

            Console.WriteLine(test0.Name);
            Console.WriteLine(test1.Name);

            // 4. Polymorphism
            // Method override -> same method name with same arguments to do different thing

            // This should change the name to "Testing_Original_Method"
            test0.ChangeName("Testing Original Method");
            // This should change the name to "Testing-Overriden-Method"
            test1.ChangeName("Testing Overriden Method");

            Console.WriteLine(test0.Name);
            Console.WriteLine(test1.Name);

            // Want to make sure your object get's destroyed as soon as you're done with it?
            // Initialize it this way then:
            using (var test2 = new ChildrenClass())
            {
                Console.WriteLine("> Creating new object");
                // Do something...
            }
            // IMPORTANT!
            // .NET's garbage collector will dispose it from the memory sooner or later
            // but in some situations, you might want to do it right away to save resources

            // For this to be allowed, the object's class or its 'superclass' must inherit from 'IDisposable' and implement a method called 'Dispose'!
            // Otherwise, the compiler won't allow a block like the one above!


            // A static property is callable on a class even when no instance of the class has been created.
            // Every static member is always accessed by the class name, not the instance name.
            // Static members can be accessed globally if their access modifier allows it.
            Console.WriteLine(StaticClass.Number);

            var num = 7;
            var multiplication = StaticClass.MultiplyNumber(num);
            Console.WriteLine($"{StaticClass.Number} * {num} is = {multiplication}");

            // A non-static class can contain static methods too
            ChildrenClass.TestStaticMethod(77);


            var partial = new PartialClass();
            Console.WriteLine(partial.Property1); // from PartialClass1.cs
            Console.WriteLine(partial.Property2); // from PartialClass2.cs

            // Initializing a class that signed a contract with an interface
            var developer = new Dev();
            developer.Code();
            developer.DrinkCoffee();
            developer.JoinDaily();

            // Abstract classes can't be initialized, only their subclasses
            // This line will throw an error
            // var payment = new Payment();

            // These won't
            var creditCard = new PayWithCreditCard();
            var bitcoin = new PayWithBitcoin();
            var paypal = new PayWithPaypal();

            // Every implementation of Pay use a method implemented only in payment, and this is good, because, otherwise, every subclass would need to implement the same piece of code.
            // For this reason, an abstract class is recommended over an interface
            creditCard.Pay();
            bitcoin.Pay();
            paypal.Pay();
        }
    }
}