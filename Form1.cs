using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5A
{
    /*
  Author:    I Prerak Patel (000736376) 
             certify that I have done this work without anyone's help and I have not made my work available to any one else.
  Date:      December 25, 2017
  
   */

    /// <summary>
    /// Form Class 
    /// </summary>
    /// <param name="color">for storing brushing color</param>
    /// <param name="counter">for keeping track of the height how much water should be poured into the bucket</param>
    /// <param name="stopped">for checking whether the bucket is stopped or not</param>
    /// <param name="filled">for checking whether the bucket is filled or not</param>
    /// <param name="speedTracker">increasin or decreasing the speed of water falling from th faucet by using trackbar value as index</param>
    public partial class Form1 : Form
    {
        private Color color;
        private int counter;
        private bool stopped, filled;
        int[] speedTracker = { 1, 180, 160, 140, 120, 100, 80, 60, 40, 20, 10 };

        /// <summary>
        /// Form Method load on startup
        /// </summary>
        /// <param name="Paint">Keeping the Paint object always on</param>
        public Form1()
        {
            // stores color white in the color object by default
            color = Color.White;
            
            // And the counter to 1 as the bucket has no water in it
            counter = 1;

            // and the initially faucet is stopped and it is not filled
            // so declaring stopped variable as true and filled variable as false
            stopped = true; filled = false;

            // Initialzes all components of form designs
            InitializeComponent();

            // Keeps declaring Paint object and passes "paintingForm" as method argument
            Paint += new System.Windows.Forms.PaintEventHandler(paintingForm);

            // trackbar is set to 0 to say there is no water falling from the faucet initially
            trackBar1.Value = 0;

            // displaying the faucet image
            this.pictureBox1.Image = Image.FromFile("../Faucet.jpg");
        }

        /// <summary>
        /// Method which is invoked by Paint Class and drawing lines for the bucket
        /// </summary>
        private void paintingForm(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new System.Drawing.Pen(System.Drawing.Color.White), 100, 290, 100, 400);
            e.Graphics.DrawLine(new System.Drawing.Pen(System.Drawing.Color.White), 100, 400, 300, 400);
            e.Graphics.DrawLine(new System.Drawing.Pen(System.Drawing.Color.White), 300, 400, 300, 290);
        }
        /// <summary>
        /// colorButton clicked then show Dialogbox
        /// </summary>
        private void colorButon_click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                color = colorDialog1.Color;
        }
        /// <summary>
        /// close Button clicked to close the program
        /// </summary>
        private void close_Program(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// method invoked on trackbar scrolled in the program
        /// </summary>
        /// <param name="graphics">Inovkes the create graphics method to draw the graphics object </param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // invokes the method and stores as a Graphics object
            Graphics graphics = CreateGraphics();

            // condition returns true if the bucket is filled
            if (filled)
            {
                // draws the graphics Fill Rectangle object
                graphics.FillRectangle(new System.Drawing.SolidBrush(BackColor), 101, 200, 199, 200);

                // initializing the variable to false
                filled = false;
            }

            // condition returns true if the bucket is stopped
            if (stopped)
            {
                // starting the timer
                timer1.Start();

                // stopped is turned to false for further use
                stopped = false;
            }

            // if the bucket is not stopped then thecondition return true
            else
            {
                // if the trackbar value is greater than 0
                if (trackBar1.Value > 0)
                {
                    // setting interval from the speedTrackar array with trackbar value as index
                    timer1.Interval = speedTracker[trackBar1.Value];
                }

                // if the trackbar value is 0 then stop the faucet
                if (trackBar1.Value == 0)
                {
                    // setting time interval to 1 to stop the object
                    timer1.Interval = 1;

                    // stops the timer
                    timer1.Stop();

                    // turning the timer to true for further uses
                    stopped = true;

                    // generating rectangle with size 0
                    graphics.FillRectangle(new SolidBrush(BackColor), 110, 200, 15, 200 - counter + 1);
                }
            }
        }

        /// <summary>
        /// invokes everytime 
        /// </summary>
        /// <param name="graphics">Inovkes the create graphics method to draw the graphics object </param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // invokes the method and stores as a Graphics object
            Graphics graphics = CreateGraphics();

            // genreating Fill Rectangle with brush object as first argument, and coordinates to draw the rectangle
            graphics.FillRectangle(new SolidBrush(color), 101, 400 - counter, 199, 1);
            graphics.FillRectangle(new SolidBrush(color), 110, 200, 15, 200 - counter + 1);
            counter += 1;

            // height of the bucket reached
            if ((400 - counter) == 295)
            {
                // turning bucket filled to true
                filled = true;

                // turning faucet to stopped
                stopped = true;

                // stoping the timer
                timer1.Stop();

                // and counter to 0 for further use
                counter = 0;

                // And trackbar value to 0 as the faucet stopped
                trackBar1.Value = 0;

                // generating black rectangle for hiding future rectangle
                graphics.FillRectangle(new SolidBrush(BackColor), 110, 200, 15, 96);
            }
        }
    }
}

