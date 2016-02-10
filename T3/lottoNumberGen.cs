using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3
{
    class lottoNumberGen
    {
        Random rand = new Random();
        string Return;

        public string generateLotto(int max, int count)
        {
            Stack<int> numbers = new Stack<int>();
            List<int> list = new List<int>();
            Return = "";
            do
            {
                int num = rand.Next(1, max + 1);
                numbers.Push(num);

                count--;
            } while (count > 0);

            list = numbers.ToList();
            list.Sort();
            foreach (int i in list)
            {
                Return += "   " + i;
            }
            return Return;
        }
        public string generateStars()
        {
            Stack<int> numbers = new Stack<int>();
            List<int> list = new List<int>();
            Return = "";
            int num = rand.Next(1, 10 + 1);
            numbers.Push(num);
            num = rand.Next(1, 10 + 1);
            numbers.Push(num);

            list = numbers.ToList();
            list.Sort();
            foreach (int i in list)
            {
                Return += "  *" + i;
            }
            return Return;
        }
    }
}
