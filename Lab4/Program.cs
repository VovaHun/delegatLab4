using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Lab4
{
    //Делегат
    public delegate int LabDelegat(string _text, string _symbol);

    class Program
    {
        //Метод подсчета
        static int Counting(string text, string sumbol)
        {
            string newtext = text;
            int quantity = newtext.Split(new string[] { sumbol }, StringSplitOptions.None).Count() - 1;
            return quantity;
        }
        
        static void Main(string[] args)
        {
            //Ввод переменных
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            Console.WriteLine("Введите 1 символ:");
            string symbol = Console.ReadLine();
            //Инициализация делегата
            LabDelegat ld = Counting;
            //Лямда выражение для вывода результата
            ld.BeginInvoke(text, symbol,ar => {
                if (ar == null) throw new ArgumentException("ar");

                Trace.Assert(ld != null, "Invalid object type");

                int result = ld.EndInvoke(ar);

                Console.WriteLine("Символ входит в строку -> {0} раз(а) ", result);
            }, null);
            
            
            for (int i = 0; i < 100; i++)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }

        }


     
    }
}
