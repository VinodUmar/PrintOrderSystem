using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintOrderingSystem
{
    public partial class OrderPrints2 : Form
    {
        public OrderPrints2()
        {
            InitializeComponent();
            qty4X6Matte.Enabled = false;
            qty4X6Glossy.Enabled = false;
            qty5X7Matte.Enabled = false;
            qty5X7Glossy.Enabled = false;
            qty8X10Matte.Enabled = false;
            qty8X10Glossy.Enabled = false;
            radNextDay.Checked = true;
            totalPrice.Text = "$ 0.00";


        }

        private void paperSizeCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chk4X6Glossy_CheckedChanged(object sender, EventArgs e)
        {

            qty4X6Glossy.Value = 0;
            totalPrice.Text = "$ 0.00";
            

            if (chk4X6Glossy.Checked)
                qty4X6Glossy.Enabled = true;
            else
                qty4X6Glossy.Enabled = false;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void chk4X6Matte_CheckedChanged(object sender, EventArgs e)
        {
            qty4X6Matte.Value = 0;
            totalPrice.Text = "$ 0.00";

            if (chk4X6Matte.Checked) {
                qty4X6Matte.Enabled = true;
        }
            else
                qty4X6Matte.Enabled=false;
        }

        private void OrderPrints2_Load(object sender, EventArgs e)
        {

        }

        private void chk5X7Matte_CheckedChanged(object sender, EventArgs e)
        {
            qty5X7Matte.Value = 0;
            totalPrice.Text = "$ 0.00";

            if (chk5X7Matte.Checked)
            {
                qty5X7Matte.Enabled = true;
            }
            else
                qty5X7Matte.Enabled = false;

        }

        private void chk5X7Glossy_CheckedChanged(object sender, EventArgs e)
        {
            qty5X7Glossy.Value = 0;
            totalPrice.Text = "$ 0.00";

            if (chk5X7Glossy.Checked)
            {
                qty5X7Glossy.Enabled = true;
            }
            else
                qty5X7Glossy.Enabled = false;

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chk8X10Matte_CheckedChanged(object sender, EventArgs e)
        {
            qty8X10Matte.Value = 0;
            totalPrice.Text = "$ 0.00";

            if (chk8X10Matte.Checked)
            {
                qty8X10Matte.Enabled = true;
            }
            else
                qty8X10Matte.Enabled = false;

        }

        private void chk8X10Glossy_CheckedChanged(object sender, EventArgs e)
        {
            qty8X10Glossy.Value = 0;
            totalPrice.Text = "$ 0.00";

            if (chk8X10Glossy.Checked)
            {
                qty8X10Glossy.Enabled = true;
            }
            else
                qty8X10Glossy.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            int count = 0;
            Boolean bol4X6Matte =false;
            Boolean bol4X6Glossy =false;
            Boolean bol5X7Matte =false;
            Boolean bol5X7Glossy =false;
            Boolean bol8X10Matte =false;
            Boolean bol8X10Glossy =false;


            total = qty4X6Matte.Value + qty4X6Glossy.Value + qty5X7Matte.Value + qty5X7Glossy.Value + qty8X10Matte.Value
                + qty8X10Glossy.Value;
            
            if (qty4X6Matte.Value>0) {bol4X6Matte =true; count ++;}
            if (qty4X6Glossy.Value>0) {bol4X6Glossy =true; count ++;}
            if (qty5X7Matte.Value>0) {bol5X7Matte =true; count ++;}
            if (qty5X7Glossy.Value>0) {bol5X7Glossy =true; count ++;}
            if (qty8X10Matte.Value>0) {bol8X10Matte =true; count ++;}
            if (qty8X10Glossy.Value>0) {bol8X10Glossy =true; count ++;}


            
            if (total <= 0)
            {
                MessageBox.Show("Select atleast one Print greater than Zero.",
                       "Critical Warning",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1
                       );
            }
            else if (total > 100)
            {
                MessageBox.Show("Total prints can't be more than 100",
                       "Critical Warning",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1
                      );

            }
            else
            {
                decimal totOrdValue = 0;


                if (count == 1)
                {

                    if (bol4X6Matte) { totOrdValue = Calculate4x6(qty4X6Matte.Value, "Matte"); }
                    if (bol4X6Glossy) { totOrdValue = Calculate4x6(qty4X6Glossy.Value, "Glossy"); }
                    if (bol5X7Matte) { totOrdValue = Calculate5x7(qty5X7Matte.Value, "Matte"); }
                    if (bol5X7Glossy) { totOrdValue = Calculate5x7(qty5X7Glossy.Value, "Glossy"); }
                    if (bol8X10Matte) { totOrdValue = Calculate8X10(qty8X10Matte.Value, "Matte"); }
                    if (bol8X10Glossy) { totOrdValue = Calculate8X10(qty8X10Glossy.Value, "Glossy"); }

                    if (radOneHour.Checked)
                    {
                        if (total <= 60)
                        {
                            totOrdValue += 1;
                        }
                        else
                        {
                            totOrdValue += (decimal)1.5;
                        }
                    }

                    if (!promoCodeTextBox.Text.Equals("") && !promoCodeTextBox.Text.Equals("N56M2"))
                    {
                        MessageBox.Show("The promo code you have entered is invalid.",
                       "Critical Warning",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1
                      );
                    }
                    if (promoCodeTextBox.Text.Equals("N56M2") && total == 100)
                    {
                        totOrdValue -= (decimal)2;
                    }
                    else if (totOrdValue > 35)
                    {
                        totOrdValue = totOrdValue - totOrdValue * (decimal).05;
                        //totOrdValue = totOrdValue - totOrdValue * (decimal).0555; //Fault 3
                    }


                }

                else
                {

                    totOrdValue = calculate4X6Glossy()
                        + calculate4X6Matte()
                        + calculate5X7Glossy()
                        + calculate5X7Matte()
                        + calculate8X10Glossy()
                        + calculate8X10Matte();

                    if (radOneHour.Checked)
                    {
                        if (total <= 60)
                        {
                            totOrdValue += 2;
                        }
                        else
                        {
                            totOrdValue += (decimal)2.5;
                        }
                    }

                    /*    MessageBox.Show("Total " + totOrdValue,
                               "Critical Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1
                              );
                        */

                    if (totOrdValue > 35) totOrdValue = totOrdValue - totOrdValue * (decimal).05;

                }
                //totalPrice.Text = "$" + totOrdValue.ToString(); //Fault 1
                totalPrice.Text = "$" + Math.Round(totOrdValue, 2).ToString();
                
            }


        }



        private decimal calculate4X6Matte()
        {

            return qty4X6Matte.Value * (decimal)0.23 ;
        }

        private decimal calculate4X6Glossy()
        {

            return qty4X6Glossy.Value * (decimal)0.19 ;
        }
        
        private decimal calculate5X7Matte()
        {

            return qty5X7Matte.Value * (decimal)0.45;
        }

        private decimal calculate5X7Glossy()
        {

            return qty5X7Glossy.Value * (decimal)0.39 ;
        }

        private decimal calculate8X10Matte()
        {

            return qty8X10Matte.Value * (decimal)0.87;
        }

        private decimal calculate8X10Glossy()
        {

            return qty8X10Glossy.Value * (decimal)0.79;
        }



        private decimal Calculate4x6(decimal printOrd, String finish)
        {
            /* 3.2.1.1       Prices for size 4 x 6 are:
            3.2.1.1.1        First 1 – 50 prints: $ 0.14 each
            3.2.1.1.2        Prints after 50 and before or equal 75 - $ 0.12
            3.2.1.1.3        Prints after 75 and before or equal 100 - $ 0.10
                             If Matte: 0.02 for each print 4 x 6 size
             */

            decimal tQ = printOrd;
            decimal totValue = 0;

            if (tQ > 0 && tQ < 51)
            {
                totValue = tQ * (decimal)0.14;
            }

            //if (tQ > 0 && tQ < 56) //Fault 2
            //{
            //    totValue = tQ * (decimal)0.14;
            //}

            //if (tQ > 56 && tQ < 76) //Fault 2
            //{
            //    totValue = tQ * (decimal)0.12;
            //}

            if (tQ > 50 && tQ < 76)
            {
                totValue = tQ * (decimal)0.12;
            }

            if (tQ > 75 && tQ < 101)
            {
                totValue = tQ * (decimal)0.10;
            }

            if (finish == "Matte") //If Matte finish is chosen, add 0.02 for each print.
            {
                decimal additionalCharge = tQ * (decimal)0.02;
                totValue += additionalCharge;
            }

            return totValue;


        }

        private decimal Calculate5x7(decimal printOrd, String finish)
        {
            /* 
                3.2.1.2  Prices for size 5 x 7 are:
                3.2.1.2.1        First 1 – 50 prints: $ 0.34 each
                3.2.1.2.2        Prints after 50 and before or equal 75 - $ 0.31
                3.2.1.2.3        Prints after 75 and before or equal 100 - $ 0.28
                If Matte: 0.03 for each print 5 x 7 size
             */

            decimal tQ = printOrd;
            decimal totValue = 0;

            if (tQ > 0 && tQ < 51)
            {
                totValue = tQ * (decimal)0.34;
            }

            if (tQ > 50 && tQ < 76)
            {
                totValue = tQ * (decimal)0.31;
            }

            if (tQ > 75 && tQ < 101)
            {
                totValue = tQ * (decimal)0.28;
            }

            if (finish == "Matte") //If Matte finish is chosen, add 0.02 for each print.
            {
                decimal additionalCharge = tQ * (decimal)0.03;
                totValue += additionalCharge;
            }
            return totValue;

        }

        private decimal Calculate8X10(decimal printOrd, String finish)
        {
            /* 
                3.2.1.3  Prices for size 8 x 10 are:
                3.2.1.3.1        First 1 – 50 prints: $ 0.68 each
                3.2.1.3.2        Prints after 50 and before or equal 75 - $ 0.64
                3.2.1.3.3        Prints after 75 and before or equal 100 - $ 0.60
                If Matte: 0.04 for each print 5 x 7 size
             */

            decimal tQ = printOrd;
            decimal totValue = 0;

            if (tQ > 0 && tQ < 51)
            {
                totValue = tQ * (decimal)0.68;
            }

            if (tQ > 50 && tQ < 76)
            {
                totValue = tQ * (decimal)0.64;
            }

            if (tQ > 75 && tQ < 101)
            {
                totValue = tQ * (decimal)0.60;
            }

            if (finish == "Matte") //If Matte finish is chosen, add 0.02 for each print.
            {
                decimal additionalCharge = tQ * (decimal)0.04;
                totValue += additionalCharge;
            }

            return totValue;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}
