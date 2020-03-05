// I Prerak Patel (000736376) certify that I have done this work without anyone's help and I have not made my work available to any one else.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3B
{
    public partial class Form1 : Form
    {
        
        int[] services = { 30, 20, 40, 50, 200, 60 };       // Price of services
        int[] dressers = { 30, 45, 40, 50, 55 };            // Price of dressers

        float totalAmount = 0;                              // totalAmount is the total

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)     // form loads
        {
            hairDresserDropDown.SelectedIndex = 0;             // making the default selection as index 0
            total.Visible = false;                             // making total box invisible
        }

        private void selectServiceListItem_Clicked(object sender, EventArgs e)  // when service list item is clicked
        {
            add.Enabled = true;                                                 // add button is enabled
        }

        private void addButton_Clicked(object sender, EventArgs e)              // on add button clicked
        {
            hairDresserDropDown.Enabled = false;                                // hairdresser dropdownlist is made disabled
            calculate.Enabled = true;                                           // calculate button is enabled

            if (chargedItemList.Items.Count > 0 && priceList.Items.Count > 0)   // is the charged item listbox already consist of values
            {
                chargedItemList.Items.Add(selectServiceList.SelectedItem);      // adds selected item from select servive listbox
                priceList.Items.Add(services[selectServiceList.SelectedIndex].ToString("C2"));  // adds price ofselected service listbox

                totalAmount += services[selectServiceList.SelectedIndex];       // total price is returned in total amount field
            }
            else                                                                // or ele he charged item listbox has no value in it
            {
                chargedItemList.Items.Add(hairDresserDropDown.SelectedItem);    // adds selected item from hair dresser dropd down to  servive listbox
                chargedItemList.Items.Add(selectServiceList.SelectedItem);      // adds selected item from select servive listbox
                priceList.Items.Add(dressers[hairDresserDropDown.SelectedIndex].ToString("C2"));    // adds price of selected hairdresser drop down
                priceList.Items.Add(services[selectServiceList.SelectedIndex].ToString("C2")); // adds price of selected service listbox

                // total price is returned in total amount field
                totalAmount += (services[selectServiceList.SelectedIndex] + dressers[hairDresserDropDown.SelectedIndex]);    
            }

            // all the time items added to the charged list box selected item from select service listbox is deselected
            selectServiceList.ClearSelected();
        }

        private void exit_Click(object sender, EventArgs e)             // action of exit button closing the program
        {
            this.Close();
        }

        private void reset_Click(object sender, EventArgs e)            // action of reset button
        {
            chargedItemList.Items.Clear();                              // clears the charged item listbox
            priceList.Items.Clear();                                    // clears the price listbox
            add.Enabled = false;                                        // add button is disabled
            calculate.Enabled = false;                                  // calculate button is disabled
            hairDresserDropDown.Enabled = true;                         // hair dresser drop down is disabled
            total.Visible = false;                                      // total field is made visible
            hairDresserDropDown.SelectedIndex = 0;                      // hair dresser drop down list is made initialized with index value at 0
            hairDresserDropDown.Focus();                                // focus of cursor is set to hair dresser drop down
        }

        private void calculate_Click(object sender, EventArgs e)        // action for calculate button
        {
            total.Visible = true;                                       // total field is made visible
            total.Text = totalAmount.ToString("C2");                    // total field is set to total amount with formatted string
        }
    }
}
