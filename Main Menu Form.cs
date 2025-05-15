using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Record_Management_System
{
    public partial class Main_Menu_Form : Form
    {
        public Main_Menu_Form()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Student_Form addStudentForm = new Add_Student_Form();
            addStudentForm.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";
            DatabaseHelper db = new DatabaseHelper(connectionString);

            // Fetch all student data
            DataTable studentsTable = db.GetAllStudents();

            if (studentsTable != null && studentsTable.Rows.Count > 0)
            {
                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = studentsTable;

                // Ensure the 'Id' column is visible in the DataGridView
                dataGridView1.Columns["Id"].Visible = true;  // Make sure 'Id' column is visible
                dataGridView1.Columns["Id"].HeaderText = "Student ID";  // Optional: Rename the 'Id' column header

                // Optionally, you can set other properties like column width
                dataGridView1.Columns["Id"].Width = 80;  // Set width of the 'Id' column

                // Adjust other columns if needed, for example:
                dataGridView1.Columns["Name"].HeaderText = "Student Name"; // Rename 'Name' column header
                dataGridView1.Columns["Grade"].HeaderText = "Grade";  // Rename 'Grade' column header
                dataGridView1.Columns["Subject"].HeaderText = "Subject";  // Rename 'Subject' column header
                dataGridView1.Columns["Marks"].HeaderText = "Marks";  // Rename 'Marks' column header

                // Optional: Hide columns that are not needed (if any)
                // For example, if you want to hide a column:
                // studentGridView.Columns["SomeOtherColumn"].Visible = false;
            }
            else
            {
                MessageBox.Show("Failed to load student data.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)

            {
                MessageBox.Show("Please select a record to edit.");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int studentId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string name = selectedRow.Cells["Name"].Value.ToString();
            int grade = Convert.ToInt32(selectedRow.Cells["Grade"].Value);
            string subject = selectedRow.Cells["Subject"].Value.ToString();
            string marks = selectedRow.Cells["Marks"].Value.ToString();

            // Open the Add Student Form for editing
            Add_Student_Form addStudentForm = new Add_Student_Form();
            addStudentForm.SetStudentData(studentId, name, grade, subject, marks);
            addStudentForm.FormClosed += (s, args) => RefreshDataGridView(); // Refresh the grid when the form is closed
            addStudentForm.ShowDialog();
        }
        private void RefreshDataGridView()

        {
            // Logic to refresh the DataGridView, e.g., re-fetching data from the database
            // Example: LoadStudents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if any row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the student ID and name from the selected row
                int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                string selectedName = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

                // Ask for confirmation before deleting the student
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the student {selectedName}?", "Delete Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;";
                    DatabaseHelper db = new DatabaseHelper(connectionString);

                    try
                    {
                        // Call the method to delete the student by ID
                        bool success = db.DeleteStudentById(selectedId); // Make sure this method exists in DatabaseHelper

                        if (success)
                        {
                            // Remove the selected row from the DataGridView
                            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            MessageBox.Show("Student deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the student.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting student: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }
    }
}


