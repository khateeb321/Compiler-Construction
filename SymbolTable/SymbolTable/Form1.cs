using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymbolTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Compute(string ss, int c)
        {
            string[] info = ss.Split('=', '/', ',', ';', ':', '\t', ' ');
            dataGridView1.Rows.Add();
            for (int i = 0; i < info.Length; i++)
            {
                if ((info[i] != "int") && (info[i] != "float"))
                {
                    // Match match = Regex.Match(i, @"^[A-Za-z][A-Za-z]*$");
                    Match match = Regex.Match(info[i], ("^[_a-zA-Z][_a-zA-Z0-9]*$"));
                    if (match.Success)
                    {
                        dataGridView1.Rows[c - 1].Cells[0].Value = match.Value;
                    }
                }

            }

            // ---------------------------------  //

            foreach (string i in info)
            {
                // Match match = Regex.Match(i, @"^[A-Za-z][A-Za-z]*$");
                Match match1 = Regex.Match(i, @"^int|float|char$");
                if (match1.Success)
                {
                    dataGridView1.Rows[c - 1].Cells[1].Value = i;
                }
            }
            // ------------------------------------//

            dataGridView1.Rows[c - 1].Cells[2].Value = c;


            // ----------------------------------- //

            foreach (string i in info)
            {
                // Match match = Regex.Match(i, @"^[A-Za-z][A-Za-z]*$");
                Match match3 = Regex.Match(i, @"^([0-9][0-9]*)(.[0-9][0-9]*)?(e[+|-]?[0-9][0-9]*)?$");
                if (match3.Success)
                {
                    dataGridView1.Rows[c - 1].Cells[3].Value = match3.Value;
                }
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = richTextBox1.Text;
            string[] lines = data.Split('\n');

            /*string sss = "";
            for (int i = 0; i < temp.Length; i++)
            {

                if (!temp[i].Contains("//"))
                    sss += temp[i] + '\n';
            }
            MessageBox.Show(sss);*/

            for (int i = 0; i < lines.Length; i++)
            {
                /*if (lines[i].Contains("/") && (!lines[i].Contains("//")))
                {
                    string temp = "";
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        temp += lines[i][j];
                    }
                    listBox5.Items.Add("Error at Line " + (i + 1));
                    Compute(temp, i);
                }*/

                //else if (!lines[i].Contains("//"))
                {
                    Compute(lines[i], i + 1);
                }
            }
        }
    }
}
