using System.Globalization;

namespace Assigm_Advan03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question
            //1at answer01
            List<int> grades = [85, 92, 78, 95, 88, 70, 100, 65];
            Helper.PrintCollection("Grades", grades);
            Console.WriteLine($"Count:{grades.Count}");
            Console.WriteLine($"Firat Grade :{grades.First()}");
            Console.WriteLine($"Last Grade :{grades.Last()}");
            Console.WriteLine();

            grades.Sort();
            Console.Write($"Sorted Grades :");
            Helper.PrintCollection("Grades", grades);

            Func<int, bool> isAbove90 = Helper.IsAbove90;

            foreach (var grade in grades)
            {
                if (isAbove90(grade))
                {
                    Console.WriteLine($"First Grade >90: {grade} .");
                    break;
                }
            }
            Func<int, bool> getFailingGrades = Helper.GetFailingGrades;
            List<int> failingGrades = new List<int>();
            foreach (var grade in grades)
            {
                if (getFailingGrades(grade))
                {
                    failingGrades.Add(grade);
                    Console.WriteLine($"Failing Grade: {grade} .");
                }
            }

            grades.RemoveAll(failingGrades.Contains);
            Helper.PrintCollection("Passed Grades", grades);

            foreach (var grade in grades)
            {
                if (Helper.IsGradeEquals100(grade))
                {
                    Console.WriteLine($"Grade equals 100: {grade} .");
                }
            }
            List<string> stringsGrades = new List<string>();
            foreach (var grade in grades)
            {
                stringsGrades.Add($"Grade: {grade}");
            }
            Helper.PrintCollection("String Grades", stringsGrades); 
            #endregion
        }
    }
}
