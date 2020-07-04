using System;
using System.Collections.Generic;
using System.Text;

namespace Exercices.Luhn
{
    public interface ILuhnCheckService
    {
        bool IsValid(string text);
    }
}
