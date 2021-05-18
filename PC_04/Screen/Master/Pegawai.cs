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
    public partial class Pegawai : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        SqlDataAdapter adapterRole, adapterPegawai;
        DataTable dtRole, dtPegawai;
        int id;

        public Pegawai()
        {
            InitializeComponent();
            this.BackColor = ColourModel.primary;
            loadComboRole();
            loadGridPegawai();
            id = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void loadComboRole()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                adapterRole = new SqlDataAdapter("SELECT * FROM role", connection);
                dtRole = new DataTable();
                adapterRole.Fill(dtRole);

                comboBox1.DataSource = dtRole;
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "nama_role";

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            loadGridPegawai();
            DataView dataView = new DataView(dtPegawai);
            dataView.RowFilter = String.Format("nama LIKE '%{0}%' OR email LIKE '%{0}%'", textBoxFilter.Text);
            gridPegawai.DataSource = dataView;
        }

        void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedValue = 1;
            id = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                if (validation())
                {
                    string pass = Encryption.encryptData(textBox3.Text);

                    command = new SqlCommand("INSERT INTO pegawai VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + pass + "', " + comboBox1.SelectedValue + ")", connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data pegawai berhasil dimasukkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }

                connection.Close();

                loadGridPegawai();
            } catch (Exception)
            {
                MessageBox.Show("Terjadi kesalahan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        void loadGridPegawai()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                adapterRole = new SqlDataAdapter("SELECT * FROM pegawai INNER JOIN role ON pegawai.level = role.id", connection);
                dtPegawai = new DataTable();
                adapterRole.Fill(dtPegawai);

                gridPegawai.DataSource = dtPegawai;

                gridPegawai.Columns[3].Visible = false;
                gridPegawai.Columns[4].Visible = false;
                gridPegawai.Columns[5].Visible = false;

                gridPegawai.Columns[0].HeaderText = "ID";
                gridPegawai.Columns[1].HeaderText = "Nama";
                gridPegawai.Columns[2].HeaderText = "Email";
                gridPegawai.Columns[6].HeaderText = "Level";

                gridPegawai.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    DialogResult dialog = MessageBox.Show("Apakah and yakin ingin mengubah pegawai ini?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.Yes)
                    {
                        command = new SqlCommand("UPDATE pegawai SET nama = '" + textBox1.Text + "', email = '" + textBox2.Text + "', level = " + comboBox1.SelectedValue + " WHERE id = " + id, connection);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Data pegawai berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }

                connection.Close();

                loadGridPegawai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridPegawai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = gridPegawai.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = gridPegawai.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.SelectedValue = Convert.ToInt32(gridPegawai.SelectedRows[0].Cells[4].Value);
            id = Convert.ToInt32(gridPegawai.SelectedRows[0].Cells[0].Value);

            textBox3.Text = "";
            textBox4.Text = "";

            showButton();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                DialogResult dialog = MessageBox.Show("Apakah and yakin ingin menghapus pegawai ini?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    command = new SqlCommand("DELETE FROM pegawai WHERE id = " + id, connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data pegawai berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }

                connection.Close();

                loadGridPegawai();
            }
            catch (Exception)
            {
                MessageBox.Show("Terjadi kesalahan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
                textBox4.UseSystemPasswordChar = false;
            } else
            {
                textBox3.UseSystemPasswordChar = true;
                textBox4.UseSystemPasswordChar = true;
            }
        }

        private void Pegawai_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        bool validation()
        {
            if (textBox1.TextLength < 1)
            {
                MessageBox.Show("Nama harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (textBox2.TextLength < 1)
            {
                MessageBox.Show("Email harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if(textBox4.TextLength < 1)
            {
                MessageBox.Show("Password harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox3.TextLength < 1)
            {
                MessageBox.Show("Password harus diisi kembali!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Level harus dipilih!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Konfirmasi password harus sama dengan password!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        bool validationUpdate()
        {
            if (textBox1.TextLength < 1)
            {
                MessageBox.Show("Nama harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox2.TextLength < 1)
            {
                MessageBox.Show("Email harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Level harus dipilih!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
