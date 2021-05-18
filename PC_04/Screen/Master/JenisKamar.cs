using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_04
{
    public partial class JenisKamar : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        SqlDataAdapter adapterRole;
        DataTable dtjenis;
        int id;

        public JenisKamar()
        {
            InitializeComponent();
            this.BackColor = ColourModel.primary;
            loadGridJenisKamar();
            id = 0;
        }

        void loadGridJenisKamar()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                adapterRole = new SqlDataAdapter("SELECT * FROM jenis_kamar", connection);
                dtjenis = new DataTable();
                adapterRole.Fill(dtjenis);

                gridJenisKamar.DataSource = dtjenis;

                gridJenisKamar.Columns[2].Visible = false;

                gridJenisKamar.Columns[0].HeaderText = "ID";
                gridJenisKamar.Columns[1].HeaderText = "Nama";
                gridJenisKamar.Columns[3].HeaderText = "Tarif";

                gridJenisKamar.Columns[3].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridJenisKamar.Columns[3].CellTemplate.Style.Font = new Font(gridJenisKamar.Font, FontStyle.Bold);

                gridJenisKamar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            loadGridJenisKamar();
            DataView dataView = new DataView(dtjenis);
            dataView.RowFilter = String.Format("nama LIKE '%{0}%'", textBoxFilter.Text);
            gridJenisKamar.DataSource = dataView;
        }

        private void gridJenisKamar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = gridJenisKamar.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = gridJenisKamar.SelectedRows[0].Cells[3].Value.ToString();

            byte[] dataImage = (byte[]) gridJenisKamar.SelectedRows[0].Cells[2].Value;
            MemoryStream stream = new MemoryStream(dataImage);
            pictureBox.Image = Image.FromStream(stream);

            id = Convert.ToInt32(gridJenisKamar.SelectedRows[0].Cells[0].Value);
            showButton();
        }
        
        void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            pictureBox.Image = null;
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

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(fileDialog.FileName);
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                if (validation())
                {
                    ImageConverter converter = new ImageConverter();
                    byte[] images = (byte[]) converter.ConvertTo(pictureBox.Image, typeof(byte[]));

                    command = new SqlCommand("INSERT INTO jenis_kamar VALUES('" + textBox1.Text + "', @gambar, " + Convert.ToInt32(textBox2.Text) + ")", connection);
                    command.Parameters.AddWithValue("@gambar", images);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data jenis kamar berhasil dimasukkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }

                connection.Close();

                loadGridJenisKamar();
            }
            catch (Exception)
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

                if (validation())
                {
                    DialogResult dialog = MessageBox.Show("Apakah and yakin ingin mengubah data jenis kamar ini?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.Yes)
                    {
                        ImageConverter converter = new ImageConverter();
                        byte[] images = (byte[])converter.ConvertTo(pictureBox.Image, typeof(byte[]));

                        command = new SqlCommand("UPDATE jenis_kamar SET nama = '" + textBox1.Text + "', gambar = @gambar, tarif = " + Convert.ToInt32(textBox2.Text) + " WHERE id = " + id, connection);
                        command.Parameters.AddWithValue("@gambar", images);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Data jenis kamar berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }

                connection.Close();

                loadGridJenisKamar();
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

                DialogResult dialog = MessageBox.Show("Apakah and yakin ingin menghapus data jenis kamar ini?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    command = new SqlCommand("DELETE FROM jenis_kamar WHERE id = " + id, connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data jenis kamar berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }

                connection.Close();

                loadGridJenisKamar();
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
                MessageBox.Show("Nama harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox2.TextLength < 1)
            {
                MessageBox.Show("Tarif harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (pictureBox.Image == null)
            {
                MessageBox.Show("Gambar harus dipilih!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void JenisKamar_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }
    }
}
