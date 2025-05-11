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
    public partial class DoctorForm : Form
    {
        public DoctorForm()
        {
            InitializeComponent();
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Doctors", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDoctors.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "INSERT INTO Doctors (Name, Specialization, Contact, Email, AvailableDays) VALUES (@Name, @Specialization, @Contact, @Email, @AvailableDays)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text);
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@AvailableDays", txtAvailableDays.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Doctor added.");
                LoadDoctors();
                ClearFields();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int doctorId = Convert.ToInt32(txtDoctorID.Text);

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "UPDATE Doctors SET Name=@Name, Specialization=@Specialization, Contact=@Contact, Email=@Email, AvailableDays=@AvailableDays WHERE DoctorID=@DoctorID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text);
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@AvailableDays", txtAvailableDays.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Doctor updated.");
                LoadDoctors();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int doctorId = Convert.ToInt32(txtDoctorID.Text);

            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UD2MIBV;Initial Catalog=HospitalDB;Integrated Security=True;"))
            {
                string query = "DELETE FROM Doctors WHERE DoctorID = @DoctorID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DoctorID", doctorId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Doctor deleted.");
                LoadDoctors();
                ClearFields();
            }
        }

        private void dgvDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDoctors.Rows[e.RowIndex];
                txtDoctorID.Text = row.Cells["DoctorID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSpecialization.Text = row.Cells["Specialization"].Value.ToString();
                txtContact.Text = row.Cells["Contact"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtAvailableDays.Text = row.Cells["AvailableDays"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtDoctorID.Clear();
            txtName.Clear();
            txtSpecialization.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtAvailableDays.Clear();
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {

        }
    }
}