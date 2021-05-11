using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MeritSupportAid
{
    public partial class MSA : Form
    {
        public MSA()
        {
            InitializeComponent();
        }
        //These events relate to MenuStrip string copy logics
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
            bool SaferThanSorry;
            bool CSMorWhut;
            float howDeep = 1;

            /*
            2 functions to make notte of isThisTheEnd gives you whether or not the current menu item is one of the roots
            by checking by name alone, this could prove problematic, but its a basis. isThisTheSystemMenu is the same 
            function returning a more specific bool based on whether its one of the ends in the system menu. 
            */
            SaferThanSorry = IsThisTheEnd(WhatClicked1up, WhatClicked);
            CSMorWhut = IsThisTheSystemMenu(WhatClicked1up);
            if (SaferThanSorry == false)
            {
                /*
                Only come in here if the not the last part of a tree, then get the NEXT part of the tree up using the current
                event item and getting their owner item. CSMorWhut is a bool being set and will help decide whether or not
                to use the CSM prefix later on. howDeep is set at each level to know how big to build the string later on.
                */
                ToolStripMenuItem miGrandpapaOwnerItem = (ToolStripMenuItem)(miOwnerItem.GetCurrentParent() as ToolStripDropDown).OwnerItem;
                WhatClicked2up = miGrandpapaOwnerItem.ToString();
                SaferThanSorry = IsThisTheEnd(WhatClicked2up, WhatClicked1up);
                CSMorWhut = IsThisTheSystemMenu(WhatClicked2up);
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
                    SaferThanSorry = IsThisTheEnd(WhatClicked3up, WhatClicked2up);
                    CSMorWhut = IsThisTheSystemMenu(WhatClicked3up);
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
                        SaferThanSorry = IsThisTheEnd(WhatClicked4up, WhatClicked3up);
                        CSMorWhut = IsThisTheSystemMenu(WhatClicked4up);
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
                            CSMorWhut = IsThisTheSystemMenu(WhatClicked5up);
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
        private bool IsThisTheEnd(string CheckMyVarOut, string SourceVar)
        {
            /*
            This function is to determine whether or not this is the last
            entry in the tree by taking the text entry and comparing the 
            passed in variable versus various text strings, if found, true
            is returned
            */

            //This is a list of drop down menu starting points that don't exist in 2 places, meaning that if you see them, this is the topmost menu
            List<string> OneAndDone = new List<string> { "File", "Clients", "Placements", "Invoicing", "Conversions", "P45/Leavers", "CIS", "Reports", "Control", "Help", "System Defaults", "Branch Tables", "Payroll Tables", "Security", "Utilities", "Supervisor" };
            if (OneAndDone.Contains(CheckMyVarOut))
            {
                //If in list return true
                return true;
            }
            else if (CheckMyVarOut == "Employees")
            {
                //Employees located in more than one place as a menu dropdown
                List<string> EmpSupervisor = new List<string> { "Contracts Setup", "Create Monthly Employee", "Delete Employees", "Employee Migration Wizard", "Move Employee Utilities", "Recalc Holiday Pay" };
                if (EmpSupervisor.Contains(SourceVar))
                {
                    //If the previous value(sourcevar) is in the list, this is the supervisor equivelant menu
                    return false;
                }
                else
                {
                    //otherwise this is Employees in payroll menu MMT
                    return true;
                }
            }
            else if (CheckMyVarOut == "Timesheets")
            {
                //Timesheets located in more than one place as a menu dropdown
                List<string> TSSupervisor = new List<string> { "Delete Adjustments", "Margin Adjustment", "Payroll Reversal Wizard", "Reverse Pay and Accrual", "Timesheet Monthly Reversal", "Timesheets Monthly Edit" };
                if (TSSupervisor.Contains(SourceVar))
                {
                    //If the previous value(sourcevar) is in the list, this is the supervisor equivelant menu
                    return false;
                }
                else
                {
                    //otherwise this is Timesheets in payroll menu MMT
                    return true;
                }

            }
            else if (CheckMyVarOut == "Payroll")
            {
                //Payroll located in more than one place as a menu dropdown
                List<string> PayrollSupervisor = new List<string> { "Accruals", "Country Codes", "Invoice Options", "Nominals", "Paytype Conversion" };
                if (PayrollSupervisor.Contains(SourceVar))
                {
                    //If the previous value(sourcevar) is in the list, this is the supervisor equivelant menu
                    return false;
                }
                else
                {
                    //otherwise this is Payroll in payroll menu MMT
                    return true;
                }
            }
            else if (CheckMyVarOut == "Pensions")
            {
                //Pensions located in more than one place as a menu dropdown
                List<string> PenSupervisor = new List<string> { "Import Office Data", "Pension Corrections", "Postponement at Staging", "Re-export Contribution Schedule", "Pension Defaults", "Pension Providers" };
                if (PenSupervisor.Contains(SourceVar))
                {
                    //If the previous value(sourcevar) is in the list, this is the supervisor equivelant menu
                    return false;
                }
                else
                {
                    //otherwise this is Pensions in payroll menu MMT
                    return true;
                }
            }
            else
            {
                /*
                Case 1 / Default returns false
                */
                return false;
            }

        }
        private bool IsThisTheSystemMenu(string CheckMyVarOut)
        {
            /*
            This function is to determine whether or not this is the last
            entry in the CSM tree by taking the text entry and comparing the 
            passed in variable versus various text strings, if found to be
            on of the system menu roots, true is returned
            */

            //A list for all the payroll menu and system menu strings seperately.
            List<string> PayrollMenu = new List<string> { "File", "Employees", "Clients", "Placements", "Timesheets", "Payroll", "Invoicing", "Conversions", "Pensions", "P45/Leavers", "CIS", "Reports", "Control", "Help" };
            List<string> SystemMenu = new List<string> { "System Defaults", "Branch Tables", "Payroll Tables", "Security", "Utilities", "Supervisor" };

            if (PayrollMenu.Contains(CheckMyVarOut))
            {
                /*
                Regular Payroll form drop downs -Return False
                */
                return false;
            }
            else if (SystemMenu.Contains(CheckMyVarOut))
            {
                /*
                System Menu Controls
                */
                return true;
            }
            else
            {
                //Case 1 False
                return false;
            }

        }
        private string CSMPreString(string CSMPrefix)
        {
            //This will create prefix string
            switch (CSMPrefix)
            {
                case "CSM":
                    return "Control -> System Menu -> ";
                default:
                    return "";
            }

        }
        private void Label_Click(object sender, EventArgs e)
        {
            //Just re-copy the string to the clipboard
            Clipboard.SetText(MenuResultsString.Text);
        }
        //These events relate to the date converter
        private string DateConversion(string PrimaryInput)
        {
            /*
            This is the date converter logic here.
            */

            if (!int.TryParse(PrimaryInput, out _))
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
        private void DateConvClick(object sender, EventArgs e)
        {
            /*
            This is the click event of the converter
            */
            ConvertButton.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            string PrimaryInput = DateConvInput.Text;
            if (PrimaryInput == "Sy is awesome!")
            {
                MessageBox.Show("Yeah he is!", "So Damn Right!");
            }
            else
            {
                SetYourCurrentDateText();
                if (PrimaryInput != "")
                {
                    //Try parsing the string into DateConversion
                    string ResultCheck = DateConversion(PrimaryInput);
                    if (ResultCheck.StartsWith("ERROR"))
                    {
                        //Error handling in here
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

                        //Hide results label and throw error popup
                        DateConvResult.Visible = false;
                        MessageBox.Show(ErrorString, "Error");

                    }
                    else
                    {
                        //Display date conversion
                        DateConvResult.Text = ResultCheck;
                    }

                    //Make some UI colour changes based on originating colours
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
                    //Hide results label and throw error here where no value entered
                    DateConvResult.Visible = false;
                    MessageBox.Show("Please enter a value to convert", "Error");
                }
            }
        }
        private void SetYourCurrentDateText()
        {
            /*
            This is to get today's date
            */
            string DayForLoad = DateTime.Today.ToString();
            string RightNow = DateConversion(DayForLoad);
            TodaysInternal.Text = RightNow;
            TrayIcon.Text = "Your internal date today is " + RightNow;
        }
        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            //On enter key run convert click
            if (e.KeyCode == Keys.Enter)
            {
                DateConvClick(sender, e);
            }
        }
        private void TaxAllowKeyDown(object sender, KeyEventArgs e)
        {
            //On enter key run convert click
            if (e.KeyCode == Keys.Enter)
            {
                TaxAllowCalcClick(sender, e);
            }
        }

        //These events relate to settings and setting updating
        private void SettingButtonClick(object sender, EventArgs e)
        {
            /*
            Show the settings screen
            */
            bool OnOff = true;
            SettingToggleView(OnOff);
        }
        private void SettingCancelClick(object sender, EventArgs e)
        {
            /*
            Cancel and hide the system settings and reapply their
            original settings.
            */
            bool OnOff = false;
            AOTCheck.Checked = Properties.Settings.Default.AlwaysOnTop;
            ForceClose.Checked = Properties.Settings.Default.ForceClose;
            SettingToggleView(OnOff);
        }
        private void SettingSaveClick(object sender, EventArgs e)
        {
            /*
            Save Settings Here and apply TopMost setting
            */
            bool OnOff = false;
            Properties.Settings.Default.Save();
            this.TopMost = Properties.Settings.Default.AlwaysOnTop;
            SettingToggleView(OnOff);
        }
        private void SettingToggleView(bool OnOff)
        {
            /*
            This will toggle the settings controls
            */
            SettingCancel.Visible = OnOff;
            SettingSave.Visible = OnOff;
            AOTCheck.Visible = OnOff;
            ForceClose.Visible = OnOff;
        }
        //These events relate to the TrayIcon and application close management
        private void TrayClick(object sender, EventArgs e)
        {
            /*
            This function handles TrayIcon click 
            logic put in place to toggle window based 
            on TrayIcon click
            */
            if (FormWindowState.Minimized == WindowState)
            {
                //Click now brings to screen and hides trayicon
                Show();
                WindowState = FormWindowState.Normal;
                SetYourCurrentDateText();
                TrayIcon.Visible = false;
            }
            else
            {
                //Minimise Here, though antequated since Icon is
                //now invisible on maximise.
                Hide();
                WindowState = FormWindowState.Minimized;
                SetYourCurrentDateText();
            }

        }
        private void CloseApplication(object sender, EventArgs e)
        {
            /*
            This will close the app. If another form is later created
            this will have to change to Application.Exit();
             */
            Properties.Settings.Default.ForceClose = true;
            Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            on system load define TodaysInternal
            */
            SetYourCurrentDateText();
            /*
            Use app config to get TopMost property
            */
            this.TopMost = false;
            if (Properties.Settings.Default.AlwaysOnTop == true)
            {
                //this being the active current window
                this.TopMost = true;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            /*
            This overrides the form close to now hide and go to system tray.
            */
            if (Properties.Settings.Default.ForceClose == true)
            {
                //Close application if force close true
                Application.Exit();
            }
            else
            {
                //Close form to Tray
                e.Cancel = true;
                base.OnFormClosing(e);
                TrayIcon.Visible = true;
                Hide();
                SetYourCurrentDateText();
                TrayIcon.ShowBalloonTip(500);
            }
        }

        //Logics for tax bands and associate tax band dev below here
        private void TaxBandFormMorph(object sender, EventArgs e)
        {
            /*
            This function hides date conv and setting functionality
            in favour of TaxAllowance functionality and repurposes
            some of the labels.
            */
            TaxAllowInput.Visible = true;
            TaxAllowanceCalc.Visible = true;
            TaxAllowInput.Text = "";
            lblYourDateToday.Text = "Your standard yearly allowance is";
            TodaysInternal.Text = "1257L";
            DateConvInput.Visible = false;
            DateConvResult.Visible = false;
            ConvertButton.Visible = false;
            SettingToggleView(false);
            lbl1TaxRes.Visible = true;
            lbl2TaxRes.Visible = true;
            lbl3TaxRes.Visible = true;
            lbl4TaxRes.Visible = true;
            lbl1TaxRes.Text = "Weekly - ";
            lbl2TaxRes.Text = "Fortnightly - ";
            lbl3TaxRes.Text = "4 Weekly - ";
            lbl4TaxRes.Text = "Monthly - ";
        }
        private void DateCalcFormMorph(object sender, EventArgs e)
        {
            /*
            This function hides tax conv and setting functionality
            in favour of DateConv functionality and resets some 
            of the labels.
            */
            TaxAllowInput.Visible = false;
            TaxAllowanceCalc.Visible = false;
            lblYourDateToday.Text = "Your internal date today is";
            SetYourCurrentDateText();
            DateConvInput.Visible = true;
            DateConvResult.Visible = false;
            ConvertButton.Visible = true;
            DateConvInput.Text = "";
            SettingToggleView(false);
            lbl1TaxRes.Visible = false;
            lbl2TaxRes.Visible = false;
            lbl3TaxRes.Visible = false;
            lbl4TaxRes.Visible = false;
        }
        private void TaxAllowCalcClick(object sender, EventArgs e)
        {
            TaxAllowInput.Text = TaxAllowInput.Text.ToUpper();
            ManipulateTaxCode TaxAllowCalculator = new ManipulateTaxCode();
            if (TaxAllowCalculator.TaxCodeValidation(TaxAllowInput.Text) == true)
            {
                //Construct the decimal using TaxAllowance function
                decimal Week = TaxAllowCalculator.TaxAllowance(TaxAllowInput.Text, "", 1, 52);
                decimal TwoWeek = TaxAllowCalculator.TaxAllowance(TaxAllowInput.Text, "", 1, 26);
                decimal FourWeek = TaxAllowCalculator.TaxAllowance(TaxAllowInput.Text, "", 1, 13);
                decimal Month = TaxAllowCalculator.TaxAllowance(TaxAllowInput.Text, "", 1, 12);

                //round to 2 decimal places
                Week = decimal.Round(Week, 2);
                TwoWeek = decimal.Round(TwoWeek, 2);
                FourWeek = decimal.Round(FourWeek, 2);
                Month = decimal.Round(Month, 2);

                //Create label text
                lbl1TaxRes.Text = "Weekly - " + Week.ToString();
                lbl2TaxRes.Text = "Fortnightly - " + TwoWeek.ToString();
                lbl3TaxRes.Text = "4 Weekly - " + FourWeek.ToString();
                lbl4TaxRes.Text = "Monthly - " + Month.ToString();
            }
            else
            {
                MessageBox.Show("Tax Code " + TaxAllowInput.Text + " is invalid, please ensure you've entered a correct tax code");
            }
        }

        public class ManipulateTaxCode
        {
            //A class for Returning Tax Allowance Information for PAYE Calc
            //RETURNED VALUE IS PERSONAL ALLOWANCE
            //A class for Returning Tax Allowance Information for PAYE Calc
            public string CountryCodeTrim(string TaxCode)
            {
                //Use for trimming scottish and welsh taxcodes
                bool CymruCode = TaxCode.StartsWith("C");
                bool ScotCode = TaxCode.StartsWith("S");
                if (CymruCode == true)
                {
                    int TCL = TaxCode.Length;
                    TaxCode = TaxCode.Substring(1, (TCL - 1)); ;
                }
                else if (ScotCode == true)
                {
                    int TCL = TaxCode.Length;
                    TaxCode = TaxCode.Substring(1, (TCL - 1)); ;
                }
                return TaxCode;
            }
            public bool TaxCodeValidation(string TaxCode)
            {
                //Setup regex string for UK tax codes
                var StandardTaxCodes = "^(BR|D0|NT)$|^(([Kk]{1}[1-9]{1}[0-9]{2,3}$)|([1-9]{1}[0-9]{2,3}[LPTYlpty]{1}$))";

                //Trim off country code to begin with as allowances are the same everywhere
                TaxCode = CountryCodeTrim(TaxCode);

                //Create a matchcollection for valid codes
                MatchCollection ValidCodes = Regex.Matches(TaxCode, StandardTaxCodes);
                foreach (Match m in ValidCodes)
                {
                    //only in here if this matches
                    return true;
                }
                //everything else is false
                return false;
            }
            public decimal TaxAllowance(string TaxCode, string TaxBase, byte Week, byte Freq)
            {
                //Use TaxCode validation before any use of TaxAllowance to ensure no debugs
                //Drop country code
                TaxCode = CountryCodeTrim(TaxCode);
                decimal TaxAllowanceForCalc;
                //Setup bools
                bool StandardTaxCode = false;
                bool BRCode = false;
                bool DCode = false;
                bool KCode = false;
                bool NCode = false;

                //Predefine TaxAllowance as null
                string TaxAllowance = "null";
                //loop here to determine tax allowance for conventional characters defined above in AllowedChars
                string[] AllowedChars = { "L", "M", "N", "S", "T" };
                int z = 0;
                while (z <= 4)
                {
                    if (TaxCode.EndsWith(AllowedChars[z]))
                    {
                        char ForReplace = System.Convert.ToChar(AllowedChars[z]);
                        TaxAllowance = TaxCode.Replace(ForReplace, System.Convert.ToChar("9"));
                        StandardTaxCode = true;
                        z = 5;
                    }
                    z = z + 1;
                }


                //Only run second logic if first isn't satisfied
                if (TaxAllowance == "null") { StandardTaxCode = false; }            //If above loop has not returned a value
                if (StandardTaxCode == false)
                {
                    string[] DifferentCodes = { "BR", "D", "K", "N" };
                    int j = 0;
                    while (j <= 3)
                    {
                        if (TaxCode.StartsWith(DifferentCodes[j]))
                        {
                            if (TaxCode.StartsWith("BR"))
                            {
                                TaxAllowance = "0";
                                BRCode = true;
                                j = 4;
                            }
                            else if (TaxCode.StartsWith("D"))
                            {
                                TaxAllowance = "0";
                                DCode = true;
                            }
                            else if (TaxCode.StartsWith("K"))
                            {
                                TaxAllowance = TaxCode.Replace("K", "0");
                                TaxAllowanceForCalc = System.Convert.ToDecimal(TaxAllowance);
                                KCode = true;
                            }
                            else if (TaxCode.StartsWith("N"))
                            {
                                TaxAllowance = "0";
                                NCode = true;
                            }
                        }
                        j = j + 1;
                    }
                }
                if (StandardTaxCode == true)
                {
                    //Convert the string to decimal and divide it by freq, if cumulative, times by current period for YTD allowance
                    TaxAllowanceForCalc = System.Convert.ToDecimal(TaxAllowance);
                    TaxAllowanceForCalc = TaxAllowanceForCalc / Freq;
                    if (TaxBase == "Cumulative")
                    {
                        TaxAllowanceForCalc = TaxAllowanceForCalc * Week;
                    }
                    return TaxAllowanceForCalc;
                }

                else if (DCode == true)
                {
                    //D Code no tax allowance, 0 is 45% 1 is 50%
                    //Potential to handle this outside of allowance given there is no allowance
                    TaxAllowanceForCalc = 0;
                    return TaxAllowanceForCalc;
                }
                else if (KCode == true)
                {
                    //Send tax allowance back as a negative for K codes
                    TaxAllowance = TaxAllowance.Replace("K", "0");
                    TaxAllowance = TaxAllowance + "9";
                    TaxAllowanceForCalc = System.Convert.ToDecimal(TaxAllowance);
                    TaxAllowanceForCalc = (TaxAllowanceForCalc * -1) / Freq;
                    if (TaxBase == "Cumulative")
                    {
                        TaxAllowanceForCalc = TaxAllowanceForCalc * Week;
                    }
                    return TaxAllowanceForCalc;
                }
                else if (NCode == true)
                {
                    //No Tax
                    //Potential to handle this outside of allowance given there is no allowance
                    TaxAllowanceForCalc = 0;
                    return TaxAllowanceForCalc;
                }
                else if (BRCode == true)
                {
                    //Potential to handle this outside of allowance given there is no allowance
                    TaxAllowanceForCalc = 0;
                    return TaxAllowanceForCalc;
                }
                return System.Convert.ToDecimal("Error");
            }
            public string CountryCode(string TaxCode)
            {
                //Get Country Code from Tax Code
                bool CymruCode = TaxCode.StartsWith("C");
                bool ScotCode = TaxCode.StartsWith("S");

                if (CymruCode == true)
                {
                    return "C";
                }
                else if (ScotCode == true)
                {
                    return "S";
                }
                return "";

            }

        }
    }
}

