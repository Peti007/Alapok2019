using System;
using System.Collections.Generic;

namespace _10DelegateExample
{
    public class DataStore
    {
        private List<string> lines;

        public delegate void FuncDef(ref string text);

        public DataStore(List<string> lines)
        {
            this.lines = lines;
        }

        public void ProcessData(FuncDef processList)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                var item = lines[i];
                processList(ref item);

                lines[i] = item;
            }
                
            
        }

        public void Print()
        {
            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }
        }
    }
}