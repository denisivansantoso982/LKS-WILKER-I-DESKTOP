using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InteropExcel = Microsoft.Office.Interop.Excel;

namespace PC_04
{
    public partial class Report : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        DataTable dtreport;

        public Report()
        {
            InitializeComponent();
        }

        void loadGrid()
        {
            try
            {
                connection = new SqlConnection(Connection.connectionString);
                connection.Open();

                adapter = new SqlDataAdapter("select CONVERT(date, tgl_booking) as tgl_booking, nik, tgl_check_in, tgl_check_out, nomor from booking inner join tamu on booking.nik_tamu = tamu.id inner join detail_booking on booking.id = detail_booking.id_booking inner join kamar_hotel on detail_booking.id_kamar = kamar_hotel.id", connection);
                dtreport = new DataTable();
                adapter.Fill(dtreport);

                gridReport.DataSource = dtreport;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Report_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int height = 5;
            int center = printDocument.DefaultPageSettings.PaperSize.Width / 2;

            StringFormat centerAlign = new StringFormat();
            StringFormat leftAlign = new StringFormat();

            centerAlign.Alignment = StringAlignment.Center;
            leftAlign.Alignment = StringAlignment.Near;

            Font title = new Font("Nirmala UI", 24, FontStyle.Bold);
            Font regular = new Font("Nirmala UI", 10, FontStyle.Regular);
            Font header = new Font("Nirmala UI", 10, FontStyle.Bold);

            e.Graphics.DrawString("HOTEL LANGIT 7", title, Brushes.Black, center, height, centerAlign);

            height += 45;
            int marginHeader = 30;
            for (int i = 0; i < gridReport.ColumnCount; i++)
            {
                e.Graphics.DrawString(gridReport.Columns[i].HeaderText.ToString(), header, Brushes.Black, marginHeader, height, leftAlign);
                marginHeader += printDocument.DefaultPageSettings.PaperSize.Width / 5;
            }
            
            height += 20;

            foreach (DataGridViewRow row in gridReport.Rows)
            {
                int margin = 30;
                for (int i = 0; i < gridReport.ColumnCount; i++)
                {
                    e.Graphics.DrawString(row.Cells[i].Value.ToString(), regular, Brushes.Black, margin, height, leftAlign);
                    margin += printDocument.DefaultPageSettings.PaperSize.Width / 5;
                }

                height += 20;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
                printDocument.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            InteropExcel.Application appExcel;
            InteropExcel.Workbook appWorkbook;
            InteropExcel.Worksheet appWorksheet;

            appExcel = new InteropExcel.Application();
            appExcel.Visible = true;
            appWorkbook = appExcel.Workbooks.Add(1);
            appWorksheet = appWorkbook.Worksheets[1];
            appWorksheet = appWorkbook.ActiveSheet;
            appWorksheet.Name = "Report";
            appWorksheet.Cells.EntireColumn.ColumnWidth = 20;

            for (int i = 1; i < gridReport.ColumnCount + 1; i++)
                appWorksheet.Cells[1, i] = gridReport.Columns[i - 1].HeaderText;

            for (int row = 1; row <= gridReport.RowCount; row++)
            {
                for (int column = 0; column < gridReport.ColumnCount; column++)
                {
                    appWorksheet.Cells[row + 1, column + 1] = gridReport.Rows[row - 1].Cells[column].Value.ToString();
                }
            }

            UseWaitCursor = false;
        }

        private void Report_Load(object sender, EventArgs e)
        {

            loadGrid();
        }
    }
}
