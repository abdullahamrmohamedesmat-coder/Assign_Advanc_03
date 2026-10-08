using System.Globalization;
using System.Linq.Expressions;

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

            #region Question02
            //ansswer02
            SortedDictionary<int, string> players = new SortedDictionary<int, string>()
            {
                {500,"Ahmed"},
                {200,"Sara" },
                {800,"Ali"  },
                {350,"Mona" }
            };
            //players.Keys.ToList<int>();  
            //players.Values.ToList<string>();

            //int minKey = players.Keys.First<int>();

            //Dictionary<int, string> sortPlayers = new Dictionary<int, string>();
            //foreach (var key in players.Keys)
            //{
            //    if (key > minKey)
            //    {
            //        minKey = key;
            //        foreach (var player in players)
            //        {
            //            if (player.Key == minKey)
            //            {
            //                sortPlayers.Add(player.Key, player.Value);
            //            }
            //        }
            //    }

            //}
            //players = sortPlayers;
            //Helper.PrintCollection("Sorted Players", sortPlayers);
            Helper.PrintCollection("Players", players);
            //foreach (KeyValuePair<int, string> player in players)
            //{
            //    Console.WriteLine($"Player ID: {player.Key}, Name: {player.Value}");
            //}
            //Console.WriteLine();
            Console.WriteLine($"First Score: {players.Keys.First()}");
            Console.WriteLine($"First Name: {players.Values.First()}");
            if (players.ContainsKey(500))
            {
                Console.WriteLine(players[500]);
            }
            if (players.TryGetValue(999, out string name))
            {
                Console.WriteLine(name);
            }
            players.Remove(200);
            Helper.PrintCollection("Players after removing ID 200", players);


            #endregion

            #region Phone Book
            //Phone Book
            Dictionary<string, string> contacts = new Dictionary<string, string>(); 
            //Contact contact = new Contact() { Name = "Omar", PhoneNumber = "0123456789" };
            contacts["Omar"]= "0123456789";
            contacts.Add("Sara", "9876543210");
            
            Helper.PrintCollection("Contacts", contacts);

            try
            {
                contacts.Add("Sara", "9876543210");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

           if( contacts.TryAdd("Sara", "9876543210"))
                Console.WriteLine("Contact added successfully.");
           
           if(contacts.ContainsKey("Ahmed")&&contacts.ContainsValue("0112353749"))
                Console.WriteLine(contacts["Ahmed"]);

            string Name = "ziad";
           string phonenUMBER=contacts.GetValueOrDefault("ziad", "Contact not found.");
            Console.WriteLine($"{Name},{ phonenUMBER}");
            foreach (var contact in contacts.Keys)
            {
                Console.WriteLine($"Contact keys: {contact}");
            }

            foreach (var contact in contacts.Values)
            {
                Console.WriteLine($"Contact values: {contact}");
            }
            #endregion

            #region Unique Email Validator
            //Unique Email Validator
            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");
            Console.WriteLine(emails.Count);//2 because HashSet is case-insensitive ,so it only keeps unique email addresses regardless of case.
            HashSet<int> A = [ 1, 2, 3, 4, 5 ];
            HashSet<int> B = [4, 5, 6, 7, 8];
            //Union and Intersection
            HashSet<int> union = new HashSet<int>(A);
             union.UnionWith(B);
            Helper.PrintCollection("Union", union);
            HashSet<int> intersection = new HashSet<int>(A);
            intersection.IntersectWith(B);
            Helper.PrintCollection("Intersection", intersection);
            //Exception
            HashSet<int> Except = new HashSet<int>(A);
            Except.ExceptWith(B);
            Helper.PrintCollection("Exception", Except);
           HashSet<int> C = [1,2];
            Console.WriteLine(C.IsSubsetOf(A));
            #endregion

            #region Queue
            //Queue
            Queue<string> documents = new Queue<string>();
            documents.Enqueue("Report.pdf");
            documents.Enqueue("Invoice.pdf");
            documents.Enqueue("Letter.docx");
            documents.Enqueue("Resume.pdf");
            documents.Enqueue("Photo.jpg");

            Helper.PrintCollection("Documents in Queue", documents);
            Console.WriteLine(documents.Count);
            Console.WriteLine(documents.Peek());

            while (documents.Count > 0)
            {
                string document = documents.Dequeue();
                Console.WriteLine($"Processing document: {document}");
            }
            documents.TryDequeue(out string doc);
            Console.WriteLine(doc);//This will print null because the queue is empty after processing all documents.
            #endregion

            #region Browser History (Undo)
            //Browser History (Undo)
            Stack<string> browserHistory = new Stack<string>();
            browserHistory.Push("google.com");
            browserHistory.Push("github.com");
            browserHistory.Push("stackoverflow.com");
            browserHistory.Push("youtube.com");
            browserHistory.Push("claude.ai");

            Console.WriteLine(browserHistory.Peek());
            
            while (browserHistory.Count >= 3)
            {
                Console.WriteLine("pressing '<-' to back 3 times");
                string leftPage = browserHistory.Pop();
                Console.WriteLine($"left Page: {leftPage}");
            }
            Console.WriteLine($"Current Page:{browserHistory.Peek()}");
            browserHistory.Pop();
            browserHistory.Pop();
            if (browserHistory.TryPop(out string page))
            {
                Console.WriteLine(page);
            }
            else
            {
                Console.WriteLine("No more pages in history.");
            }
            #endregion
        }
    }
}
