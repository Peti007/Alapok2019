using System;
using System.Collections;
using System.Collections.Generic;

namespace _01IEnumerableT
{
 
    public class BejarhatoAdatok<TAdat> : IEnumerable<TAdat>, IEnumerator<TAdat>
    {
        List<TAdat> adatok = new List<TAdat>();
        int position = -1;



        public TAdat Current
        {
            get
            {
                return adatok[position];
            }
            
        }

        object IEnumerator.Current { get { return Current; } }

        #region Adatok karbantartására szolgáló felület
        /// <summary>
        /// egy adatcsomagot hozzá tudunk adni a listához
        /// </summary>
        /// <param name="adat"></param>
        public void Add(TAdat adat)
        {
            adatok.Add(adat);
        }



        /// <summary>
        /// Egy bejegyzés eltávolítása az adatok közül
        /// </summary>
        /// <param name="adat"></param>
        /// <returns></returns>
        public bool Remove(TAdat adat)
        {
            return adatok.Remove(adat);
        }


        #endregion Adatok karbantartására szolgáló felület
       
        #region IEnumerable<TAdat> implementáció
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        public IEnumerator<TAdat> GetEnumerator()
        {
            return this;
        }
        #endregion IEnumerable<TAdat> implementáció

        #region IEnumerator<T> implementáció
        public bool MoveNext()
        {
            position++;
            return position < adatok.Count;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //nem kell most takarítanunk
        }
        #endregion IEnumerator<T> implementáció
    }
}