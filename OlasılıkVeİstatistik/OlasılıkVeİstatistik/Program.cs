using System;

namespace OlasılıkVeİstatistik
{
    public class Formüller
    { 
        public static void binomuy()
        {
            double toplam = 0;
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("BİNOM DAĞILIM İLE UYGUNLUK TESTİ");
            Console.WriteLine("--------------------------------------");
            Console.Write("Özellik Sayısı: ");
            int ozellik = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("--------------------------------------");
            Console.Write("Özelliklerin Arasındaki İlişki Sayısı: ");
            int iliski = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("--------------------------------------");
            int serbestlikderecesi = (iliski - 1) * (ozellik - 1);
            int[,] gozlenenfrekans = new int[ozellik, iliski];
            double[,] beklenenfrekans = new double[ozellik, iliski];
            double[] binom = new double[iliski * ozellik];
            int[] satir = new int[iliski];
            int[] sutun = new int[ozellik];


            for (int i = 0; i < ozellik; i++)
            {
                for (int j = 0; j < iliski; j++)
                {
                    Console.Write("Gözlenen Frekans Değerlerini Giriniz: ");
                    gozlenenfrekans[i, j] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    toplam = toplam + gozlenenfrekans[i, j];
                }

            }

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Gözlenen Frekans Tablosu");

            for (int i = 0; i < ozellik; i++)
            {
                for (int j = 0; j < iliski; j++)
                {
                    Console.Write(gozlenenfrekans[i, j] + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Binom Dağılımı Olasılık Hesaplama:");

            for (int z = 0; z < (iliski * ozellik); z++)
            {
                int n, x;
                double p, q;
                Console.Write("n: ");
                n = Convert.ToInt32(Console.ReadLine());
                Console.Write("x: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.Write("p: ");
                p = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                q = (1 - p);

                static double faktoriyel(int i)
                {
                    double sonuc = 1;
                    for (int j = i; j > 1; j--)
                    {
                        sonuc = sonuc * j;

                    }
                    return sonuc;
                }


                binom[z] = ((faktoriyel(n) / faktoriyel(n - x)) / faktoriyel(x)) * (Math.Pow(p, x)) * (Math.Pow(q, (n - x)));
                Console.WriteLine(binom[z]);

            }

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Beklenen Frekans Tablosu");

            for (int i = 0; i < ozellik; i++)
            {
                for (int j = 0; j < iliski; j++)
                {

                    beklenenfrekans[i, j] = binom[i] * toplam;
                    Console.Write(beklenenfrekans[i, j] + " ");
                }
                Console.WriteLine();
            }




            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Ki-Kare Hesabı");

            double kikare = 0;
            for (int i = 0; i < ozellik; i++)
            {
                for (int j = 0; j < iliski; j++)
                {
                    kikare = kikare + Math.Pow((gozlenenfrekans[i, j] - beklenenfrekans[i, j]), 2) / beklenenfrekans[i, j];
                }
            }


            Console.WriteLine("Ki-Kare: " + kikare);
            int kikarekritik;
            Console.Write("Ki-Kare Kritik Değerini Giriniz: ");
            kikarekritik = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            if (kikare > kikarekritik)
            {
                Console.WriteLine("H0 RED EDİLİR");
            }
            else
            {
                Console.WriteLine("H0 RED EDİLEMEZ(BİNOM DAĞILIMIDIR)");
            }
        }

        public static void kikarebag()
        {
            int toplam = 0;
            Console.WriteLine("------------------------------");
            Console.WriteLine(" Kİ-KARE BAĞIMSIZLIK TESTİ ");
            Console.WriteLine("------------------------------");
            //Console.WriteLine("Anlamlılık Düzeyi:");
            //double anlamlilik = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("--------------------------------------");
            Console.Write("Özellik Sayısı: ");
            int ozellik = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("--------------------------------------");
            Console.Write("Özelliklerin Arasındaki İlişki Sayısı: ");
            int iliski = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("--------------------------------------");
            int serbestlikderecesi = (iliski - 1) * (ozellik - 1);
            int[,] gozlenenfrekans = new int[ozellik, iliski];
            int[,] beklenenfrekans = new int[ozellik, iliski];
            int[] satir = new int[iliski];
            int[] sutun = new int[ozellik];


            for (int i = 0; i < ozellik; i++)
            {
                for (int j = 0; j < iliski; j++)
                {
                    Console.Write("Gözlenen Frekans Değerlerini Giriniz: ");
                    gozlenenfrekans[i, j] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    toplam = toplam + gozlenenfrekans[i, j];
                }

            }


            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Gözlenen Frekans Tablosu");

            for (int i = 0; i < ozellik; i++)
            {
                for (int j = 0; j < iliski; j++)
                {
                    Console.Write(gozlenenfrekans[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int m = 0; m < ozellik; m++)
            {
                int sutuntoplam = 0;
                int satirtoplam = 0;
                for (int n = 0; n < iliski; n++)
                {
                    satirtoplam += gozlenenfrekans[m, n];
                    sutuntoplam += gozlenenfrekans[n, m];
                }
                Console.WriteLine("{0}. Satırın Toplamı: {1}   {2}. SütununToplamı: {3}", (m + 1), satirtoplam, (m + 1), sutuntoplam);
                sutun[m] = sutuntoplam;
                satir[m] = satirtoplam;
            }


            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Beklenen Frekans Tablosu");

            for (int i = 0; i < ozellik; i++)
            {
                for (int j = 0; j < iliski; j++)
                {
                    beklenenfrekans[i, j] = (sutun[j] * satir[i]) / toplam;
                    Console.Write(beklenenfrekans[i, j] + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Ki-Kare Hesabı");

            int kikare = 0;
            for (int i = 0; i < ozellik; i++)
            {
                for (int j = 0; j < iliski; j++)
                {
                    kikare = kikare + (int)Math.Pow((gozlenenfrekans[i, j] - beklenenfrekans[i, j]), 2) / beklenenfrekans[i, j];
                }
            }

            Console.WriteLine("Ki-Kare:" + kikare);
            int kikarekritik;
            Console.Write("Ki-Kare Kritik Değerini Giriniz: ");
            kikarekritik = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            if (kikare > kikarekritik)
            {
                Console.WriteLine("H0 RED EDİLİR");
            }
            else
            {
                Console.WriteLine("H0 RED EDİLEMEZ");
            }
        }

        public static void kikarehom()
        {
            int toplam = 0;
            Console.WriteLine("------------------------------");
            Console.WriteLine(" Kİ-KARE HOMOJENLİK TESTİ ");
            Console.WriteLine("------------------------------");
            //Console.WriteLine("Anlamlılık Düzeyi:");
            //double anlamlilik = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("--------------------------------------");
            Console.Write("Özellik Sayısı: ");
            int ozellik = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("--------------------------------------");
            Console.Write("Özellikleri Arasındaki İlişki Sayısı: ");
            int iliski = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("--------------------------------------");
            int serbestlikderecesi = (iliski - 1) * (ozellik - 1);
            int[,] gozlenenfrekans = new int[ozellik, iliski];
            int[,] beklenenfrekans = new int[ozellik, iliski];
            int[] satir = new int[iliski];
            int[] sutun = new int[ozellik];


            for (int i = 0; i < ozellik; i++)
            {
                for (int j = 0; j < iliski; j++)
                {
                    Console.Write("Gözlenen Frekans Değerlerini Giriniz: ");
                    gozlenenfrekans[i, j] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    toplam = toplam + gozlenenfrekans[i, j];
                }

            }


            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Gözlenen Frekans Tablosu");

            for (int i = 0; i < ozellik; i++)
            {
                for (int j = 0; j < iliski; j++)
                {
                    Console.Write(gozlenenfrekans[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int m = 0; m < ozellik; m++)
            {
                int sutuntoplam = 0;
                int satirtoplam = 0;
                for (int n = 0; n < iliski; n++)
                {
                    satirtoplam += gozlenenfrekans[m, n];
                    sutuntoplam += gozlenenfrekans[n, m];
                }
                Console.WriteLine("{0}. Satırın Toplamı: {1}   {2}. SütununToplamı: {3}", (m + 1), satirtoplam, (m + 1), sutuntoplam);
                sutun[m] = sutuntoplam;
                satir[m] = satirtoplam;
            }


            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Beklenen Frekans Tablosu");

            for (int i = 0; i < ozellik; i++)
            {
                for (int j = 0; j < iliski; j++)
                {
                    beklenenfrekans[i, j] = (sutun[j] * satir[i]) / toplam;
                    Console.Write(beklenenfrekans[i, j] + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Ki-Kare Hesabı");

            int kikare = 0;
            for (int i = 0; i < ozellik; i++)
            {
                for (int j = 0; j < iliski; j++)
                {
                    kikare = kikare + (int)Math.Pow((gozlenenfrekans[i, j] - beklenenfrekans[i, j]), 2) / beklenenfrekans[i, j];
                }
            }

            Console.WriteLine("Ki-Kare:" + kikare);
            int kikarekritik;
            Console.Write("Ki-Kare Kritik Değerini Giriniz: ");
            kikarekritik = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            if (kikare > kikarekritik)
            {
                Console.WriteLine("H0 RED EDİLİR");
            }
            else
            {
                Console.WriteLine("H0 RED EDİLEMEZ (HOMOJENDİR)");
            }

        }
        public static void kombinasyon()
        {
            int n, r, kombinasyon, fakt, fakt1, fakt2;
            Console.WriteLine("Kombinasyon hesaplaması için n ve r değerlerini girin..:");
            Console.WriteLine("n değeri ..:");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("r değeri..:");
            r = Convert.ToInt32(Console.ReadLine());
            fakt = n;
            for (int i = n - 1; i >= 1; i--)
            {
                fakt = fakt * i;
            }
            fakt2 = r;
            for (int i = r - 1; i >= 1; i--)
            {
                fakt2 = fakt2 * i;
            }
            int number;
            number = n - r;
            fakt1 = number;
            for (int i = number - 1; i >= 1; i--)
            {
                fakt1 = fakt1 * i;
            }
            fakt1 = fakt2 * fakt1;
            kombinasyon = fakt / fakt1;
            Console.WriteLine("Kombinasyon : " + kombinasyon);
        }

        public static void faktoriyel()
        {
            int sayi, i, f = 1;
            Console.WriteLine("Faktoriyeli alınacak sayı girin");
            sayi = Convert.ToInt16(Console.ReadLine());
            for (i = 1; i <= sayi; i++)
            {

                f = i * f;

            }
            Console.WriteLine("Cevap : " + f);
        }

        public static void permutasyon()
        {
            int n, r, per, fakt, fakt1;
            Console.WriteLine("Permütasyon hesaplaması için n ve r değerlerini girin..:");
            Console.WriteLine("n değeri ..:");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("r değeri..:");
            r = Convert.ToInt32(Console.ReadLine());
            fakt = n;
            for (int i = n - 1; i >= 1; i--)
            {
                fakt = fakt * i;
            }
            int number;
            number = n - r;
            fakt1 = number;
            for (int i = number - 1; i >= 1; i--)
            {
                fakt1 = fakt1 * i;
            }
            per = fakt / fakt1;
            Console.WriteLine("Permütasyon : " + per);
        }

        public static void duzgun_dagilim()
        {

            double beklenen_deger, varyans, fx_degeri, x, a, b; ;
            Console.WriteLine("Duzgun dagilimin hesaplanacagi sabit a ve b değerlerini ve x degerini girin..:");
            Console.WriteLine("a değeri ..:");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("b değeri..:");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("x değeri..:");
            x = Convert.ToDouble(Console.ReadLine());

            if (x < a)
            {
                fx_degeri = 0d;
                Console.WriteLine("F(x) degeri: " + fx_degeri);
            }
            else if (x >= a && x <= b)
            {
                fx_degeri = (x - a) / (b - a);
                Console.WriteLine("F(x) degeri: " + fx_degeri);
            }
            else
            {
                fx_degeri = 1d;
                Console.WriteLine("F(x) degeri: " + fx_degeri);
            }

            beklenen_deger = (a + b) / 2d;
            varyans = Math.Pow((b - a), 2) / 12d;
            Console.WriteLine("Beklenen deger: " + beklenen_deger);
            Console.WriteLine("Varyans: " + varyans);

        }


        public static void geometrik_dagilim()
        {
            // geometrik dagilimda verilen olasilik degerin kacinci deneyde ortaya cikma htimalini verir.
            double olasi_deger, beklenen_deger, varyans;
            Console.WriteLine("Geometrik dagilimin hesaplanacagi degeri girin( virgul kullanimina dikkat ediniz )..:");
            Console.WriteLine(" Deger:  ..:");
            olasi_deger = Convert.ToDouble(Console.ReadLine());

            beklenen_deger = 1 / olasi_deger;
            varyans = (1 - olasi_deger) / Math.Pow(olasi_deger, 2);
            Console.WriteLine("Beklenen deger: " + beklenen_deger);
            Console.WriteLine("Varyans: " + varyans);
        }


        public static void binom_dagilim()
        {
            double n, r, kombinasyon, fakt, fakt1, fakt2, olasi_deger, binom, beklenen_deger, varyans;
            Console.WriteLine("Binomun dagiliminin hesaplaması için n(deney sayisi), r(basari sayisi) ve olasilik değerlerini girin..:");
            Console.WriteLine("n değeri ..:");
            n = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("r değeri..:");
            r = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("olasilik değeri..:");
            olasi_deger = Convert.ToDouble(Console.ReadLine());
            fakt = n;
            for (double i = n - 1; i >= 1; i--)
            {
                fakt = fakt * i;
            }
            fakt2 = r;
            for (double i = r - 1; i >= 1; i--)
            {
                fakt2 = fakt2 * i;
            }
            double number;
            number = n - r;
            fakt1 = number;
            for (double i = number - 1; i >= 1; i--)
            {
                fakt1 = fakt1 * i;
            }
            fakt1 = fakt2 * fakt1;
            kombinasyon = fakt / fakt1;

            binom = kombinasyon * Math.Pow(olasi_deger, r) * Math.Pow((1 - olasi_deger), (n - r));

            beklenen_deger = olasi_deger;
            varyans = olasi_deger * (1 - olasi_deger) / n;
            Console.WriteLine("Beklenen deger: " + beklenen_deger);
            Console.WriteLine("Varyans: " + varyans);
            Console.WriteLine("Binom: " + binom);


        }


        public static void pascal_dagilim()
        {
            double deney_sayisi, basari_sayisi, olasi_deger, beklenen_deger, varyans;
            Console.WriteLine("Negatif binom dagilimin hesaplanmasi icin x(deney sayisi),k(basari sayisi) ve olasilik degerlerini girin( virgul kullanimina dikkat ediniz )..:");
            Console.WriteLine(" x:  ..:");
            deney_sayisi = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(" k:  ..:");
            basari_sayisi = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(" Deger:  ..:");
            olasi_deger = Convert.ToDouble(Console.ReadLine());

            beklenen_deger = basari_sayisi / olasi_deger;
            varyans = basari_sayisi * (1 - olasi_deger) / Math.Pow(olasi_deger, 2);
            Console.WriteLine("Beklenen deger: " + beklenen_deger);
            Console.WriteLine("Varyans: " + varyans);


        }

        public static void binom()
        {
            int n, x;
            double p, q, binom;
            Console.Write("n: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("x: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("p: ");
            p = Convert.ToDouble(Console.ReadLine());
            q = (1 - p);


            static double faktoriyel(int i)
            {
                double sonuc = 1;
                for (int j = i; j > 1; j--)
                {
                    sonuc = sonuc * j;
                    Console.WriteLine(sonuc);

                }
                return sonuc;
            }


            binom = ((faktoriyel(n) / faktoriyel(n - x)) / faktoriyel(x)) * (Math.Pow(p, x)) * (Math.Pow(q, (n - x)));

            Console.WriteLine("Binom Dağılımı Olasılık Sonucu: " + binom);
            Console.WriteLine();

        }



        static double faktoriyel(int i)
        {
            double sonuc = 1;
            for (int j = i; j > 1; j--)
            {
                sonuc = sonuc * j;
                Console.WriteLine(sonuc);

            }
            return sonuc;
        }


        public static void rasvar()
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
        public static void binomol()
        {
            int n, x;
            double p, q, binom;
            Console.Write("n: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("x: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("p: ");
            p = Convert.ToDouble(Console.ReadLine());
            q = (1 - p);

            static double faktoriyel(int i)
            {
                double sonuc = 1;
                for (int j = i; j > 1; j--)
                {
                    sonuc = sonuc * j;
                    Console.WriteLine(sonuc);

                }
                return sonuc;
            }


            binom = ((faktoriyel(n) / faktoriyel(n - x)) / faktoriyel(x)) * (Math.Pow(p, x)) * (Math.Pow(q, (n - x)));

            Console.WriteLine("Binom Dağılımı Olasılık Sonucu: " + binom);
            Console.WriteLine();
        }

        public static void aritmetikort()
        {
            double toplam = 0, ortalama = 0;
            Console.Write("Kaç elemanlı dizi oluşturulsun :");
            int n = Int32.Parse(Console.ReadLine());
            double[] dizi = new double[n];
            for (int i = 0; i < dizi.Length; i++)
            {
                Console.Write("Sayı {0}: ", i + 1);
                dizi[i] = Convert.ToDouble(Console.ReadLine());
                toplam += dizi[i];
            }
            ortalama = toplam / dizi.Length;
            Console.WriteLine("Toplam : " + toplam);
            Console.WriteLine("Ortalama : " + ortalama);
        }

        public static void geometrikort()
        {
            Console.Write("Kaç elemanlı dizi oluşturulsun :");
            int n = Int32.Parse(Console.ReadLine());
            double[] dizi = new double[n];
            for (int i = 0; i < dizi.Length; i++)
            {
                Console.Write("Sayı {0}: ", i + 1);
                dizi[i] = Convert.ToDouble(Console.ReadLine());
            }
            double carpim = 1;
            for (int i = 0; i < dizi.Length; i++)
                carpim *= dizi[i];
            double geometrikOrtalama = Math.Pow(carpim, 1.0 / dizi.Length);
            Console.WriteLine(geometrikOrtalama);
        }

        public static void harmonikort()
        {
            Console.Write("Kaç elemanlı dizi oluşturulsun :");
            int n = Int32.Parse(Console.ReadLine());
            double[] dizi = new double[n];
            for (int i = 0; i < dizi.Length; i++)
            {
                Console.Write("Sayı {0}: ", i + 1);
                dizi[i] = Convert.ToDouble(Console.ReadLine());
            }
            double toplam = 0.0;
            for (int i = 0; i < dizi.Length; i++)
                toplam += 1.0 / dizi[i];
            double harmonikOrtalama = (double)dizi.Length / toplam;
            Console.WriteLine(harmonikOrtalama);

        }
        class Program
        {
            static void Main(string[] args)
            {
                int a=50;
                while (a != 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Çıkmak için 0");
                    Console.WriteLine("Binom Uygunluk testi için 1");
                    Console.WriteLine("Ki-kare bagımsızlık testi için için 2");
                    Console.WriteLine("Ki-kare homojenlik tesi  için 3");
                    Console.WriteLine("Kombinasyon için 4");
                    Console.WriteLine("Faktöriyel için 5");
                    Console.WriteLine("Permütasyon için 6");
                    Console.WriteLine("Düzgün dağılım için 7");
                    Console.WriteLine("Geometrik dağılımı için 8");
                    Console.WriteLine("Binom dağılımı için 9");
                    Console.WriteLine("Pascal dağılımı için 10");
                    Console.WriteLine("Binom için 11");
                    Console.WriteLine("Kesikli rastgele değişken varyansı için 12");
                    Console.WriteLine("Binom olasılık için 13");
                    Console.WriteLine("Aritmetik ortalama için 14");
                    Console.WriteLine("Geometrik ortalama için 15");
                    Console.WriteLine("Harmonik ortalama için 16");
                    Console.WriteLine("Giriniz");
                    a = Convert.ToInt32(Console.ReadLine());
                    switch (a)
                    {
                        case 0:
                            Console.WriteLine("Çıkış yapıyorsunuz");
                            break;
                        case 1:
                            Formüller.binomuy();
                            break;
                        case 2:
                            Formüller.kikarebag();
                            break;
                        case 3:
                            Formüller.kikarehom();
                            break;
                        case 4:
                            Formüller.kombinasyon();
                            break;
                        case 5:
                            Formüller.faktoriyel();
                            break;
                        case 6:
                            Formüller.permutasyon();
                            break;
                        case 7:
                            Formüller.duzgun_dagilim();
                            break;
                        case 8:
                            Formüller.geometrik_dagilim();
                            break;
                        case 9:
                            Formüller.binom_dagilim();
                            break;
                        case 10:
                            Formüller.pascal_dagilim();
                            break;
                        case 11:
                            Formüller.binom();
                            break;
                        case 12:
                            Formüller.rasvar();
                            break;
                        case 13:
                            Formüller.binomol();
                            break;
                        case 14:
                            Formüller.aritmetikort();
                            break;
                        case 15:
                            Formüller.geometrikort();
                            break;
                        case 16:
                            Formüller.harmonikort();
                            break;
                        default:
                            Console.WriteLine("Olmayan bir değer girdiniz");
                            break;
                    }
                }
            }
            }
        }
    }



