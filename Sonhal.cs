using System;

namespace ConsoleApp3
{
    public class Formüller
    {
        public static void rasvar()//Kesikli Rastgele değişken varyans
        {
            System.Console.WriteLine("Kaç veri olacğını giriniz");
            int say = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Olasılıklarını girniz. Nokta değil virigül kullanınız");
            double i;
            double[] asd = new double[say];
            int p = 0;
            do
            {
                i = Convert.ToDouble(Console.ReadLine());
                asd[p] = i;
                p++;
            }
            while (p <= (say - 1));
            System.Console.WriteLine("Değerleri girniz.");
            double[] asf = new double[say];
            p = 0;
            do
            {
                i = Convert.ToDouble(Console.ReadLine());
                asf[p] = i;
                p++;
            }
            while (p <= (say - 1));
            double deg1 = 0;
            for (int m = 0; m <= (say - 1); m++)
            {

                deg1 += asd[m] * asf[m];


            }
            System.Console.WriteLine(deg1);

            double deg2 = 0;
            for (int m = 0; m <= (say - 1); m++)
            {

                deg2 += (asf[m] * asf[m]) * asd[m];


            }
            System.Console.WriteLine(deg2);

            double deg3 = deg2 - deg1 * deg1;
            System.Console.WriteLine(deg3);

        }


        public static void bagtest()//Ki kare bağımsızlık Testi
        {
            System.Console.WriteLine("Bu fonksiyon 2x2 Tablolar için hazırlanmıştır.");

            int say = 2;
            System.Console.WriteLine("Alpha değerini giriniz.");
            double alpha= Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("Birinci Satırı giriniz.");
            int i;
            int[] asd = new int[say];
            int p = 0;
            do
            {
                i = Convert.ToInt32(Console.ReadLine());
                asd[p] = i;
                p++;
            }
            while (p <= (say - 1));

            System.Console.WriteLine("İkinci Satırı giriniz");
            int[] asf = new int[say];
            p = 0;
            do
            {
                i = Convert.ToInt32(Console.ReadLine());
                asf[p] = i;
                p++;
            }
            while (p <= (say - 1));
            //Burdan sonrasını tek tek yazmadan yapabilmenin bir yolu olduğuna eminim. Şu anda yazmak daha hızlı geliyor.
            int[] dizi = new int[5];
            dizi[0] = asd[0] + asd[1];
            dizi[1] = asf[0] + asf[1]; 
            dizi[2] = dizi[0] + dizi[1];
            dizi[3] = asd[0] + asf[0]; 
            dizi[4] = asd[1] + asf[1];
            double d1 =((double)dizi[3]* (double)dizi[0])/((double)dizi[2]);
            double d2 = ((double)dizi[3] * (double)dizi[1]) / ((double)dizi[2]);
            double d3 = ((double)dizi[4] * (double)dizi[0]) / ((double)dizi[2]);
            double d4 = ((double)dizi[4] * (double)dizi[1]) / ((double)dizi[2]);
            double d5 = (Math.Pow(asd[0] - d1, 2) ) / (d1);
            double d6 = (Math.Pow(asd[1] - d2, 2) ) / (d2);
            double d7 = (Math.Pow(asf[0] - d3, 2) ) / (d3);
            double d8 = (Math.Pow(asf[1] - d4, 2) ) / (d4);
            double d9 = d5 + d6 + d7 + d8;
            System.Console.WriteLine(d9);
            System.Console.WriteLine(alpha);
            double qwe= 1.000;
            double d10= MathNet.Numerics.Distributions.ChiSquared.InvCDF(qwe , alpha);
            System.Console.WriteLine(d10);






        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(MathNet.Numerics.Distributions.ChiSquared.InvCDF(1,0.01));
            System.Console.WriteLine(MathNet.Numerics.Distributions.ChiSquared.CDF(1, 0.01));
            System.Console.WriteLine(MathNet.Numerics.Distributions.ChiSquared.InvCDF(0.01, 1));
            System.Console.WriteLine(MathNet.Numerics.Distributions.ChiSquared.CDF(0.01, 1));

        }
    }
}
    