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

namespace LabSessional1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void Compute(string ss, int c)
        {
            string[] info = ss.Split('=', '/', ',', ';', ':', '\t', ' ');

            for (int i = 0; i < info.Length; i++)
            {
                if ((info[i] != "int") && (info[i] != "float"))
                {
                    // Match match = Regex.Match(i, @"^[A-Za-z][A-Za-z]*$");
                    Match match = Regex.Match(info[i], ("^[_a-zA-Z][_a-zA-Z0-9]*$"));
                    if (match.Success)
                    {
                        listBox2.Items.Add(match.Value);
                    }
                }
                
            }

            // ------------------------------------------ //
            foreach (string i in info)
            {
                // Match match = Regex.Match(i, @"^[A-Za-z][A-Za-z]*$");
                Match match1 = Regex.Match(i, @"^int|float|char$");
                if (match1.Success)
                {
                    listBox1.Items.Add(i);
                }
            }
            // ------------------------------------------ //

            foreach (string i in info)
            {
                // Match match = Regex.Match(i, @"^[A-Za-z][A-Za-z]*$");
                Match match3 = Regex.Match(i, @"^([0-9][0-9]*)(.[0-9][0-9]*)?(e[+|-]?[0-9][0-9]*)?$");
                if (match3.Success)
                {
                    listBox4.Items.Add(i);
                }
            }
            // ------------------------------------------ //
            for (int k = 0; k < ss.Length; k++)
            {
                if (ss[k] == '=')
                {
                    listBox3.Items.Add("=");
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
                if (lines[i].Contains("/") && (!lines[i].Contains("//")))
                {
                    string temp = "";
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        temp += lines[i][j];
                    }
                    listBox5.Items.Add("Error at Line " + (i + 1));
                    Compute(temp, i);
                }
                else if (!lines[i].Contains("//"))
                {
                    Compute(lines[i], i + 1);
                }
            }
            
        }
    }
}
