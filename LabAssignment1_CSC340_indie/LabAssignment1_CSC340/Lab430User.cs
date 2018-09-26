using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabAssignment1_CSC340
{
    public partial class Lab430User : Form
    {
        List<Button> buttons = new List<Button>();
        List<Lab> labList = new List<Lab>();
        public Lab430User()
        {
            //int lab = 1;
            InitializeComponent();

            labList = Lab.retrieveLabStatus();

            //InitializeComponent();
            collectButtons();
            collectButtons2();
            //foreach (Lab l in labList)
            //{
            //    Console.WriteLine(l.times);
            //}

            //   labList = re
            textBox1.Text += labList[0].times;
            //date time test
            DateTime thisDay = DateTime.Today;
            DateTime timeOfDay = DateTime.Now;
            int start = labList[0].times.IndexOf("_") + 1;
            int start2 = labList[0].times.IndexOf("-") + 1;
            string time = labList[0].times.Substring(start, labList[0].times.IndexOf("-") - 3);//" \n  " + (timeOfDay.ToString());
            int n = labList[0].times.LastIndexOf(" ");
            string time2 = labList[0].times.Substring(start2, n - start2);
            int grr = timeOfDay.ToString().IndexOf(" ") + 1;
            int grrrr = timeOfDay.ToString().LastIndexOf(":");
            String currentTime = timeOfDay.ToString().Substring(grr, grrrr - grr);
            string MorP = timeOfDay.ToString().Substring(timeOfDay.ToString().IndexOf("M") - 1);


            if (labList[0].times.IndexOf(thisDay.ToString("D")[0]) != -1)
            {
                //checks if it's am or pm
                if (labList[0].times.Substring(labList[0].times.IndexOf(" ") + 1) == MorP && MorP == "AM")
                {
                    //checks hours
                    if ((Convert.ToInt32(time.Substring(0, time.IndexOf(":") - 1)) <= Convert.ToInt32(currentTime.Substring(0, currentTime.IndexOf(":") - 1))
                    && Convert.ToInt32(time2.Substring(0, time2.IndexOf(":") - 1)) > Convert.ToInt32(currentTime.Substring(0, currentTime.IndexOf(":") - 1))))
                    {
                        textBox1.BackColor = Color.Red;
                    }
                    else
                    {
                        textBox1.BackColor = Color.LimeGreen;
                    }
                }
                else if (labList[0].times.Substring(labList[0].times.IndexOf(" ") + 1) == MorP && MorP == "PM")
                {
                    if ((Convert.ToInt32(time.Substring(0, time.IndexOf(":"))) <= Convert.ToInt32(currentTime.Substring(0, currentTime.IndexOf(":")))
                    && Convert.ToInt32(time2.Substring(0, time2.IndexOf(":"))) > Convert.ToInt32(currentTime.Substring(0, currentTime.IndexOf(":"))))
                    || (Convert.ToInt32(time.Substring(0, time.IndexOf(":"))) == 12) && Convert.ToInt32(currentTime.Substring(0, currentTime.IndexOf(":"))) < Convert.ToInt32(time2.Substring(0, time2.IndexOf(":"))))
                    {
                        textBox1.BackColor = Color.Red;
                    }
                    else
                    {
                        textBox1.BackColor = Color.LimeGreen;
                    }
                }
                else
                {
                    textBox1.BackColor = Color.LimeGreen;
                }
            }
            else
            {
                //available
                textBox1.BackColor = Color.LimeGreen;
            }
        }
        private void collectButtons()
        {
            foreach (Control c in this.Controls)
            {
                Button b = c as Button;
                if (b != null)
                {
                    buttons.Add(b);
                    b.Click += button_Click;
                }
            }
        }

        public void collectButtons2()
        {
            int stat;
            foreach (Button b in buttons)
            {
                if (b.Text != "Refresh" && b.Text != "Simulate login" && b.Text != "SImulate log out" && b.Text != "Random login" && b.Text != "Random log out" && b.Text != "Return to Main Menu")
                {
                    //int eh = Convert.ToInt32(b.Text.ToString());
                    int ee = 0;
                    int cId = int.Parse(b.Text);
                    stat = Lab.retreivelabComputerStatus(cId, 1);
                    if (stat == 1)
                    {
                        b.BackColor = Color.Red;
                    }
                    else
                    {
                        b.BackColor = Color.LimeGreen;
                    }
                }
            }
        }

        private static void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "Refresh")
            {
                ActiveForm.Visible = false;
                //Lab430.ActiveForm.ShowDialog();
                Lab430User frmsecond = new Lab430User();
                frmsecond.ShowDialog();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            //label4.Text = labList[0].times;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //for (int i = 1; i < 9; i++)
            //{
            //    textBox1.Text += labList[i-1].times + "\n";
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)//refresh button
        {
            //collectButtons();
            //collectButtons2();
            ActiveForm.Visible = false;
            //Lab430.ActiveForm.ShowDialog();
            Lab430 frmsecond = new Lab430();
            frmsecond.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button22_Click_1(object sender, EventArgs e)
        {
        }

        private void button22_Click_2(object sender, EventArgs e)
        {
            ActiveForm.Visible = false;
            //Lab430.ActiveForm.ShowDialog();
           UserTesterOption frmsecond = new UserTesterOption();
            frmsecond.ShowDialog();
        }
    }
}
