namespace _02Ermehamisitas
{
    public class FakeCoin : Coin 
    {
        public FakeCoin()
        {
            System.Console.WriteLine("FakeCoin konstruktor");
        }

        public override int Collect()
        {
            System.Console.Write("FakeCoin.Collect");
            return 0;
        }
    }
}