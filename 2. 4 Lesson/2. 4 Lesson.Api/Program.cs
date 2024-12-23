using _2._4_Lesson.Api.Models;
using _2._4_Lesson.Api.Services;

namespace _2._4_Lesson.Api
{
    internal class Program
    {
        public static string directorPassword = "director";


        public static void PasswordRun()
        {
            ITeacherService teacherService = new TeacherService();

            while (true)
            {
                Console.WriteLine("1. Director");
                Console.WriteLine("2. Teacher");
                Console.WriteLine("3. Student");
                Console.WriteLine();
                Console.Write("Choose >> ");
                var option = int.Parse(Console.ReadLine());
                Console.Clear();

                if (option is 1)
                {
                    Console.Write("Enter your password: ");
                    var password = Console.ReadLine();

                    if (password == directorPassword)
                    {
                        DirectorRun();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("0. Forgot password");
                        Console.Write("Enter zero >> ");
                        var pass = int.Parse(Console.ReadLine());
                        if (pass is 0)
                        {
                            Console.Write("Enter username: ");
                            var user = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Enter phone number: ");
                            var phone = Console.ReadLine();

                            var result = teacherService.DefineByPhoneNumber(user, phone);

                            if (result is false)
                            {
                                Console.WriteLine("\nError occured, incorrect username or phone number!!!\n");
                            }
                            else
                            {
                                Console.Write("Enter new password: ");
                                directorPassword = Console.ReadLine();
                                Console.WriteLine("\nChoosen password has been changed SUCCESSFULLY!!!\n");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nError occured or incorrect password!!!\n");
                        }
                    }
                }
                else if (option is 2)
                {
                    var teacherss = teacherService.GetAllTeachers();

                    Console.Write("Enter your password: ");
                    var password = Console.ReadLine();

                    foreach (var teach in teacherss)
                    {
                        if (password == teach.Password)
                        {
                            TeacherRun();
                        }
                        else
                        {
                            Console.WriteLine("0. Forgot password");
                            Console.Write("Enter zero >> ");
                            var pass = int.Parse(Console.ReadLine());
                            if (pass is 0)
                            {
                                Console.Write("Enter username: ");
                                var user = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Enter phone number: ");
                                var phone = Console.ReadLine();

                                var result = teacherService.DefineByPhoneNumber(user, phone);

                                if (result is false)
                                {
                                    Console.WriteLine("\nError occured, incorrect username or phone number!!!\n");
                                }
                                else
                                {
                                    Console.Write("Enter new password: ");
                                    teach.Password = Console.ReadLine();
                                    teacherService.UpdateTeacher(teach);
                                    Console.WriteLine("\nChoosen password has been changed SUCCESSFULLY!!!\n");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nError occured or incorrect password!!!\n");
                            }
                        }
                    }
                    continue;
                }
                else if(option is 3)
                {
                    var studentService = new StudentService();
                    var studentss = studentService.GetAllStudents();

                    Console.Write("Enter your password: ");
                    var password = Console.ReadLine();

                    foreach (var student in studentss)
                    {
                        if (password == student.Password)
                        {
                            StudentRun();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("0. Forgot password");
                            Console.Write("Enter zero >> ");
                            var pass = int.Parse(Console.ReadLine());
                            if (pass is 0)
                            {
                                Console.Write("Enter username: ");
                                var user = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Enter phone number: ");
                                var phone = Console.ReadLine();

                                var result = studentService.DefineByPhoneNumber(user, phone);

                                if (result is false)
                                {
                                    Console.WriteLine("\nError occured, incorrect username or phone number!!!\n");
                                }
                                else
                                {
                                    Console.Write("Enter new password: ");
                                    student.Password = Console.ReadLine();
                                    studentService.UpdateStudent(student);
                                    Console.WriteLine("\nChoosen password has been changed SUCCESSFULLY!!!\n");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nError occured or incorrect password!!!\n");
                            }
                        }
                    }
                    continue;
                }
            }
        }

        static void Main(string[] args)
        {
            PasswordRun();
        }

        public static void DirectorRun()
        {
            var teacher = new Teacher();
            ITeacherService teacherService = new TeacherService();

            while (true)
            {
                Console.WriteLine("1. Add teacher");
                Console.WriteLine("2. Get teacher by ID");
                Console.WriteLine("3. Get all teachers");
                Console.WriteLine("4. Delete teacher");
                Console.WriteLine("5. Update teacher");
                Console.WriteLine("6. Change password of teacher");
                Console.WriteLine();
                Console.Write("Choose: ");
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
                    Console.Write("DisLikes: ");
                    teacher.Dislike = int.Parse(Console.ReadLine());
                    Console.Write("Gender: ");
                    teacher.Gender = Console.ReadLine();
                    Console.Write("User name: ");
                    teacher.UserName = Console.ReadLine();
                    Console.Write("Phone number: ");
                    teacher.PhoneNumber = Console.ReadLine();
                    Console.Write("New password: ");
                    teacher.Password = Console.ReadLine();

                    var result = teacherService.AddTeacher(teacher);

                    Console.WriteLine("\nTeacher has been SUCCESSFULLY!!!\n");
                }
                else if (option is 2)
                {
                    Console.Write("Enter teacher's ID: ");
                    var teacherId = Guid.Parse(Console.ReadLine());

                    var result = teacherService.GetById(teacherId);

                    var str = $"First name: {result.FirstName}\n " +
                        $"Last name: {result.LastName}\n " +
                        $"Age: {result.Age}\n " +
                        $"Subject: {result.Subject}\n " +
                        $"Likes: {result.Likes}\n " +
                        $"DisLikes: {result.Dislike}\n " +
                        $"Password: {result.Password}";

                    Console.WriteLine(str);
                    Console.WriteLine();
                }
                else if (option is 3)
                {
                    var allTeachers = teacherService.GetAllTeachers();

                    foreach (var result in allTeachers)
                    {
                        var str = $"First name: {result.FirstName}\n " +
                        $"Last name: {result.LastName}\n " +
                        $"Age: {result.Age}\n " +
                        $"Subject: {result.Subject}\n " +
                        $"Likes: {result.Likes}\n " +
                        $"DisLikes: {result.Dislike}\n " +
                        $"Password: {result.Password}";

                        Console.WriteLine(str);
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (option is 4)
                {
                    Console.Write("Enter teacher's Id for removing >> ");
                    var deletingTeacher = Guid.Parse(Console.ReadLine());

                    var result = teacherService.DeleteTeacher(deletingTeacher);

                    if (result is true)
                    {
                        Console.WriteLine("\nChoosen teacher has been removed SUCCESSFULLY!!!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nChoosen teacher has NOT been DELETED\n");
                    }
                }
                else if (option is 5)
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
                    Console.Write("DisLikes: ");
                    teacher.Dislike = int.Parse(Console.ReadLine());
                    Console.Write("New password: ");
                    teacher.Password = Console.ReadLine();

                    var updatedTeacher = teacherService.UpdateTeacher(teacher);

                    if (updatedTeacher is true)
                    {
                        Console.WriteLine("\nChoosen teacher has been updated SUCCESSFULLY!!!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nChoosen teacher has NOT been UPDATED\n");
                    }
                }
                else if (option is 6)
                {
                    Console.Write("Enter user name: ");
                    var user = Console.ReadLine();
                    Console.Write("Enter phone number: ");
                    var number = Console.ReadLine();
                    Console.WriteLine();
                    var result = teacherService.DefineByPhoneNumber(user, number);

                    if (result is true)
                    {
                        Console.WriteLine("\nChoosen teacher's password has been changed successfully!!!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nPassword hasn't been changed. ERROR occured!\n");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public static void TeacherRun()
        {
            var students = new Student();
            IStudentService studentService = new StudentService();

            var tests = new Test();
            ITestService testService = new TestService();

            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Get student by ID");
            Console.WriteLine("3. Get all students");
            Console.WriteLine("4. Delete student");
            Console.WriteLine("5. Update student");
            Console.WriteLine("6. Change password of student");
            Console.WriteLine();
            Console.WriteLine("7. Add test");
            Console.WriteLine("8. Get test by ID");
            Console.WriteLine("9. Get all tests");
            Console.WriteLine("10. Delete test");
            Console.WriteLine("11. Update test");
            Console.WriteLine();

            Console.Write("Choose: ");
            var option = int.Parse(Console.ReadLine());

            Console.Clear();

            if (option is 1)
            {
                Console.Write("First name: ");
                students.FirstName = Console.ReadLine();
                Console.Write("Last name: ");
                students.LastName = Console.ReadLine();
                Console.Write("Age: ");
                students.Age = int.Parse(Console.ReadLine());
                Console.Write("Degree: ");
                students.Degree = int.Parse(Console.ReadLine());
                Console.Write("Phone number: ");
                students.PhoneNumber = Console.ReadLine();
                Console.Write("User name: ");
                students.UserName = Console.ReadLine();
                Console.Write("New password: ");
                students.Password = Console.ReadLine();

                var result = studentService.AddStudent(students);

                Console.WriteLine("\nChoosen student has been added SUCCESSFULLY!!!\n");
            }
            else if (option is 2)
            {
                Console.WriteLine("Enter student's ID: ");
                var studentId = Guid.Parse(Console.ReadLine());

                var result = studentService.GetById(studentId);

                var str = $"First name: {result.FirstName}\n " +
                    $"Last name: {result.LastName}\n " +
                    $"Age: {result.Age}\n " +
                    $"Degree: {result.Degree}\n " +
                    $"Phone number: {result.PhoneNumber}\n " +
                    $"User name: {result.UserName}\n " +
                    $"Password: {result.Password}\n " +
                    $"Results: ";
                foreach (var res in result.StudentResults)
                {
                    Console.Write($"{res} | ");
                }

                Console.WriteLine(str);
                Console.WriteLine();

                Console.ReadKey();
                Console.Clear();
            }
            else if (option is 3)
            {
                var allStudents = studentService.GetAllStudents();

                foreach(var student in allStudents)
                {
                    var str =$"Student's ID: {student.Id}\n " +
                        $"First name: {student.FirstName}\n " +
                        $"Last name: {student.LastName}\n " +
                        $"Age: {student.Age}\n " +
                        $"Degree: {student.Degree}\n " +
                        $"Phone number: {student.PhoneNumber}\n " +
                        $"User name: {student.UserName}\n " +
                        $"Password: {student.Password}\n " +
                        $"Results: ";
                    if (student.StudentResults is null)
                    {
                        str += " Empty";
                    }
                    else
                    {
                        foreach (var pupil in student.StudentResults)
                        {
                            Console.Write($"{pupil} | ");
                        }
                    }
                    Console.WriteLine(str);
                    Console.WriteLine();
                }
                Console.ReadKey();
                Console.Clear();
            }
            else if(option is 4)
            {
                Console.Write("Enter student's ID: ");
                var studentId = Guid.Parse(Console.ReadLine());

                var deletedResult = studentService.DeleteStudent(studentId);

                if(deletedResult is true)
                {
                    Console.WriteLine("\nChoosen student has been removed SUCCESSFULLY!!!\n");
                }
                else
                {
                    Console.WriteLine("\nChoosen student has NOT been deleted\n");
                }
            }
            else if(option is 5)
            {
                Console.Write("First name: ");
                students.FirstName = Console.ReadLine();
                Console.Write("Last name: ");
                students.LastName = Console.ReadLine();
                Console.Write("Age: ");
                students.Age = int.Parse(Console.ReadLine());
                Console.Write("Degree: ");
                students.Degree = int.Parse(Console.ReadLine());
                Console.Write("Phone number: ");
                students.PhoneNumber = Console.ReadLine();
                Console.WriteLine("User name: ");
                students.UserName = Console.ReadLine();
                Console.WriteLine("Password: ");
                students.Password = Console.ReadLine();

                var result = studentService.UpdateStudent(students);

                if(result is true)
                {
                    Console.WriteLine("\nChoosen student has been updated SUCCESSFULLY!!!\n");
                }
                else
                {
                    Console.WriteLine("\nChoosen student NOT UPDATED!\n");
                }
            }
            else if(option is 6)
            {
                Console.Write("Enter user name: ");
                var user = Console.ReadLine();
                Console.Write("Enter phone number: ");
                var number = Console.ReadLine();

                var result = studentService.DefineByPhoneNumber(user, number);

                if(result is true)
                {
                    Console.WriteLine("\nPassword has been changed SUCCESSFULLY!!!\n");
                }
                else
                {
                    Console.WriteLine("\nPassword has NOT been changed!\n");
                }
            }
            else if(option is 7)
            {
                Console.Write("Question: ");
                tests.QuestionText = Console.ReadLine();
                Console.Write("Variant A: ");
                tests.A_Variant = Console.ReadLine();
                Console.Write("Variant B: ");
                tests.B_Variant = Console.ReadLine();
                Console.Write("Variant C: ");
                tests.C_Variant = Console.ReadLine();
                Console.Write("Answer: ");
                tests.Answer = Console.ReadLine();

                testService.AddTest(tests);

                Console.WriteLine("\nChoosen test task has been added SUCCESSFULLY!!!\n");
            }
            else if(option is 8)
            {
                Console.Write("Enter test's ID: ");
                var testById = Guid.Parse(Console.ReadLine());

                var result = testService.GetById(testById);

                var str = $"Question: {result.QuestionText}\n " +
                    $"A option: {result.A_Variant}\n " +
                    $"B option: {result.B_Variant}\n " +
                    $"C option: {result.C_Variant}\n " +
                    $"Answer: {result.Answer}\n";

                Console.WriteLine(str);
                Console.WriteLine();
            }
            else if (option is 9)
            {
                var allTests = testService.GetAllTests();

                foreach(var result in allTests)
                {
                    var str = $"Question: {result.QuestionText}\n " +
                    $"A option: {result.A_Variant}\n " +
                    $"B option: {result.B_Variant}\n " +
                    $"C option: {result.C_Variant}\n " +
                    $"Answer: {result.Answer}\n";

                    Console.WriteLine(str);
                    Console.WriteLine();
                }
            }
            else if(option is 10)
            {
                Console.Write("Enter test's ID: ");
                var test = Guid.Parse(Console.ReadLine());

                var result = testService.DeleteTest(test);

                if(result is true)
                {
                    Console.WriteLine("\nChoosen test has been REMOVED SUCCESSFULLY!!!\n");
                }
                else
                {
                    Console.WriteLine("\nChoosen test has NOT been deleted!\n");
                }
            }
            else if(option is 11)
            {
                Console.Write("Question: ");
                tests.QuestionText = Console.ReadLine();
                Console.Write("Variant A: ");
                tests.A_Variant = Console.ReadLine();
                Console.Write("Variant B: ");
                tests.B_Variant = Console.ReadLine();
                Console.Write("Variant C: ");
                tests.C_Variant = Console.ReadLine();
                Console.Write("Answer: ");
                tests.Answer = Console.ReadLine();

                var result = testService.UpdateTest(tests);

                if(result is true)
                {
                    Console.WriteLine("\nChoosen test has been UPDATED SUCCESSFULLY!!!\n");
                }
                else
                {
                    Console.WriteLine("\nChoosen test has NOT been updated or ERROR occured!\n");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void StudentRun()
        {
            var tests = new Test();
            ITestService testServices = new TestService();

            IStudentService studentService = new StudentService();

            while (true)
            {
                Console.Write("Enter student's ID: ");
                var studentId = Guid.Parse(Console.ReadLine());
                var students = studentService.GetById(studentId);

                if (students is null)
                {
                    Console.WriteLine("Wrong ID");
                }
                else
                {
                    Console.WriteLine("1. Start test");
                    Console.WriteLine("2. Get all test");
                    Console.WriteLine("3. Show my results");
                    Console.WriteLine();
                    Console.Write("Choose: ");
                    var option = int.Parse(Console.ReadLine());

                    if (option is 1)
                    {
                        Console.Write("Enter test ID to begin: ");
                        var test = Guid.Parse(Console.ReadLine());

                        var idOfTest = testServices.GetById(test);

                        if (idOfTest is null)
                        {
                            Console.WriteLine("\nWrong test ID or ERROR occured\n");
                        }
                        else
                        {
                            var str = $"Question: {idOfTest.QuestionText}\n " +
                                $"A option: {idOfTest.A_Variant}\n " +
                                $"B option: {idOfTest.B_Variant}\n " +
                                $"C option: {idOfTest.C_Variant}\n ";
                            Console.WriteLine();
                            Console.Write("Choose one of them >> ");
                            var result = Console.ReadLine();  

                            if (result == idOfTest.Answer)
                            {
                                students.StudentResults.Add(1);
                                studentService.UpdateStudent(students);
                            }
                            else
                            {
                                students.StudentResults.Add(0);
                                studentService.UpdateStudent(students);
                            }
                        }
                    }
                    else if (option is 2)
                    {
                        var allTests = testServices.GetAllTests();

                        foreach (var test in allTests)
                        {
                            var str = $"Test's ID: {test.Id}\n " +
                                $"Question: {test.QuestionText}\n " +
                                $"A option: {test.A_Variant}\n " +
                                $"B option: {test.B_Variant}\n " +
                                $"C option: {test.C_Variant}\n ";

                            Console.WriteLine(str);
                            Console.WriteLine();

                            Console.Write("Enter your answer: ");
                            var answer = Console.ReadLine();

                            if (answer == test.Answer)
                            {
                                students.StudentResults.Add(1);
                                studentService.UpdateStudent(students);
                            }
                            else
                            {
                                students.StudentResults.Add(0);
                                studentService.UpdateStudent(students);
                            }
                        }
                    }
                    else if (option is 3)
                    {
                        foreach(var res in students.StudentResults)
                        {
                            Console.WriteLine($"{res} ");
                        }
                    }
                }
            }
        }



    }
}
