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
            
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            StringBuilder sb = new StringBuilder();

            if (mnu.HasDropDown == true)
            {
                //do nothing
            }
            else
            {
                DoArrow();
                sb.Append(mnu.Text);
                MenuResultsBox.Text += sb.ToString();
            }
            */
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
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
                textBox1.Text = sb.ToString();
                MenuResultsBox.Text = sb.ToString();
            }
            Clipboard.SetText(MenuResultsBox.Text);
        }


        private void SecondaryMenuDrop(object sender, EventArgs e)
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
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            //This catches MenuResults before manipulation so it can be replaced later 
            //if DropDownClosed triggered causing the MenuClear function

            //To ensure that the same value isn't repeatedly added. May need further
            //thought with some of the repeated nesting in the tree.
            //Post
            if ((MenuResultsBox.Text.EndsWith(mnu.Text) == true) &(MenuResultsBox.Text.EndsWith("/" + mnu.Text) == false))
            {
                //Don't keep adding
            }
            else if (MenuResultsBox.Text.EndsWith(mnu.Text + " -> ") == true)
            {
                //Don't add if mnu.Text with an arrow is the end
            }
            else
            {
                DoArrow();
                sb.Append(mnu.Text);
                MenuResultsBox.Text += sb.ToString();
                textBox2.Text = MenuResultsBox.Text;
                Clipboard.SetText(MenuResultsBox.Text);
            }
        }

        private void TertiaryMenuDrop(object sender, EventArgs e)
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
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            //This catches MenuResults before manipulation so it can be replaced later 
            //if DropDownClosed triggered causing the MenuClear function

            //To ensure that the same value isn't repeatedly added. May need further
            //thought with some of the repeated nesting in the tree.
            //Post
            if ((MenuResultsBox.Text.EndsWith(mnu.Text) == true) & (MenuResultsBox.Text.EndsWith("/" + mnu.Text) == false))
            {
                //Don't keep adding
            }
            else if (MenuResultsBox.Text.EndsWith(mnu.Text + " -> ") == true)
            {
                //Don't add if mnu.Text with an arrow is the end
            }
            else
            {
                DoArrow();
                sb.Append(mnu.Text);
                MenuResultsBox.Text += sb.ToString();
                textBox3.Text = MenuResultsBox.Text;
                Clipboard.SetText(MenuResultsBox.Text);
            }
        }
        private void QuaternaryMenuDrop(object sender, EventArgs e)
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
            textBox4.Text = "";
            textBox5.Text = "";
            //This catches MenuResults before manipulation so it can be replaced later 
            //if DropDownClosed triggered causing the MenuClear function

            //To ensure that the same value isn't repeatedly added. May need further
            //thought with some of the repeated nesting in the tree.
            //Post
            if ((MenuResultsBox.Text.EndsWith(mnu.Text) == true) & (MenuResultsBox.Text.EndsWith("/" + mnu.Text) == false))
            {
                //Don't keep adding
            }
            else if (MenuResultsBox.Text.EndsWith(mnu.Text + " -> ") == true)
            {
                //Don't add if mnu.Text with an arrow is the end
            }
            else
            {
                DoArrow();
                sb.Append(mnu.Text);
                MenuResultsBox.Text += sb.ToString();
                textBox4.Text = MenuResultsBox.Text;
                Clipboard.SetText(MenuResultsBox.Text);
            }
        }

        private void QuinaryMenuDrop(object sender, EventArgs e)
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
            textBox5.Text = "";
            //This catches MenuResults before manipulation so it can be replaced later 
            //if DropDownClosed triggered causing the MenuClear function

            //To ensure that the same value isn't repeatedly added. May need further
            //thought with some of the repeated nesting in the tree.
            //Post
            if ((MenuResultsBox.Text.EndsWith(mnu.Text) == true) & (MenuResultsBox.Text.EndsWith("/" + mnu.Text) == false))
            {
                //Don't keep adding
            }
            else if (MenuResultsBox.Text.EndsWith(mnu.Text + " -> ") == true)
            {
                //Don't add if mnu.Text with an arrow is the end
            }
            else
            {
                DoArrow();
                sb.Append(mnu.Text);
                MenuResultsBox.Text += sb.ToString();
                textBox5.Text = MenuResultsBox.Text;
                Clipboard.SetText(MenuResultsBox.Text);
            }
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

            //To ensure that the same value isn't repeatedly added. May need further
            //thought with some of the repeated nesting in the tree.
            //Post
            if ((MenuResultsBox.Text.EndsWith(mnu.Text) == true) & (MenuResultsBox.Text.EndsWith("/" + mnu.Text) == false))
            {
                //Don't keep adding
            }
            else if (MenuResultsBox.Text.EndsWith(mnu.Text + " -> ") == true)
            {
                //Don't add if mnu.Text with an arrow is the end
            }
            else
            {
                DoArrow();
                sb.Append(mnu.Text);
                MenuResultsBox.Text += sb.ToString();
                Clipboard.SetText(MenuResultsBox.Text);
            }
        }



        private void MouseOver(object sender, EventArgs e)
        {
            /*
            Treated the same way as menu drop in terms of logic
            */
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            StringBuilder sb = new StringBuilder();

            //This catches MenuResults before manipulation so it can be replaced later 
            //if DropDownClosed triggered causing the MenuClear function

            //To ensure that the same value isn't repeatedly added. May need further
            //thought with some of the repeated nesting in the tree.
            //Post
            
            if (MenuResultsBox.Text.EndsWith(mnu.Text) == true)
            {
                //Don't keep adding
            }
            else if (MenuResultsBox.Text.EndsWith(mnu.Text + " -> ") == true)
            {
                //Don't add if mnu.Text with an arrow is the end
            }
            else
            {
                DoArrow();
                sb.Append(mnu.Text);
                MenuResultsBox.Text = textBox1.Text + " -> " + sb.ToString();
                Clipboard.SetText(MenuResultsBox.Text);
            }
            
        }

        private void MouseLeave(object sender, EventArgs e)
        {//MenuResultsBox.Text.Substring(0, (MenuResultsBox.TextLength - MyString.Length));
            string MyString = sender.ToString();
            float BoxNoToGo = 0;
            if (textBox1.Text != "") { BoxNoToGo = 1; }
            if (textBox2.Text != "") { BoxNoToGo = 2; }
            if (textBox3.Text != "") { BoxNoToGo = 3; }
            if (textBox4.Text != "") { BoxNoToGo = 4; }
            if (textBox5.Text != "") { BoxNoToGo = 5; }
            switch (BoxNoToGo)
            {
                case 1:
                    //MenuResultsBox.Text
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }

            MenuResultsBox.Text = textBox1.Text;
            Clipboard.SetText(MenuResultsBox.Text);
        }

        private void MenuDropDownClose(object sender, EventArgs e)
        {
            /*
            This function is called where a drop down closes. Works with 1 thus far
            */
            //string MyString = " -> " + sender.ToString(); MenuResultsBox.Text.Substring(0, (MenuResultsBox.TextLength - MyString.Length));
            MenuResultsBox.Text = textBox1.Text;
            Clipboard.SetText(MenuResultsBox.Text);
        }

        private void DoArrow()
        {
            /*
            Where called and MenuResultsBox isn't null, it will concat an arrow inbetween 
            current string and the next child element. Protection for multiple arrows added.
            */
            if (MenuResultsBox.Text.Length > 0)
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
