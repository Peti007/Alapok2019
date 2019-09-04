using System;
using System.Collections;
using System.Collections.Generic;

namespace _01IEnumerableT
{
 
    public class BejarhatoAdatok<TAdat> : IEnumerable<TAdat>, IEnumerator<TAdat>
    {
        List<TAdat> adatok = new List<TAdat>();

        public TAdat Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

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
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion IEnumerator<T> implementáció
    }
}