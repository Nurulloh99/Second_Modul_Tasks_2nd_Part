using _2._8_Lesson.Api.DataAccess.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _2._8_Lesson.Api.Repositories;

public class SchoolRepositorie : ISchoolRepositorie
{
    public string _path = "../../../DataAccess/Data/Schools.json";
    private List<School> _schools;

    public SchoolRepositorie()
    {
        _schools = new List<School>();

        if(File.Exists(_path) is false)
        {
            File.WriteAllText(_path, "[]");
        }

        _schools = ReadAllSchools();
    }
    
    public List<School> ReadAllSchools()
    {
        var studentJson = JsonSerializer.Deserialize<List<School>>(File.ReadAllText(_path));
        return studentJson;
    }

    public void DataSave()
    {
        var schoolJson = JsonSerializer.Serialize(_schools);
        File.WriteAllText(_path, schoolJson);
    }


    public School WriteSchool(School school)
    {
        _schools.Add(school);
        DataSave();
        return school;
    }


    public School ReadSchoolById(Guid schoolId)
    {
        foreach(var school in _schools)
        {
            if(school.Id == schoolId)
            {
                return school;
            }
        }

        return null;
    }

    /// 20070721

    public void RemoveSchool(Guid schoolId)
    {
        _schools.Remove(ReadSchoolById(schoolId));
        DataSave();
    }


    public void UpdateSchool(School school)
    {
        _schools[_schools.IndexOf(ReadSchoolById(school.Id))] = school;
        DataSave();
    }

    
}
