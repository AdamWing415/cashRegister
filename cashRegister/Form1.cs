using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;


namespace cashRegister
{
    /// <summary>
    /// Adam Wingert
    /// 25/2/2020
    /// Cash register
    /// </summary>
    public partial class Form1 : Form
    {
        // constant for my three products
        const double SOUL_PRICE = 6.99;
        const double DARK_SOUL_PRICE = 13.95;
        const double DIET_SOUL_PRICE = 7.99;

        //constant for tax rate
        const double TAXRATE = 0.13;

        //variable for subtotal, tax, total, tendered, change, and order number
        double subtotal, tax, total, tendered, change;
        int orderNumber = 1;
        

       

        public Form1()
        {
            InitializeComponent();
            
        }

       
        private void totalButton_Click(object sender, EventArgs e)
        {
            //stops an error if a text box is left blank
            if (soulInput.Text == "")
            {
                soulInput.Text = "0";
            }
            if (darkInput.Text == "")
            {
                darkInput.Text = "0";
            }
            if (dietInput.Text == "")
            {
                dietInput.Text = "0";
            }
            //tries to capture values contained in each input for product amount and calculate the subtotal, tax, and total
            try
            {
                subtotal = (SOUL_PRICE * Convert.ToInt16(soulInput.Text)) + (DARK_SOUL_PRICE * Convert.ToInt16(darkInput.Text)) + (DIET_SOUL_PRICE * Convert.ToInt16(dietInput.Text));
                subOutput.Text = subtotal.ToString("C");
                tax = subtotal * TAXRATE;
                taxOutput.Text = tax.ToString("C");
                total = subtotal + tax;
                totalOutput.Text = total.ToString("C");
            }
            //if a value isn't valid, it prints an error message and resets the text boxes
            catch
            {
                soulInput.ResetText();
                darkInput.ResetText();
                dietInput.ResetText();
                receiptLabel.Text = "The values inputted are incorrect";
            }
        }
        private void changeButton_Click(object sender, EventArgs e)
        {
            //tries to capture tendered amount and calculate change owed 
            try
            {
                tendered = Convert.ToDouble(tenderedInput.Text);
                change = tendered - total;
                changeOutput.Text = change.ToString("C");
            }
            //if a value is incorrect, it resets text and outputs an error message
            catch
            {
                tenderedInput.ResetText();
                receiptLabel.Text = "The values inputted are incorrect";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //adds and plays my sound
            SoundPlayer chaChing = new SoundPlayer(Properties.Resources.Cha_Ching);
            chaChing.Play();
            receiptLabel.ResetText();
            receiptTop.ResetText();
            rightReceipt.ResetText();

            //writes my header text in my top text box with pauses between each line
            receiptTop.Text = ($"Ye Olde Soule Shoppe \n");
            receiptTop.Refresh();
            Thread.Sleep(500);

            receiptTop.Text += ($"Order Number: {orderNumber} \n  ");
            receiptTop.Refresh();
            Thread.Sleep(500);

            receiptTop.Text += ($"{DateTime.Now.ToString("dd / mm / yyyy")} \n \n ");
            receiptTop.Refresh();
            Thread.Sleep(500);

            //prints my main receipt text on both the right and left sides using 2 labels for allignment.  also has pauses between lines
            receiptLabel.Text += ($"Souls               x{soulInput.Text}");
            rightReceipt.Text += ($"@  ${SOUL_PRICE}\n");
            receiptLabel.Refresh();
            rightReceipt.Refresh();
            Thread.Sleep(500);

            receiptLabel.Text += ($"\nDark Souls      x {darkInput.Text}\n");
            rightReceipt.Text += ($"@  ${DARK_SOUL_PRICE}\n");
            receiptLabel.Refresh();
            rightReceipt.Refresh();
            Thread.Sleep(500);

            receiptLabel.Text += ($"Diet Souls       x{dietInput.Text}");
            rightReceipt.Text += ($"@   ${DIET_SOUL_PRICE}\n\n");
            receiptLabel.Refresh();
            rightReceipt.Refresh();
            Thread.Sleep(500);

            receiptLabel.Text += ($"\n\nSubtotal\n");
            rightReceipt.Text += ($"{subtotal.ToString("C")}\n");
            receiptLabel.Refresh();
            rightReceipt.Refresh();
            Thread.Sleep(500);

            receiptLabel.Text += ($"Tax\n");
            rightReceipt.Text += ($"{tax.ToString("C")}\n");
            receiptLabel.Refresh();
            rightReceipt.Refresh(); Thread.Sleep(500);

            receiptLabel.Text += ($"Total");
            rightReceipt.Text += ($"{total.ToString("C")}\n \n");
            receiptLabel.Refresh();
            rightReceipt.Refresh(); Thread.Sleep(500);

            receiptLabel.Text += ($"\n\nTendered\n");
            rightReceipt.Text += ($"{tendered.ToString("C")}\n ");
            receiptLabel.Refresh();
            rightReceipt.Refresh(); Thread.Sleep(500);

            receiptLabel.Text += ($"Change");
            rightReceipt.Text += ($"{change.ToString("C")}");
            receiptLabel.Refresh();
            rightReceipt.Refresh(); Thread.Sleep(500);
        }
    private void newOrderButton_Click(object sender, EventArgs e)
        {
            //adds a new ound to be used later
            SoundPlayer crumple = new SoundPlayer(Properties.Resources.paper_rustle_1);
            //resets all my text boxes and variabes that need reseting
            receiptLabel.ResetText();
            receiptTop.ResetText();
            rightReceipt.ResetText();
            soulInput.ResetText();
            darkInput.ResetText();
            dietInput.ResetText();
            subOutput.ResetText();
            taxOutput.ResetText();
            totalOutput.ResetText();
            tenderedInput.ResetText();
            changeOutput.ResetText();
            subtotal = 0;
            tax = 0;
            total = 0;
            tendered = 0;
            change = 0;
            orderNumber++;

            //plays my paper crumple "animation" which uses magic to reuse the same receipt paper until the und of time,
            //just crumple, then flatten and you'll have a brand new piece of paper without killing another tree.
            receiptLabel.Hide();
            receiptTop.Hide();
            rightReceipt.Hide();
            crumple.Play();
            paper1.Show();
            paper2.Hide();
            Refresh();
            Thread.Sleep(750);
            paper1.Hide();
            paper2.Show();
            Refresh();
            Thread.Sleep(750);
            paper2.Hide();
            paper1.Show();
            Refresh();
            Thread.Sleep(750);
            paper1.Hide();
            paper3.Show();
            Refresh();
            Thread.Sleep(750);
            paper3.Hide();
            crumple.Stop();
            receiptTop.Show();
            rightReceipt.Show();
            receiptLabel.Show();
            Refresh();

        }
    } 
   
}
