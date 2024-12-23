using _2._2_Lesson.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._2_Lesson.Api.Services;

public class TestService
{
    private string testFilePath;

    public TestService()
    {
        testFilePath = "../../../Data/Tests.json";

        if(File.Exists(testFilePath) is false)
        {
            File.WriteAllText(testFilePath, ".");
        }
    }


    public void SaveData(List<Test> tests)
    {
        var testJson = JsonSerializer.Serialize(tests);
        File.WriteAllText(testFilePath, testJson);
    }


    public List<Test> GetAllTestsFromJson()
    {
        var testsResult = File.ReadAllText(testFilePath);
        var testsJson = JsonSerializer.Deserialize<List<Test>>(testsResult);
        return testsJson;
    }

   
    
    public Test AddTest(Test test)
    {
        test.Id = Guid.NewGuid();
        var allTests = GetAllTestsFromJson();

        allTests.Add(test);
        SaveData(allTests);
        return test;
    }



    public Test GetById(Guid testId)
    {
        var allTests = GetAllTestsFromJson();

        foreach (var test in allTests)
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
        var allTests = GetAllTestsFromJson();
        return allTests;
    }



    public bool DeleteTest(Guid testId)
    {
        var testResult = GetById(testId);

        if(testResult is null)
        {
            return false;
        }

        var allTests = GetAllTestsFromJson();

        foreach(var test in allTests)
        {
            if(test.Id == testResult.Id)
            {
                allTests.Remove(test);
                break;
            }
        }
        SaveData(allTests);
        return true;
    }



    public bool UpdateTest(Test test)
    {
        var testById = GetById(test.Id);

        if(testById is null)
        {
            return false;
        }

        var allTests = GetAllTestsFromJson();

        for(var i = 0; i < allTests.Count; i++)
        {
            if (allTests[i].Id == testById.Id)
            {
                allTests[i] = test;
                break;
            }
        }
        SaveData(allTests);
        return true;
    }







}
