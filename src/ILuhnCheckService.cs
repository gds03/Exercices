using System;
using System.Collections.Generic;
using System.Text;

namespace Luhn
{
    public interface ILuhnCheckService
    {
        bool IsValid(string text);
    }
}
