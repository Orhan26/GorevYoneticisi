using GorevYoneticisi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GorevYoneticisi.Repository
{
    public class TaskRepository
    {
        string conStr = "Data Source=192.168.18.230;Initial Catalog=TaskManager;User ID=sa;Password=Acd2004;MultipleActiveResultSets=True;Connection Timeout=120;";
        public DbWorksResult GetAll() {
            DbWorksResult result = new DbWorksResult();
            using (SqlConnection cnn = new SqlConnection(conStr))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM TaskList";
                command.Connection = cnn;
                command.CommandType = System.Data.CommandType.Text;
                SqlDataReader rdr = command.ExecuteReader();
                List<TaskModel> taskList = new List<TaskModel>();
                while (rdr.Read())
                {
                    TaskModel task = new TaskModel();
                    task.Id = int.Parse(rdr[0].ToString());
                    task.TaskName = rdr[1].ToString();
                    task.Description = rdr[2].ToString();                  
                    task.Date = rdr[3].ToString();
                    task.Status = bool.Parse(rdr[4].ToString());
                    task.CreateDate = DateTime.Parse(rdr[5].ToString());
                    taskList.Add(task);
                }
                cnn.Close();
                result.Result = taskList;
                result.Message = "Bütün kayıtlar getirildi";
                result.Success = true;
                return result;
            }
        }
        public void EndTask(int id)
        {
            using (SqlConnection cnn = new SqlConnection(conStr))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE TaskList SET Status=1 WHERE Id=@id";
                command.Connection = cnn;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                cnn.Close();
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection cnn = new SqlConnection(conStr))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "DELETE FROM TaskList WHERE Id=@id";
                command.Connection = cnn;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                cnn.Close();
            }
        }
        public void AddNewDayTask(TaskModel taskModel)
        {
            using (SqlConnection cnn = new SqlConnection(conStr))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO TaskList VALUES (@TaskName,@Description,@Date,@Status,@CreateDate)";
                command.Connection = cnn;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("@TaskName", taskModel.TaskName);
                command.Parameters.AddWithValue("@Description", taskModel.Description);
                command.Parameters.AddWithValue("@Date", taskModel.Date + "--Günlük Görev");
                command.Parameters.AddWithValue("@Status", 0);
                command.Parameters.AddWithValue("@CreateDate", System.DateTime.Now);
                command.ExecuteNonQuery();
                cnn.Close();
            }

        }
        public void AddNewWeekTask(TaskModel taskModel)
        {
            using (SqlConnection cnn = new SqlConnection(conStr))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO TaskList VALUES (@TaskName,@Description,@Date,@Status,@CreateDate)";
                command.Connection = cnn;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("@TaskName", taskModel.TaskName);
                command.Parameters.AddWithValue("@Description", taskModel.Description);
                command.Parameters.AddWithValue("@Date", taskModel.Date + "--Haftalık Görev");
                command.Parameters.AddWithValue("@Status", 0);
                command.Parameters.AddWithValue("@CreateDate", System.DateTime.Now);
                command.ExecuteNonQuery();
                cnn.Close();
            }
        }
    }
}
