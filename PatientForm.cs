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
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
            LoadPatients();
        }

        private void LoadPatients()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Patients", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPatients.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "INSERT INTO Patients (Name, Gender, Age, Contact, Address, Email) VALUES (@Name, @Gender, @Age, @Contact, @Address, @Email)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Patient added.");
                LoadPatients();
                ClearFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int patientId = Convert.ToInt32(txtPatientId.Text);

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "UPDATE Patients SET Name=@Name, Gender=@Gender, Age=@Age, Contact=@Contact, Address=@Address, Email=@Email WHERE PatientID=@PatientID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientID", patientId);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Patient information updated.");
                LoadPatients();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int patientId = Convert.ToInt32(txtPatientId.Text);

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "DELETE FROM Patients WHERE PatientID = @PatientID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientID", patientId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Patient deleted.");
                LoadPatients();
                ClearFields();
            }
        }

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPatients.Rows[e.RowIndex];
                txtPatientId.Text = row.Cells["PatientID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                cmbGender.Text = row.Cells["Gender"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();
                txtContact.Text = row.Cells["Contact"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }
        private void ClearFields()
        {
            txtPatientId.Clear();
            txtName.Clear();
            cmbGender.SelectedIndex = -1;
            txtAge.Clear();
            txtContact.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
        }
    }
}
