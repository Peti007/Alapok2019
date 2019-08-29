namespace _01ConstructorFinalizer
{
    public class Middle : Base
    {
        //public Middle()
        //{
        //    System.Console.WriteLine("Middle létrehozó: Middle()");
        //}

        public Middle(string name, string email) : base(name, email)
        {
            System.Console.WriteLine("Middle létrehozó: Middle(string name, string email)");
        }

        ~Middle()
        {
            System.Console.WriteLine("véglegesítő: ~Middle()");
        }
    }
}