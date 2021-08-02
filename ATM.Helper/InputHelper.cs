using System;

namespace ATM.Helper
{
    public class InputHelper
    {
        public static int GetNumberInputWithSecureString()
        {
            string pwd = "";
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.Remove(pwd.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd = pwd + i.KeyChar;
                    Console.Write("*");
                }
            }
            int number = 0;
            if (int.TryParse(pwd, out number))
                return number;
            else
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Invalid number.");
                Console.WriteLine("Enter the number again");
                GetNumberInputWithSecureString();
            }
            return 0;
        }

        public static float GetFloatNumber()
        {
            float fNumber = 0;
            string number = Console.ReadLine();

            if (float.TryParse(number, out fNumber))
                return fNumber;
            else
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Invalid number.");
                Console.WriteLine("Enter the number again");
                return GetFloatNumber();
            }
        }
    }
}
