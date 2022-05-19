using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult NewTask() { return View(); }
        public IActionResult NewMonthTask() { return View();}
        public IActionResult ttt() { return View("Index1");}
    }
}