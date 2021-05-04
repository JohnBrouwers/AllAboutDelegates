using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAreUsedInSamples.Delegates
{
    class DelegatesUsedInLinq
    {
        public void LinqWhere()
        {
            var colors = new List<string>();
            colors.Add("Red");
            colors.Add("Yellow");
            colors.Add("Blue");

            //This Where uses the System predefined delegate Func<string, bool> as a parameter:
            var filtered = colors.Where(s => s.StartsWith("B"));
            colors.Add("Black");
            //A bit offtopic, Linq uses deferred execution.
            //The 'where filter method' is not executed on each item in the list until iteration, or calling the filtered.ToList(). This is shown by first calling the Where method and adding a new item later.
            foreach (var item in filtered)
            {
                Console.WriteLine();
            }

            //This OrderBy uses the System predefined delegate Func<string, int>:
            var sorted1 = colors.OrderBy(s => s.Length);
            var sorted2 = colors.OrderBy(LengthFunc());
            var sorted3 = colors.OrderBy(s => GetLength(s)); 
        }

        private int GetLength(string s)
        {
            return s.Length;
        }

        private Func<string, int> LengthFunc()
        {
            return s => s.Length;
        }
    }
}
