namespace _01ConstructorFinalizer
{
    public class Base
    {
        /// <summary>
        /// a readonly kulcsszó azt jelenti, hogy csak a konstruktorban változtathatjuk az értékét
        /// </summary>
        private readonly bool IsConstructed; //= false;

        public Base()
        {
            System.Console.WriteLine("Base létrehozó: Base()");
            IsInitiated = true;
            IsConstructed = true;

        }


        public string Name { get; private set; }

        public Base(string name) : this()
        {
            Name = name;
            System.Console.WriteLine("Base létrehozó: Base(string name)");
        }

        public Base(string name, string email) : this(name) 
        {
            
            System.Console.WriteLine("Base létrehozó: Base(string name, string email)");
            Email = email;
        }


        public bool IsInitiated { get; private set; }

        /// <summary>
        /// Read-only property: csak olvasható, DE
        /// a konstruktorban írható
        /// </summary>
        public string Email { get; }

        ~Base()
        {
            System.Console.WriteLine("véglegesítő: ~Base()");
        }
    }
}