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
            MenuResultsBox.Text = "";
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            string WhatClicked = mi.ToString();
            ToolStripMenuItem miOwnerItem = (ToolStripMenuItem)(mi.GetCurrentParent() as ToolStripDropDown).OwnerItem;
            string WhatClicked1up = miOwnerItem.ToString();
            string WhatClicked2up = "";
            string WhatClicked3up = "";
            string WhatClicked4up = "";
            string WhatClicked5up = "";
            /*
            Array Handling to catch exceptions, click events not added to the initial drop down item.
            */
            bool SaferThanSorry = true;
            float howDeep = 1;


            SaferThanSorry = isThisTheEnd(WhatClicked1up);
            if (SaferThanSorry == false)
            {
                ToolStripMenuItem miGrandpapaOwnerItem = (ToolStripMenuItem)(miOwnerItem.GetCurrentParent() as ToolStripDropDown).OwnerItem;
                WhatClicked2up = miGrandpapaOwnerItem.ToString();
                SaferThanSorry = isThisTheEnd(WhatClicked2up);
                howDeep = 2;
                if (SaferThanSorry == false)
                {
                    ToolStripMenuItem miGreatGrandpapaOwnerItem = (ToolStripMenuItem)(miGrandpapaOwnerItem.GetCurrentParent() as ToolStripDropDown).OwnerItem;
                    WhatClicked3up = miGreatGrandpapaOwnerItem.ToString();
                    SaferThanSorry = isThisTheEnd(WhatClicked3up);
                    howDeep = 3;
                    if (SaferThanSorry == false)
                    {
                        ToolStripMenuItem miGreatestGrandpapaOwnerItem = (ToolStripMenuItem)(miGreatGrandpapaOwnerItem.GetCurrentParent() as ToolStripDropDown).OwnerItem;
                        WhatClicked4up = miGreatestGrandpapaOwnerItem.ToString();
                        SaferThanSorry = isThisTheEnd(WhatClicked4up);
                        howDeep = 4;
                        if (SaferThanSorry == false)
                        {
                            ToolStripMenuItem miAncestralGrandpapaOwnerItem = (ToolStripMenuItem)(miGreatestGrandpapaOwnerItem.GetCurrentParent() as ToolStripDropDown).OwnerItem;
                            WhatClicked5up = miAncestralGrandpapaOwnerItem.ToString();
                            howDeep = 5;
                        }
                            
                    }

                        
                }
                
            }



            switch (howDeep)
            {
                case 1:
                    MenuResultsBox.Text = WhatClicked1up + " -> " + WhatClicked;
                    break;
                case 2:
                    MenuResultsBox.Text = WhatClicked2up + " -> " + WhatClicked1up + " -> " + WhatClicked;
                    break;
                case 3:
                    MenuResultsBox.Text = WhatClicked3up + " -> " + WhatClicked2up + " -> " + WhatClicked1up + " -> " + WhatClicked;
                    break;
                case 4:
                    MenuResultsBox.Text = WhatClicked4up + " -> " + WhatClicked3up + " -> " + WhatClicked2up + " -> " + WhatClicked1up + " -> " + WhatClicked;
                    break;
                case 5:
                    MenuResultsBox.Text = WhatClicked5up + " -> " + WhatClicked4up + " -> " + WhatClicked3up + " -> " + WhatClicked2up + " -> " + WhatClicked1up + " -> " + WhatClicked;
                    break;
                default:
                    MenuResultsBox.Text = "Error when determining parent components in click event";
                    break;
            }
            Clipboard.SetText(MenuResultsBox.Text);
        }

        private bool isThisTheEnd(string CheckMyVarOut)
        {
            if (CheckMyVarOut == "File") { return true; }
            if (CheckMyVarOut == "Employees") { return true; }
            if (CheckMyVarOut == "Clients") { return true; }
            if (CheckMyVarOut == "Placements") { return true; }
            if (CheckMyVarOut == "Timesheets") { return true; }
            if (CheckMyVarOut == "Payroll") { return true; }
            if (CheckMyVarOut == "Invoicing") { return true; }
            if (CheckMyVarOut == "Conversions") { return true; }
            if (CheckMyVarOut == "Pensions") { return true; }
            if (CheckMyVarOut == "P45/Leavers") { return true; }
            if (CheckMyVarOut == "CIS") { return true; }
            if (CheckMyVarOut == "Reports") { return true; }
            if (CheckMyVarOut == "Control") { return true; }
            if (CheckMyVarOut == "Help") { return true; }
            if (CheckMyVarOut == "System Defaults") { return true; }
            if (CheckMyVarOut == "Branch Tables") { return true; }
            if (CheckMyVarOut == "Payroll Tables") { return true; }
            if (CheckMyVarOut == "Security") { return true; }
            if (CheckMyVarOut == "Utilities") { return true; }
            if (CheckMyVarOut == "Supervisor") { return true; }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
