using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
using Irony.Ast;
 
namespace parser
{
    public partial class Form1 : Form
    {
        public class ExpressionGrammar : Irony.Parsing.Grammar
        {
            public ExpressionGrammar()
            {
                var Number = new NumberLiteral("Number");
                var Var = new IdentifierTerminal("Var");
                var conditional_expression = new NonTerminal("conditional_expression");

                //conditional_expression.Rule = expression + PreferShiftHere() + qmark + expression + colon + expression;
                //NonTerminal DataType = new NonTerminal("DataType");

                NonTerminal DecSt = new NonTerminal("DecSt");
                DecSt.Rule = "int" + Var + "=" + Number + ";" | "int" + Var + ";";

                NonTerminal PrintSt = new NonTerminal("PrintSt");
                PrintSt.Rule = "cout <<" + Var;



                //NonTerminal IF = new NonTerminal("IF");
                //IF.Rule = "if( + ;

                NonTerminal stmt = new NonTerminal("stmt");
                stmt.Rule = PrintSt | DecSt;

                NonTerminal stmt1 = new NonTerminal("stmt");
                stmt1.Rule = "begin{" + stmt + "}end;";

                this.Root = DecSt;
            }
            
        }

        public Form1()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Grammar grammar = new ExpressionGrammar();
            Parser parser = new Parser(grammar);
            ParseTree parseTree = parser.Parse(richTextBox1.Text);
            if (parseTree.Status.ToString() != "Error")
                listBox1.Items.Add(parseTree.SourceText);
        }
    }
}
