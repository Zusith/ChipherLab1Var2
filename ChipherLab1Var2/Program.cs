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
            #region ColumnCipher test

            //string message = "первая лабораторная работа по киоки!";
            //string key = "криптография";

            //Console.WriteLine("Столбцовый метод");
            //Console.WriteLine("Начальное: " + message);
            //ColumnCipher ciph = new ColumnCipher(message, key);
            //ciph.Encrypt();
            //Console.WriteLine("Зашифрованное: " + ciph.EncryptedMessage);

            //ColumnCipher ciphdecrypt = new ColumnCipher(ciph.EncryptedMessage, ciph.Key);
            //ciphdecrypt.Decrypt();
            //Console.WriteLine("Расшифрованное: " + ciphdecrypt.DecryptedMessage);

            #endregion

            #region CesarCipher test

            //Console.WriteLine("----------------------------------------------------------------");
            //Console.WriteLine("метод Цезаря");

            ////message = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя!";
            //message = "курица! привет";
            //int keycesar = 3;

            //Console.WriteLine("Начальное: " + message);
            //CesarCipher cesciph = new CesarCipher(message, keycesar);
            //cesciph.Encrypt();
            //Console.WriteLine("Зашифрованное: " + cesciph.EncryptedMessage);

            //CesarCipher cesciph2 = new CesarCipher(cesciph.EncryptedMessage, cesciph.Key);
            //cesciph2.Decrypt();
            //Console.WriteLine("Расшифрованное: " + cesciph2.DecryptedMessage);

            //Console.WriteLine();
            //Console.WriteLine("END");

            #endregion

            #region ElGamalCipher test

            string messageElGamal = "azx";
            ElGamalCipher ch = new ElGamalCipher(messageElGamal);
            ch.KeyGeneration();
            Console.WriteLine("Ключ сгенерирован");
            
            Console.WriteLine("Секретный ключ: " + ch.KeySecret);
            Console.WriteLine($"Открытый ключ: p = {ch.Keyopen["p"]}; g = {ch.Keyopen["g"]}; y = {ch.Keyopen["y"]}" );
            Console.WriteLine("Зашифрованное сообщение: " + ch.Encrypt());

            #endregion

            Console.ReadLine();

            
        }
    }
}
