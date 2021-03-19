using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_04
{
    public partial class BookingDetail : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dtCheck;

        public BookingDetail()
        {
            InitializeComponent();
            this.BackColor = ColourModel.primary;
        }

        void doCheckIn()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                adapter = new SqlDataAdapter("select * from booking inner join tamu on booking.nik_tamu = tamu.id where tamu.email = '" + textBoxEmail.Text + "' and booking.tgl_check_in = '" + dateTimePickerCheckIn.Value.Date + "'", connection);
                dtCheck = new DataTable();
                adapter.Fill(dtCheck);

                if (dtCheck.Rows.Count < 1)
                {
                    MessageBox.Show("Data booking tidak ditemukan! Harap booking terlebih dahulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridCheckBooking.DataSource = null;
                }
                else
                {
                    gridCheckBooking.DataSource = dtCheck;
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BookingDetail_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Harap diisi form diatas!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                doCheckIn();
            }
        }
    }
}
