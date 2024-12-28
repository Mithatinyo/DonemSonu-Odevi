namespace DonemSonu_Odevi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string formatHata = "Lütfen sadece sayıyı uygun formatta giriniz";
            string OverflowHata = "Girilen sayı değeri tanımlanamadı";
            string notDegeriHata = "Notu 0-100 aralığında girmelisiniz";

            double vizeNotu = 0;//double kullanma sebebim küsüratlı değerleri intle girememek.
            double finalNotu = 0;
            double notOrtalama = 0;

            double sinifNotOrtalama = 0;
            double enKucuk = 0;
            double enBuyuk = 0;

            string[] tabloBaslik = new string[] //Metin  olduğu için string yazılıyor
            {
                    "Numara",       //dizinin elemanlarını sırasıyla sisteme tanımlıyoruz.
                    "Ad",
                    "Soyad",
                    "Vize Notu",
                    "Final Notu",
                    "Ortalama",
                    "Harf Notu"
            };

            try        //Sayı verileri girilen kod bloklarındaki harf veya başka bir cisim yazılması durumunda hatayı manuel olarak yakalamak için kullanılır.
            {
                Console.Write("Kaç öğrenci kaydetmek istiyorsunuz: ");
                int ogrenciSayisi = Convert.ToInt32(Console.ReadLine());// girilen sayı değerini inte çevirir.


                double[] ortalamaToplam = new double[ogrenciSayisi];



                string[,] dizi = new string[ogrenciSayisi + 1, tabloBaslik.Length];

                for (int i = 0; i < tabloBaslik.Length; i++) //length dizide kaç eleman varsa hepsini kapsar.
                {
                    dizi[0, i] = tabloBaslik[i];
                }


                for (int i = 0; i < ogrenciSayisi; i++) //parse kullanıcıdan aldığın değeri sayıya çevirmek için kullanılır.
                {
                    Console.Write($"{i + 1}. Öğrencinin Numarasını Giriniz: ");
                    dizi[i + 1, 0] = int.Parse(Console.ReadLine()).ToString();//Kullanıcının girdiği bilgiyi önce sayıya çeviriyo ondan sonra metne çevirip diziye aktarır.
                    Console.Write($"{i + 1}. Öğrencinin Adını Giriniz: ");
                    dizi[i + 1, 1] = Console.ReadLine().Trim();// trim gereksiz boşlukları siler

                    Console.Write($"{i + 1}. Öğrencinin Soyadını Giriniz: ");// Dolar işareti süslü parantez içindeki değerleri metin olarak tanımlamak için kullanılır.
                    dizi[i + 1, 2] = Console.ReadLine().Trim();//sıfırıncı öğrenci numarası girmesin ve direkt birden başlasın amacıyla kullandım.

                    while (true) //not 100den büyük veya sıfırdan küçükse hata verdikten sonra soruyu tekrar sorması için kullanılır.
                    {
                        try
                        {
                            Console.Write($"{i + 1}. Öğrencinin Vize Notunu Giriniz: ");
                            dizi[i + 1, 3] = Console.ReadLine();
                            vizeNotu = Convert.ToDouble(dizi[i + 1, 3]);//küsuratlı çıkarsa diye double a tanımladım.

                            if (vizeNotu > 100 || vizeNotu < 0) // iki tane dik çizgi ya da anlamına gelir 
                            {
                                Console.WriteLine(notDegeriHata);
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (FormatException) //Sayı yerine metin harfleri girilirse yakalamada kullanılır.
                        {
                            Console.WriteLine(formatHata);
                        }
                        catch (Exception hata) //Hiçbir hatayı uygulama yakalayamaz. Bu sadece hatayı düzeltmek adına geri bildirim almak için kullanılır.
                        {
                            Console.WriteLine($"Beklenmeyen bir hata oluştu: {hata.Message}");
                        }
                    }

                    while (true)
                    {
                        try
                        {
                            Console.Write($"{i + 1}. Öğrencinin Final Notunu Giriniz: ");
                            dizi[i + 1, 4] = Console.ReadLine();
                            finalNotu = Convert.ToDouble(dizi[i + 1, 4]);

                            if (finalNotu > 100 || finalNotu < 0)
                            {
                                Console.WriteLine(notDegeriHata);
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (FormatException) 
                        {
                            Console.WriteLine(formatHata);
                        }
                        catch (Exception hata)
                        {
                            Console.WriteLine($"Beklenmeyen bir hata oluştu: {hata.Message}");
                        }
                    }

                    notOrtalama = vizeNotu * 0.40 + finalNotu * 0.60;
                    dizi[i + 1, 5] = notOrtalama.ToString();//diziye aktarmak için stringi kullandık ama not ortalaması double olarak kaldı.
                    ortalamaToplam[i] = notOrtalama; //ortalamatoplam dizisinin elemanlarını not ortalamaya aktardım.

                    if (notOrtalama >= 85) { dizi[i + 1, 6] = "AA"; }
                    else if (notOrtalama >= 75) { dizi[i + 1, 6] = "BA"; }
                    else if (notOrtalama >= 60) { dizi[i + 1, 6] = "BB"; }
                    else if (notOrtalama >= 50) { dizi[i + 1, 6] = "CB"; }
                    else if (notOrtalama >= 40) { dizi[i + 1, 6] = "CC"; }
                    else if (notOrtalama >= 30) { dizi[i + 1, 6] = "DC"; }
                    else if (notOrtalama >= 20) { dizi[i + 1, 6] = "DD"; }
                    else if (notOrtalama >= 10) { dizi[i + 1, 6] = "FD"; }
                    else { dizi[i + 1, 6] = "FF"; }

                    Console.WriteLine(" ");// diğer öğrenciye geçerken alt satıra geçmesi için kısayol.
                }
                //linq metodu denir  //dizilerde çalışır
                enKucuk = ortalamaToplam.Min();//bu dizideki en küçük değişkeni aktarıyosun
                enBuyuk = ortalamaToplam.Max();// en büyük değişkeni aktarıyosun
                sinifNotOrtalama = ortalamaToplam.Average();//tüm elemanları toplayıp ortalamaya bölüm averajını alıyosun.

                for (int i = 0; i < ogrenciSayisi + 1; i++) // Sıfırdan öğrenci sayısına kadar devam edilir.

                {
                    for (int j = 0; j < tabloBaslik.Length; j++)
                    {
                        Console.Write(dizi[i, j] + " ");// ad soyad- notlar vs arası boşluk bırakmak için.
                    }
                    Console.WriteLine(" ");//alt satır geçişi
                }

                Console.WriteLine($"\nSınıf Ortalaması: {sinifNotOrtalama}\nEn Düşük Not: {enKucuk}\nEn Yüksek Not: {enBuyuk}");
            }
            catch (FormatException)
            {
                Console.WriteLine(formatHata);
            }
            catch (OverflowException) //int byte double gibi değerlerin sınırını geçersen bu hatayı verir.
            {
                Console.WriteLine(OverflowHata);
            }
            catch (Exception hata)
            {
                Console.WriteLine($"Beklenmeyen bir hata oluştu: {hata.Message}");
            }
        }
    }
}
