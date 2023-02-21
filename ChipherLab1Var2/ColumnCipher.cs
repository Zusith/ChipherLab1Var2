using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipherLab1Var2
{
    public class ColumnCipher
    {
        string Message;
        string Key;
        string encryptedmessage;

        public ColumnCipher(string message, string key)
        {
            Message = message;
            Key = key;
        }

        public string Encrypt()
        {
            int rowscount = 0;
            rowscount = (int)Math.Ceiling((double)Message.Length / (double)Key.Length);
 
            string[,] ciphertable = new string[2 + rowscount, Key.Length];

            for (int column = 0; column < ciphertable.GetLength(1); column++)
            {
                ciphertable[0, column] = Convert.ToString(Key[column]);
            }

            int countletterkey = 1;
            for (int letter = 'а'; letter < 'я'; letter++)
            {
                for (int column = 0; column < ciphertable.GetLength(1); column++)
                {
                    if (Key[column] == letter)
                    {
                        
                        ciphertable[1, column] = Convert.ToString(countletterkey);
                        countletterkey++;
                    }
                }
            }
            ciphertable[1, ciphertable.GetLength(1) - 1] = Convert.ToString(countletterkey);

            int countlettermess = 0;
            bool checkletters = false;
            for (int row = 2; row < ciphertable.GetLength(0); row++)
            {
                for (int column = 0; column < ciphertable.GetLength(1); column++)
                {
                    if (countlettermess == Message.Length)
                    {
                        checkletters = true;
                        break;
                    }
                    ciphertable[row, column] = Convert.ToString(Message[countlettermess]);
                    countlettermess++;
                }
                if (checkletters)
                {
                    break;
                }
            }

            encryptedmessage = "";
            
            for (int countnumbers = 1; countnumbers != countletterkey + 1; countnumbers++)
            {
                for (int column = 0; column < ciphertable.GetLength(1); column++)
                {
                    if (ciphertable[1, column] == Convert.ToString(countnumbers))
                    {
                        for (int row = 2; row < ciphertable.GetLength(0); row++)
                        {
                            if (ciphertable[row, column] != " ")
                            {
                                encryptedmessage += ciphertable[row, column];
                            }
                        }
                        break;
                    }
                }
            }
            
            return encryptedmessage;
        }
    }
}
