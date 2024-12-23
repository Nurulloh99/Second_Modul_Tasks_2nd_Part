using _2._4_Lesson.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._4_Lesson.Api.Services;

public class TestService : ITestService
{
    private string testFilePath;
    private List<Test> _tests;

    public string studentPassword = "student";

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

    public void DataSave()
    {
        var testJson = JsonSerializer.Serialize(_tests);
        File.WriteAllText(testFilePath, testJson);
    }

    public List<Test> GetAllTestsFromJson()
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

    public Test GetById(Guid testID)
    {
        foreach(var test in _tests)
        {
            if(test.Id == testID)
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

    public bool DeleteTest(Guid testID)
    {
        var deletingTest = GetById(testID);

        if(deletingTest is null)
        {
            return false;
        }

        _tests.Remove(deletingTest);
        DataSave();
        return true;
    }

    public bool UpdateTest(Test test)
    {
        var updatingTest = GetById(test.Id);

        if(updatingTest is null)
        {
            return false;
        }

        var index = _tests.IndexOf(updatingTest);
        _tests[index] = test;
        DataSave();
        return true;
    }
}
