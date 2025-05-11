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
using static Hospital_Management_System.AppointmentForm;

namespace Hospital_Management_System
{
    public partial class BillingForm : Form
    {
        public BillingForm()
        {
            InitializeComponent();
            LoadPatients();
            LoadBilling();
        }

        private void LoadPatients()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                SqlCommand cmd = new SqlCommand("SELECT PatientID, Name FROM Patients", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbPatient.Items.Add(new ComboBoxItem(reader["Name"].ToString(), reader["PatientID"].ToString()));
                }
                con.Close();
            }
        }

        private void LoadBilling()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT b.BillID, p.Name AS Patient, b.Amount, b.Date, b.Description
                      FROM Billing b
                      JOIN Patients p ON b.PatientID = p.PatientID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBilling.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var selectedPatient = (ComboBoxItem)cmbPatient.SelectedItem;
            decimal amount;

            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("Enter a valid amount.");
                return;
            }

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "INSERT INTO Billing (PatientID, Amount, Date, Description) VALUES (@PatientID, @Amount, @Date, @Description)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientID", selectedPatient.Value);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Date", dtpDate.Value.Date);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Bill saved.");
                LoadBilling();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int billId = Convert.ToInt32(txtBillID.Text);

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "DELETE FROM Billing WHERE BillID = @BillID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BillID", billId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Bill deleted.");
                LoadBilling();
                ClearFields();
            }
        }

        private void dgvBilling_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBilling.Rows[e.RowIndex];
                txtBillID.Text = row.Cells["BillID"].Value.ToString();
                cmbPatient.Text = row.Cells["Patient"].Value.ToString();
                txtAmount.Text = row.Cells["Amount"].Value.ToString();
                dtpDate.Value = Convert.ToDateTime(row.Cells["Date"].Value);
                txtDescription.Text = row.Cells["Description"].Value.ToString();
            }
        }
        private void ClearFields()
        {
            txtBillID.Clear();
            cmbPatient.SelectedIndex = -1;
            txtAmount.Clear();
            dtpDate.Value = DateTime.Today;
            txtDescription.Clear();
        }

        private void BillingForm_Load(object sender, EventArgs e)
        {

        }
    }

}
