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
    public partial class Booking : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        DataTable dtJenis, dtKamar;
        int values, id, total, gap, duration = 1;

        public Booking()
        {
            InitializeComponent();
            this.BackColor = ColourModel.primary;
            values = 1;
            dateTimePickerBooking.MinDate = DateTime.Now;
            dateTimePickerCheckIn.MinDate = DateTime.Now;
            dateTimePickerCheckOut.MinDate = DateTime.Now.AddDays(1);
            loadComboStatus();
            loadGridPilihKamar();
            loadComboJenis();
            loadComboKamar();
            loadAutoComplete();
        }

        void loadAutoComplete()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                command = new SqlCommand("select nik from tamu", connection);
                reader = command.ExecuteReader();

                AutoCompleteStringCollection sourceAutoComplete = new AutoCompleteStringCollection();

                while (reader.Read())
                {
                    sourceAutoComplete.Add(reader[0].ToString());
                }

                textBoNik.AutoCompleteCustomSource = sourceAutoComplete;

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void loadComboStatus()
        {
            string[] data = { "DP", "LUNAS" };
            comboBoxStatus.DataSource = data;
        }

        void loadGridPilihKamar()
        {
            gridPilihKamar.Columns.Add("No", "No.");
            gridPilihKamar.Columns.Add("idJenis", "idJenis");
            gridPilihKamar.Columns.Add("Jenis", "Jenis Kamar");
            gridPilihKamar.Columns.Add("idNomor", "idNomor");
            gridPilihKamar.Columns.Add("NoKamar", "No Kamar");
            gridPilihKamar.Columns.Add("Tarif", "Tarif");

            gridPilihKamar.Columns[4].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridPilihKamar.Columns[5].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridPilihKamar.Columns[5].CellTemplate.Style.Font = new Font(gridPilihKamar.Font, FontStyle.Bold);
            gridPilihKamar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            gridPilihKamar.Columns[1].Visible = false;
            gridPilihKamar.Columns[3].Visible = false;
        }

        void loadComboJenis()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                adapter = new SqlDataAdapter("select kh.id, kh.nomor, kh.id_jenis_kamar, jk.nama, jk.tarif from kamar_hotel as kh inner join jenis_kamar as jk on kh.id_jenis_kamar = jk.id", connection);
                dtJenis = new DataTable();
                adapter.Fill(dtJenis);

                comboBoxJenis.DataSource = dtJenis;
                comboBoxJenis.DisplayMember = "nama";
                comboBoxJenis.ValueMember = "id_jenis_kamar";

                connection.Close();
            } catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        void loadComboKamar()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                adapter = new SqlDataAdapter("select kh.id, kh.nomor, kh.id_jenis_kamar, jk.nama, jk.tarif from kamar_hotel as kh inner join jenis_kamar as jk on kh.id_jenis_kamar = jk.id where kh.id_jenis_kamar = " + comboBoxJenis.SelectedValue, connection);
                dtKamar = new DataTable();
                adapter.Fill(dtKamar);

                comboBoxNoKamar.DataSource = dtKamar;
                comboBoxNoKamar.DisplayMember = "nomor";
                comboBoxNoKamar.ValueMember = "id";

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

        private void Booking_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxJumlahKamar.TextLength < 1)
            {
                values = 0;
                textBoxJumlahKamar.Text = values.ToString();
            }
            else
            {
                values++;
                textBoxJumlahKamar.Text = values.ToString();
            }
        }

        private void textBoxJumlahKamar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            bool sama = false;
            int roomCount = Convert.ToInt32(textBoxJumlahKamar.Text);

            if (gridPilihKamar.RowCount < roomCount)
            {
                foreach (DataGridViewRow row in gridPilihKamar.Rows)
                {
                    string id = row.Cells[4].Value.ToString();
                    if (row.Cells[4].Value.ToString().Equals(comboBoxNoKamar.Text.ToString()))
                    {
                        sama = true;
                        break;
                    } else
                    {
                        sama = false;
                    }
                }

                if (sama)
                {
                    MessageBox.Show("Tidak dapat menambah kamar yang sama!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    int tarif = dtKamar.Rows[comboBoxNoKamar.SelectedIndex].Field<int>(4);
                    gridPilihKamar.Rows.Add(gridPilihKamar.RowCount + 1, comboBoxJenis.SelectedValue, comboBoxJenis.Text, comboBoxNoKamar.SelectedValue, comboBoxNoKamar.Text, tarif);
                }
            } else
            {
                MessageBox.Show("Tidak dapat menambah kamar! Anda hanya input " + textBoxJumlahKamar.Text + "!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            calculate();
        }

        private void comboBoxJenis_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadComboKamar();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridPilihKamar.SelectedRows)
                gridPilihKamar.Rows.Remove(row);

            calculate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxJumlahKamar.TextLength < 1 || textBoxJumlahKamar.Text == "0")
            {
                values = 0;
                textBoxJumlahKamar.Text = values.ToString();
            } else
            {
                values--;
                textBoxJumlahKamar.Text = values.ToString();
            }
        }

        private void dateTimePickerCheckOut_ValueChanged(object sender, EventArgs e)
        {
            duration = Convert.ToInt32((dateTimePickerCheckOut.Value - dateTimePickerCheckIn.Value).TotalDays);
            calculate();
        }

        private void dateTimePickerCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerCheckOut.Value <= dateTimePickerCheckIn.Value)
            {
                dateTimePickerCheckOut.MinDate = dateTimePickerCheckIn.Value.AddDays(1);
                dateTimePickerCheckOut.Value = dateTimePickerCheckIn.Value.AddDays(1);
            }

            duration = Convert.ToInt32((dateTimePickerCheckOut.Value - dateTimePickerCheckIn.Value).TotalDays);
            calculate();
        }

        private void textBoxBayar_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }

        void calculate()
        {
            total = 0;
            gap = 0;
            int bayar = 0;

            if (textBoxBayar.TextLength < 1)
            {
                bayar = 0;
            } else
            {
                bayar = Convert.ToInt32(textBoxBayar.Text);
            }

            foreach (DataGridViewRow row in gridPilihKamar.Rows)
            {
                total += Convert.ToInt32(row.Cells[5].Value);
            }

            total *= duration;

            gap = total - bayar;

            textBoxSisa.Text = gap.ToString();
            labeltotal.Text = total.ToString();
            textBoxTotal.Text = total.ToString();
        }

        private bool validation()
        {
            if (textBoNik.TextLength < 1)
            {
                MessageBox.Show("NIK tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (textBoxJumlahKamar.Text == "0" || textBoxJumlahKamar.TextLength < 1)
            {
                MessageBox.Show("Jumlah kamar harus diisi dan tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBoxBayar.TextLength < 4)
            {
                MessageBox.Show("Mohon bayar terlebih dahulu dengan baik!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (gridPilihKamar.Rows.Count < 1)
            {
                MessageBox.Show("Pilih kamar dulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            bool sama = false;

            try
            {
                if (validation())
                {
                    connection = new SqlConnection(Connection.connectionString);
                    connection.Open();

                    foreach (DataGridViewRow row in gridPilihKamar.Rows)
                    {
                        string checkIn = dateTimePickerCheckIn.Value.ToString("yyyy-MM-dd");
                        string checkOut = dateTimePickerCheckOut.Value.ToString("yyyy-MM-dd");

                        int nomor = Convert.ToInt32(row.Cells[3].Value);
                        command = new SqlCommand("select * from booking inner join detail_booking on booking.id = detail_booking.id_booking where CONVERT(date, tgl_check_in) between @checkIn and @checkOut and CONVERT(date, tgl_check_out) between @checkIn and @checkOut and id_kamar = " + nomor, connection);
                        command.Parameters.AddWithValue("@checkIn", checkIn);
                        command.Parameters.AddWithValue("@checkOut", checkOut);
                        reader = command.ExecuteReader();
                        reader.Read();

                        if (reader.HasRows)
                        {
                            sama = true;
                            break;
                        }
                        else
                        {
                            sama = false;
                        }

                        reader.Close();
                    }


                    if (sama)
                    {
                        MessageBox.Show("Tidak dapat menyimpan karena kamar telah dipesan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        command = new SqlCommand("SELECT id FROM tamu WHERE nik = '" + textBoNik.Text + "'", connection);
                        reader = command.ExecuteReader();
                        reader.Read();

                        if (reader.HasRows)
                        {
                            int status = Convert.ToInt32(comboBoxStatus.SelectedIndex + 1);
                            int ids = Convert.ToInt32(reader[0]);
                            reader.Close();

                            command = new SqlCommand("INSERT INTO booking VALUES(@booking, '" + ids + "', @checkIn, @checkOut, " + Convert.ToInt32(textBoxJumlahKamar.Text) + ", " + Convert.ToInt32(labeltotal.Text) + ", " + status + ", " + PegawaiModel.id + ")", connection);
                            command.Parameters.AddWithValue("@booking", dateTimePickerBooking.Value.Date);
                            command.Parameters.AddWithValue("@checkIn", dateTimePickerCheckIn.Value.Date);
                            command.Parameters.AddWithValue("@checkOut", dateTimePickerCheckOut.Value.Date);
                            command.ExecuteNonQuery();

                            command = new SqlCommand("SELECT id FROM booking WHERE tgl_booking = @booking and nik_tamu = " + ids + "", connection);
                            command.Parameters.AddWithValue("@booking", dateTimePickerBooking.Value.Date);
                            reader = command.ExecuteReader();
                            reader.Read();

                            if (reader.HasRows)
                            {
                                foreach (DataGridViewRow row in gridPilihKamar.Rows)
                                {
                                    int bookingId = Convert.ToInt32(reader[0]);
                                    int tarif = dtKamar.Rows[comboBoxNoKamar.SelectedIndex].Field<int>(4);
                                    reader.Close();
                                    command = new SqlCommand("INSERT INTO detail_booking VALUES(" + bookingId + ", " + Convert.ToInt32(row.Cells[3].Value) + ", " + Convert.ToInt32(row.Cells[5].Value) + ")", connection);
                                    command.ExecuteNonQuery();

                                    MessageBox.Show("Booking sudah ditambahkan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            } else
                            {
                                MessageBox.Show("Data booking tidak dapat ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        } else
                        {
                            MessageBox.Show("Data tamu tidak dapat ditemukan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    connection.Close();
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
