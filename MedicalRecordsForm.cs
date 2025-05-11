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
    public partial class MedicalRecordsForm : Form
    {
        public MedicalRecordsForm()
        {
            InitializeComponent();
            LoadPatients();
            LoadRecords();
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

        private void LoadRecords()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT mr.RecordID, p.Name AS Patient, mr.Diagnosis, mr.Treatment, mr.Prescriptions, mr.Date
                      FROM MedicalRecords mr
                      JOIN Patients p ON mr.PatientID = p.PatientID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRecords.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var selectedPatient = (ComboBoxItem)cmbPatient.SelectedItem;

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "INSERT INTO MedicalRecords (PatientID, Diagnosis, Treatment, Prescriptions, Date) VALUES (@PatientID, @Diagnosis, @Treatment, @Prescriptions, @Date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientID", selectedPatient.Value);
                cmd.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text);
                cmd.Parameters.AddWithValue("@Treatment", txtTreatment.Text);
                cmd.Parameters.AddWithValue("@Prescriptions", txtPrescriptions.Text);
                cmd.Parameters.AddWithValue("@Date", dtpDate.Value.Date);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record added.");
                LoadRecords();
                ClearFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int recordId = Convert.ToInt32(txtRecordID.Text);
            var selectedPatient = (ComboBoxItem)cmbPatient.SelectedItem;

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "UPDATE MedicalRecords SET PatientID=@PatientID, Diagnosis=@Diagnosis, Treatment=@Treatment, Prescriptions=@Prescriptions, Date=@Date WHERE RecordID=@RecordID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RecordID", recordId);
                cmd.Parameters.AddWithValue("@PatientID", selectedPatient.Value);
                cmd.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text);
                cmd.Parameters.AddWithValue("@Treatment", txtTreatment.Text);
                cmd.Parameters.AddWithValue("@Prescriptions", txtPrescriptions.Text);
                cmd.Parameters.AddWithValue("@Date", dtpDate.Value.Date);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record updated.");
                LoadRecords();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int recordId = Convert.ToInt32(txtRecordID.Text);

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "DELETE FROM MedicalRecords WHERE RecordID = @RecordID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RecordID", recordId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record deleted.");
                LoadRecords();
                ClearFields();
            }
        }

        private void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRecords.Rows[e.RowIndex];
                txtRecordID.Text = row.Cells["RecordID"].Value.ToString();
                cmbPatient.Text = row.Cells["Patient"].Value.ToString();
                txtDiagnosis.Text = row.Cells["Diagnosis"].Value.ToString();
                txtTreatment.Text = row.Cells["Treatment"].Value.ToString();
                txtPrescriptions.Text = row.Cells["Prescriptions"].Value.ToString();
                dtpDate.Value = Convert.ToDateTime(row.Cells["Date"].Value);
            }
        }
        private void ClearFields()
        {
            txtRecordID.Clear();
            cmbPatient.SelectedIndex = -1;
            txtDiagnosis.Clear();
            txtTreatment.Clear();
            txtPrescriptions.Clear();
            dtpDate.Value = DateTime.Today;
        }
    }
}
