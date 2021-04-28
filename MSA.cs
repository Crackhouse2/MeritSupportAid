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
            /* 
            When click event is triggered, if there are no further drop down elements
            it will add the clicked menu item to the string before copying. May consider a 
            mouseover argument later on.
            */
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            StringBuilder sb = new StringBuilder();
            if (mnu.HasDropDown == true)
            {
                //do nothing
            }
            else
            {
                //MenuResultsBox.Text = invisDDTextBox.Text;
                DoArrow();
                sb.Append(mnu.Text);
                invisDDTextBox.Text = MenuResultsBox.Text;
                MenuResultsBox.Text += sb.ToString();
            }

            Clipboard.SetText(MenuResultsBox.Text);
        }

        private void PrimaryMenuDrop(object sender, EventArgs e)
        {
            /*
            The primary difference with PrimaryMenuDrop and MenuDrop is that Primary ALWAYS begins the 
            string again, no adding. MenuDrop is for submenus and will add to strings. PrimaryMenuDrop will
            also assess the menu item to see if it is the MMT or CSM variant and if the latter, apply a prefix
            */
            
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
                MenuResultsBox.Text = sb.ToString();
            }
            invisDDTextBox.Text = MenuResultsBox.Text;
            Clipboard.SetText(MenuResultsBox.Text);
        }


        private void MenuDrop(object sender, EventArgs e)
        {
            /*
            Where this differs is that it will concatonate the strings at the end.
            This will be for all sub menu items after first drop downs for example 
            File -> Contacts -> to gain access to the further drop down items such as 
            Outstanding (All) etc. Where this is implemented, as DropDownOpened, you
            also need to implement MenuClear as DropDownClosed to avoid duplication in
            the string.
            */

            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            StringBuilder sb = new StringBuilder();

            //This catches MenuResults before manipulation so it can be replaced later 
            //if DropDownClosed triggered causing the MenuClear function
            invisDropDownLastParent.Text = MenuResultsBox.Text;

            //To ensure that the same value isn't repeatedly added. May need further
            //thought with some of the repeated nesting in the tree.
            bool TextCheck = MenuResultsBox.Text.EndsWith(mnu.Text);
            if (TextCheck == true)
            {
                //Don't keep adding
            }
            else
            {
                DoArrow();
                sb.Append(mnu.Text);
                string test = MenuResultsBox.Text + sb.ToString();
                MenuResultsBox.Text += sb.ToString();
                Clipboard.SetText(MenuResultsBox.Text);
            }
        }

        private void MenuClear(object sender, EventArgs e)
        {
            /*
            This function is called ot to entirely clear the text boxes but to step back
            from any DropDownOpened additions that you may not want. It does this by using
            the text value in invisDDTextBox which is set at any point there is text added
            to the result field.
            */
            MenuResultsBox.Text = invisDDTextBox.Text;
            Clipboard.SetText(MenuResultsBox.Text);
        }
        private void MenuDropDownClose(object sender, EventArgs e)
        {
            /*
            This function is called where the last parent is closed, such as with a click
            */
            MenuResultsBox.Text = invisDropDownLastParent.Text;
            Clipboard.SetText(MenuResultsBox.Text);
        }

        private void DoArrow()
        {
            /*
            Where called and MenuResultsBox isn't null, it will concat an arrow inbetween 
            current string and the next child element. Protection for multiple arrows added.
            */
            string s = MenuResultsBox.Text;
            if (s.Length > 0)
            {
                if (MenuResultsBox.Text.EndsWith(" -> ") == false)
                {
                    MenuResultsBox.Text += (" -> ");
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
