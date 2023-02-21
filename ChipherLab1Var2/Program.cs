using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipherLab1Var2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Convert.ToChar(Convert.ToString(1)));

            ColumnCipher ciph = new ColumnCipher("перваялабораторнаяработапокиоки", "криптография");
            Console.WriteLine(ciph.Encrypt());
            Console.WriteLine("END");
            Console.ReadLine();
        }

        
    }
}
