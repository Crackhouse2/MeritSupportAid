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
            MenuResultsBox.Text += sb.ToString();
        }

        private void PrimaryMenuDrop(object sender, EventArgs e)
        {
            //Created supplementary menu drop for PrimaryMenuItems, this will create a new string rather than append
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            StringBuilder sb = new StringBuilder();
           
            //Where called from CSM menu tree, use the system menu prefix
            if (mnu.Owner.Name == "CSM") 
            {
                string CSMPrefix = "Control -> System Menu -> ";
                sb.Append(CSMPrefix);
                MenuResultsBox.Text = sb.ToString();
                sb.Append(mnu.Text);
                MenuResultsBox.Text += sb.ToString();
            }
            //Otherwise use no prefix
            else
            {
                sb.Append(mnu.Text);
            }
             
            MenuResultsBox.Text = sb.ToString();
            invisDDTextBox.Text = MenuResultsBox.Text;
        }


        private void MenuDrop(object sender, EventArgs e)
        {
            //This will be for all sub menu items after first drop downs for example File -> Contacts
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            StringBuilder sb = new StringBuilder();

            //This catches MenuResults before manipulation so it can be replaced later if DropDownClosed triggered causing the MenuClear
            invisDDTextBox.Text = MenuResultsBox.Text;
            DoArrow();
            sb.Append(mnu.Text);
            MenuResultsBox.Text += sb.ToString();
        }

        private void MenuClear(object sender, EventArgs e)
        {
            //Clear Textbox
            //This needs to be dynamically used in instances of opening and closing a submenu to strip out the erroneously opened menu item.
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            StringBuilder sb = new StringBuilder();
            MenuResultsBox.Text = invisDDTextBox.Text;

        }

        private void ResetTextBox(object sender, EventArgs e)
        {
            //Clear Textboxes
            MenuResultsBox.Text = null;
            invisDDTextBox.Text = null;
        }

        private void DoArrow()
        {
            string s = MenuResultsBox.Text;
            if (s.Length > 0)
            {
                MenuResultsBox.Text += (" -> ");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*
            private void CSM_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {

            }
        
          private void toolStripSeparator22_Click(object sender, EventArgs e)
          {

          }

          private void toolStripSeparator26_Click(object sender, EventArgs e)
          {

          }

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
