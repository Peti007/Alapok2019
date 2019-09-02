using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

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
       

        //menedzslet stream, de IDisposable felületet implementál
        private Stream fileStream = new FileStream("file.text",FileMode.Create);
        //menedzselt lista, de nagy méretű
        private List<string> managedMemory = new List<string>();
        //nem menedzselt memóriaterület
        private IntPtr unmanagedMemory = IntPtr.Zero;

        /// <summary>
        /// Logikai érték: 0=false (hamis, 1=true (igaz))
        /// jelzi, hogy lefutott e már a Dispose
        /// </summary>
        private int isDisposed = 0;

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

        public int FuggvenyAmiFigyelADisposra()
        {
            EnsureNotDisposed();
            return 1;
        }

        public int MyProperty {
            get {
                EnsureNotDisposed();
                return 1;

            }
            set {
                EnsureNotDisposed();

            }
        }


        private void EnsureNotDisposed()
        {
            if (isDisposed == 1)
            {
                throw new ObjectDisposedException(nameof(ItselfCleaner));
            }
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

            //Egy logikai lépésben ezeket a műveleteket végzi:
            //1. old = IsDispose (elmenti az isDispose jelenlegi értékét)
            //2. isDispose = 1 (megváltoztatja az isDispose értékét 1-re)
            //3. return old; (visszatér a régi értékkel)

            if (Interlocked.Exchange(ref isDisposed, 1) == 1)
            {
                //return;
                //amennyiben kétszer fut le az általában logikai hiba, érdemes ezt hangosan és érthetően jelezni
                throw new ObjectDisposedException(nameof(ItselfCleaner));
            }

            if (dispose)
            {//a Dispose-ból hívtuk, így a menedzslet részeket is takarítjuk 
             //menedzselt IDisposablet használó példány felszabadítása

                if (fileStream != null)
                { 
                fileStream.Dispose();
                fileStream = null;
                }
                //menedzselt memória felszbadítása
                if (managedMemory != null)
                {
                    managedMemory.Clear();
                    managedMemory = null;
                }
            }

            //inicializálatlan helyzet kizárása, nehogy hibára fussunk
            if (unmanagedMemory != IntPtr.Zero)
            {
                //nem menedzslet memória felszabadítása
                Marshal.FreeHGlobal(unmanagedMemory);
                //szólunk a GC-nek, hogy újra használhatja ezt a területet

                GC.RemoveMemoryPressure(1000000);

            }
            

        }
    }
}