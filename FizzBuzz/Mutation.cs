using System;
using System.Collections.Generic;
using System.Linq;

struct TableIndex
{
    public int column, row;
};

namespace FizzBuzz
{
    class Mutation
    {
        Random rand = new Random();
        public List<List<TableIndex>> teachersIndexTable = new List<List<TableIndex>>();
        public List<TableIndex> teachersIndexItem = new List<TableIndex>();

        public List<List<TableIndex>> roomsIndexTable = new List<List<TableIndex>>();
        public List<TableIndex> roomsIndexItem = new List<TableIndex>();

        public TupleStruct[][] Mutate(TupleStruct[][] genotype)
        {
            Chromosome t = new Chromosome();
            int violations = CheckViolations(genotype);
            if (violations >= 2)
            {
                genotype = TwoViolations(genotype);
            }
            else if (violations == 1)
            {
                genotype = OneViolation(genotype);
            }

            return genotype;
        }

        public TupleStruct[][] TwoViolations(TupleStruct[][] offsping)
        {
            //Swap Teachers
            TableIndex aTeacher = teachersIndexTable[0][0];
            TableIndex bTeacher = teachersIndexTable[rand.Next(teachersIndexTable.Count())][1];

            var tempTeacher = offsping[bTeacher.row][bTeacher.column];
            offsping[bTeacher.row][bTeacher.column].teacher = offsping[aTeacher.row][aTeacher.column].teacher;
            offsping[aTeacher.row][aTeacher.column].teacher = tempTeacher.teacher;

            //Swap Rooms
            TableIndex aRoom = roomsIndexTable[0][0];
            TableIndex bRoom = roomsIndexTable[rand.Next(teachersIndexTable.Count())][1];

            var tempRoom = offsping[bRoom.row][bRoom.column];
            offsping[bRoom.row][bRoom.column].room = offsping[aRoom.row][aRoom.column].room;
            offsping[aRoom.row][aRoom.column].room = tempRoom.room;

            return offsping;
        }

        public TupleStruct[][] OneViolation(TupleStruct[][] offsping)
        {
            //Swap Teachers
            TableIndex aTeacher = teachersIndexTable[0][0];

            TableIndex bTeacher;
            bTeacher.column = aTeacher.column;
            bTeacher.row = rand.Next(Program.nbrPeriods);

            var tempTeacher = offsping[bTeacher.row][bTeacher.column];
            offsping[bTeacher.row][bTeacher.column].teacher = offsping[aTeacher.row][aTeacher.column].teacher;
            offsping[aTeacher.row][aTeacher.column].teacher = tempTeacher.teacher;

            //Swap Rooms
            TableIndex aRoom = roomsIndexTable[0][0];

            TableIndex bRoom;
            bRoom.column = aRoom.column;
            bRoom.row = rand.Next(Program.nbrPeriods);

            var tempRoom = offsping[bRoom.row][bRoom.column];
            offsping[bRoom.row][bRoom.column].room = offsping[aRoom.row][aRoom.column].room;
            offsping[aRoom.row][aRoom.column].room = tempRoom.room;

            return offsping;
        }

        public int CheckViolations(TupleStruct[][] genotype)
        {
            teachersIndexTable = new List<List<TableIndex>>();
            roomsIndexTable = new List<List<TableIndex>>();

            int violations = 0;
            for (int i = 0; i < Program.nbrPeriods; i++)
            {
                int rowViolations = 0;
                //Find teacher duplicates in a row of the genotype
                var groupTeachers = genotype[i].Select((v, j) => new { Value = v.teacher, Index = j }).GroupBy(t => t.Value).Where(t => t.Count() > 1);
                foreach (var teacher in groupTeachers)
                {
                    rowViolations++;
                    int k = 0;
                    teachersIndexItem = new List<TableIndex>();
                    foreach (var item in teacher)
                    {
                        var tuple = new TableIndex();
                        tuple.row = i;
                        tuple.column = item.Index;
                        teachersIndexItem.Add(tuple);
                        k++;
                    }
                    if (rowViolations > 0)
                    {
                        violations++;
                    }
                }

                //Find room duplicates in a row of the genotype
                var groupRooms = genotype[i].Select((v, j) => new { Value = v.room, Index = j }).GroupBy(t => t.Value).Where(t => t.Count() > 1);
                foreach (var room in groupRooms)
                {
                    rowViolations++;
                    int k = 0;
                    roomsIndexItem = new List<TableIndex>();
                    foreach (var item in room)
                    {
                        var tuple = new TableIndex();
                        tuple.row = i;
                        tuple.column = item.Index;
                        roomsIndexItem.Add(tuple);
                        k++;
                    }
                    if (rowViolations > 0)
                    {
                        violations++;
                    }
                }
            }
            teachersIndexTable.Add(teachersIndexItem);
            roomsIndexTable.Add(roomsIndexItem);
            return violations;
        }

    }
}
