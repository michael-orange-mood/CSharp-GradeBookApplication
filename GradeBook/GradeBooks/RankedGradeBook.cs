using System;
using System.Linq;

using GradeBook.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked Grading requires a minimum of 5 students to work");
            }

            int studentsBetterThanThis = this.Students.Where(x => x.AverageGrade > averageGrade).Count();

            int twentyPercent = Students.Count / 5;

            if (studentsBetterThanThis < twentyPercent)
            {
                return 'A';
            }
            else if (studentsBetterThanThis < twentyPercent * 2)
            {
                return 'B';
            }
            else if (studentsBetterThanThis < twentyPercent * 3)
            {
                return 'C';
            }
            else if (studentsBetterThanThis < twentyPercent * 4)
            {
                return 'D';
            }

            return 'F';
        }

    }
}