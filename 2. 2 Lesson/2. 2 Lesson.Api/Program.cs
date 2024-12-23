using _2._2_Lesson.Api.Models;
using _2._2_Lesson.Api.Services;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace _2._2_Lesson.Api
{
    internal class Program
    {

        public static void PasswordFrontEnd()
        {
            Console.WriteLine("1. Director");
            Console.WriteLine("2. Teacher");
            Console.WriteLine("3. Student");
            Console.WriteLine();
            Console.Write("Choose option >> ");
            var option = int.Parse(Console.ReadLine());

            var teacherService = new TeacherService();
            var studentService = new StudentService();

            if (option == 1) // DIRECTOR
            {
                Console.Write("Passwordni kiriting >> ");
                var passResult = Console.ReadLine();

                if (teacherService.password == passResult)
                {
                    DirectorFrontEnd();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect password or ERROR has been occured !!!\n");
                }
            }
            else if (option == 2) // TEACHER
            {
                Console.Write("Passwordni kiriting >> ");
                var secondPassword = Console.ReadLine();

                if (studentService.password == secondPassword)
                {
                    TeacherFrontEnd();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect password or ERROR has been occured !!!\n");
                }
            }
            else if (option == 3) // STUDENT
            {
                Console.Write("Passwordni kiriting >> ");
                var thirdPassword = Console.ReadLine();

                Console.Write("Enter your ID >> ");
                var studentId = Guid.Parse(Console.ReadLine());

                var result = studentService.GetById(studentId);

                if(result is null)
                {
                    Console.WriteLine("Wrong ID");
                }
                else
                {
                    if (studentService.password == thirdPassword)
                    {
                        StudentFrontEnd(result);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Incorrect password or ERROR has been occured !!!\n");
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            PasswordFrontEnd();
        }


        public static void DirectorFrontEnd()
        {

            var teacherServices = new TeacherService();
            var teacher = new Teacher();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Delete Teacher");
                Console.WriteLine("3. Update Teacher");
                Console.WriteLine("4. Get All Teachers");
                Console.WriteLine("5. Get by ID of Teacher");
                Console.WriteLine();
                Console.Write("Choose option >> ");
                var option = int.Parse(Console.ReadLine());
                Console.Clear();

                if (option is 1)
                {
                    Console.Write("First name: ");
                    teacher.FirstName = Console.ReadLine();

                    Console.Write("Last name: ");
                    teacher.LastName = Console.ReadLine();

                    Console.Write("Age: ");
                    teacher.Age = int.Parse(Console.ReadLine());

                    Console.Write("Subject: ");
                    teacher.Subject = Console.ReadLine();

                    Console.Write("Likes: ");
                    teacher.Likes = int.Parse(Console.ReadLine());

                    Console.Write("Dislikes: ");
                    teacher.DisLikes = int.Parse(Console.ReadLine());

                    Console.Write("Gender: ");
                    teacher.Gender = (Console.ReadLine());

                    Console.WriteLine("\nThe Teacher has been added succesfully\n");

                    teacherServices.AddTeacher(teacher);

                }
                else if(option is 2)
                {
                    Console.Write("Enter ID for removing >> ");
                    var delOption = Guid.Parse(Console.ReadLine());

                    var resultDelTeacher = teacherServices.DeleteTeacher(delOption);

                    if(resultDelTeacher is true)
                    {
                        Console.WriteLine("\nTeacher has been removed successfully!!!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nError occured or not deleted\n");
                    }
                }
                else if(option is 3)
                {
                    Console.Write("Enter teacher ID for update >> ");
                    teacher.Id = Guid.Parse(Console.ReadLine());

                    Console.Write("Enter teacher's first name >> ");
                    teacher.FirstName = Console.ReadLine();

                    Console.Write("Enter teacher's last name >> ");
                    teacher.LastName = Console.ReadLine();

                    Console.Write("Enter teacher's age >> ");
                    teacher.Age = int.Parse(Console.ReadLine());

                    Console.Write("Enter teacher's subject >> ");
                    teacher.Subject = Console.ReadLine();

                    Console.Write("Enter teacher's likes >> ");
                    teacher.Likes = int.Parse(Console.ReadLine());

                    Console.Write("Enter teacher's dislikes >> ");
                    teacher.DisLikes = int.Parse(Console.ReadLine());

                    Console.Write("Enter teacher's gender >> ");
                    teacher.Gender = (Console.ReadLine());

                    var updatingResult = teacherServices.UpdateTeacher(teacher);

                    if (updatingResult is true)
                    {
                        Console.WriteLine("\nTeacher has been updated successfully!!!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nError occured or not updated\n");
                    }
                }
                else if(option is 4)
                {
                    var allTeachers = teacherServices.GetAllTeachers();

                    foreach(var teachr in allTeachers)
                    {
                        var str = $"Teacher's ID: {teachr.Id}\n First name: {teachr.FirstName}\n Last name: {teachr.LastName}\n " +
                            $"Age: {teachr.Age}\n Subject: {teachr.Subject}\n Likes: {teachr.Likes}\n " +
                            $"Dislikes: {teachr.DisLikes}\n Gender: {teachr.Gender}";

                        Console.WriteLine(str);
                        Console.WriteLine();
                    }
                }
                else if(option is 5)
                {
                    Console.Write("Enter ID of teacher >> ");
                    var teacherId = Guid.Parse(Console.ReadLine());

                    var teachr = teacherServices.GetById(teacherId);

                    var str = $"Teacher's ID: {teachr.Id}\n First name: {teachr.FirstName}\n Last name: {teachr.LastName}\n " +
                            $"Age: {teachr.Age}\n Subject: {teachr.Subject}\n Likes: {teachr.Likes}\n " +
                            $"Dislikes: {teachr.DisLikes}\n Gender: {teachr.Gender}";

                    Console.WriteLine(str);
                    Console.WriteLine();
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void TeacherFrontEnd()
        {
            var teacherServices = new TeacherService();
            var studendService = new StudentService();
            var students = new Student();
            var test = new Test();
            var testService = new TestService();


            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add sutudent");
                Console.WriteLine("2. Delete sutudent");
                Console.WriteLine("3. Update sutudent");
                Console.WriteLine("4. Get all sutudents");
                Console.WriteLine("5. Get by ID of sutudent");
                Console.WriteLine();
                Console.WriteLine("6. Add test");
                Console.WriteLine("7. Delete test");
                Console.WriteLine("8. Update test");
                Console.WriteLine("9. Get all tests");
                Console.WriteLine("10. Get by ID of test");
                Console.WriteLine("11. Get by ID of test");
                Console.WriteLine();
                Console.Write("Enter your option >> ");
                var option = int.Parse(Console.ReadLine());
                Console.Clear();

                if (option is 1)
                {
                    Console.Write("Enter name >> ");
                    students.FirstName = Console.ReadLine();

                    Console.Write("Enter last name >> ");
                    students.SecondName = Console.ReadLine();

                    Console.Write("Enter age >> ");
                    students.Age = int.Parse(Console.ReadLine());

                    Console.Write("Enter degree >> ");
                    students.Degree = int.Parse(Console.ReadLine());

                    Console.Write("Enter gender >> ");
                    students.Gender = Console.ReadLine();

                    studendService.AddStudent(students);

                    Console.WriteLine("Student added successfully!!!");
                }
                else if(option is 2)
                {
                    Console.Write("Enter student's ID >> ");
                    var studentsID = Guid.Parse(Console.ReadLine());

                    var deletingStudent = studendService.DeleteStudent(studentsID);

                    if(deletingStudent is true)
                    {
                        Console.WriteLine("\nStudent deleted successfully!!!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nNot deleted or ERROR occured!!!\n");
                    }
                }
                else if(option is 3)
                {
                    Console.Write("Enter student's ID >> ");
                    students.Id = Guid.Parse(Console.ReadLine());

                    Console.Write("Enter name >> ");
                    students.FirstName = Console.ReadLine();

                    Console.Write("Enter last name >> ");
                    students.SecondName = Console.ReadLine();

                    Console.Write("Enter age >> ");
                    students.Age = int.Parse(Console.ReadLine());

                    Console.Write("Enter name >> ");
                    students.Degree = int.Parse(Console.ReadLine());

                    Console.Write("Enter name >> ");
                    students.Gender = Console.ReadLine();

                    var studentResult = studendService.UpdateStudent(students);

                    if(studentResult is true)
                    {
                        Console.WriteLine("\nStudent has been updated successfully!!!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nNot updated or ERROR occured\n");
                    }
                }
                else if(option is 4)
                {
                    var allStudents = studendService.GetAllStudents();

                    foreach(var student in allStudents)
                    {
                        var str = $"Student's ID: {student.Id}\n First name: {student.FirstName}\n " +
                            $"Last name: {student.SecondName}\n Age: {student.Age}\n Degree: {student.Degree}\n " +
                            $"Gender: {student.Gender}";

                        Console.WriteLine(str);
                        Console.WriteLine();
                    }
                }
                else if(option is 5)
                {
                    Console.Write("Enter student's ID >> ");
                    var studentId = Guid.Parse(Console.ReadLine());
                    var student = studendService.GetById(studentId);

                    var str = $"Student's ID: {student.Id}\n First name: {student.FirstName}\n " +
                            $"Last name: {student.SecondName}\n Age: {student.Age}\n Degree: {student.Degree}\n " +
                            $"Gender: {student.Gender}";

                    Console.WriteLine(str);
                    Console.WriteLine();
                }
                else if(option is 6)
                {
                    Console.Write("Question: ");
                    test.QuestionText = Console.ReadLine();

                    Console.Write("Variant A: ");
                    test.AVariant = Console.ReadLine();

                    Console.Write("VAriant B: ");
                    test.BVariant = Console.ReadLine();

                    Console.Write("Variant C: ");
                    test.CVariant = Console.ReadLine();

                    Console.Write("Answers: ");
                    test.Answer = Console.ReadLine();

                    testService.AddTest(test);

                    Console.WriteLine("\nTest has been added successfully!!!\n");
                }
                else if(option is 7)
                {
                    Console.Write("Enter test ID to delete >> ");
                    var deletingTest = Guid.Parse(Console.ReadLine());

                    var resultForDelete = testService.DeleteTest(deletingTest);

                    if(resultForDelete is true)
                    {
                        Console.WriteLine("\nTest has been removed successfully!!!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nNot deleted or ERROR occured\n");
                    }
                }
                else if(option is 8)
                {
                    Console.Write("Question: ");
                    test.QuestionText = Console.ReadLine();

                    Console.Write("Variant A: ");
                    test.AVariant = Console.ReadLine();

                    Console.Write("VAriant B: ");
                    test.BVariant = Console.ReadLine();

                    Console.Write("Variant C: ");
                    test.CVariant = Console.ReadLine();

                    Console.Write("Answers: ");
                    test.Answer = Console.ReadLine();

                    var resultUpdating = testService.UpdateTest(test);

                    if(resultUpdating is true)
                    {
                        Console.WriteLine("\nChoosen test has been updated successfully\n");
                    }
                    else
                    {
                        Console.WriteLine("\nNot updated or ERROR has been occured!!!\n");
                    }
                }
                else if(option is 9)
                {
                    var getAllTests = testService.GetAllTests();

                    foreach(var tesst in getAllTests)
                    {
                        var str = $"Test Id: {tesst.Id}\n Question: {tesst.QuestionText}\n Variant A: {tesst.AVariant}\n Variant B: {tesst.BVariant}\n Variant C: {tesst.CVariant}\n " +
                            $"Answer: {tesst.Answer}";

                        Console.WriteLine(str);
                        Console.WriteLine();
                    }
                }
                else if(option is 10)
                {
                    Console.Write("Enter test's ID: ");
                    var testID = Guid.Parse(Console.ReadLine());

                    var resultTestById = testService.GetById(testID);

                    var str = $"Question: {resultTestById.QuestionText}\n Variant A: {resultTestById.AVariant}\n " +
                        $"Variant B: {resultTestById.BVariant}\n Variant C: {resultTestById.CVariant}\n " +
                    $"Answer: {resultTestById.Answer}";
                    Console.WriteLine(str);
                    Console.WriteLine();
                }
                Console.ReadKey();
                Console.Clear();
            }
        }



        public static void StudentFrontEnd(Student studentById)
        {
            var testService = new TestService();
            var studentService = new StudentService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine( "    MENU\n");
                Console.WriteLine("1. Get Test By ID");
                Console.WriteLine("2. Get All Tests");
                Console.WriteLine("3. Show my results");
                Console.WriteLine();
                Console.Write("Choose >> ");
                var option = int.Parse(Console.ReadLine());
                Console.Clear();

                if (option is 1)
                {
                    Console.Write("Test's ID >> ");
                    var testId = Guid.Parse(Console.ReadLine());

                    var testRes = testService.GetById(testId);

                    if (testRes is null)
                    {
                        Console.WriteLine("Wrong test ID");
                    }
                    else
                    {
                        Console.WriteLine(testRes.QuestionText);
                        Console.WriteLine(testRes.AVariant);
                        Console.WriteLine(testRes.BVariant);
                        Console.WriteLine(testRes.CVariant);

                        Console.Write("Enter your answer >> ");

                        var studentAnswer = Console.ReadLine();

                        if(studentAnswer == testRes.Answer)
                        {
                            studentById.StudentTestResults.Add(1);

                            studentService.UpdateStudent(studentById);
                        }
                        else
                        {
                            studentById.StudentTestResults.Add(0);

                            studentService.UpdateStudent(studentById);
                        }
                    }
                }else if(option is 2)
                {
                    var testRes = testService.GetAllTests();

                    foreach(var test in testRes)
                    {
                        Console.WriteLine(test.QuestionText);
                        Console.WriteLine(test.AVariant);
                        Console.WriteLine(test.BVariant);
                        Console.WriteLine(test.CVariant);

                        Console.Write("Enter your answer >> ");
                        var studentAnswer = Console.ReadLine();

                        if (studentAnswer == test.Answer)
                        {
                            studentById.StudentTestResults.Add(1);

                            studentService.UpdateStudent(studentById);
                        }
                        else
                        {
                            studentById.StudentTestResults.Add(0);

                            studentService.UpdateStudent(studentById);
                        }
                    }
                }else if(option is 3)
                {
                    foreach(var result in studentById.StudentTestResults)
                    {
                        Console.WriteLine($"{result} ");
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}