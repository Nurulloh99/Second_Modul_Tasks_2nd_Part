using _2._3_Lesson.Models;
using _2._3_Lesson.Services;
using System.IO;

namespace _2._3_Lesson;

internal class Program
{
    private static string DirectorPassword = "director";
    private static string TeacherPassword = "teacher";
    private static string StudentPassword = "student";


    static void Main(string[] args)
    {
        RunPassword();
    }

    public static void RunPassword()
    {
        Console.WriteLine("1. Director");
        Console.WriteLine("2. Teacher");
        Console.WriteLine("3. Student");
        Console.WriteLine();
        Console.Write("Choose option: ");
        var option = int.Parse(Console.ReadLine());

        if (option is 1)
        {
            Console.Write("Enter Director password >> ");
            var drPassword = Console.ReadLine();

            if (drPassword == DirectorPassword)
            {
                DirectorRunFrontEnd();
            }

        }
        else if (option is 2)
        {
            Console.Write("Enter Teacher password >> ");
            var tchPassword = Console.ReadLine();

            if (tchPassword == TeacherPassword)
            {
                TeacherRunFrontEnd();
            }
        }
        else if (option is 3)
        {
            Console.Write("Enter Student password >> ");
            var stPassword = Console.ReadLine();

            if (stPassword == StudentPassword)
            {
                StudentRunFrontEnd();
            }
        }
    }


    public static void DirectorRunFrontEnd()
    {
        var teacher = new Teacher();
        ITeacherService teacherService = new TeacherService();

        while (true)
        {
            Console.WriteLine("      MENU\n");
            Console.WriteLine("1. Add teacher");
            Console.WriteLine("2. Get teacher by ID");
            Console.WriteLine("3. Get all teachers");
            Console.WriteLine("4. Delete teacher");
            Console.WriteLine("5. Update teacher");
            Console.WriteLine();
            Console.Write("Choose option >> ");
            var option = int.Parse(Console.ReadLine());

            if(option is 1)
            {
                Console.WriteLine("First name: ");
                teacher.FirstName = Console.ReadLine();

                Console.WriteLine("Last name: ");
                teacher.LastName = Console.ReadLine();

                Console.WriteLine("Age: ");
                teacher.Age = int.Parse(Console.ReadLine());

                Console.WriteLine("Subject: ");
                teacher.Subject = Console.ReadLine();

                Console.WriteLine("Likes: ");
                teacher.Likes = int.Parse(Console.ReadLine());

                Console.WriteLine("Dislikes: ");
                teacher.DisLikes = int.Parse(Console.ReadLine());

                Console.WriteLine("Gender: ");
                teacher.Gender = Console.ReadLine();

                teacherService.AddTeacher(teacher);

                Console.WriteLine("\nTeacher has been added successfully!!!\n");
            }
            else if(option is 2)
            {
                Console.Write("Enter teacher's ID >> ");
                var teacherID = Guid.Parse(Console.ReadLine());

                var teacherById = teacherService.GetById(teacherID);

                var str = $"First name: {teacherById.FirstName}\n Last name: {teacherById.LastName}\n Age: {teacherById.Age} " +
                    $"Subject: {teacherById.Subject}\n Likes: {teacherById.Likes}\n Dislikes: {teacherById.DisLikes}\n Gender: {teacherById.Gender}";

                Console.WriteLine(str);
                Console.WriteLine();
            }
            else if(option is 3)
            {
                var allTeachers = teacherService.GetAllTeachers();

                foreach(var teacherById in allTeachers)
                {
                    var str = $"First name: {teacherById.FirstName}\n Last name: {teacherById.LastName}\n Age: {teacherById.Age} " +
                    $"Subject: {teacherById.Subject}\n Likes: {teacherById.Likes}\n Dislikes: {teacherById.DisLikes}\n Gender: {teacherById.Gender}";

                    Console.WriteLine(str);
                    Console.WriteLine();
                }
            }
            else if(option is 4)
            {
                Console.Write("Enter teacher's ID to delete >> ");
                var teacherID = Guid.Parse(Console.ReadLine());

                var deletingResult = teacherService.DeleteTeacher(teacherID);
                if(deletingResult is true)
                {
                    Console.WriteLine("\nTeacher has been REMOVED successfully!!!\n");
                }
                else
                {
                    Console.WriteLine("\nTeacher has NOT REMOVED!!!\n");
                }
            }
            else if(option is 5)
            {
                Console.Write("Enter teacher's ID: ");
                teacher.Id = Guid.Parse(Console.ReadLine());

                Console.WriteLine("Enter teacher's first name: ");
                teacher.FirstName = Console.ReadLine();

                Console.WriteLine("Enter teacher's last name: ");
                teacher.LastName = Console.ReadLine();

                Console.WriteLine("Enter teacher's age: ");
                teacher.Age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter teacher's subject: ");
                teacher.Subject = Console.ReadLine();

                Console.WriteLine("Enter teacher's Likes: ");
                teacher.Likes = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter teacher's Dislike: ");
                teacher.DisLikes = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter teacher's gender: ");
                teacher.Gender = Console.ReadLine();

                var updatingTeacher = teacherService.UpdateTeacher(teacher);

                if(updatingTeacher is true)
                {
                    Console.WriteLine("\nChoosen teacher has been UPDATED successfully!!\n");
                }
                else
                {
                    Console.WriteLine("\nChoosen teacher has NOT UPDATED!!!\n");
                }
            }
        }
    }
    

