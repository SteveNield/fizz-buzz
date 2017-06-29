using System;

namespace FizzBuzz
{
    class Parent
    {
        public TupleStruct[][] Selection(TupleStruct[][][] population)
        {
            Random rand = new Random();
            Fitness fitness = new Fitness();

            TupleStruct[][] champion = population[rand.Next(0, Program.populationSize)];
            TupleStruct[][] challenger;
            for (int i = 2; i <= Program.populationSize; i++)
            {
                challenger = population[rand.Next(0, Program.populationSize)];
                int randomNumber = rand.Next(1, 4);
                if (randomNumber == 2)
                {
                    champion = challenger;
                }
                else if (randomNumber == 3)
                {
                    if (fitness.Evaluate(challenger) < fitness.Evaluate(champion)) //Less is better
                        champion = challenger;
                }
            }
            return champion;
        }
    }
}
