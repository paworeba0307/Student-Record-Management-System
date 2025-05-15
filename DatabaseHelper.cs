using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Student_Record_Management_System

{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper(string connString)
        {
            connectionString = connString;
        }
      
        public bool IsValidGrade(int grade)
        {
            return grade == 9 || grade == 10 || grade == 11 || grade == 12;
        }

        public bool InsertStudent(string name, int grade, string subject, string marks)
        {
            //validate the grades
            if (!IsValidGrade(grade))
            {
                Console.WriteLine("Invalid grade! Grade must be 9,10,11,or 12");
                return false;
            }

            using (SqlConnection conn = new SqlConnection(connectionString)) // Use SQLiteConnection for SQLite
            {
                string query = "INSERT INTO Studentdbt (Name, Grade, Subject, Marks) VALUES (@Name, @Grade, @Subject, @Marks)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Grade", grade);
                    cmd.Parameters.AddWithValue("@Subject", subject);
                    cmd.Parameters.AddWithValue("@Marks", marks);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log error or show a message
                        Console.WriteLine("Error inserting student: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public DataTable GetAllStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Studentdbt";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error fetching students: " + ex.Message);
                        return null;
                    }
                }
            }
        }

        public bool DeleteStudentByName(string Name)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Studentdbt WHERE Name = @Name"; // Assuming column is FirstName

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", Name);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return true; // Student deleted successfully
                        }
                        else
                        {
                            MessageBox.Show("No student found with the given name.");
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL error while deleting student: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return false;
            }
        }

        public bool UpdateStudent(int id, string name, int grade, string subject, string marks)
        {
            //validate the grades
            if (!IsValidGrade(grade))
            {
                Console.WriteLine("Invalid grade! Grade must be 9,10,11,or 12");
                return false;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Studentdbt SET Name = @Name, Grade = @Grade, Subject = @Subject, Marks = @Marks WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Grade", grade);
                    cmd.Parameters.AddWithValue("@Subject", subject);
                    cmd.Parameters.AddWithValue("@Marks", marks);
                    cmd.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error updating student: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool DeleteStudentById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Studentdbt WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("SQL Error while deleting student: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
