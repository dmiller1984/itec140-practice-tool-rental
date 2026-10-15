using System.Diagnostics.Eventing.Reader;

namespace ToolRentalPractice
{
    public partial class Form1 : Form

    {

        int intDays = 0;
        decimal decDailyRate = 0;
        int intDiscountDays = 0;
        decimal decTotalCharge = 0;

        public Form1()
        {
            InitializeComponent();






        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {




            try
            {
                intDays = int.Parse(txtDays.Text);
                decDailyRate = decimal.Parse(txtDailyRate.Text);
                intDiscountDays = int.Parse(txtDiscountDays.Text);

                decTotalCharge = intDays * decDailyRate;

                if (intDays >= intDiscountDays)
                {
                    decTotalCharge = decTotalCharge * 0.90m;
                    lblNote.Text = "Long rental discount";
                }
                else
                {
                    lblNote.Text = "Standard rate";
                }

                txtTotalCharge.Text = decTotalCharge.ToString("C");
            }  

            catch (Exception ex)
            {
                lblError.Text = "Please enter valid numbers";
            }




        }
    }
}
