using System;
using System.Collections;
using System.Collections.Generic;
using Num = System.UInt64;

namespace LuckyNumber
{
    /// <summary>
    /// Полный перебор и проверка вариантов
    /// </summary>
    public class BruteForce : ILuckyNumbers
    {
        public Num GetCount(int basis, int digits)
        {
            var bf = new BruteForceChecker(basis, digits);
            foreach (var i in bf) ;
            return bf.LuckyCount;
        }
    }

    internal class BruteForceChecker: IEnumerator<Num>, IEnumerable<Num>
    {
        public BruteForceChecker(int basis, int digits)
        {
            _basis = basis;
            _digits = digits;
            _maxBasis = (Num)Math.Pow(basis, digits);
        }

        private Num _value = 0;
        private int _basis;
        private int _digits;
        private Num _maxBasis;

        private void CheckLucky()
        {
            if (IsLucky(_basis, _digits)) LuckyCount++;
        }
        
        public Num LuckyCount { get; private set; }

        private bool IsLucky(int basis, int digits)
        {
            int left = 0, right = 0;
            var v = _value;

            for (var i = 0; i < digits / 2; i++) Digit(ref right, ref v);

            int mid = 0;
            if (digits % 2 > 0) Digit(ref mid, ref v);

            for (var i = 0; i < digits / 2; i++) Digit(ref left, ref v);

            return left == right;

            void Digit(ref int l, ref ulong v)
            {
                l = l + (int)(v % (Num) basis);
                v = v / (Num) basis;
            }
        }

        #region interfaces implementation
        public Num Current => _value;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            _value++;
            CheckLucky();
            return _value < _maxBasis;
        }

        public void Reset()
        {
            _value = 0;
            LuckyCount = 0;
        }

        public void Dispose()
        {  }

        public IEnumerator<ulong> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        #endregion
    }
}
