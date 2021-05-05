using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_04
{
    public partial class AdminLandingPage : Form
    {
        public AdminLandingPage()
        {
            InitializeComponent();
            this.BackColor = ColourModel.primary;
            labelTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            string[] name = PegawaiModel.nama.Split(' ');
            labelName.Text = name[0];
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Pegawai pegawai = new Pegawai();
            pegawai.ShowDialog();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Kamar kamar = new Kamar();
            kamar.ShowDialog();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            JenisKamar jenisKamar = new JenisKamar();
            jenisKamar.ShowDialog();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Booking booking = new Booking();
            booking.ShowDialog();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            BookingDetail bookingDetail = new BookingDetail();
            bookingDetail.ShowDialog();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Apakah and yakin?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.Yes)
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Apakah and yakin?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            Tamu tamu = new Tamu();
            tamu.ShowDialog();
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }

        private void AdminLandingPage_Paint(object sender, PaintEventArgs e)
        {
            //GradientBackground.gradient(e, this.ClientRectangle);
        }
    }
}
