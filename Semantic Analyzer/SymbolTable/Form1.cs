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
            string chk = "";
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
                    chk = match1.Value;
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
                    Match match4 = Regex.Match(i, @"^([0-9][0-9]*)?$");
                   // Match match5 = Regex.Match(i, @"^([0-9][0-9])(.[0-9][0-9]*)?(e[+|-]?[0-9][0-9]*)?$");
                    if ((chk == "int" && match4.Success))
                    {
                        dataGridView1.Rows[c - 1].Cells[3].Value = match3.Value;
                        break;
                    }


                    else if ((chk == "float" && match3.Value.ToString().Contains('.')))
                    {
                        dataGridView1.Rows[c - 1].Cells[3].Value = match3.Value;
                        break;
                    }

                    else
                    {
                        MessageBox.Show("Not same type");
                    }
                }
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = richTextBox1.Text;
            string[] lines = data.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                {
                    if (!lines[i].Contains('+'))
                        Compute(lines[i], i + 1);
                    else
                        CompatabilityCheck(lines[i], i + 1);
                }
            }
        }

        private void CompatabilityCheck(string p, int row)
        {
            string[] info = p.Split('=', '/', ',', ';', ':', '\t', ' ');
            foreach (string j in info)
            {
                // Match match = Regex.Match(i, @"^[A-Za-z][A-Za-z]*$");
                Match match1 = Regex.Match(j, @"^int|float|char$");
                if (match1.Value == "int")
                {
                   // var a = dataGridView1.Rows[row - 1].Cells[1].Value;

                    for (int i = 0; i < info.Length; i++)
                    {
                        if ((info[i] != "int") && (info[i] != "float"))
                        {
                            // Match match = Regex.Match(i, @"^[A-Za-z][A-Za-z]*$");
                            Match match = Regex.Match(info[i], ("^[_a-zA-Z][_a-zA-Z0-9]*$"));
                            if (match.Success)
                            {
                                for (int k = 0; k < dataGridView1.Rows.Count - 1; k++)
                                {
                                    if (!(dataGridView1.Rows[k].Cells[1].Value.ToString() == "int"))
                                    {
                                        MessageBox.Show("Error!");
                                        break;
                                    }
                                    
                                }

                            }
                        }

                    }
                }
            }
        }
    }
}
