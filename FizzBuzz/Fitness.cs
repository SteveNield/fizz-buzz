using System.Linq;

namespace FizzBuzz
{
    class Fitness
    {
        public int Evaluate(TupleStruct[][] genotype)
        {
            int fitnessScore = 0;
            for (int i = 0; i < Program.nbrPeriods; i++)
            {
                //Increment the fitnessScore everytime a teacher duplicate is found in the same row (time period)
                var groupTeachers = genotype[i].Select((v, j) => new { Value = v.teacher, Index = j }).GroupBy(t => t.Value).Where(t => t.Count() > 1);
                foreach (var teacher in groupTeachers)
                {
                    fitnessScore++;
                }

                //Increment the fitnessScore everytime a room duplicate is found in the same row (time period)
                var groupRooms = genotype[i].Select((v, j) => new { Value = v.room, Index = j }).GroupBy(t => t.Value).Where(t => t.Count() > 1);
                foreach (var room in groupRooms)
                {
                    fitnessScore++;
                }
            }
            return fitnessScore;
        }
    }
}
