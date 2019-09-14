namespace _08StrategyPattern
{
    public class SumOfOddStrategy : IStrategy
    {
        public int Process(int[] data)
        {
            var sum = 0;
            foreach (var d in data)
            {
                if (d % 2 == 1)
                {
                    sum += d;
                }
            }
            return sum;
        }
    }
}