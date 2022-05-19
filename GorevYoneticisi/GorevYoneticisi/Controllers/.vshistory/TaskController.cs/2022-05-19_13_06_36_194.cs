using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GorevYoneticisi.Models;
using GorevYoneticisi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GorevYoneticisi.Controllers
{
    public class TaskController : Controller
    {
        TaskRepository taskRepository = new TaskRepository();
        public IActionResult Index()
        {
            return View(taskRepository.GetAll());
        }
        public IActionResult EndTask(int id)
        {
            taskRepository.EndTask(id);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTask(int id)
        {
            taskRepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddNewDayTask(TaskModel taskModel)
        {
            taskRepository.AddNewDayTask(taskModel);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddNewWeekTask(TaskModel taskModel)
        {
            taskRepository.AddNewWeekTask(taskModel);
            return RedirectToAction("Index");  
        }
        public IActionResult AddNewMonthTask(TaskModel taskModel)
        {
            taskRepository.AddNewMonthTask(taskModel);
            return RedirectToAction("Index");
        }
        public IActionResult NewTask() { return View(); }
        public IActionResult AddNewMonthTask() { return View();}
        public IActionResult NewDayTask() { return View();}
    }
}