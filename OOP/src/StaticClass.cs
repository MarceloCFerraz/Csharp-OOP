namespace OOP
{
    // A static class is essentially the same as a non-static class, but there is one key difference: a static class cannot be instantiated
    // 1. This means you cannot use the 'new' operator to create a variable of the class type
    // 2. Because there is no instance variable, you access the members of a static class by using the class name itself and can do it right away
    // 3. This is possible because static classes get available as soon as the application starts
    // A static class can be used as a convenient container for sets of methods that just operate on input parameters and do not have to get or set any internal instance.
    // Have you imagined if we needed to inicialize a Math object everytime we needed to get the PI value?
    // On the other hand, you wouldn't want to standardize something like a subscription for every user every time, right? 
    public static class StaticClass
    {
        // Static Properties: A static property is a property that belongs to the class rather than an instance of the class. It Can also be accessed using the class name rather than an instance name if its access modifier allows it.
        public static int Number { get; set; } = 77;

        // Static Methods: A static method is callable on a class even when no instance of the class has been created. The static member is always accessed by the class name, not the instance name.
        public static int MultiplyNumber(int num)
        {
            return Number * num;
        }

    }
}