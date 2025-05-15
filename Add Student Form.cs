using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Record_Management_System
{
    public partial class Add_Student_Form : Form
    {
        public Add_Student_Form()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string subject = txtSubject.Text.Trim();
            string marks = txtMarks.Text.Trim();


            if (!int.TryParse(txtGrade.Text, out int grade))

            {
                MessageBox.Show("Please enter a valid grade number.");
                return;
            }

            // Validate the grade to ensure it is 9, 10, 11, or 12
            if (grade < 9 || grade > 12)
            {
                MessageBox.Show("Invalid grade! Grade must be 9, 10, 11, or 12.");
                return;
            }

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";
            DatabaseHelper db = new DatabaseHelper(connectionString);

            if (btnSave.Tag != null) // Editing an existing student

            {
                int studentId = Convert.ToInt32(btnSave.Tag);
                bool success = db.UpdateStudent(studentId, name, grade, subject, marks);

                if (success)
                {
                    MessageBox.Show("Student record updated successfully.");
                }

                else
                {
                    MessageBox.Show("Failed to update student record.");
                }
            }

            else // Adding a new student

            {
                bool success = db.InsertStudent(name, grade, subject, marks);

                if (success)

                {
                    MessageBox.Show("Student added successfully.");
                }

                else
                {
                    MessageBox.Show("Failed to add student.");
                }
            }

            this.Close(); // Close the form after saving
        }

        public void SetStudentData(int id, string name, int grade, string subject, string marks)
        {
            txtName.Text = name;
            txtGrade.Text = grade.ToString();
            txtSubject.Text = subject;
            txtMarks.Text = marks;
            btnSave.Tag = id; // Store the student ID in the Save button's Tag property
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
