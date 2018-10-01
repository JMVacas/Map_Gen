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


namespace Map_Gen
{
    public partial class Form1 : Form
    {
        string Mapa;
        string Texto;
        string Nombre_Variable;
        List<string> Lista_Mapa = new List<string>();
        bool Error_Tamaño;
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Nombre_Variable = textBox1.Text;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            OpenFileDialog ArchivoCSV = new OpenFileDialog();
            ArchivoCSV.Filter = "Archivos csv|*.csv";
            ArchivoCSV.Title = "Mapa de puntos ";

            if (ArchivoCSV.ShowDialog() == DialogResult.OK)
            {
                StreamReader Lector = new StreamReader(ArchivoCSV.FileName);
                Mapa=Lector.ReadToEnd();
                Mapa=Mapa.Replace(";", "");
                Mapa=Mapa.Replace("\n", "");
                Mapa = Mapa.Replace("\t", "");



                Lista_Mapa = Mapa.Split('\r').ToList();
                
                
                int Tamanio = Lista_Mapa[0].Length;
                for (int i = 0; i<Lista_Mapa.Count; i++)
                {
                    for (int j = 0; j < Lista_Mapa[i].Length; j++)
                    {
                        if (Lista_Mapa[i].Length != Tamanio)
                        {
                            i = Lista_Mapa.Count;
                        }
                        else if (Lista_Mapa[i][j] >'4' || Lista_Mapa[i][j]<'0')
                        {

                        }
                        else
                        {
                            Texto += Nombre_Variable +"[" + (i+1) + "," + (j+1) + "]:= " + Lista_Mapa[i][j] + "; \r\n";
                        }
                    }
                }
                Lector.Close();
            }

            SaveFileDialog Text_OUT = new SaveFileDialog();
            Text_OUT.Filter = "Archivos txt |*.txt";
            Text_OUT.Title = "Mapa Texto";
            if (Text_OUT.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Escritor = new StreamWriter(Text_OUT.FileName);
                Escritor.Write(Texto);
                Escritor.Close();
            }
        }

        
    }
}
