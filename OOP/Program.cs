namespace OOP
{
    class Program
    {

        struct EqualsTest
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }

            public EqualsTest(Guid id, string name, string password)
            {
                Id = id;
                Name = name;
                Password = password;
            }
        }


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

            var baseObj = new SuperClass();     // a base class
            var childObj = new ChildrenClass(); // a child class

            // Upcast: A child object is a base object with more properties and methods, so we can simply assign a child object to a base object variable/constant.
            baseObj = childObj;

            // Downcast: The reverse is also possible, but it requires an explicit *cast* or a direct conversion, because the child has everything the base class has, plus extras (methods and usually properties). This means that since the child usually demands more attributes that the base class doesn't have, it's necessary to convert it and deal with any extra attributes that aren't present in the original class.
            childObj = (ChildrenClass)baseObj; // or
            childObj = baseObj.ToChildrenClass();


            // How do you know two objects are equal?
            Console.WriteLine(childObj == baseObj); // this should work, right?
            // Except it returns 'False'. But now both these objs have the same properties. Same id, name and password. It's probably because they objects from different classes, right?
            using (var newObj = new ChildrenClass(
                childObj.Id,
                childObj.Name,
                childObj.GetPassword()
            ))
                Console.WriteLine(childObj == newObj); // Now this should work
            // Nope                

            // Classes generate 'reference type' objects, meaning they take different spaces in memory, which will never be equal.
            // Structs generate 'value type' objs so they theoretically return the correct result.
            var testStr = new EqualsTest(childObj.Id, childObj.Name, childObj.GetPassword());
            var otherStr = new EqualsTest(
                testStr.Id,
                testStr.Name,
                testStr.Password
            );

            // Console.WriteLine(testStr == otherStr); // However, this throws an error

            // So what's the correct way to compare objects?
            // It depends on your situation. We could compare Ids, but this doesn't mean they're completely equal.
            Console.WriteLine(childObj.Id == testStr.Id); // This will return 'True'
            // The best way is to implement a comparison method inside your classes and adapt each '.Equals' to their specific use case. For example:
            Console.WriteLine(childObj.Equals(baseObj)); // also returns 'True'

            // Delegates
            // Basically, it's a method that doesn't want to do anything. It delegates its task to the another method that takes the same parameters and returns the same type.
            // Like suggested above, a delegate function only defines a standard signature (return type and parameters).
            // Let's initialize a delegate function to demonstrate it:
            Operation add = (a, b) => a + b;
            Operation multiply = (a, b) => a * b;
            // 'add' and 'multiply' are functions of type Operation (a delegate function that returns a double and receives two double values) and we are specifying exactly what they need to do with those parameters. We could also reference another function, but let's keep it like this for now.
            // But only this won't do anything. We need to use those functions. Let's create a calculator to do it
            var calc = new Calculator();
            calc.Calculate(12, 30, add); // prints 42
            calc.Calculate(12, 30, multiply); // prints 360
            // What we're saying here is: hey, calculator, you don't know what to do, so here are two numbers and a function that will do what you need to do.
            // Other concepts use delegates under the hood. Some of them are:

            // Actions and Events.
            // Actions are a reference for a method with no return. Since it's a reference for another thing and, by itself, it doesn't do anything, you can already imagine it's a delegate. Here is Action in action:
            calc.Sum = (x, y) => Console.WriteLine($"{x} + {y} = {x + y}");
            calc.Sum(30, 30); // prints 60

            // Events are a bit more complex, but very useful to make classes communicate when something important happens without coupling them
            // Let's do a little tweak in our previous example to explore Events:
            var logger = new CalculatorLogger(calc);
            calc.Sum = (x, y) => calc.OnCalculation(x, y, x + y);
            calc.Sum(30, 40); // prints 70
            // What this piece of code is doing:
            // 1. initializing a logger to print calculator results
            // 2. The logger has a method (CalculationMade) that will be used as target for calculator's CalculationEvent (which is an event: a delegate function of type EventHandler, in this case)
            // 3. every time the sum function is called, it calls the OnCalculation method, which creates the default signature for CalculationEvent and triggers any other class that address a target function for CalculationEvent
            // Events are onsiderably more complex and harder to implement in comparison to Actions and raw Delegates, but uses the same concepts and allows classes to be uncoupled (not hard linked to each other) while still making one trigger another
        }

        public delegate double Operation(double x, double y);

        public class Calculator
        {
            public Action<double, double>? Sum;
            public event EventHandler<CalculatorEventArgs> CalculationEvent;

            public double Calculate(double x, double y, Operation operation)
            {
                return operation(x, y);
            }

            // it's usually protected but i'll leave it as public just to demonstrate Events
            public virtual void OnCalculation(double x, double y, double result)
            {
                CalculationEvent?.Invoke(this, new CalculatorEventArgs(x, y, result));
            }
        }

        public class CalculatorLogger
        {
            public void CalculationMade(object sender, CalculatorEventArgs args)
            {
                // Not ideal but just to demonstrate Events
                Console.WriteLine($"{args.X} + {args.Y} = {args.Result}");
            }
            public CalculatorLogger(Calculator calc)
            {
                calc.CalculationEvent += CalculationMade;
            }
        }
    }

}