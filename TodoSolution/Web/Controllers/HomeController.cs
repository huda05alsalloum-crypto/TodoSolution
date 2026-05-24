using Microsoft.AspNetCore.Mvc;
using Business; // الـ Namespace الحقيقي لطبقة البزنس عندك

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskService taskService;

        public HomeController(TaskService service)
        {
            taskService = service;
        }

        public IActionResult Index()
        {
            var tasks = taskService.GetTasks();
            return View(tasks);
        }

        [HttpPost]
        public IActionResult AddTask(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                taskService.AddTask(title);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            taskService.CompleteTask(id);
            return RedirectToAction("Index");
        }

        // تنفيذ إجراء حذف المهمة وحل الـ TODO المكتوب بكتاب الدكتور
        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            taskService.DeleteTask(id); // استدعاء دالة الحذف في الـ TaskService
            return RedirectToAction("Index");
        }
    }
}