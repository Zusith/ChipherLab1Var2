using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipherLab1Var2
{
    class ElGamalCipher : Cipher
    {
        Hashtable keyopen = new Hashtable();
        int keysecret = 0;
        int maxprimenum;
        List<int> primesnumlist;

        public ElGamalCipher(string message = "", int maxprimenum = 6000)
            : base(message) 
        {
            this.maxprimenum = maxprimenum;
            primesnumlist = SieveEratosthenes(this.maxprimenum);
        }
       

        public int KeySecret
        {
           get { return keysecret; }
        }

        public Hashtable Keyopen
        {
            get { return keyopen; }
        }

        public void KeyGeneration() 
        {
            Random rnd = new Random();
            int p = 0;

            int rndindex = rnd.Next(0, primesnumlist.Count);
            p = primesnumlist[rndindex];
            
            int g = 0;

            //g = (int)Math.Pow(1 % p, 1 / (p - 1));

            bool check = true;
            Console.WriteLine(check);
            while (check)
            {
                check = true;
                g = 1;
                Console.WriteLine(g);
                if (Math.Pow(g, p - 1) == 1 % p)
                {
                    Console.WriteLine("+");
                    for (int k = 1; k <= p - 2; k++)
                    {
                        if (Math.Pow(g, k) == 1 % p)
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check)
                    {
                        break;
                    }
                }
            }
            
            int x = rnd.Next(2, p - 1);

            int y = (int)Math.Pow(g, x) % p;

            keyopen.Add("p", p);
            keyopen.Add("g", g);
            keyopen.Add("y", y);

            keysecret = x;
        }

        private List<int> SieveEratosthenes(int n) //генерация списка простых чисел в диапозоне от 2 до n
        {
            var numbers = new List<int>();
            //заполнение списка числами от 2 до n-1
            for (int i = 2; i < n; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 2; j < n; j++)
                {
                    //удаляем кратные числа из списка
                    numbers.Remove(numbers[i] * j);
                }
            }
            return numbers;
        }
        
        public static bool IsCoprime(int num1, int num2)
        {
            if (num1 == num2)
            {
                return num1 == 1;
            }
            else
            {
                if (num1 > num2)
                {
                    return IsCoprime(num1 - num2, num2);
                }
                else
                {
                    return IsCoprime(num2 - num1, num1);
                }
            }
        }

        public override string Encrypt()
        {
            Random rnd = new Random();

            EncryptedMessage = "";

            int a = 0, b = 0;
            for (int cell = 0; cell < Message.Length; cell++)
            {
                int k = 0, p = (int)keyopen["p"], g = (int)keyopen["g"], y = (int)keyopen["y"];
                while (true)
                {
                    k = rnd.Next(2, p - 1);
                    if (IsCoprime(k, p - 1))
                    {
                        break;
                    }
                }

                a = (int)Math.Pow(g, k) % p;
                b = ((int)Math.Pow(y, k) * Convert.ToInt32(Message[cell])) % p;
                EncryptedMessage += a + " " + b + ";";
            }
            return EncryptedMessage;
        }

        public override string Decrypt()
        {
            throw new NotImplementedException();
        }
    }
}
