using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeritSupportAid
{
    public partial class MSA : Form
    {
        public MSA()
        {
            InitializeComponent();
        }

        private void MenuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            StringBuilder sb = new StringBuilder();
            DoArrow();
            sb.Append(mnu.Text);
            textBox1.Text += sb.ToString();
        }

        private void MenuDrop(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            StringBuilder sb = new StringBuilder();
            DoArrow();
            sb.Append(mnu.Text);
            textBox1.Text += sb.ToString();
        }

        private void MenuClear(object sender, EventArgs e)
        {
            //Clear Textbox
            //This needs to be dynamically used in instances of opening and closing a submenu to strip out the erroneously opened menu item.
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            StringBuilder sb = new StringBuilder();
            textBox1.Text.Replace(mnu.Text, "");
        }

        private void CSMPreString(object sender, EventArgs e)
        {
            //This will create prefix string for the CSM menuStrip
            string CSMPrefix = "Control -> System Menu";
            textBox1.Text = CSMPrefix;
        }

        private void ResetTextBox(object sender, EventArgs e)
        {
            //Clear Textbox
            textBox1.Text = "";
        }

        private void DoArrow()
        {
            string s = textBox1.Text;
            if (s.Length > 0)
            {
                textBox1.Text += (" -> ");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /*
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
private void callsContactsToolStripMenuItem_Click(object sender, EventArgs e)
{

}

private void allCallsToolStripMenuItem_Click(object sender, EventArgs e)
{

}
*/
    }
}
