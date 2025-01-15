using Student.Api.DataAccess.Enums;
using Student.Api.Services;
using Student.Api.Services.DTOs;

namespace Student.Api
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new StudentService();

            var newStudent = new StudentCreateDto()
            {
                FirstName = "Test",
                SecondName = "familiya",
                Age = 18,
                Email = "jhdsf@gmail.com",
                Password = "password",
                StatusDegree = Degree.PHD,
                StatusGender = Gender.Male,
            };



            var newStudent2 = new StudentGetDto()
            {
                FirstName = "Nurulloh",
                SecondName = "Lutfullayev",
                Age = 25,
                Email = "qwerty@gmail.com",
                StatusDegree = Degree.Bachalor,
                StatusGender = Gender.Female,
            };



            var delete = new StudentGetDto()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };
            service.DeleteStudent(delete.Id);




            var id = "8e85d9b5-2843-441d-8b51-2468b6fed2f9";
            var updatingStudent = new StudentUpdateDto()
            {
                Id = Guid.Parse(id),
                FirstName = "Nuuuuurulloh",
            };

            service.UpdateStudent(updatingStudent);
        }
    }
}


//public Guid Id { get; set; }
//public string FirstName { get; set; }
//public string SecondName { get; set; }
//public int Age { get; set; }
//public string Email { get; set; }
//public string Password { get; set; }
//public Degree StatusDegree { get; set; }
//public Gender StatusGender { get; set; }
