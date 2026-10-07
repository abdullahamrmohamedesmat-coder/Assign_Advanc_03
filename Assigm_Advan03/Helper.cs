using System;
using System.Collections.Generic;
using System.Text;

namespace Assigm_Advan03
{
    public class Helper
    {
        public static void PrintCollection<T>(string nameOfCollection, IEnumerable<T> Collection)
        {

            Console.WriteLine($" {nameOfCollection}:{string.Join(',', Collection)}");
        }

        public static bool IsAbove90(int grade)
        {
            return grade > 90;
        }

        public static bool GetFailingGrades(int grade)
        {
            return grade < 75;
        }
        public static bool IsGradeEquals100(int grade)
        {
            return grade == 100;
        }
    }
}
