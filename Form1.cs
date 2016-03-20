using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private static int elemety_tab1 = 100;
        private static int elemety_tab2 = 100;
        private int[] tab = new int[elemety_tab1];
        private int[] tab2 = new int[elemety_tab2];
        private int[] tab3 = new int[1001];
        public Form1()
        {
            InitializeComponent();
            this.Text = "Losowanie, sortowanie, obliczanie.";
            this.BackColor = Color.LightGoldenrodYellow;
            label1.Text = "Witaj w naszej aplikacji okienkowej!";
            label2.Text = "Wylosowane i posortowane liczby:";
            label3.Text = "Pola wybranej figury:";
            comboBox1.Text = "Obliczanie pól";
            comboBox1.Items.Add("Trójkąt");
            comboBox1.Items.Add("Kwadrat");
            comboBox1.Items.Add("Koło");
            button1.Text = "Losowanie";
            button2.Text = "Sortowanie";
        }
        
      
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                chart1.Series.Clear();
                chart1.Series.Add("Value");
                tab = Form1.losowanie(elemety_tab1);
                textBox1.Clear();
                for (int i = 0; i < tab.Length; i++)
                {
                    textBox1.AppendText(tab[i] + ", ");
                    this.chart1.Series["Value"].Points.AddY(tab[i]);
                }
            }
            if (checkBox2.Checked)
            {
                chart1.Series.Clear();
                chart1.Series.Add("Value");
                tab2 = Form1.losowanie(elemety_tab2);
                textBox3.Clear();
                for (int i = 0; i < tab2.Length; i++)
                {
                    textBox3.AppendText(tab2[i] + ", ");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                chart2.Series.Clear();
                chart2.Series.Add("Value");
                Array.Sort(tab);
                textBox1.Clear();
                for (int i = 0; i < tab.Length; i++)
                {
                    textBox1.AppendText(tab[i] + ", ");
                    this.chart2.Series["Value"].Points.AddY(tab[i]);
                }
            }
            if (checkBox2.Checked)
            {
                Array.Sort(tab2);
                textBox3.Clear();
                for (int i = 0; i < tab2.Length; i++)
                {
                    textBox3.AppendText(tab2[i] + ", ");
                }
            }

            if (checkBox1.Checked && checkBox2.Checked)
            {
                chart3.Series.Clear();
                chart3.Series.Add("histogram");

                Array.Clear(tab3, 0, 1001);
                porownanie(tab, tab3, tab2);


                for (int j = 0; j < tab3.Length; j++)
                {
                    this.chart3.Series["histogram"].Points.AddY(tab3[j]);
                }
            }
            else if(checkBox1.Checked && !checkBox2.Checked)
            {
                chart3.Series.Clear();
                chart3.Series.Add("histogram");

                Array.Clear(tab3, 0, 1001);
                histogram(tab, tab3);


                for (int j = 0; j < tab3.Length; j++)
                {
                    this.chart3.Series["histogram"].Points.AddY(tab3[j]);
                }
            }
            else if (!checkBox1.Checked && checkBox2.Checked)
            {
                chart3.Series.Clear();
                chart3.Series.Add("histogram");

                Array.Clear(tab3, 0, 1001);
                histogram(tab2, tab3);


                for (int j = 0; j < tab3.Length; j++)
                {
                    this.chart3.Series["histogram"].Points.AddY(tab3[j]);
                }
            }

        }

        private static String tablicaToString(int[] tab)
        {
            String result = "";
            for (int i = 0; i < tab.Length; i++)
            {
                result += tab[i] + ", ";
            }
            return result;
        }
        private static String tablicaToString2(double[] tab)
        {
            String result = "";
            for (int i = 0; i < tab.Length; i++)
            {
                result += tab[i] + ", ";
            }
            return result;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((String)comboBox1.SelectedItem == "Kwadrat")
            {
                int[] polaKwadratu = Form1.pole_kwadratu(tab);
                textBox2.Clear();
                for (int i = 0; i < polaKwadratu.Length; i++)
                {
                    textBox2.AppendText(polaKwadratu[i] + ",   ");
                }
                int[] polaKwadratu1 = Form1.pole_kwadratu(tab2);
                textBox4.Clear();
                for (int i = 0; i < polaKwadratu1.Length; i++)
                {
                    textBox4.AppendText(polaKwadratu1[i] + ",   ");
                }
            }
            if ((String)comboBox1.SelectedItem == "Trójkąt")
            {
                double[] polatrojkata = Form1.pole_trojkata(tab);
                textBox2.Clear();
                textBox2.AppendText(tablicaToString2(polatrojkata));
                double[] polatrojkata1 = Form1.pole_trojkata(tab2);
                textBox4.Clear();
                textBox4.AppendText(tablicaToString2(polatrojkata1));
            }
            if ((String)comboBox1.SelectedItem == "Koło")
            {
                double[] polakola = Form1.pole_kola(tab);
                textBox2.Clear();
                for (int i = 0; i < tab.Length; i++)
                {
                    textBox2.AppendText(polakola[i] + ",   ");
                }
                double[] polakola1 = Form1.pole_kola(tab2);
                textBox4.Clear();
                for (int i = 0; i < tab2.Length; i++)
                {
                    textBox4.AppendText(polakola1[i] + ",   ");
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        
        static public int[] losowanie(int size)
        {
            Random rnd1 = new Random(DateTime.Now.Millisecond);
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = rnd1.Next(1, 1000);
                
            }
            return result;
        }

        static public double[] pole_trojkata(int[] tablica)
        {
            double[] result = new double[tablica.Length];
            for (int i = 0; i < tablica.Length; i++)
            {
                double a = (double)tablica[i];
                result[i] = (a * a * Math.Sqrt(3)) / 4.0;
            }
            return result;
        }
        static public int[] pole_kwadratu(int[] tablica)
        {
            int[] result = new int[tablica.Length];
            for (int i = 0; i < tablica.Length; i++)
            {
                result[i] = tablica[i] * tablica[i];
            }
            return result;
        }
        static public double[] pole_kola(int[] tablica)
        {
            double[] result = new double[tablica.Length];
            for (int i = 0; i < tablica.Length; i++)
            {
                result[i] = tablica[i] * tablica[i] * 3.14;
            }
            return result;
        }
        public void porownanie(int[] sorted, int[] licznik, int[]sorted2)
        {
            for (int j = 1; j < sorted.Length; j++)
            {
                for (int i = 0; i < sorted2.Length; i++)
                {
                    for (int k = 1; k < 1000; k++)
                    {
                        if (sorted[i] == sorted2[j] && sorted2[j] == k)
                            licznik[k]++;
                    }
                }
            }

        }
        public void histogram(int[] sorted, int[] licznik)
        {
            for (int k = 1; k < 1000; k++)
            {
                for (int j = 1; j < sorted.Length; j++)
                {
                        if (sorted[j] == k)
                            licznik[k]++;
                    }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void chart1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
