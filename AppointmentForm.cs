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

namespace Hospital_Management_System
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            LoadPatients();
            LoadDoctors();
            LoadAppointments();
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
        private void LoadDoctors()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                SqlCommand cmd = new SqlCommand("SELECT DoctorID, Name FROM Doctors", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbDoctor.Items.Add(new ComboBoxItem(reader["Name"].ToString(), reader["DoctorID"].ToString()));
                }
                con.Close();
            }
        }

        private void LoadAppointments()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT a.AppointmentID, p.Name AS Patient, d.Name AS Doctor, a.Date, a.Time, a.Notes
                      FROM Appointments a
                      JOIN Patients p ON a.PatientID = p.PatientID
                      JOIN Doctors d ON a.DoctorID = d.DoctorID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAppointments.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var selectedPatient = (ComboBoxItem)cmbPatient.SelectedItem;
            var selectedDoctor = (ComboBoxItem)cmbDoctor.SelectedItem;

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "INSERT INTO Appointments (PatientID, DoctorID, Date, Time, Notes) VALUES (@PatientID, @DoctorID, @Date, @Time, @Notes)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientID", selectedPatient.Value);
                cmd.Parameters.AddWithValue("@DoctorID", selectedDoctor.Value);
                cmd.Parameters.AddWithValue("@Date", dtpDate.Value.Date);
                cmd.Parameters.AddWithValue("@Time", dtpTime.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Appointment created.");
                LoadAppointments();
                ClearFields();
            }

        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public ComboBoxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int appointmentId = Convert.ToInt32(txtAppointmentID.Text);

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "DELETE FROM Appointments WHERE AppointmentID = @AppointmentID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Appointment deleted.");
                LoadAppointments();
                ClearFields();
            }
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAppointments.Rows[e.RowIndex];
                txtAppointmentID.Text = row.Cells["AppointmentID"].Value.ToString();
                cmbPatient.Text = row.Cells["Patient"].Value.ToString();
                cmbDoctor.Text = row.Cells["Doctor"].Value.ToString();
                dtpDate.Value = Convert.ToDateTime(row.Cells["Date"].Value);
                dtpTime.Value = DateTime.Today.Add(TimeSpan.Parse(row.Cells["Time"].Value.ToString()));
                txtNotes.Text = row.Cells["Notes"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtAppointmentID.Clear();
            cmbPatient.SelectedIndex = -1;
            cmbDoctor.SelectedIndex = -1;
            dtpDate.Value = DateTime.Today;
            dtpTime.Value = DateTime.Now;
            txtNotes.Clear();
        }
    }
}
