namespace Lab3B
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hairDresser = new System.Windows.Forms.GroupBox();
            this.hairDresserDropDown = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectServiceList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chargedItemList = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.priceList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.calculate = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.total = new System.Windows.Forms.Label();
            this.hairDresser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // hairDresser
            // 
            this.hairDresser.Controls.Add(this.hairDresserDropDown);
            this.hairDresser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hairDresser.Location = new System.Drawing.Point(12, 12);
            this.hairDresser.Name = "hairDresser";
            this.hairDresser.Size = new System.Drawing.Size(213, 218);
            this.hairDresser.TabIndex = 0;
            this.hairDresser.TabStop = false;
            this.hairDresser.Text = "Select a HairDresser :";
            // 
            // hairDresserDropDown
            // 
            this.hairDresserDropDown.BackColor = System.Drawing.SystemColors.Menu;
            this.hairDresserDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hairDresserDropDown.FormattingEnabled = true;
            this.hairDresserDropDown.Items.AddRange(new object[] {
            "Jane Smaley",
            "Pat Johnson",
            "Ron Chambers",
            "Sue Pallon",
            "Laurie Renkins"});
            this.hairDresserDropDown.Location = new System.Drawing.Point(6, 32);
            this.hairDresserDropDown.Name = "hairDresserDropDown";
            this.hairDresserDropDown.Size = new System.Drawing.Size(201, 32);
            this.hairDresserDropDown.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectServiceList);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(231, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 218);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select a Service :";
            // 
            // selectServiceList
            // 
            this.selectServiceList.FormattingEnabled = true;
            this.selectServiceList.ItemHeight = 24;
            this.selectServiceList.Items.AddRange(new object[] {
            "Cut",
            "Wash, blow-dry, and style",
            "Colour",
            "Highlights",
            "Extensions",
            "Up-do"});
            this.selectServiceList.Location = new System.Drawing.Point(7, 32);
            this.selectServiceList.Name = "selectServiceList";
            this.selectServiceList.Size = new System.Drawing.Size(241, 172);
            this.selectServiceList.TabIndex = 7;
            this.selectServiceList.Click += new System.EventHandler(this.selectServiceListItem_Clicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chargedItemList);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(491, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 218);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Charged Items :";
            // 
            // chargedItemList
            // 
            this.chargedItemList.AllowDrop = true;
            this.chargedItemList.Enabled = false;
            this.chargedItemList.FormattingEnabled = true;
            this.chargedItemList.HorizontalScrollbar = true;
            this.chargedItemList.ImeMode = System.Windows.Forms.ImeMode.On;
            this.chargedItemList.ItemHeight = 24;
            this.chargedItemList.Location = new System.Drawing.Point(6, 32);
            this.chargedItemList.Name = "chargedItemList";
            this.chargedItemList.Size = new System.Drawing.Size(241, 172);
            this.chargedItemList.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.priceList);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(750, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(112, 204);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Price :";
            // 
            // priceList
            // 
            this.priceList.AllowDrop = true;
            this.priceList.Enabled = false;
            this.priceList.FormattingEnabled = true;
            this.priceList.HorizontalScrollbar = true;
            this.priceList.ItemHeight = 24;
            this.priceList.Location = new System.Drawing.Point(6, 28);
            this.priceList.Name = "priceList";
            this.priceList.Size = new System.Drawing.Size(99, 172);
            this.priceList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(622, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total Price";
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(692, 322);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(170, 41);
            this.exit.TabIndex = 6;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(516, 322);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(170, 41);
            this.reset.TabIndex = 7;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // calculate
            // 
            this.calculate.Enabled = false;
            this.calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculate.Location = new System.Drawing.Point(298, 322);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(212, 41);
            this.calculate.TabIndex = 8;
            this.calculate.Text = "Calculate Total Price";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // add
            // 
            this.add.Enabled = false;
            this.add.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Location = new System.Drawing.Point(122, 322);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(170, 41);
            this.add.TabIndex = 9;
            this.add.Text = "Add Service";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.addButton_Clicked);
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.Location = new System.Drawing.Point(752, 269);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(100, 24);
            this.total.TabIndex = 10;
            this.total.Text = "                  ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 375);
            this.Controls.Add(this.total);
            this.Controls.Add(this.add);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hairDresser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.hairDresser.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox hairDresser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox selectServiceList;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.ComboBox hairDresserDropDown;
        private System.Windows.Forms.ListBox priceList;
        private System.Windows.Forms.ListBox chargedItemList;
        private System.Windows.Forms.Label total;
    }
}

