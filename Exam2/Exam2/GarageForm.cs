using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

/// <summary>
/// Developer:  Frankie Barrios
/// Date:       10/11/2018
/// Purpose:    Parking Garage Midterm Project
/// </summary>

namespace Exam2
{
    public partial class GarageForm : Form
    {
        private DateTime btn1Click;

        public GarageForm()
        {
            InitializeComponent();
            fullLbl.Visible = false;
            thankLbl.Visible = false;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Clear previous textbox entries upon click
            int hours;
            double totalCharge = 0;
            btn1Click = DateTime.Now;
            //DateTime HoursParkedLater = btn1Click.AddHours(hours);



            ////Display time in time in box
            //timeInTxBx.Text = btn1Click.ToShortTimeString();

            //Entry Validation
            if(CustNameTxtBx.Text == "")
            {
                MessageBox.Show("Please Enter Your Full Name And Resubmit Form");
                return;
            }


            if (Int32.TryParse(hrsParkTxtBx.Text, out hours) == false)
            {
                MessageBox.Show("Please Enter A Valid Hour Entry");
                return;
            }//end of if

            //Minimum Charge
            if (hours <= 3)
            {
                totalCharge = 2;
                AmtDueTxtBx.Text = String.Format("{0:C}", totalCharge);

            }

            //Calculate charge for additional time over 3 hours
            else if (hours > 3 || hours < 17)
            {
                totalCharge += (hours - 3) * .5 + 2;

                //Maximum Charge Limiter
                if (totalCharge > 10)
                {
                    totalCharge = 10;
                }

                AmtDueTxtBx.Text = String.Format("{0:C}", totalCharge);
            }//end of if

            //Display Customer Name in Ticket Details
            tickNameTxtBx.Text = CustNameTxtBx.Text;

            //Display Hours Parked in Time Parked
            tickTimeTxtBx.Text = hrsParkTxtBx.Text + " hours";

            //Display time in time in box
            timeInTxBx.Text = btn1Click.ToShortTimeString();

            //Figures correct timeOut by adding hours parked
            DateTime TimeAtDepart = btn1Click.AddHours(Int32.Parse(hrsParkTxtBx.Text));
            timeOutTxBx.Text = TimeAtDepart.ToShortTimeString();

            //XML -- takes entered customer data and writes to XML file located in : C:\Users\barri\source\repos\Exam2\Exam2\bin\Debug       
            CustomerData customer = new CustomerData();
            customer.Name = CustNameTxtBx.Text;
            customer.hoursParked = int.Parse(hrsParkTxtBx.Text);
            customer.amtDue = AmtDueTxtBx.Text;
            customer.timeIn = timeInTxBx.Text;
            customer.timeOut = timeOutTxBx.Text;

            // Create and XmlSerializer to serialize the data to a file
            XmlSerializer xs = new XmlSerializer(typeof(CustomerData));

            using (FileStream fs = new FileStream("Tickets.xml", FileMode.Append))
            {
                xs.Serialize(fs, customer);
            }

        }//end of button1_click


        private void button2_Click(object sender, EventArgs e)
        {
            //Will display customer name in ticket details name section of form, hours parked in hours parked ticket box
            //and amount due taken from calculation from button1_click and dispaly in amount due ticket box here
            //Clears all boxes upon click
            AmtDueTxtBx.Clear();
            tickNameTxtBx.Clear();
            CustNameTxtBx.Clear();
            hrsParkTxtBx.Clear();
            tickTimeTxtBx.Clear();
            thankLbl.Visible = true;
            welcomeLbl.Visible = false;
            timeInTxBx.Clear();
            timeOutTxBx.Clear();

        }//end of button2_click


    }//end of class
}//end of solution
