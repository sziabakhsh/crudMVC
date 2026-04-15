using CRUDOperationMVC.Data;
using CRUDOperationMVC.Entities;
using CRUDOperationMVC.Models;
using CRUDOperationMVC.DTOs.Student;
using CRUDOperationMVC.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDOperationMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly MyDbContext _context;

        public StudentController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Students
                .Select(s=>s.ToStudentDto())
                .ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Add([Bind("Id,Name,Email,Phone,Address")] StudentViewModel student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Student newStudent = new Student
        //        {
        //            Name = student.Name,
        //            Email = student.Email,
        //            Phone = student.Phone,
        //            Address = student.Address
        //        };
        //        _context.Students.Add(newStudent);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(student);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CreateStudentFromDto studentDto)
        {
            if (ModelState.IsValid)
            {
                Student newStudent = studentDto.ToStudent();

                _context.Students.Add(newStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            if (Id == null)
            {
                return NotFound();
            }
            Student? student = await _context.Students.FindAsync(Id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                StudentViewModel model = new StudentViewModel();
                model.Id = student.Id;
                model.Name = student.Name;
                model.Email = student.Email;
                model.Phone = student.Phone;
                model.Address = student.Address;

                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? Id,[Bind("Id,Name,Email,Phone,Address")] StudentViewModel student)
        {
            if (Id == null)
                return RedirectToAction(nameof(Index));

            if (ModelState.IsValid)
            {

                Student? editedStudent = await _context.Students.FindAsync(Id);

                if (editedStudent != null)
                {
                    editedStudent.Name = student.Name;
                    editedStudent.Email = student.Email;
                    editedStudent.Phone = student.Phone;
                    editedStudent.Address = student.Address;


                    _context.Students.Update(editedStudent);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? Id) {
            if (Id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            Student? student = await _context.Students.FindAsync(Id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
