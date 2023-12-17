namespace OOP
{
    // Sealed classes doesn't allow inheritance from themselves. This means that no other class can inherit and override/overload any of it methods
    // On the other hand, a sealed class inherit from another class or interface
    sealed class SealedClass : SuperClass
    {
        public string MyProperty { get; set; } = "This class cannot be inherited";
    }
}