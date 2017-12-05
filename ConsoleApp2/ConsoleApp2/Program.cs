using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser
{
    public class GroupsInOneCategory
    {
        public string Category { get; set; }
        public List<string> Names { get; set; }

        public GroupsInOneCategory(string category)
        {
            Category = category;
            Names = new List<string>();
        }
    }

    /* Редкостный говнокод. */
    public class Program
    {
        static void Main(string[] args)
        {
            var test = new Dictionary<string, string>();

            StreamReader sr = new StreamReader("new_interest.csv",Encoding.GetEncoding(1251));
            string line;
            string[] row = new string[2];
            var agr = new List<GroupsInOneCategory>();
            line = sr.ReadLine();
            line = sr.ReadLine();
            //row = line.Split(';');
            //GroupsInOneCategory currGroup = new GroupsInOneCategory(row[1].Replace(".txt", ""));
            while ((line = sr.ReadLine()) != null)
            {
                /*
                if (currGroup.Category != row[1].Replace(".txt", ""))
                {
                    agr.Add(currGroup);
                    currGroup = new GroupsInOneCategory(row[1].Replace(".txt", ""));
                }

                row = line.Split(';');

                currGroup.Names.Add(row[0]);
                */
                row = line.Split(';');
                if (!test.ContainsKey(row[row.Length - 1].Replace(".txt", "")))
                {
                    test.Add(row[row.Length - 1].Replace(".txt", ""), row[0]);
                }
                else
                {
                    
                    foreach (var key in test.Keys.ToList())
                    {
                        if (row[row.Length - 1].Replace(".txt", "") == key) test[key]+=";"+row[0];
                        
                    }
                }
            }
            sr.Close();
            using (StreamWriter outputFile = new StreamWriter("WriteLines.txt"))
            {
                foreach (var v in test)
                    outputFile.WriteLine(v);
            }
        }
    }
}

