using CRUDOperationMVC.DTOs.Student;
using CRUDOperationMVC.Entities;

namespace CRUDOperationMVC.Mappers
{
    public static class StudentMapper
    {
        public static StudentDto ToStudentDto(this Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                Address = student.Address
            };
        }

        public static Student ToStudent(this CreateStudentFromDto createStudentFromDto)
        {
            return new Student
            {
                Name = createStudentFromDto.Name,
                Email = createStudentFromDto.Email,
                Phone = createStudentFromDto.Phone,
                Address = createStudentFromDto.Address
            };
        }
    }
}
