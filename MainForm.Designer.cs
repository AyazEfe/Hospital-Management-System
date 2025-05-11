namespace Hospital_Management_System
{
    partial class MainForm
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
            this.btnPatientManagement = new System.Windows.Forms.Button();
            this.btnDoctorManagement = new System.Windows.Forms.Button();
            this.btnAppointments = new System.Windows.Forms.Button();
            this.btnMedicalRecords = new System.Windows.Forms.Button();
            this.btnBilling = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblHms = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPatientManagement
            // 
            this.btnPatientManagement.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnPatientManagement.Location = new System.Drawing.Point(86, 137);
            this.btnPatientManagement.Name = "btnPatientManagement";
            this.btnPatientManagement.Size = new System.Drawing.Size(168, 30);
            this.btnPatientManagement.TabIndex = 12;
            this.btnPatientManagement.Text = "Patient Management";
            this.btnPatientManagement.UseVisualStyleBackColor = true;
            this.btnPatientManagement.Click += new System.EventHandler(this.btnPatientManagement_Click);
            // 
            // btnDoctorManagement
            // 
            this.btnDoctorManagement.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnDoctorManagement.Location = new System.Drawing.Point(86, 77);
            this.btnDoctorManagement.Name = "btnDoctorManagement";
            this.btnDoctorManagement.Size = new System.Drawing.Size(168, 30);
            this.btnDoctorManagement.TabIndex = 13;
            this.btnDoctorManagement.Text = "Doctor Management";
            this.btnDoctorManagement.UseVisualStyleBackColor = true;
            this.btnDoctorManagement.Click += new System.EventHandler(this.btnDoctorManagement_Click);
            // 
            // btnAppointments
            // 
            this.btnAppointments.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnAppointments.Location = new System.Drawing.Point(86, 193);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new System.Drawing.Size(168, 30);
            this.btnAppointments.TabIndex = 14;
            this.btnAppointments.Text = "Appointments";
            this.btnAppointments.UseVisualStyleBackColor = true;
            this.btnAppointments.Click += new System.EventHandler(this.btnAppointments_Click);
            // 
            // btnMedicalRecords
            // 
            this.btnMedicalRecords.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnMedicalRecords.Location = new System.Drawing.Point(86, 253);
            this.btnMedicalRecords.Name = "btnMedicalRecords";
            this.btnMedicalRecords.Size = new System.Drawing.Size(168, 30);
            this.btnMedicalRecords.TabIndex = 15;
            this.btnMedicalRecords.Text = "Medical Records";
            this.btnMedicalRecords.UseVisualStyleBackColor = true;
            this.btnMedicalRecords.Click += new System.EventHandler(this.btnMedicalRecords_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnBilling.Location = new System.Drawing.Point(86, 320);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(168, 30);
            this.btnBilling.TabIndex = 16;
            this.btnBilling.Text = "Billing";
            this.btnBilling.UseVisualStyleBackColor = true;
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Brown;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(248, 380);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(97, 30);
            this.btnLogout.TabIndex = 17;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblHms
            // 
            this.lblHms.AutoSize = true;
            this.lblHms.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHms.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblHms.Location = new System.Drawing.Point(12, 9);
            this.lblHms.Name = "lblHms";
            this.lblHms.Size = new System.Drawing.Size(336, 37);
            this.lblHms.TabIndex = 18;
            this.lblHms.Text = "Hospital Manage System";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(357, 427);
            this.Controls.Add(this.lblHms);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnBilling);
            this.Controls.Add(this.btnMedicalRecords);
            this.Controls.Add(this.btnAppointments);
            this.Controls.Add(this.btnDoctorManagement);
            this.Controls.Add(this.btnPatientManagement);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPatientManagement;
        private System.Windows.Forms.Button btnDoctorManagement;
        private System.Windows.Forms.Button btnAppointments;
        private System.Windows.Forms.Button btnMedicalRecords;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblHms;
    }
}