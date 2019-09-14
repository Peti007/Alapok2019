using System;
using System.Collections.Generic;
using System.Text;

namespace _08StrategyPattern
{
    interface IStrategy
    {
        int Process(int[] data);
    }
}
