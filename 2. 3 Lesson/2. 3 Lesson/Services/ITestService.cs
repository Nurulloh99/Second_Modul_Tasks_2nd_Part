using _2._3_Lesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3_Lesson.Services;

public interface ITestService
{
    public Test AddTest(Test test);

    public Test GetById(Guid test);

    public List<Test> GetAllTests();

    public bool DeleteTest(Guid testId);

    public bool UpdateTest(Test test);
}
