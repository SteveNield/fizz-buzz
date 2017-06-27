using System.Linq;

namespace FizzBuzz
{
    public class FizzBuzzer : IFizzBuzzer
    {
        public string FizzBuzzRange(int start, int end)
        {
            string result = string.Empty;

            for (int i = start; i <= end; i++)
            {
                result +=
                    i % 15 == 0 // 15 is the smallest divisible by 3 and 5, and so are all it's multipiers
                    ? "fizzbuzz"
                    : i % 3 == 0
                    ? "fizz"
                    : i % 5 == 0
                    ? "buzz"
                    : i.ToString();
            }

            return result;
        }
    }
}
