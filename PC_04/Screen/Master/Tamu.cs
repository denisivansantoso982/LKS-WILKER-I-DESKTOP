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
    public partial class Tamu : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        SqlDataAdapter adapterRole;
        DataTable dtjenis;
        int id;

        public Tamu()
        {
            InitializeComponent();
        }

        void loadGridTamu()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                adapterRole = new SqlDataAdapter("SELECT * FROM tamu", connection);
                dtjenis = new DataTable();
                adapterRole.Fill(dtjenis);

                gridTamu.DataSource = dtjenis;

                gridTamu.Columns[6].Visible = false;

                gridTamu.Columns[0].HeaderText = "ID";
                gridTamu.Columns[1].HeaderText = "NIK";
                gridTamu.Columns[2].HeaderText = "Nama";
                gridTamu.Columns[3].HeaderText = "Email";
                gridTamu.Columns[4].HeaderText = "No. HP";
                gridTamu.Columns[5].HeaderText = "Alamat";

                gridTamu.Columns[1].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridTamu.Columns[4].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                gridTamu.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.UseSystemPasswordChar = false;
                textBox5.UseSystemPasswordChar = false;
            } else
            {
                textBox4.UseSystemPasswordChar = true;
                textBox5.UseSystemPasswordChar = true;
            }
        }
        
        void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text= "";
            textBox4.Text= "";
            textBox5.Text= "";
            textBox6.Text= "";
            richTextBox.Text= "";
            id = 0;
            hideButton();
        }

        void showButton()
        {
            button3.Visible = true;
            button4.Visible = true;
        }

        void hideButton()
        {
            button3.Visible = false;
            button4.Visible = false;
        }

        private void gridTamu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(gridTamu.SelectedRows[0].Cells[0].Value);
            textBox1.Text = Convert.ToString(gridTamu.SelectedRows[0].Cells[1].Value);
            textBox2.Text = Convert.ToString(gridTamu.SelectedRows[0].Cells[2].Value);
            textBox3.Text = Convert.ToString(gridTamu.SelectedRows[0].Cells[3].Value);
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = Convert.ToString(gridTamu.SelectedRows[0].Cells[4].Value);

            richTextBox.Text = Convert.ToString(gridTamu.SelectedRows[0].Cells[5].Value);

            showButton();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            loadGridTamu();
            DataView dataView = new DataView(dtjenis);
            dataView.RowFilter = String.Format("nama LIKE '%{0}%' OR email LIKE '%{0}%' OR nohp LIKE '%{0}%' OR alamat LIKE '%{0}%'", textBoxFilter.Text);
            gridTamu.DataSource = dataView;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                this.Close();
            } else
            {
                reset();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                if (validation())
                {
                    string pass = Encryption.encryptData(textBox5.Text);

                    command = new SqlCommand("INSERT INTO tamu VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox6.Text + "', '" + richTextBox.Text + "', '" + pass + "')", connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data tamu berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }

                connection.Close();

                loadGridTamu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool validation()
        {
            if (textBox1.TextLength < 1)
            {
                MessageBox.Show("NIK harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox2.TextLength < 1)
            {
                MessageBox.Show("Nama harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox4.TextLength < 1)
            {
                MessageBox.Show("Password harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox5.TextLength < 1)
            {
                MessageBox.Show("Password harus diisi kembali!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox3.TextLength < 1)
            {
                MessageBox.Show("Email harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(textBox6.TextLength < 1)
            {
                MessageBox.Show("Nomor Telepon harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (richTextBox.TextLength < 1)
            {
                MessageBox.Show("Alamat harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Konfirmasi password harus sama dengan password!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (checkSimilarNIK() == false)
            {
                MessageBox.Show("NIK telah digunakan!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (checkSimilarEmail() == false)
            {
                MessageBox.Show("Email telah digunakan!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        bool validationUpdate()
        {
            if (textBox1.TextLength < 1)
            {
                MessageBox.Show("NIK harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox2.TextLength < 1)
            {
                MessageBox.Show("Nama harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox3.TextLength < 1)
            {
                MessageBox.Show("Email harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox6.TextLength < 1)
            {
                MessageBox.Show("Nomor Telepon harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (richTextBox.TextLength < 1)
            {
                MessageBox.Show("Alamat harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (checkSimilarNIK() == false)
            {
                MessageBox.Show("NIK telah digunakan!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (checkSimilarEmail() == false)
            {
                MessageBox.Show("Email telah digunakan!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        bool checkSimilarEmail()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                command = new SqlCommand("SELECT * FROM pegawai WHERE email = '" + textBox3.Text + "'", connection);
                reader = command.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    reader.Close();
                    connection.Close();
                    return false;
                }
                else
                {
                    reader.Close();

                    command = new SqlCommand("SELECT * FROM tamu WHERE email = '" + textBox3.Text + "'", connection);
                    reader = command.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        reader.Close();
                        connection.Close();
                        return false;
                    }

                    reader.Close();
                    connection.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        bool checkSimilarNIK()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                command = new SqlCommand("SELECT * FROM tamu WHERE nik = '" + textBox1.Text + "'", connection);
                reader = command.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    reader.Close();
                    connection.Close();
                    return false;
                }

                reader.Close();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                if (validationUpdate())
                {
                    DialogResult dialog = MessageBox.Show("Apakah and yakin ingin mengubah data tamu ini?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.Yes)
                    {
                        command = new SqlCommand("UPDATE tamu SET nik=" + Convert.ToInt32(textBox1.Text) + ", nama = '" + textBox2.Text + "', email = '" + textBox3.Text + "', nohp = '" + textBox6.Text + "', alamat='" + richTextBox.Text + "' WHERE id = " + id, connection);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Data tamu berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }

                connection.Close();

                loadGridTamu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                DialogResult dialog = MessageBox.Show("Apakah and yakin ingin menghapus data tamu ini?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    command = new SqlCommand("DELETE FROM tamu WHERE id = " + id, connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data tamu berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }

                connection.Close();

                loadGridTamu();
            }
            catch (Exception)
            {
                MessageBox.Show("Terjadi kesalahan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tamu_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void Tamu_Load(object sender, EventArgs e)
        {
            loadGridTamu();
        }
    }
}
