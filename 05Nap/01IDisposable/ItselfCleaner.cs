using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace _01IDisposable
{
    /// <summary>
    /// Saját maga után takarítani képes osztály készítése
    /// a beípitett IDisposable felület segítségével
    /// 
    /// Mikor kell megunk után takarítani?
    /// 
    /// - külső függőségünk van (file, hálózat, stb) esetén, ha menedzselt objektumot használunk, akkor a GC megold mident
    ///  - kivéve ha a menedzselt kód IDisposable mintát használ, mert akkor nekünk is kötelező ezt implementálni
    /// - nagy memóriát használunk, akkor javasolt megunk után takarítani
    /// -direkt memóriakezelést használunk6 nem menedzselt memóriakezelés
    /// 
    /// ha takarítani való függőségei vannak 
    /// </summary>


    public class ItselfCleaner : IDisposable 
    {
        private bool isDisposed = false;

        //menedzslet stream, de IDisposable felületet implementál
        private Stream fileStream = new FileStream("file.text",FileMode.Create);
        //menedzselt lista, de nagy méretű
        private List<string> managedMemory = new List<string>();
        //nem menedzselt memóriaterület
        private IntPtr unmanagedMemory = IntPtr.Zero;

        public ItselfCleaner()
        {
            //menedzselt memória feltöltése
            for (int i = 0; i < 1000000; i++)
            {
                managedMemory.Add("AAAAAAAA");
            }

            unmanagedMemory = Marshal.AllocHGlobal(1000000);
            //mivel nem menedzslet memóriaterületről van szó, így szólnunk kell a GC-nek, hogy ezt a területet már nem használhatja
            GC.AddMemoryPressure(1000000);

        }


        /// <summary>
        /// A takarítást végző függvény
        /// 
        /// dispose függvényben nem szabad kivételt okoznunk
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            //kivesszük a Finalizer queue-ból az osztálypéldányt,
            //hiszen takarítottunk, nincs már szükség erre
            //ezzel elérjük, hogy ha jól használjuk a usingot,
            //akkor a Finalizer sose fog lefutni
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// Az osztály finalizere, ha már nincs a példányra mutató hivatkozás
        /// akkor egyszer, valalmikor lefut. Feladata, hogy lehetőleg sose fusson.
        /// </summary>
        ~ItselfCleaner()
        {
            Dispose(false);
        }

        /// <summary>
        /// A "valódi" takarító függvény
        /// </summary>
        /// <param name="dispose">jelzi, hogy a Dispose függvényből hívtuk (true), vagy a Finalizerből(false).</param>
        private void Dispose(bool dispose)
        {
            if (isDisposed)
            {
                return;
            }

            if (dispose)
            {//a Dispose-ból hívtuk, így a menedzslet részeket is takarítjuk 
             //menedzselt IDisposablet használó példány felszabadítása
                fileStream.Dispose();
                fileStream = null;

                //menedzselt memória felszbadítása
                managedMemory.Clear();
                managedMemory = null;
            }

            //nem menedzslet memória felszabadítása
            Marshal.FreeHGlobal(unmanagedMemory);
            //szólunk a GC-nek, hogy újra használhatja ezt a területet

            GC.RemoveMemoryPressure(1000000);

            //takarítás
            isDisposed = true;
        }
    }
}