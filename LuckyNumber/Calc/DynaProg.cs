using System.Linq;
using Num = System.UInt64;

namespace LuckyNumber
{
    public class DynaProg : ILuckyNumbers
    {
        private Num[][] _variants;

        public Num GetCount(int basis, int digits)
        {
            _variants = new Num[basis][];

            Num[] seedLine = Enumerable.Repeat<Num>(1, basis).ToArray();

            var sums = seedLine;
            for (int i = 1; i < digits / 2; i++)
            {
                sums = GetSums(basis, seedLine);
                seedLine = sums;
            }

            Num result;
            //результат для чётного кол-ва разрядов
            result = (Num)sums.Sum(_ => (decimal)_ * _);
            //учитываем нечётный разряд в середине
            if (digits % 2 > 0) result *= (Num)basis;
            return result;
        }

        private Num[] GetSums(int basis, Num[] seedLine)
        {
            _variants[0] = seedLine;
            for (int i = 1; i < basis; i++)
            {
                _variants[i] = Enumerable.Repeat<Num>(0, 1)
                    .Concat(_variants[i - 1]).ToArray();
            }

            int sumsLen = _variants.Last().Count();
            var sums = new Num[sumsLen];
            for (int j = 0; j < sumsLen; j++)
            {
                Num r = 0;
                foreach (var v in _variants) if (v.Length > j) r += v[j];
                sums[j] = r;
            }

            return sums;
        }
    }
}