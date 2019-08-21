namespace _01Objektumok
{
    internal class Plane
    {
        public Plane()
        {
        }

        //mező (field)
        //tartalmazza az élek számát
        public int NrOfEdge;

        public int NrOfArcs { get; set; }

        private string _name;
        public string Name {
            get {
                
                return _name;
            }
            set {
                _name = value;
            }
        }

        public void Show() {

        }
        public void Show(bool disabled)
        {

        }
        public void Show(int PosX, int PosY)
        {

        }

        //az out paraméternél mindenképpen kell értéket adni az out-ként definiált paraméternek
        public void Show(int height, ReferenciaTipus referencia, ref int width, out int ertek3)
        {
            System.Console.WriteLine($"Show height: {height}, referencia: {referencia.ertek}, width: {width}");

            //az out paraméternél mindenképpen kell értéket adni az out-ként definiált paraméternek
            ertek3 = 10;

            height = height * 2;
            referencia.ertek = referencia.ertek * 2;
            width *= 2;

            

            System.Console.WriteLine($"Show height: {height}, referencia: {referencia.ertek}, width: {width}");
        }

        public void Show(int height = 5, int width= 4, string name = "név") {

        }

        

    }
}