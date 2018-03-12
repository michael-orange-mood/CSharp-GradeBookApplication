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

            if (studentsBetterThanThis < Students.Count / 5)
            {
                return 'A';
            }

            return 'F';
        }

    }
}