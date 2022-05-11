namespace LuckyNumber
{
    public interface ILuckyNumbers
    {
        /// <summary>
        /// Посчитать количество счастливых чисел,
        /// когда сумма цифр правой половины равна сумме цифр левой половины.
        /// </summary>
        /// <param name="basis">Основание цифры разряда [0..basis) [0..basis-1]</param>
        /// <param name="digits">Кол-во цифр в числе</param>
        /// <returns>Количество счастливых чисел</returns>
        public System.UInt64 GetCount(int basis, int digits);
    }
}
