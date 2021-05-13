using System;
using org.mariuszgromada.math.mxparser; //Dıştan aldığım parser.

namespace ConsoleApp3
{
    //İki formül var o yüzden iki fonkisyon var. Daha kolay yapmak için dıştın class alıyorum.


    public class Formüller
    {
        public static Function Formul1()
        {
            System.Console.WriteLine("Fonksiyonu giriniz");
            string fonksiyon = Console.ReadLine();
            Function f = new Function(fonksiyon);
            System.Console.WriteLine("X'in başlangıç değerini giriniz");
            int a = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("X'in bitiş değerini giriniz");
            int b = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine(f.calculate(1));
            Function g = new Function("g(x) = f(x)*e^(x)", f);
            for (int l = a; l <= b; l++)
            {
                System.Console.WriteLine(g.calculate(l));
                Function s = new Function("s(t) = g(x)*e^(t)", g.calculate(l).ToString());
                //Şurada takılıyor iki sıkıntı var 1) t yi değişken olarak alırsam onu da çözmek istiyor ama t ye değer vermemeiz lazım. 2 Sadece çözülmüş kısmını geri döndürüyor toplama işlemine devam edemiyor. 

            }

          

            return s;

        }


        public static Function Formul2()
        {
            System.Console.WriteLine("Fonksiyonu giriniz");
            string fonksiyon = Console.ReadLine();
            Function f = new Function(fonksiyon);
            System.Console.WriteLine("X'in başlangıç değerini giriniz");
            int a = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("X'in bitiş değerini giriniz");
            int b = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine(f.calculate(1));
            Function g = new Function("g(x,t) = f(x)*e^(x*t)", f);
            Expression e = new Expression("int( g(), x, a, b )");

            return g;

        }

        class Program
        {
            static void Main(string[] args)
            {
                //Sürekli veya süreksiz olmasına göre durumlar farklı.
                System.Console.WriteLine("Fonksiyonun Sürekli veya Kesikli Olduğunu giriniz");
                string tür = Console.ReadLine();
                if (tür == "kesikli")
                {
                    //Almam gerekn değerler fonksiyon ve nerelde sürekli olduğu.Alt tarafta fonksiyon ve Kesikli olduğu yerler.
                    Formüller.Formul1();
                }
                else if (tür == "sürekli")
                {
                    Formüller.Formul2();


                }
                //Bu kısım değiştirilebilir sürekli veya süreksiz olmak zorunda değil. Sürekli için 1 süreksiz için 2 olabilir mesela.
                else
                    System.Console.WriteLine("Lütfen sürekli veya kesikli giriniz");

            }
        }
    }
}