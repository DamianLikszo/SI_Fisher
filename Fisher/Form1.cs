using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Fisher
{
    public partial class Form1 : Form
    {
        public int[,] aSystem;
        public string sLog;

        public Form1()
        {
            aSystem = null;
            sLog = "";
            InitializeComponent();
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            int nCols, nRows;
            string sPath = "SystemDecyzyjny.txt";
            string[] aLinie;

            if (File.Exists(sPath))
            {
                aLinie = File.ReadAllLines(sPath);
                nCols = aLinie[0].Split(' ').Length;
                nRows = aLinie.Length;

                this.aSystem = new int[nRows, nCols];

                string[] aLiczby;
                for (int i = 0; i < aLinie.Length; i++)
                {
                    aLiczby = aLinie[i].Split(' ');
                    for (int j = 0; j < aLiczby.Length; j++)
                    {
                        this.aSystem[i, j] = int.Parse(aLiczby[j]);
                    }
                }

                //Odblokowanie
                this.btnLicz.Enabled = true;
                this.rtxtWynik.Visible = true;

                //Wypisanie
                string sSystem = "";

                sSystem += WypiszTablice(this.aSystem);

                this.rtxtSystem.Text = sSystem;
                this.rtxtWynik.Text = "";
            }

            return;
        }

        private string WypiszTablice(int[,] aTab)
        {
            string sRet = "";

            for (int i = 0; i < aTab.GetLength(0); i++)
            {
                for (int j = 0; j < aTab.GetLength(1); j++)
                {
                    sRet += aTab[i, j];

                    if (j != aTab.GetLength(1) - 1)
                        sRet += " ";
                }
                if( i != aTab.GetLength(0) - 1)
                    sRet += "\r\n";
            }

            return sRet;
        }

        private void btnWyjscie_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rtxtSystem_TextChanged(object sender, EventArgs e)
        {
            int nCols, nRows;
            string[] aLinie;

            sLog = "";

            if (rtxtSystem.Text.Length != 0)
            {
                aLinie = this.rtxtSystem.Text.Split("\r\n".ToCharArray());
                nCols = aLinie[0].Split(' ').Length;
                nRows = aLinie.Length;

                this.aSystem = new int[nRows, nCols];

                string[] aLiczby;
                for (int i = 0; i < aLinie.Length; i++)
                {
                    aLiczby = aLinie[i].Split(' ');
                    for (int j = 0; j < aLiczby.Length; j++)
                    {
                        this.aSystem[i, j] = int.Parse(aLiczby[j]);
                    }
                }

                //Odblokowanie
                this.btnLicz.Enabled = true;
                this.rtxtWynik.Visible = true;
            }
            else
            {
                this.btnLicz.Enabled = false;
                this.rtxtWynik.Visible = false;
            }
        }

        private void btnLicz_Click(object sender, EventArgs e)
        {
            this.rtxtWynik.Text = "";
            this.rtxtLogi.Text = "";
            sLog = "";

            // Wyliczanie stopnia separacji
            int i = 0;
            List<int> C, nC;
            List<int> aListaDecyzji = ListaKlasDecyzji();
            Separacja[,] aStopnieSeparacji = new Separacja[aListaDecyzji.Count, this.aSystem.GetLength(1) - 1];
            foreach (int klasa in aListaDecyzji)
            {
                C = new List<int>();          // obiekty majace ta samo decyzje co klasa
                nC = new List<int>();         // obiekty majace rozna decyzje od klasy
                for (int u = 0; u < this.aSystem.GetLength(0); u++)     // row
                {
                    if(this.aSystem[u, this.aSystem.GetLength(1) - 1] == klasa)
                    {
                        C.Add(u);
                    }
                    else
                    {
                        nC.Add(u);
                    }
                }

                double Ck, Cd, ZCk, ZCd;
                double dStopienSeparacji;
                
                for (int a = 0; a < this.aSystem.GetLength(1) - 1; a++)
                {
                    Ck = Cd = ZCk = ZCd = 0;
                    
                    // Ct
                    foreach (int item in C)
                    {
                        Ck += this.aSystem[item, a];
                    }
                    Ck /= (double)C.Count;

                    // Cp
                    foreach (int item in nC)
                    {
                        Cd += this.aSystem[item, a];
                    }
                    Cd /= (double)nC.Count;

                    //ZCt
                    foreach (int item in C)
                    {
                        ZCk += Math.Pow(this.aSystem[item, a] - Ck, 2);
                    }
                    ZCk /= (double)C.Count;

                    //ZCp
                    foreach (int item in nC)
                    {
                        ZCd += Math.Pow(this.aSystem[item, a] - Cd, 2);
                    }
                    ZCd /= (double)nC.Count;

                    dStopienSeparacji = (Math.Pow(Ck - Cd, 2)) / (ZCk + ZCd);

                    sLog += "S^C" + (i+1) + "(a" + (a+1) + ") = " + dStopienSeparacji + "\r\n";

                    aStopnieSeparacji[i, a] = new Separacja(a, dStopienSeparacji, i);
                }   
                i++;
            }

            //Sortowanie
            List<Separacja> aTmp = null;
            for (int k = 0; k < aStopnieSeparacji.GetLength(0); k++)
            {
                aTmp = new List<Separacja>();
                for (int a = 0; a < aStopnieSeparacji.GetLength(1); a++)        //przepisanie do tempa
                {
                    aTmp.Add(aStopnieSeparacji[k, a]);
                }
                aTmp.Sort((x, y) => x.wartosc.CompareTo(y.wartosc));
                aTmp.Reverse();

                for (int a = 0; a < aStopnieSeparacji.GetLength(1); a++)        // przepisanie z tempa
                {
                    aStopnieSeparacji[k, a] = aTmp[a];
                }
            }

            // Logi
            sLog += "\r\n";
            sLog += "Tablica numerów atrybutów najlepiej separujących poszczególne klasy decyzyjne jest postaci:\r\n";
            for (int k = 0; k < aStopnieSeparacji.GetLength(0); k++)
            {
                sLog += "Dla klasy centralnej c" + (k+1) + ": ";
                for (int a = 0; a < aStopnieSeparacji.GetLength(1); a++)
                {
                    sLog += "a" + (aStopnieSeparacji[k,a].argument + 1);
                    if (a != aStopnieSeparacji.GetLength(1) - 1)
                    {
                        sLog += ", ";
                    }
                }
                sLog += "\r\n";
            }

            //procedura
            int atrybuty = 3;
            List<int> Atrybuty = null;
            sLog += "\r\n";
            sLog += "Wybieramy " + atrybuty + " najlepsze atrybuty na podstawie naszej procedury wyboru.\r\n";
            Atrybuty = WybierzAtrybuty(aStopnieSeparacji, atrybuty);

            //Wynik
            string sWynik;
            int[,] aWynik = new int[this.aSystem.GetLength(0), atrybuty + 1];
            for (int u = 0; u < this.aSystem.GetLength(0); u++)
            {
                i = 0;
                for (int a = 0; a < this.aSystem.GetLength(1); a++)
                {
                    if (Atrybuty.Contains(a) || a == this.aSystem.GetLength(1)-1)
                    {
                        aWynik[u, i] = this.aSystem[u, a];
                        i++;
                    }
                }
            }

            sWynik = WypiszTablice(aWynik);

            this.rtxtWynik.Text = sWynik;
            this.rtxtLogi.Text = sLog;
            return;
        }

        private List<int> WybierzAtrybuty(Separacja[,] aStopnieSeparacji, int ile)
        {
            List<int> Aprim = new List<int>();
            int iter = 0;

            for (int a = 0; a < aStopnieSeparacji.GetLength(1); a++)
            {
                for (int k = 0; k < aStopnieSeparacji.GetLength(0); k++)
                {
                    if( !Aprim.Contains(aStopnieSeparacji[k,a].argument))
                    {
                        sLog += "Klasę centralną c" + (k+1) + " najlepiej separuje atrybut a" + (aStopnieSeparacji[k,a].argument + 1) +" - traﬁa on do naszego nowego systemu decyzyjnego \r\n";
                        Aprim.Add(aStopnieSeparacji[k, a].argument);
                        iter++;
                        if (iter == ile)
                            break;
                    }
                    else
                    {
                        sLog += "Klasę centralną c" + (k+1) + " również najlepiej separuje atrybut a" + (aStopnieSeparacji[k,a].argument + 1) + " - jednak mamy już ten atrybut w nowym systemie \r\n";
                    }
                }
                if (iter == ile)
                    break;
            }

            return Aprim;
        }

        private List<int> ListaKlasDecyzji()
        {
            List<int> decyzje = new List<int>();

            for (int row = 0; row < this.aSystem.GetLength(0); row++)
            {
                int decyzja = this.aSystem[row, this.aSystem.GetLength(1) - 1];

                if(!decyzje.Contains(decyzja))
                {
                    decyzje.Add(decyzja);
                }
            }

            decyzje.Sort();

            return decyzje;
        }
    }
}
