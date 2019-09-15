using System;

namespace _09Delagate
{
    public class DataStoreWDelegate
    {
        private int[] data;

        // olyan mint az objektumnál az interfész
        //függvény definició, ami megmondja, hogy a függvényem, amit majd ProcessDef hivatkozással adok meg, hogy néz ki.
        public delegate int ProcessDef(int[] data);


        public DataStoreWDelegate(int[] data)
        {
            this.data = data;
        }

        public int Process(ProcessDef strategy)
        {
            return strategy(data);
        }

        public int Process3(Func<int[], int> strategy)
        {
            return strategy(data);
        }

        public int Process2(Func<int[],int> strategy)
        {
              return strategy(data);
        }



    }
}