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
        string conStr = "Data Source=DESKTOP-K1NSSFM;Initial Catalog=TaskManager;Integrated Security = True;";
        DbWorksResult result = new DbWorksResult();
        public DbWorksResult GetAll() {
           
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
        public DbWorksResult EndTask(int id)
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
            result.Message = "Görev bitirildi";
            result.Success=true;
            return result;
        }
        public DbWorksResult Delete(int id)
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
            result.Message = "Görev silindi";
            result.Success = true;
            return result;
        }
        public DbWorksResult AddNewDayTask(TaskModel taskModel)
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
            result.Message = "Günlük görev kaydedildi";
            result.Success = true;
            return result;

        }
        public DbWorksResult AddNewWeekTask(TaskModel taskModel)
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
            result.Message = "Haftalık görev kaydedildi";
            result.Success = true;
            return result;
        }
        public DbWorksResult AddNewMonthTask(TaskModel taskModel)
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
                command.Parameters.AddWithValue("@Date", taskModel.Date + "--Aylık Görev");
                command.Parameters.AddWithValue("@Status", 0);
                command.Parameters.AddWithValue("@CreateDate", System.DateTime.Now);
                command.ExecuteNonQuery();
                cnn.Close();
            }
            result.Message = "Aylık görev kaydedildi";
            result.Success = true;
            return result;
        }
    }
}
