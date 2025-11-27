using Microsoft.AspNetCore.Mvc;
using StudentManagementDapper.Interfaces;
using StudentManagementDapper.Models;

namespace StudentManagementDapper.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _service.GetAllStudentsAsync();
            return View(students);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            await _service.AddStudentAsync(student);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _service.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            await _service.UpdateStudentAsync(student);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _service.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _service.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
