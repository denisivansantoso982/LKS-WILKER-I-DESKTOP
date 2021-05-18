using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_04
{
    public partial class Splash : Form
    {
        int loading;

        public Splash()
        {
            InitializeComponent();
            this.BackColor = ColourModel.primary;
            panel1.Width = 0;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            loading += 5;

            panel1.Width = loading;

            if (panel1.Width >= 1050)
            {
                timer.Stop();
                Login login = new Login();
                login.Show();
                this.Hide();
            } else
            {

            }

        }
    }
}
