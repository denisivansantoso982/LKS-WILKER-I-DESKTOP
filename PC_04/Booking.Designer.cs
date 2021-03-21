namespace PC_04
{
    partial class Booking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePickerBooking = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoNik = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerCheckIn = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerCheckOut = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxJumlahKamar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxBayar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxSisa = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxJenis = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxNoKamar = new System.Windows.Forms.ComboBox();
            this.gridPilihKamar = new System.Windows.Forms.DataGridView();
            this.buttonTambah = new System.Windows.Forms.Button();
            this.buttonHapus = new System.Windows.Forms.Button();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.labeltotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridPilihKamar)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nirmala UI Semilight", 28F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(22, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 51);
            this.label2.TabIndex = 7;
            this.label2.Text = "Booking";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(886, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 28);
            this.button2.TabIndex = 12;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePickerBooking
            // 
            this.dateTimePickerBooking.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerBooking.Location = new System.Drawing.Point(172, 108);
            this.dateTimePickerBooking.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerBooking.Name = "dateTimePickerBooking";
            this.dateTimePickerBooking.Size = new System.Drawing.Size(249, 29);
            this.dateTimePickerBooking.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(27, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tanggal Booking";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(27, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "NIK Tamu";
            // 
            // textBoNik
            // 
            this.textBoNik.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoNik.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoNik.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoNik.Location = new System.Drawing.Point(172, 153);
            this.textBoNik.Margin = new System.Windows.Forms.Padding(2);
            this.textBoNik.MaxLength = 20;
            this.textBoNik.Name = "textBoNik";
            this.textBoNik.Size = new System.Drawing.Size(249, 29);
            this.textBoNik.TabIndex = 21;
            this.textBoNik.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxJumlahKamar_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(27, 207);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 21);
            this.label4.TabIndex = 24;
            this.label4.Text = "Tanggal Check In";
            // 
            // dateTimePickerCheckIn
            // 
            this.dateTimePickerCheckIn.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckIn.Location = new System.Drawing.Point(172, 203);
            this.dateTimePickerCheckIn.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new System.Drawing.Size(249, 29);
            this.dateTimePickerCheckIn.TabIndex = 23;
            this.dateTimePickerCheckIn.ValueChanged += new System.EventHandler(this.dateTimePickerCheckIn_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(27, 253);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 21);
            this.label5.TabIndex = 26;
            this.label5.Text = "Tanggal Check Out";
            // 
            // dateTimePickerCheckOut
            // 
            this.dateTimePickerCheckOut.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckOut.Location = new System.Drawing.Point(172, 249);
            this.dateTimePickerCheckOut.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            this.dateTimePickerCheckOut.Size = new System.Drawing.Size(249, 29);
            this.dateTimePickerCheckOut.TabIndex = 25;
            this.dateTimePickerCheckOut.ValueChanged += new System.EventHandler(this.dateTimePickerCheckOut_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(484, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 21);
            this.label6.TabIndex = 28;
            this.label6.Text = "Jumlah Kamar";
            // 
            // textBoxJumlahKamar
            // 
            this.textBoxJumlahKamar.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxJumlahKamar.Location = new System.Drawing.Point(616, 107);
            this.textBoxJumlahKamar.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxJumlahKamar.MaxLength = 50;
            this.textBoxJumlahKamar.Name = "textBoxJumlahKamar";
            this.textBoxJumlahKamar.Size = new System.Drawing.Size(188, 29);
            this.textBoxJumlahKamar.TabIndex = 27;
            this.textBoxJumlahKamar.Text = "1";
            this.textBoxJumlahKamar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxJumlahKamar_KeyPress);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(808, 107);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 28);
            this.button1.TabIndex = 29;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Maroon;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(838, 107);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 28);
            this.button3.TabIndex = 30;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(484, 158);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 21);
            this.label7.TabIndex = 32;
            this.label7.Text = "Total Transaksi";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotal.Location = new System.Drawing.Point(616, 153);
            this.textBoxTotal.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTotal.MaxLength = 50;
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(249, 29);
            this.textBoxTotal.TabIndex = 31;
            this.textBoxTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxJumlahKamar_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F);
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(484, 203);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 21);
            this.label8.TabIndex = 34;
            this.label8.Text = "Jumlah Bayar";
            // 
            // textBoxBayar
            // 
            this.textBoxBayar.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBayar.Location = new System.Drawing.Point(616, 198);
            this.textBoxBayar.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBayar.MaxLength = 50;
            this.textBoxBayar.Name = "textBoxBayar";
            this.textBoxBayar.Size = new System.Drawing.Size(249, 29);
            this.textBoxBayar.TabIndex = 33;
            this.textBoxBayar.Text = "0";
            this.textBoxBayar.TextChanged += new System.EventHandler(this.textBoxBayar_TextChanged);
            this.textBoxBayar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxJumlahKamar_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F);
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(484, 249);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 21);
            this.label9.TabIndex = 36;
            this.label9.Text = "Sisa Bayar";
            // 
            // textBoxSisa
            // 
            this.textBoxSisa.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSisa.Location = new System.Drawing.Point(616, 244);
            this.textBoxSisa.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSisa.MaxLength = 50;
            this.textBoxSisa.Name = "textBoxSisa";
            this.textBoxSisa.ReadOnly = true;
            this.textBoxSisa.Size = new System.Drawing.Size(249, 29);
            this.textBoxSisa.TabIndex = 35;
            this.textBoxSisa.Text = "0";
            this.textBoxSisa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxJumlahKamar_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Nirmala UI Semilight", 24F);
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(24, 319);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(313, 45);
            this.label10.TabIndex = 37;
            this.label10.Text = "Data Transaksi Kamar";
            // 
            // comboBoxJenis
            // 
            this.comboBoxJenis.BackColor = System.Drawing.SystemColors.HighlightText;
            this.comboBoxJenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxJenis.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxJenis.FormattingEnabled = true;
            this.comboBoxJenis.Location = new System.Drawing.Point(156, 393);
            this.comboBoxJenis.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxJenis.Name = "comboBoxJenis";
            this.comboBoxJenis.Size = new System.Drawing.Size(228, 29);
            this.comboBoxJenis.TabIndex = 39;
            this.comboBoxJenis.SelectionChangeCommitted += new System.EventHandler(this.comboBoxJenis_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F);
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(27, 396);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 21);
            this.label11.TabIndex = 38;
            this.label11.Text = "Jenis Kamar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F);
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(27, 441);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 21);
            this.label12.TabIndex = 41;
            this.label12.Text = "Nomor Kamar";
            // 
            // comboBoxNoKamar
            // 
            this.comboBoxNoKamar.BackColor = System.Drawing.SystemColors.HighlightText;
            this.comboBoxNoKamar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNoKamar.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNoKamar.FormattingEnabled = true;
            this.comboBoxNoKamar.Location = new System.Drawing.Point(156, 441);
            this.comboBoxNoKamar.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxNoKamar.Name = "comboBoxNoKamar";
            this.comboBoxNoKamar.Size = new System.Drawing.Size(228, 29);
            this.comboBoxNoKamar.TabIndex = 42;
            // 
            // gridPilihKamar
            // 
            this.gridPilihKamar.AllowUserToAddRows = false;
            this.gridPilihKamar.AllowUserToDeleteRows = false;
            this.gridPilihKamar.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            this.gridPilihKamar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.gridPilihKamar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPilihKamar.BackgroundColor = System.Drawing.Color.White;
            this.gridPilihKamar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPilihKamar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gridPilihKamar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Nirmala UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPilihKamar.DefaultCellStyle = dataGridViewCellStyle15;
            this.gridPilihKamar.Location = new System.Drawing.Point(491, 366);
            this.gridPilihKamar.Margin = new System.Windows.Forms.Padding(2);
            this.gridPilihKamar.MultiSelect = false;
            this.gridPilihKamar.Name = "gridPilihKamar";
            this.gridPilihKamar.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Nirmala UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPilihKamar.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.gridPilihKamar.RowHeadersVisible = false;
            this.gridPilihKamar.RowTemplate.Height = 24;
            this.gridPilihKamar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPilihKamar.ShowCellToolTips = false;
            this.gridPilihKamar.Size = new System.Drawing.Size(374, 150);
            this.gridPilihKamar.TabIndex = 43;
            // 
            // buttonTambah
            // 
            this.buttonTambah.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTambah.BackColor = System.Drawing.Color.Maroon;
            this.buttonTambah.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTambah.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonTambah.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.buttonTambah.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.buttonTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTambah.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonTambah.ForeColor = System.Drawing.Color.White;
            this.buttonTambah.Location = new System.Drawing.Point(212, 487);
            this.buttonTambah.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(83, 28);
            this.buttonTambah.TabIndex = 44;
            this.buttonTambah.Text = "Tambah";
            this.buttonTambah.UseVisualStyleBackColor = false;
            this.buttonTambah.Click += new System.EventHandler(this.buttonTambah_Click);
            // 
            // buttonHapus
            // 
            this.buttonHapus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHapus.BackColor = System.Drawing.Color.Maroon;
            this.buttonHapus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHapus.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonHapus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.buttonHapus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.buttonHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHapus.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonHapus.ForeColor = System.Drawing.Color.White;
            this.buttonHapus.Location = new System.Drawing.Point(299, 487);
            this.buttonHapus.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHapus.Name = "buttonHapus";
            this.buttonHapus.Size = new System.Drawing.Size(83, 28);
            this.buttonHapus.TabIndex = 45;
            this.buttonHapus.Text = "Hapus";
            this.buttonHapus.UseVisualStyleBackColor = false;
            this.buttonHapus.Click += new System.EventHandler(this.buttonHapus_Click);
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.BackColor = System.Drawing.SystemColors.HighlightText;
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(616, 290);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(249, 29);
            this.comboBoxStatus.TabIndex = 47;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F);
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Location = new System.Drawing.Point(484, 292);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 21);
            this.label13.TabIndex = 46;
            this.label13.Text = "Status Bayar";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Maroon;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(488, 561);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 28);
            this.button4.TabIndex = 48;
            this.button4.Text = "Simpan";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F);
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label14.Location = new System.Drawing.Point(38, 566);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 21);
            this.label14.TabIndex = 52;
            this.label14.Text = "Total : Rp. ";
            // 
            // labeltotal
            // 
            this.labeltotal.AutoSize = true;
            this.labeltotal.BackColor = System.Drawing.Color.Transparent;
            this.labeltotal.Font = new System.Drawing.Font("Nirmala UI Semilight", 20F, System.Drawing.FontStyle.Bold);
            this.labeltotal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labeltotal.Location = new System.Drawing.Point(116, 561);
            this.labeltotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labeltotal.Name = "labeltotal";
            this.labeltotal.Size = new System.Drawing.Size(29, 37);
            this.labeltotal.TabIndex = 53;
            this.labeltotal.Text = "_";
            // 
            // Booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(914, 640);
            this.Controls.Add(this.labeltotal);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.buttonHapus);
            this.Controls.Add(this.buttonTambah);
            this.Controls.Add(this.gridPilihKamar);
            this.Controls.Add(this.comboBoxNoKamar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxJenis);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxSisa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxBayar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxJumlahKamar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerCheckOut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerCheckIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoNik);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerBooking);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Booking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Booking_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gridPilihKamar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateTimePickerBooking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoNik;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckIn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxJumlahKamar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxBayar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxSisa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxJenis;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxNoKamar;
        private System.Windows.Forms.DataGridView gridPilihKamar;
        private System.Windows.Forms.Button buttonTambah;
        private System.Windows.Forms.Button buttonHapus;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labeltotal;
    }
}