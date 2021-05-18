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
    public partial class Kamar : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        SqlDataAdapter adapterRole, adapterPegawai;
        DataTable dtJenis, dtKamar;
        int id;

        public Kamar()
        {
            InitializeComponent();
            this.BackColor = ColourModel.primary;
            loadComboJenis();
            loadGridKamar();
            id = 0;
        }

        void loadComboJenis()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                adapterRole = new SqlDataAdapter("SELECT id, nama FROM jenis_kamar", connection);
                dtJenis = new DataTable();
                adapterRole.Fill(dtJenis);

                comboBox.DataSource = dtJenis;
                comboBox.ValueMember = "id";
                comboBox.DisplayMember = "nama";

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        void reset()
        {
            textBox1.Text = "";
            comboBox.SelectedValue = 1;
            id = 0;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void gridKamar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(gridKamar.SelectedRows[0].Cells[0].Value);
            textBox1.Text = Convert.ToString(gridKamar.SelectedRows[0].Cells[1].Value);
            comboBox.SelectedValue = Convert.ToInt32(gridKamar.SelectedRows[0].Cells[2].Value);

            showButton();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            loadGridKamar();
            DataView dataView = new DataView(dtKamar);
            dataView.RowFilter = String.Format("nama LIKE '%{0}%'", textBoxFilter.Text);
            gridKamar.DataSource = dataView;
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
                    command = new SqlCommand("INSERT INTO kamar_hotel VALUES(" + Convert.ToInt32(textBox1.Text) + ", " + Convert.ToInt32(comboBox.SelectedValue) + ")", connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data kamar berhasil dimasukkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }

                connection.Close();

                loadGridKamar();
            }
            catch (Exception)
            {
                MessageBox.Show("Terjadi kesalahan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void loadGridKamar()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                adapterRole = new SqlDataAdapter("select * from kamar_hotel inner join jenis_kamar on kamar_hotel.id_jenis_kamar = jenis_kamar.id", connection);
                dtKamar = new DataTable();
                adapterRole.Fill(dtKamar);

                gridKamar.DataSource = dtKamar;

                gridKamar.Columns[2].Visible = false;
                gridKamar.Columns[3].Visible = false;
                gridKamar.Columns[5].Visible = false;

                gridKamar.Columns[0].HeaderText = "ID";
                gridKamar.Columns[1].HeaderText = "Nomor";
                gridKamar.Columns[4].HeaderText = "Jenis";
                gridKamar.Columns[6].HeaderText = "Tarif";

                gridKamar.Columns[1].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridKamar.Columns[6].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridKamar.Columns[6].CellTemplate.Style.Font = new Font(gridKamar.Font, FontStyle.Bold);

                gridKamar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                connection.Close();
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
                    DialogResult dialog = MessageBox.Show("Apakah and yakin ingin mengubah data kamar ini?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.Yes)
                    {
                        command = new SqlCommand("UPDATE kamar_hotel SET nomor = " + Convert.ToInt32(textBox1.Text) + ", id_jenis_kamar = '" + Convert.ToInt32(comboBox.SelectedValue) + "' WHERE id = " + id, connection);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Data kamar berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }

                connection.Close();

                loadGridKamar();
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

                if (validation())
                {
                    DialogResult dialog = MessageBox.Show("Apakah and yakin ingin mengubah data kamar ini?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.Yes)
                    {
                        command = new SqlCommand("DELETE FROM kamar_hotel WHERE id = " + id, connection);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Data kamar berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }

                connection.Close();

                loadGridKamar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Kamar_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool validation()
        {
            if (textBox1.TextLength < 1)
            {
                MessageBox.Show("Nomor kamar harus diisi!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
