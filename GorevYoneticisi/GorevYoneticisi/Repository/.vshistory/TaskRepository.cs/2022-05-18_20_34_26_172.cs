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
                    task.StartDate = DateTime.Parse(rdr[3].ToString());
                    task.EndDate= DateTime.Parse(rdr[4].ToString());
                    task.Status = bool.Parse(rdr[5].ToString());
                    task.StatusDesc = rdr[5].ToString()=="1"?"Bitti":"Devam Ediyor";
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
