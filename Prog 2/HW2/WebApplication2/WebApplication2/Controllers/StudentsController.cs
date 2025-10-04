using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly appDbcontext dbContext;
        public StudentsController(appDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(addStudentViewModel viewModel)
        {
            var student = new Students
            {
                Name = viewModel.Name,
                email = viewModel.email,
                lastName = viewModel.lastName,
                Description = viewModel.Description,
                phone = viewModel.phone,
                News = viewModel.News,
            };

            dbContext.Students.Add(student);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Students");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Students viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);

            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.phone = viewModel.phone;
                student.News = viewModel.News;
                student.Description = viewModel.Description;
                student.lastName = viewModel.lastName;
                student.email = viewModel.email;

                await dbContext.SaveChangesAsync();
                return RedirectToAction("List", "Students");
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(Students viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);

            if (student is not null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");

        }
    }
}
