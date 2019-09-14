using System;
using System.Collections.Generic;
using System.Text;

namespace _08StrategyPattern
{
    public interface IStrategy
    {
        int Process(int[] data);
    }
}
