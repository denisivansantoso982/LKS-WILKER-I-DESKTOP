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
    public partial class Login : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public Login()
        {
            InitializeComponent();
            this.BackColor = ColourModel.primary;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            } else if (e.KeyChar == (char) Keys.Enter)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            } else if (!checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (validation())
                {
                    connection = new SqlConnection(Connection.connectionString);
                    connection.Open();

                    string pass = Encryption.encryptData(textBox2.Text);

                    command = new SqlCommand("SELECT * FROM pegawai WHERE email = '" + textBox1.Text + "' AND password LIKE '" + pass + "'", connection);
                    reader = command.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        PegawaiModel.id = Convert.ToInt32(reader[0]);
                        PegawaiModel.nama = Convert.ToString(reader[1]);
                        PegawaiModel.email = Convert.ToString(reader[2]);
                        PegawaiModel.password = Convert.ToString(reader[3]);
                        PegawaiModel.level = Convert.ToInt32(reader[4]);

                        if (PegawaiModel.level == 1)
                        {
                            AdminLandingPage landing = new AdminLandingPage();
                            landing.Show();
                            this.Close();
                        } else
                        {
                            EmployeeLandingPage employee = new EmployeeLandingPage();
                            employee.Show();
                            this.Close();
                        }
                    } else
                    {
                        reader.Close();

                        command = new SqlCommand("SELECT * FROM tamu WHERE email = '" + textBox1.Text + "' AND password LIKE '" + pass + "'", connection);
                        reader = command.ExecuteReader();
                        reader.Read();

                        if (reader.HasRows)
                        {
                            GuestLandingPage guest = new GuestLandingPage();
                            guest.Show();
                            this.Close();
                        } else
                        {
                            MessageBox.Show("Pengguna tidak ditemukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }

                    connection.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Terjadi kesalahan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validation()
        {
            if (textBox1.TextLength < 1 || textBox2.TextLength < 1)
            {
                MessageBox.Show("Form harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (textBox2.TextLength < 8)
            {
                MessageBox.Show("Form password harus lebih dari 8 karakter!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
