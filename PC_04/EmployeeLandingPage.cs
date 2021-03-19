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
    public partial class EmployeeLandingPage : Form
    {
        public EmployeeLandingPage()
        {
            InitializeComponent();
            labelTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            string[] name = PegawaiModel.nama.Split(' ');
            labelName.Text = name[0];
            this.BackColor = ColourModel.primary;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Apakah and yakin?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Apakah and yakin?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.Yes)
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Booking booking = new Booking();
            booking.ShowDialog();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            BookingDetail detail = new BookingDetail();
            detail.ShowDialog();
        }
    }
}
