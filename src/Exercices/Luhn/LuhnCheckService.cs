using System;
using System.Linq;

namespace Exercices.Luhn
{
    public class LuhnCheckService : ILuhnCheckService
    {
        const ushort ZERO_CODE_CHAR = 48;

        public bool IsValid(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            text = text.Replace(" ", "");

            if (text.Length <= 1) throw new InvalidOperationException();

            return text.All(char.IsDigit) &&
                text.Reverse()
                    .Select(c => c - ZERO_CODE_CHAR)
                    .Select((thisNum, i) => i % 2 == 0
                        ? thisNum
                        : (thisNum *= 2) > 9 ? thisNum - 9 : thisNum
                    )
                    .Sum() % 10 == 0;
        }
    }
}
