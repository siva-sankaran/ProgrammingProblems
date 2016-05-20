using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchAsMuchColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repo = new Repository();
            IEnumerable<Record> output;
           

            output = repo.filter(10, 20, 30, 40);
            output = repo.filter(15, 20, 30, 40);
            output = repo.filter(15, 20, 30, 90);

        }

    }
}
