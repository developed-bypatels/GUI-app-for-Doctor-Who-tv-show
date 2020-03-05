using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1B
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Client_Box_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Cal_Button_Click(object sender, EventArgs e)
        {
            float hairCutRate = 0;                  // variable to store the price of hairdresser

            // First Radio Button

            if (radioButton1.Checked)               // checking the radiobuttos are checked or not
            {
                hairCutRate = 30;   
            }
            else if (radioButton2.Checked)
            {
                hairCutRate = 45;
            }
            else if (radioButton3.Checked)
            {
                hairCutRate = 40;
            }
            else if (radioButton4.Checked)
            {
                hairCutRate = 50;
            }
            else if (radioButton5.Checked)
            {
                hairCutRate = 55;
            }

            // Check Box
            bool serviceFlag = false;                   // boolean variable serviceFlag for checking that user must select one of
            if (checkBox1.Checked)                      // the check box
            {
                hairCutRate += 30;                      // adding the services price to the existing total
                serviceFlag = true;
            }

            if (checkBox2.Checked)
            {
                hairCutRate += 40;
                serviceFlag = true;
            }

            if (checkBox3.Checked)
            {
                hairCutRate += 50;
                serviceFlag = true;
            }

            if (checkBox4.Checked)
            {
                hairCutRate += 200;
                serviceFlag = true;
            }
            if (!serviceFlag)                           // check if the boolean variable returns false then alert box pops up
            {
                MessageBox.Show("Please select at least one service", "Select Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            // Second Radio Button
            float totalHairCutRate = hairCutRate;       // final value variable

            if (radioButton6.Checked)
            {
                totalHairCutRate = hairCutRate - (hairCutRate / 100) * 0;           // deducting price from the total value as per the client status by discount
            }                                                                       // it can be student, senior citizen, child, adult

            else if (radioButton7.Checked)
            {
                totalHairCutRate = hairCutRate - (hairCutRate / 100) * 10;
            }

            else if (radioButton8.Checked)
            {
                totalHairCutRate = hairCutRate - (hairCutRate / 100) * 5;
            }

            else if (radioButton9.Checked)
            {
                totalHairCutRate = hairCutRate - (hairCutRate / 100) * 15;
            }

            // Number of Visits
            
            int clientVisits;

            if (!Int32.TryParse(textBox1.Text, out clientVisits) || clientVisits <=0)           // check if the entered input is positive integer or not 
            {
                MessageBox.Show("Please enter any integer", "Invalid Inpt !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                label5.Text = "$ 0";
            }
            else if (textBox1.Text == "")                                                  // check if it is empty then prompt user to enter to enter value
            {
                MessageBox.Show("Please enter some integer", "No Input !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                label5.Text = "$ 0";
            }
            if(clientVisits > 0)
            {
                if (clientVisits >= 1 && clientVisits <= 3)                             // deducting the price as per the client's visits
                {
                    totalHairCutRate = totalHairCutRate - (totalHairCutRate / 100) * 0;
                    label5.Text = "$" + totalHairCutRate.ToString();                        // updating the text section to final price
                }
                else if (clientVisits >= 4 && clientVisits <= 8)
                {
                    totalHairCutRate = totalHairCutRate - (totalHairCutRate / 100) * 5;
                    label5.Text = "$" + totalHairCutRate.ToString();
                }

                else if (clientVisits >= 9 && clientVisits <= 13)
                {
                    totalHairCutRate = totalHairCutRate - (totalHairCutRate / 100) * 10;
                    label5.Text = "$" + totalHairCutRate.ToString();
                }

                else if (clientVisits >= 14)
                {
                    totalHairCutRate = totalHairCutRate - (totalHairCutRate / 100) * 15;
                    label5.Text = "$" + totalHairCutRate.ToString();
                }

                
            }

        }



        private void Clear_Button_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;                        // by intializing everything to false all radio buttons and check boxes will be unchecked
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

            label5.Text = "$ 0";
            textBox1.Text = "";
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();                           // this will close the window
        }




        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void Dresser_Box_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