    public static void TeacherRunFrontEnd()
    {
        var student = new Student();
        IStudentService studentService = new StudentService();

        var test = new Test();
        ITestService testSrvice = new TestService(); 

        while (true)
        {
            Console.Clear();
            Console.WriteLine("     MENU\n");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Get student by Id");
            Console.WriteLine("3. Get all students");
            Console.WriteLine("4. Delete student");
            Console.WriteLine("5. Update student");
            Console.WriteLine();
            Console.WriteLine("6. Add test");
            Console.WriteLine("7. Get test by Id");
            Console.WriteLine("8. Get all tests");
            Console.WriteLine("9. Delete test");
            Console.WriteLine("10. Update test");
            Console.WriteLine("0. Back: ");

            Console.Write("Choose option >> ");
            var option = int.Parse(Console.ReadLine());
            Console.Clear();

            if (option is 1)
            {
                Console.Write("Enter first name: ");
                student.FirstName = Console.ReadLine();

                Console.WriteLine("Enter last name: ");
                student.SecondName = Console.ReadLine();

                Console.WriteLine("Enter age: ");
                student.Age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Subject: ");
                student.Degree = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter gender: ");
                student.Gender = Console.ReadLine();

                studentService.AddStudent(student);

                Console.WriteLine("\nStudent has been added successfully!!!\n");
            }
            else if(option is 2)
            {
                Console.Write("Enter student's ID >> ");
                var studentID = Guid.Parse(Console.ReadLine());

                var studentt = studentService.GetById(studentID);

                var str = $"First name: {studentt.FirstName}\n Last name: {studentt.SecondName}\n " +
                    $"Age: {studentt.Age}\n Degree: {studentt.Degree}\n Gender: {studentt.Gender}";

                Console.WriteLine(str);
                Console.WriteLine();
            }
            else if(option is 3)
            {
                var allStudents = studentService.GetAllStudents();

                foreach(var studentt in allStudents)
                {
                    var str = $"First name: {studentt.FirstName}\n Last name: {studentt.SecondName}\n " +
                    $"Age: {studentt.Age}\n Degree: {studentt.Degree}\n Gender: {studentt.Gender}";

                    Console.WriteLine(str);
                    Console.WriteLine();
                }
            }
            else if(option is 4)
            {
                Console.Write("Enter student's ID to remove >> ");
                var studentID = Guid.Parse(Console.ReadLine());

                var studentResult = studentService.DeleteStudent(studentID);

                if(studentResult is true)
                {
                    Console.WriteLine("\nStudent has been deleted successfully!!!\n");
                }
                else
                {
                    Console.WriteLine("\nStudent has NOT REMOVED!!!\n");
                }
            }
            else if(option is 5)
            {
                Console.WriteLine("Student ID: ");
                student.Id = Guid.Parse(Console.ReadLine());

                Console.Write("First name: ");
                student.FirstName = Console.ReadLine();

                Console.Write("Last name: ");
                student.SecondName = Console.ReadLine();

                Console.Write("Age: ");
                student.Age = int.Parse(Console.ReadLine());    

                Console.Write("Degree: ");
                student.Degree = int.Parse(Console.ReadLine());

                Console.Write("Gender: ");
                student.Gender = Console.ReadLine();

                var updatingStudent = studentService.UpdateStudent(student);

                if(updatingStudent is true)
                {
                    Console.WriteLine("\nChoosen student has been UPDATED successfully!!!\n");
                }
                else
                {
                    Console.WriteLine("\nChoosen student has NOT UPDATED!!!\n");
                }
            }
            else if(option is 6)
            {
                Console.Write("Enter question: ");
                test.QuestionText = Console.ReadLine();

                Console.Write("Enter variant A: ");
                test.AVariant = Console.ReadLine();

                Console.Write("Enter variant B: ");
                test.BVariant = Console.ReadLine();

                Console.Write("Enter variant C: ");
                test.CVariant = Console.ReadLine();

                Console.Write("Enter answer: ");
                test.Answer = Console.ReadLine();

                var testResult = testSrvice.AddTest(test);

                Console.WriteLine("\nTest has been added successfully!!!\n");
            }
            else if(option is 0)
            {
                break;
            }
            else if(option is 7)
            {
                Console.Write("Enter test's ID: ");
                var testByID = Guid.Parse(Console.ReadLine());

                var testResById = testSrvice.GetById(testByID);

                var str = $"Question: {testResById.QuestionText}\n Variant A: {testResById.AVariant}\n " +
                    $"Variant B: {testResById.BVariant}\n Variant C: {testResById.CVariant}\n Answer: {testResById.Answer}";

                Console.WriteLine(str);
                Console.WriteLine();
            }
            else if(option is 8)
            {
                var allTests = testSrvice.GetAllTests();

                foreach(var testResById in allTests)
                {
                    var str = $"Question: {testResById.QuestionText}\n Variant A: {testResById.AVariant}\n " +
                    $"Variant B: {testResById.BVariant}\n Variant C: {testResById.CVariant}\n Answer: {testResById.Answer}";

                    Console.WriteLine(str);
                    Console.WriteLine();
                }
            }
            else if(option is 9)
            {
                Console.WriteLine("Enter test's ID to remove: ");
                var testID = Guid.Parse(Console.ReadLine());

                var removingTest = testSrvice.DeleteTest(testID);

                if(removingTest is true)
                {
                    Console.WriteLine("\nChoosen test has been REMOVED successfully\n");
                }
                else
                {
                    Console.WriteLine("\nChoosen test has NOT REMOVED\n");
                }
            }
            else if(option is 10)
            {
                Console.Write("Question: ");
                test.QuestionText = Console.ReadLine();

                Console.Write("A variant: ");
                test.AVariant = Console.ReadLine();

                Console.Write("B variant: ");
                test.BVariant = Console.ReadLine();

                Console.Write("C variant: ");
                test.CVariant = Console.ReadLine();

                Console.Write("Answer: ");
                test.Answer = Console.ReadLine();

                var updatingTest = testSrvice.UpdateTest(test);

                if(updatingTest is true)
                {
                    Console.WriteLine("\nChoosen test has been UPDATED successfully!!!\n");
                }
                else
                {
                    Console.WriteLine("\nChoosen test has NOT UPDATED!!!\n");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }


    public static void StudentRunFrontEnd()
    {
        var test = new Test();
        ITestService testService = new TestService();
        IStudentService studentService = new StudentService();

        while (true)
        {
            Console.Write("Enter your ID: ");
            var studentID = Guid.Parse(Console.ReadLine());

            var studendRes = studentService.GetById(studentID);

            Console.WriteLine("1. Start test: ");
            Console.WriteLine("2. Get all tests: ");
            Console.WriteLine("3. Show my results: ");
            Console.WriteLine();
            Console.Write("Option >> ");
            var option = int.Parse(Console.ReadLine());

            if (option is 1)
            {

                if (studendRes is null)
                {
                    Console.WriteLine("Wrong ID");
                }
                else
                {
                    Console.Write("Enter test ID for begin: ");
                    var testByID = Guid.Parse(Console.ReadLine());

                    var testResult = testService.GetById(testByID);

                    if (testResult is null)
                    {
                        Console.WriteLine("\nWrong test ID\n");
                    }
                    else
                    {

                        Console.WriteLine(testResult.QuestionText);
                        Console.WriteLine(testResult.AVariant);
                        Console.WriteLine(testResult.BVariant);
                        Console.WriteLine(testResult.CVariant);

                        Console.Write("Choose your option: ");
                        var testOption = Console.ReadLine();

                        if (testOption == testResult.Answer)
                        {
                            studendRes.StudentTestResults.Add(1);
                        }
                        else
                        {
                            studendRes.StudentTestResults.Add(0);
                        }
                        studentService.UpdateStudent(studendRes);
                    }

                }
            }
            else if(option is 2)
            {
                var allTests = testService.GetAllTests();

                foreach (var tesst in allTests)
                {
                    var str = $"Question: {tesst.QuestionText}\n A variant: {tesst.AVariant}\n B variant: {tesst.BVariant}\n " +
                        $"C variant: {tesst.CVariant}";

                    Console.WriteLine(str);
                    Console.WriteLine();

                    Console.Write("Enter your answer: ");
                    var testAnswer = Console.ReadLine();

                    if(testAnswer == tesst.Answer)
                    {
                        studendRes.StudentTestResults.Add(1);
                        studentService.UpdateStudent(studendRes);
                    }
                    else
                    {
                        studendRes.StudentTestResults.Add(0);
                        studentService.UpdateStudent(studendRes);
                    }
                }
            }
            else if(option is 3)
            {
                foreach(var testt in studendRes.StudentTestResults)
                {
                    Console.WriteLine($"{testt} ");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }

}