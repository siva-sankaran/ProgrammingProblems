using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchAsMuchColumns
{
    class Repository
    {
        List<Record> records;

        public Repository()
        {
            records = new List<Record>();
            records.Add(new Record() { ID = 1, text1 = 10, text2 = 20, text3 = 30, text4 = 40 });
            records.Add(new Record() { ID = 2, text1 = 11, text2 = 20, text3 = 30, text4 = 40 });
            records.Add(new Record() { ID = 3, text1 = 10, text2 = 20, text3 = 30, text4 = 80 });
            records.Add(new Record() { ID = 4, text1 = 10, text2 = 20, text3 = 30, text4 = 81 });
            records.Add(new Record() { ID = 5, text1 = 10, text2 = 20, text3 = 1, text4 = 1 });
            records.Add(new Record() { ID = 6, text1 = 10, text2 = 21, text3 = 31, text4 = 41 });
        }

        public IEnumerable<Record> filter(int text1, int text2, int text3, int text4)
        {
            IEnumerable<Record> output;
            if (records.Any(r => FourColumnMatch(r, text1, text2, text3, text4)))
                output = records.Where(r => FourColumnMatch(r, text1, text2, text3, text4));
            else if (records.Any(r => AnyThreeColumnMatch(r, text1, text2, text3, text4)))
                output = records.Where(r => AnyThreeColumnMatch(r, text1, text2, text3, text4));
            else
                output = records.Where(r => AnyTwoColumnMatch(r, text1, text2, text3, text4));

            return output;
        }


        private bool FourColumnMatch(Record r, int text1, int text2, int text3, int text4)
        {
            return r.text1 == text1 && r.text2 == text2 && r.text3 == text3 && r.text4 == text4;
        }

        private bool AnyThreeColumnMatch(Record r, int text1, int text2, int text3, int text4)
        {
            return (r.text1 == text1 && r.text2 == text2 && r.text3 == text3) || (r.text1 == text1 && r.text2 == text2 && r.text4 == text4) || (r.text1 == text1 && r.text3 == text3 && r.text4 == text4)
                                || (r.text2 == text2 && r.text3 == text3 && r.text4 == text4);
        }

        private bool AnyTwoColumnMatch(Record r, int text1, int text2, int text3, int text4)
        {
            return (r.text1 == text1 && r.text2 == text2) ||
                    (r.text1 == text1 && r.text3 == text3) ||
                    (r.text1 == text1 && r.text4 == text4) ||
                    (r.text2 == text2 && r.text3 == text3) ||
                    (r.text2 == text2 && r.text4 == text4) ||
                    (r.text3 == text3 && r.text4 == text4);
        }
    }
}
