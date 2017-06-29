using System;

namespace FizzBuzz
{
    class Population
    {
        public TupleStruct[][][] Initialize()
        {
            Random rand = new Random();
            for (int p = 0; p < Program.populationSize; p++)
            {
                Program.initialPopulation[p] = new TupleStruct[Program.nbrPeriods][];
                for (int i = 0; i < Program.nbrPeriods; i++)
                {
                    Program.initialPopulation[p][i] = new TupleStruct[Program.nbrGroups];
                    for (int j = 0; j < Program.nbrGroups; j++)
                    {
                        Program.initialPopulation[p][i][j].teacher = Program.teachers[rand.Next(0, Program.teachers.Length)];
                        Program.initialPopulation[p][i][j].room = Program.rooms[rand.Next(0, Program.rooms.Length)];
                    }
                }
            }
            return Program.initialPopulation;
        }
    }
}
