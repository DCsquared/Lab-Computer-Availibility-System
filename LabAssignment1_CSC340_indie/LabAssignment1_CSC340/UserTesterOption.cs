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
    public partial class UserTesterOption : Form
    {
        public UserTesterOption()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Visible = false;
            //Lab430.ActiveForm.ShowDialog();
            Lab430User frmsecond = new Lab430User();
            frmsecond.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActiveForm.Visible = false;
            //Lab430.ActiveForm.ShowDialog();
            Lab430 frmsecond = new Lab430();
            frmsecond.ShowDialog();
        }
    }
}
