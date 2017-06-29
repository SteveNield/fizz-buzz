using System;

struct TupleStruct
{
    public string teacher, room;
};


namespace FizzBuzz
{
    class Program
    {
        public static int populationSize = 10;
        public static int nbrPeriods = 20;
        public static int nbrGroups = 5;
        public static string[] teachers = { "T1", "T2", "T3", "T4", "T5" };
        public static string[] rooms = { "R1", "R2", "R3", "R4", "R5" };
        public static TupleStruct[][][] initialPopulation = new TupleStruct[populationSize][][];
        public static TupleStruct[][][] offspringPopulation = new TupleStruct[populationSize][][];

        static void Main(string[] args)
        {
            Chromosome genotype = new Chromosome();
            Population population = new Population();
            Fitness fitness = new Fitness();
            Parent parent = new Parent();
            Mutation mutation = new Mutation();

            initialPopulation = population.Initialize();

            TupleStruct[][] fittestGenotype = initialPopulation[0];
            int currentGeneration = 0;
            int maxGenerations = 1000;

            while (currentGeneration < maxGenerations && fitness.Evaluate(fittestGenotype) > 0)
            {
                for (int i = 0; i < populationSize; i++)
                {
                    offspringPopulation[i] = mutation.Mutate(parent.Selection(initialPopulation));
                    if (fitness.Evaluate(offspringPopulation[i]) < fitness.Evaluate(fittestGenotype))
                    {
                        fittestGenotype = offspringPopulation[i];
                    }
                }

                initialPopulation = offspringPopulation;
                currentGeneration++;
                Console.WriteLine("Generation {0}", currentGeneration);
            }
            Console.WriteLine("\nFittest genotype :");
            genotype.Print(fittestGenotype);
            Console.WriteLine("Fitness : {0}\n", fitness.Evaluate(fittestGenotype));

        }
    }
}
