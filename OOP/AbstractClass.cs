namespace OOP
{
    // Yeah, I know putting everything inside a single file is not ideal, but let's do it just this time.

    // Abstract classes can't be initialized, just classes that inherits from them. They are used over interfaces when a implementation of some method is needed or welcome (to avoid repeating coding the same thing), as interfaces doesn't allow that
    abstract class Payment
    {
        public DateTime ExpirationDate { get; set; }
        public decimal Total { get; set; }

        public Payment()
        {
            ExpirationDate = DateTime.Now.AddDays(1);
            Total = 100m;
        }

        protected bool IsExpired()
        {
            return DateTime.Now.CompareTo(ExpirationDate) > 0;
        }
    }

    class PayWithCreditCard : Payment
    {
        public PayWithCreditCard() : base()
        {

        }
        public void Pay()
        {
            if (!IsExpired())
                Console.WriteLine("Paying with Credit Card");
            else
                Console.WriteLine("You can't pay this anymore");
        }
    }

    class PayWithBitcoin : Payment
    {
        public PayWithBitcoin() : base()
        {

        }
        public void Pay()
        {
            if (!IsExpired())
                Console.WriteLine("Paying with Bitcoin");
            else
                Console.WriteLine("You can't pay this anymore");
        }

    }

    class PayWithPaypal : Payment
    {
        public PayWithPaypal() : base()
        {

        }
        public void Pay()
        {
            if (!IsExpired())
                Console.WriteLine("Paying with Paypal");
            else
                Console.WriteLine("You can't pay this anymore");
        }

    }

}