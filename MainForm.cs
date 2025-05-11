using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnPatientManagement_Click(object sender, EventArgs e)
        {
            PatientForm form = new PatientForm();
            form.Show();

        }

        private void btnDoctorManagement_Click(object sender, EventArgs e)
        {
            DoctorForm form = new DoctorForm();
            form.Show();
        }

        private void btnMedicalRecords_Click(object sender, EventArgs e)
        {
            MedicalRecordsForm form = new MedicalRecordsForm();
            form.Show();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            AppointmentForm form = new AppointmentForm();
            form.Show();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            BillingForm form = new BillingForm();
            form.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to get out?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
