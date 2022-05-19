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
        string conStr = "Server=DESKTOP-K1NSSFM;Database=TaskManager;Integrated Security = True";
        public DbWorksResult GetAll() {
            DbWorksResult result = new DbWorksResult();
            using (SqlConnection cnn = new SqlConnection(conStr))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "select*from TaskList";
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
                    task.StartDate = DateTime.Parse(rdr[3].ToString());
                    task.EndDate= DateTime.Parse(rdr[4].ToString());
                    task.Status = bool.Parse(rdr[5].ToString());
                    task.CreateDate = DateTime.Parse(rdr[6].ToString());
                    taskList.Add(task);
                }
                cnn.Close();
                result.Result = taskList;
                result.Message = "Bütün kayıtlar getirildi";
                result.Success = true;
                return result;
            }
        }
    }
}
