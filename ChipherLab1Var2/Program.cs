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
            
            string message = "перваялабораторнаяработапокиоки";
            string key = "криптография";

            ColumnCipher ciph = new ColumnCipher(message, key);
            ciph.Encrypt();
            Console.WriteLine(ciph.EncryptedMessage);

            ColumnCipher ciphdecrypt = new ColumnCipher(ciph.EncryptedMessage, ciph.Key);
            ciphdecrypt.Decrypt();
            Console.WriteLine(ciphdecrypt.DecryptedMessage);

            Console.WriteLine("END");
            Console.ReadLine();
        }

        
    }
}
