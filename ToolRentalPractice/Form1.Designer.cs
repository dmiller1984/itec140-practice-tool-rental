namespace ToolRentalPractice
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            picTool = new PictureBox();
            txtDays = new TextBox();
            txtTotalCharge = new TextBox();
            txtDiscountDays = new TextBox();
            txtDailyRate = new TextBox();
            btnCalculate = new Button();
            lblError = new Label();
            lblNote = new Label();
            lblDaysrented = new Label();
            lblDaysdiscount = new Label();
            lblPriceday = new Label();
            lblTotalcharge = new Label();
            ((System.ComponentModel.ISupportInitialize)picTool).BeginInit();
            SuspendLayout();
            // 
            // picTool
            // 
            picTool.Image = (Image)resources.GetObject("picTool.Image");
            picTool.Location = new Point(287, 36);
            picTool.Name = "picTool";
            picTool.Size = new Size(180, 130);
            picTool.SizeMode = PictureBoxSizeMode.Zoom;
            picTool.TabIndex = 0;
            picTool.TabStop = false;
            // 
            // txtDays
            // 
            txtDays.Location = new Point(143, 36);
            txtDays.Name = "txtDays";
            txtDays.Size = new Size(100, 23);
            txtDays.TabIndex = 1;
            // 
            // txtTotalCharge
            // 
            txtTotalCharge.Enabled = false;
            txtTotalCharge.Location = new Point(143, 253);
            txtTotalCharge.Name = "txtTotalCharge";
            txtTotalCharge.Size = new Size(100, 23);
            txtTotalCharge.TabIndex = 2;
            // 
            // txtDiscountDays
            // 
            txtDiscountDays.Location = new Point(143, 170);
            txtDiscountDays.Name = "txtDiscountDays";
            txtDiscountDays.Size = new Size(100, 23);
            txtDiscountDays.TabIndex = 3;
            // 
            // txtDailyRate
            // 
            txtDailyRate.Location = new Point(143, 91);
            txtDailyRate.Name = "txtDailyRate";
            txtDailyRate.Size = new Size(100, 23);
            txtDailyRate.TabIndex = 4;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(88, 326);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(75, 23);
            btnCalculate.TabIndex = 5;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(106, 394);
            lblError.Name = "lblError";
            lblError.Size = new Size(38, 15);
            lblError.TabIndex = 6;
            lblError.Text = "label1";
            // 
            // lblNote
            // 
            lblNote.Location = new Point(12, 491);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(244, 50);
            lblNote.TabIndex = 7;
            lblNote.Text = "label2";
            // 
            // lblDaysrented
            // 
            lblDaysrented.AutoSize = true;
            lblDaysrented.Location = new Point(29, 39);
            lblDaysrented.Name = "lblDaysrented";
            lblDaysrented.Size = new Size(75, 15);
            lblDaysrented.TabIndex = 8;
            lblDaysrented.Text = "Days Rented:";
            // 
            // lblDaysdiscount
            // 
            lblDaysdiscount.AutoSize = true;
            lblDaysdiscount.Location = new Point(25, 178);
            lblDaysdiscount.Name = "lblDaysdiscount";
            lblDaysdiscount.Size = new Size(98, 15);
            lblDaysdiscount.TabIndex = 9;
            lblDaysdiscount.Text = "Discounted Days:";
            // 
            // lblPriceday
            // 
            lblPriceday.AutoSize = true;
            lblPriceday.Location = new Point(25, 99);
            lblPriceday.Name = "lblPriceday";
            lblPriceday.Size = new Size(79, 15);
            lblPriceday.TabIndex = 10;
            lblPriceday.Text = "Price per Day:";
            // 
            // lblTotalcharge
            // 
            lblTotalcharge.AutoSize = true;
            lblTotalcharge.Location = new Point(25, 261);
            lblTotalcharge.Name = "lblTotalcharge";
            lblTotalcharge.Size = new Size(77, 15);
            lblTotalcharge.TabIndex = 11;
            lblTotalcharge.Text = "Total Charge:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 628);
            Controls.Add(lblTotalcharge);
            Controls.Add(lblPriceday);
            Controls.Add(lblDaysdiscount);
            Controls.Add(lblDaysrented);
            Controls.Add(lblNote);
            Controls.Add(lblError);
            Controls.Add(btnCalculate);
            Controls.Add(txtDailyRate);
            Controls.Add(txtDiscountDays);
            Controls.Add(txtTotalCharge);
            Controls.Add(txtDays);
            Controls.Add(picTool);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tool Rental Discount — Practice";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picTool).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picTool;
        private TextBox txtDays;
        private TextBox txtTotalCharge;
        private TextBox txtDiscountDays;
        private TextBox txtDailyRate;
        private Button btnCalculate;
        private Label lblError;
        private Label lblNote;
        private Label lblDaysrented;
        private Label lblDaysdiscount;
        private Label lblPriceday;
        private Label lblTotalcharge;
    }
}
