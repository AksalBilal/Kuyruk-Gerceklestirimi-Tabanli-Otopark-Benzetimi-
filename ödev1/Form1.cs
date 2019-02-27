using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ödev1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Queue<string> kuyruk = new Queue<string>();//NORMAL SIRALAMA İÇİN KULLANILDI
        Queue<string> kuyruk2 = new Queue<string>();// ÖNCELİKLİ SIRALAMA İÇİN KULLANILDI
        Queue<string> kuyruk3 = new Queue<string>();// ÖNCELİKLİ SIRALAMA DA SÜRE KUYRUĞU İÇİN KULLANILDI
        Queue<string> kuyruk4 = new Queue<string>();// NORMAL SIRALAMA DA SÜRE KUYRUĞU İÇİN KULLANILDI
        int[] sure = new int[10];//NORMAL SIRALAMADAKİ ARAÇLARIN OTOPARKTAKİ TOPLAM SÜRESİNİ TUTAR
        int[] sure2 = new int[10];//ÖNCELİKLİ SIRALAMADAKİ ARAÇLARIN OTOPARKTAKİ TOPLAM SÜRESİNİ TUTAR
        int[] sonuc = new int[10];// NORMAL SIRALAMADAKİ ARACIN ÖNCELİKLİ SIRALAMADAKİ ARAC İLE ARASINDAKİ TOPLAM SÜRE FARKINI TUTAR
        int[] arabalar = new int[10];// NORMAL SIRALAMADAKİ ARACLARI TUTAR
        int[] arabalar2 = new int[10];  // ÖNCELİKLİ SIRALAMADAKİ ARAÇLARI TUTAR    
        int[] numara = new int[10];// NORMAL SIRALAMADAKİ ARACLARIN RANDOM NUMARALARINI TUTAR
        int[] numara2 = new int[10];// SİLME İŞLEMLERİNDEN SONRA LİSTE GÜNCELLENMESİ İÇİN
        int[] numara3 = new int[10];// SİLME İŞLEMLERİNDEN SONRA LİSTE GÜNCELLENMESİ İÇİN
        int[] numara4 = new int[10];// ÖNCELİKLİ SIRALAMADAKİ ARAÇLARIN SIRALI NUMARASINI TUTAR

             
        int[,] karsılastırma = new int[10,10];
        int[,] karsılastırma2 = new int[10,10];
        float ortalamahesapla = 0.2f;
        int gecici, gecici2, sayi1, sayi2;
        float gecici3;
        private void Form1_Load(object sender, EventArgs e)
        {                
            Random rastgele = new Random();
            Random rastgele2 = new Random();
            for (int i = 0; i < 10; i++)
            {
                sayi1= Convert.ToInt32(rastgele.Next(50, 150));
               
                if (arabalar.Contains(sayi1))
                {
                    sayi1= Convert.ToInt32(rastgele.Next(150, 300));
                }
                arabalar[i] = sayi1;
                sayi2 = Convert.ToInt32(rastgele2.Next(10, 50));

                if (numara.Contains(sayi2))
                {sayi2= Convert.ToInt32(rastgele2.Next(50, 100)); }
               
                numara[i] = sayi2;
                numara3[i] = numara[i];
             
            }
            for (int i = 0; i < arabalar2.Length; i++)
            {
                arabalar2[i] = arabalar[i];
                numara4[i] = numara[i];
            }
            for (int i = 0; i < arabalar.Length; i++)
            {
                listKuyruk.Items.Add("" + numara[i] + "  nolu arabanın süresi" + "" + "\t" + arabalar[i]);
            }
        
            for (int i = 0; i < 10; i++)
            {
                for (int t = 0; t < 10; t++)
                {
                    if (arabalar2[t] > arabalar2[i])
                    {

                        gecici = arabalar2[i];

                        arabalar2[i] = arabalar2[t];

                        arabalar2[t] = gecici;

                        gecici2 = numara4[i];

                        numara4[i] = numara4[t];

                        numara4[t] = gecici2;

                    }
                }
            }
     
            for (int i = 0; i < arabalar2.Length; i++)
            {
                ListÖncelikliKuyruk.Items.Add("" + numara4[i] + "  nolu arabanın süresi " + "" + "\t" + arabalar2[i]);
            }
            for (int i = 0; i < arabalar.Length; i++)
            {
                kuyruk.Enqueue(Convert.ToString(arabalar[i]));
                kuyruk2.Enqueue(Convert.ToString(arabalar2[i]));
                kuyruk3.Enqueue(Convert.ToString(numara4[i]));
                kuyruk4.Enqueue(Convert.ToString(numara3[i]));
            }
            for (int i = 0; i < arabalar2.Length; i++)
            {
                if (kuyruk2.Contains(Convert.ToString(arabalar2[i])))
                {
                    numara2[i] = numara[i];
                }            
            }           
            for (int j = 0; j < arabalar.Length; j++)
            {
                if (j == 0)
                {
                    sure[j] = arabalar[j];
                    sure2[j] = arabalar2[j];
                }
                else
                {
                    sure[j] = sure[j - 1] + arabalar[j];
                    sure2[j] = sure2[j - 1] + arabalar2[j];
                }
                if (j == 9)
                {
                    ortalamahesapla = sure[j] / 10;
                    
                }
            }
            for (int i = 0; i < 10; i++)
            {
                karsılastırma[i, 0] = numara4[i];
                karsılastırma[i, 1] = sure[i];
            }
            for (int i = 0; i < 10; i++)
            {
                karsılastırma2[i, 0] = numara[i];
                karsılastırma2[i, 1] = sure2[i];
            }
        } 
        
        private void btnKuyruktanSil_Click(object sender, EventArgs e)
        {
            
            listKuyruk.Items.Clear();
            string isim = kuyruk.Dequeue();
            string isim3 = kuyruk4.Dequeue();           
            string[] Dizi = kuyruk.ToArray();
            string[] Dizi3 = kuyruk4.ToArray();
           
            for (int i = 0; i < Dizi.Length; i++)
            {
               listKuyruk.Items.Add("" +Dizi3[i] + "  nolu arabanın süresi\t " + "" + Dizi[i]);
            }
        }
        private void btnKuyrukSuresi_Click(object sender, EventArgs e)
        {
            listKuyrukSuresi.Items.Clear();
            for (int i = 0; i < sure.Length; i++)
            {               
                listKuyrukSuresi.Items.Add("" + numara3[i] + "  nolu arabanın toplam süresi " + "" + sure[i]);
            }
        }
        private void btnZamanKazancı_Click(object sender, EventArgs e)
        {
            listZamanFarkı.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (numara[i] == numara4[j])
                    {
                        sonuc[i] = karsılastırma[i, 1] - karsılastırma2[j, 1];
                    }
                }  
            }
            for (int i = 0; i < 10; i++)
            {
                gecici3 = sonuc[i] * 100 / sure2[i];
                listZamanFarkı.Items.Add("" + numara3[i] + "  nolu arabanın zaman kazancı  " + "" + Convert.ToString(sonuc[i]) + "  %" + gecici3);

            }
        }
        
        private void btnÖncelikliKuyruktanSil_Click(object sender, EventArgs e)
        {
            ListÖncelikliKuyruk.Items.Clear();
            string isim2 = kuyruk2.Dequeue();
            string isim4 = kuyruk3.Dequeue();
            string[] Dizi2 = kuyruk2.ToArray();
            string[] Dizi4 = kuyruk3.ToArray();
            for (int i = 0; i < Dizi2.Length; i++)
            {
                ListÖncelikliKuyruk.Items.Add("" + Dizi4[i] + "  nolu arabanın süresi\t " + "" + Dizi2[i]);
            }
        }
        private void btnÖncelikliKuyrukSuresi_Click_1(object sender, EventArgs e)
        {
            ListÖncelikliKuyrukSuresi.Items.Clear();
            for (int i = 0; i < sure2.Length; i++)
            {
                ListÖncelikliKuyrukSuresi.Items.Add("" + numara4[i] + "  nolu arabanın toplam süresi  " + "" + sure2[i]);
            }
        }
        private void btnOrtalamaHesapla_Click(object sender, EventArgs e)
        {
            txt1.Text = Convert.ToString(Convert.ToDouble(ortalamahesapla));
            
        }
    }
}
