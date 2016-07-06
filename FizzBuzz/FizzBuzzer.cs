namespace FizzBuzz
{
    public class FizzBuzzer : IFizzBuzzer
    {
        //real simples, feel like i'm missing something?..
        //Wanting to include validation; but that would void testcase exceptions I think
        public string FizzBuzzRange(int start, int end)
        {
            string result = "";

            for (int i = start; i <= end; i++) //record all fiz, buzz or fizzbuzz
            {
                string tmp = i.ToString();

                if ((i % 3) == 0 && (i % 5) != 0)
                {
                    tmp = "fizz";
                }
                if ((i % 5) == 0 && (i % 3) != 0)
                {
                    tmp = "buzz";
                }
                if ((i % 5) == 0 && (i % 3) == 0)
                {
                    tmp = "fizzbuzz";
                }
                result += tmp;
            }
            return result;
        }
    }
}