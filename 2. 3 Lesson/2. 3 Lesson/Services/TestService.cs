using _2._3_Lesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._3_Lesson.Services;

public class TestService : ITestService
{
    private string testFilePath;
    private List<Test> _tests;

    public TestService()
    {
        testFilePath = "../../../Data/Tests.json";

        _tests = new List<Test>();

        if(File.Exists(testFilePath) is false)
        {
            File.WriteAllText(testFilePath, "[]");
        }

        _tests = GetAllTestsFromJson();
    }


    private void DataSave()
    {
        var testJson = JsonSerializer.Serialize(testFilePath);
        File.WriteAllText(testFilePath, testJson);
    }


    private List<Test> GetAllTestsFromJson()
    {
        var testResult = File.ReadAllText(testFilePath);
        var testJson = JsonSerializer.Deserialize<List<Test>>(testResult);
        return testJson;
    }


    public Test AddTest(Test test)
    {
        test.Id = Guid.NewGuid();
        _tests.Add(test);
        DataSave();
        return test;
    }



    public Test GetById(Guid testId)
    {
        foreach(var test in _tests)
        {
            if(test.Id == testId)
            {
                return test;
            }
        }
        return null;
    }



    public List<Test> GetAllTests()
    {
        return _tests;
    }



    public bool DeleteTest(Guid testId)
    {
        var tests = GetById(testId);

        if(tests is null)
        {
            return false;
        }

        _tests.Remove(tests);
        DataSave();
        return true;
    }



    public bool UpdateTest(Test test)
    {
        var testId = GetById(test.Id);

        if(testId is null)
        {
            return false;
        }

        var index = _tests.IndexOf(testId);
        _tests[index] = test;
        DataSave();
        return true;
    }
}
