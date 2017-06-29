using ConsoleTables;

namespace FizzBuzz
{
    class Chromosome
    {
        public void Print(TupleStruct[][] genotype)
        {
            ConsoleTable table = new ConsoleTable("Periods", "Groupe 1", "Groupe 2", "Groupe 3", "Groupe 4", "Groupe 5");
            int i = 0;
            foreach (var item in genotype)
            {
                table.AddRow(
                    i + 1,
                    item[0].teacher,
                    item[1].teacher,
                    item[2].teacher,
                    item[3].teacher,
                    item[4].teacher
                    );

                //table.AddRow(
                //    i + 1,
                //    item[0].teacher + " / " + item[0].room,
                //    item[1].teacher + " / " + item[1].room,
                //    item[2].teacher + " / " + item[2].room,
                //    item[3].teacher + " / " + item[3].room,
                //    item[4].teacher + " / " + item[4].room
                //    );
                i++;
            }
            table.Write(Format.Alternative);
        }
    }
}
