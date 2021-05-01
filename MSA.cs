﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            //Click event begins by setting up variables and bringing in the sender as a menu item
            MenuResultsString.Visible = false;
            MenuResultsString.Text = "";
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            string WhatClicked = mi.ToString();
            ToolStripMenuItem miOwnerItem = (ToolStripMenuItem)(mi.GetCurrentParent() as ToolStripDropDown).OwnerItem;
            string WhatClicked1up = miOwnerItem.ToString();
            string WhatClicked2up = "";
            string WhatClicked3up = "";
            string WhatClicked4up = "";
            string WhatClicked5up = "";
            /*
            Array Handling to catch exceptions, click events not added to the initial drop down item. Added additional
            checks around CSM calls as the click doesn't have the event being owned by the relevant menu bar as the
            dropdown opened closed events did. howDeep is set at each level to know how big to build the string later on.
            */
            bool SaferThanSorry = true;
            bool CSMorWhut = false;
            float howDeep = 1;

            /*
            2 functions to make notte of isThisTheEnd gives you whether or not the current menu item is one of the roots
            by checking by name alone, this could prove problematic, but its a basis. isThisTheSystemMenu is the same 
            function returning a more specific bool based on whether its one of the ends in the system menu. 
            */
            SaferThanSorry = isThisTheEnd(WhatClicked1up);
            CSMorWhut = isThisTheSystemMenu(WhatClicked1up);
            if (SaferThanSorry == false)
            {
                /*
                Only come in here if the not the last part of a tree, then get the NEXT part of the tree up using the current
                event item and getting their owner item. CSMorWhut is a bool being set and will help decide whether or not
                to use the CSM prefix later on. howDeep is set at each level to know how big to build the string later on.
                */
                ToolStripMenuItem miGrandpapaOwnerItem = (ToolStripMenuItem)(miOwnerItem.GetCurrentParent() as ToolStripDropDown).OwnerItem;
                WhatClicked2up = miGrandpapaOwnerItem.ToString();
                SaferThanSorry = isThisTheEnd(WhatClicked2up);
                CSMorWhut = isThisTheSystemMenu(WhatClicked2up);
                howDeep = 2;
                if (SaferThanSorry == false)
                {
                    /*
                    Only come in here if the not the last part of a tree, then get the NEXT part of the tree up using the current
                    event item and getting their owner item.CSMorWhut is a bool being set and will help decide whether or not
                    to use the CSM prefix later on. howDeep is set at each level to know how big to build the string later on.
                    */
                    ToolStripMenuItem miGreatGrandpapaOwnerItem = (ToolStripMenuItem)(miGrandpapaOwnerItem.GetCurrentParent() as ToolStripDropDown).OwnerItem;
                    WhatClicked3up = miGreatGrandpapaOwnerItem.ToString();
                    SaferThanSorry = isThisTheEnd(WhatClicked3up);
                    CSMorWhut = isThisTheSystemMenu(WhatClicked3up);
                    howDeep = 3;
                    if (SaferThanSorry == false)
                    {
                        /*
                        Only come in here if the not the last part of a tree, then get the NEXT part of the tree up using the current
                        event item and getting their owner item. CSMorWhut is a bool being set and will help decide whether or not
                        to use the CSM prefix later on. howDeep is set at each level to know how big to build the string later on.
                        */
                        ToolStripMenuItem miGreatestGrandpapaOwnerItem = (ToolStripMenuItem)(miGreatGrandpapaOwnerItem.GetCurrentParent() as ToolStripDropDown).OwnerItem;
                        WhatClicked4up = miGreatestGrandpapaOwnerItem.ToString();
                        SaferThanSorry = isThisTheEnd(WhatClicked4up);
                        CSMorWhut = isThisTheSystemMenu(WhatClicked4up);
                        howDeep = 4;
                        if (SaferThanSorry == false)
                        {
                            /*
                            Only come in here if the not the last part of a tree, then get the NEXT part of the tree up using the current
                            event item and getting their owner item. CSMorWhut is a bool being set and will help decide whether or not
                            to use the CSM prefix later on. howDeep is set at each level to know how big to build the string later on.

                            After this there will be no further nesting or interrogation of the next generation of owner, if the result is too
                            small, it is highly likely that a 6th case should be added.
                            */
                            ToolStripMenuItem miAncestralGrandpapaOwnerItem = (ToolStripMenuItem)(miGreatestGrandpapaOwnerItem.GetCurrentParent() as ToolStripDropDown).OwnerItem;
                            WhatClicked5up = miAncestralGrandpapaOwnerItem.ToString();
                            CSMorWhut = isThisTheSystemMenu(WhatClicked5up);
                            howDeep = 5;
                        }
                            
                    }

                        
                }
                
            }

            /*
            Using the CSMorWhut result, stage the CSMCheck variable and if true to CSMorWhut, change this to CSM
            then use the CSMPreString function to gather the full string. This could easily be factored out tbh.
            Just generating the string here as opposed to the function.
            */
            string CSMCheck = "";
            if (CSMorWhut == true)
            {
                CSMCheck = "CSM";
            }
            string CSM = CSMPreString(CSMCheck);

            /*
            howDeep being the variable set with each nested argument to know how deep to build the string and what values to use.
            */
            switch (howDeep)
            {
                case 1:
                    MenuResultsString.Text = CSM + WhatClicked1up + " -> " + WhatClicked;
                    break;
                case 2:
                    MenuResultsString.Text = CSM + WhatClicked2up + " -> " + WhatClicked1up + " -> " + WhatClicked;
                    break;
                case 3:
                    MenuResultsString.Text = CSM + WhatClicked3up + " -> " + WhatClicked2up + " -> " + WhatClicked1up + " -> " + WhatClicked;
                    break;
                case 4:
                    MenuResultsString.Text = CSM + WhatClicked4up + " -> " + WhatClicked3up + " -> " + WhatClicked2up + " -> " + WhatClicked1up + " -> " + WhatClicked;
                    break;
                case 5:
                    MenuResultsString.Text = CSM + WhatClicked5up + " -> " + WhatClicked4up + " -> " + WhatClicked3up + " -> " + WhatClicked2up + " -> " + WhatClicked1up + " -> " + WhatClicked;
                    break;
                default:
                    MenuResultsString.Text = "Error when determining parent components in click event";
                    break;
            }

            /*
            Simple copy to clipboard command to close 
            */
            MenuResultsString.Visible = true;
            //MenuResultsBox2.Text = MenuResultsBox.Text;
            Clipboard.SetText(MenuResultsString.Text);
        }

        private bool isThisTheEnd(string CheckMyVarOut)
        {
            /*
            This function is to determine whether or not this is the last
            entry in the tree by taking the text entry and comparing the 
            passed in variable versus various text strings, if found, true
            is returned
            */

            /*
            Regular Payroll form drop downs 
            */
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

            /*
            System Menu Controls
            */
            if (CheckMyVarOut == "System Defaults") { return true; }
            if (CheckMyVarOut == "Branch Tables") { return true; }
            if (CheckMyVarOut == "Payroll Tables") { return true; }
            if (CheckMyVarOut == "Security") { return true; }
            if (CheckMyVarOut == "Utilities") { return true; }
            if (CheckMyVarOut == "Supervisor") { return true; }

            /*
            Case 1 / Default returns false
            */
            return false;
        }

        private bool isThisTheSystemMenu(string CheckMyVarOut)
        {
            /*
            This function is to determine whether or not this is the last
            entry in the CSM tree by taking the text entry and comparing the 
            passed in variable versus various text strings, if found to be
            on of the system menu roots, true is returned
            */

            /*
            Regular Payroll form drop downs -Return False
            */
            if (CheckMyVarOut == "File") { return false; }
            if (CheckMyVarOut == "Employees") { return false; }
            if (CheckMyVarOut == "Clients") { return false; }
            if (CheckMyVarOut == "Placements") { return false; }
            if (CheckMyVarOut == "Timesheets") { return false; }
            if (CheckMyVarOut == "Payroll") { return false; }
            if (CheckMyVarOut == "Invoicing") { return false; }
            if (CheckMyVarOut == "Conversions") { return false; }
            if (CheckMyVarOut == "Pensions") { return false; }
            if (CheckMyVarOut == "P45/Leavers") { return false; }
            if (CheckMyVarOut == "CIS") { return false; }
            if (CheckMyVarOut == "Reports") { return false; }
            if (CheckMyVarOut == "Control") { return false; }
            if (CheckMyVarOut == "Help") { return false; }

            /*
            System Menu Controls
            */
            if (CheckMyVarOut == "System Defaults") { return true; }
            if (CheckMyVarOut == "Branch Tables") { return true; }
            if (CheckMyVarOut == "Payroll Tables") { return true; }
            if (CheckMyVarOut == "Security") { return true; }
            if (CheckMyVarOut == "Utilities") { return true; }
            if (CheckMyVarOut == "Supervisor") { return true; }

            /*
            Case 1 / Default returns false
            */
            return false;
        }

        private string CSMPreString(string CSMPrefix)
        {
            //This will create prefix string
            switch (CSMPrefix)
            {
                case "CSM":
                    return CSMPrefix = "Control -> System Menu -> ";
                default:
                    return CSMPrefix = "";
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            on system load define TodaysInternal
            */
            string DayForLoad = DateTime.Today.ToString();
            string RightNow = DateConversion(DayForLoad);
            TodaysInternal.Text = RightNow;

            /*
            Use app config to get TopMost property
            */
            var TopThis = ConfigurationManager.AppSettings["TopThis"];
            if (TopThis == "true")
            {
                //this being the active current window
                this.TopMost = true;
            }
        }

        private string DateConversion(string PrimaryInput)
        {
            int i;
            if (!int.TryParse(PrimaryInput, out i))
            {
                try
                {
                    /*
                    This is where a date is converted to a number
                    */
                    DateTime DayOne = new DateTime(1967, 12, 31);
                    DateTime DayTwo = DateTime.Parse(PrimaryInput);
                    TimeSpan t = DayTwo - DayOne;
                    double NrOfDays = t.TotalDays;
                    return (NrOfDays.ToString());
                }
                catch (FormatException)
                {
                    //If error in int conversion, return this error
                    return "ERROR 001";
                }

            }
            else
            {
                //If textBox has been entered as number
                try
                {
                    DateTime DayTwoConv;
                    DateTime DayOne = new DateTime(1967, 12, 31);
                    double MyVar = Convert.ToDouble(PrimaryInput);
                    DayTwoConv = DayOne.AddDays(MyVar);
                    string OutputVar = DayTwoConv.ToString("dd/MM/yy");
                    //return (DayTwoConv.ToShortDateString());
                    return OutputVar;
                }
                catch (FormatException)
                {
                   //If error with string conversion, return this error
                   return "ERROR 002";
                }

            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MenuResultsString.Text);
        }
    
        private void DateConvClick(object sender, EventArgs e)
        {
            ConvertButton.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipY);
            string PrimaryInput = DateConvInput.Text;
            if (PrimaryInput != "")
            {
                string ResultCheck = DateConversion(PrimaryInput);
                if (ResultCheck.StartsWith("ERROR"))
                {
                    string ErrorString;
                    switch (ResultCheck)
                    {
                        case "ERROR 001":
                            ErrorString = "Error in int conversion, revise your input";
                            break;
                        case "ERROR 002":
                            ErrorString = "Error in string conversion, revise your input. Please use a valid date format.";
                            break;
                        default:
                            ErrorString = "Unknown error, this is why you can't have nice things!";
                            //Put a thing here for writing a log entry
                            break;
                    }

                    DateConvResult.Visible = false;
                    MessageBox.Show(ErrorString,"Error");

                }
                else
                {
                    DateConvResult.Text = DateConversion(PrimaryInput);
                }
                
                string ColCheck = DateConvResult.ForeColor.ToString();
                if (ColCheck == "Color [A=255, R=252, G=79, B=21]")
                {
                    DateConvResult.ForeColor = System.Drawing.Color.FromArgb(234, 71, 179);
                }
                else
                {
                    DateConvResult.ForeColor = System.Drawing.Color.FromArgb(252, 79, 21);
                }

                DateConvResult.Visible = true;

            }
            else
            {
                DateConvResult.Visible = false;
                MessageBox.Show("Please enter a value to convert", "Error");
            }

        }
    }
}
