using _2._4_Lesson.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_Lesson.Api.Services;

public interface ITestService
{
    public Test AddTest(Test test);

    public Test GetById(Guid testID);

    public List<Test> GetAllTests();

    public bool DeleteTest(Guid testID);

    public bool UpdateTest(Test test);
}
