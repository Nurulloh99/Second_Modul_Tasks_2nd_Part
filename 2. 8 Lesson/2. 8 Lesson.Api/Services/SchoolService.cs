using _2._8_Lesson.Api.DataAccess.Entities;
using _2._8_Lesson.Api.DataAccess.Enums;
using _2._8_Lesson.Api.Repositories;
using _2._8_Lesson.Api.Services.DTOs;

namespace _2._8_Lesson.Api.Services;

public class SchoolService : ISchoolService
{
    private ISchoolRepositorie schoolRepo;
    private ISchoolService schoolSecRepo;

    public SchoolService()
    {
        schoolRepo = new SchoolRepositorie();
        schoolSecRepo = new SchoolService();
    }

    public SchoolGetDto AddSchool(SchoolCreateDto school)
    {
        ValidateSchoolCreateDto(school);
        var newSchool = ConvertSchool(school);
        newSchool.Id = Guid.NewGuid();
        schoolRepo.WriteSchool(newSchool);
        return ConvertSchool(newSchool);
    }

    public List<SchoolGetDto> GetAllSchools()
    {
        var schoolResult = schoolRepo.ReadAllSchools();
        var schoolRes = new List<SchoolGetDto>();

        foreach(var school in schoolResult)
        {
            schoolRes.Add(ConvertSchool(school));
        }

        return schoolRes;
    }

    public string GetLocationBySchool(string schoolName)
    {
        var schoolResult = schoolRepo.ReadAllSchools();

        foreach (var school in schoolResult)
        {
            if(school.Name == schoolName)
            {
                return school.Location;
            }
        }

        throw new Exception("Not found!");
    }


    public List<SchoolGetDto> GetSchoolsByLocation(string location)
    {
        var schoolResult = schoolRepo.ReadAllSchools();
        var schoolsByLoc = new List<SchoolGetDto>();

        foreach (var school in schoolResult)
        {
            if(school.Location == location)
            {
                schoolsByLoc.Add(ConvertSchool(school));
            }
        }

        return schoolsByLoc;
    }







    public SchoolGetDto GetSchoolById(Guid schoolId)
    {
        var schoolResult = schoolRepo.ReadAllSchools();

        foreach (var school in schoolResult)
        {
            if(school.Id == schoolId)
            {
                return ConvertSchool(school);
            }
        }

        throw new Exception("Error occured!!!");
    }




    public int GetStudentsAmountByGender(Gender studentGender, string school)
    {
        var schoolResult = schoolRepo.ReadAllSchools();
        var amount = 0;

        foreach(var student in schoolResult)
        {
            if(student.Name == school && student.MaleFemale == studentGender)
            {
                amount++;
            }
        }

        return amount;
    }




    public void RemoveSchool(Guid schoolId)
    {
        schoolRepo.RemoveSchool(schoolId);
    }


    public void UpdateSchool(SchoolUpdateDto school)
    {
        schoolRepo.UpdateSchool(ConvertSchool(school));
    }



    private School ConvertSchool(SchoolUpdateDto school)
    {
        return new School()
        {
            Id = school.Id,
            Name = school.Name,
            Location = school.Location,
            Rating = school.Rating,
            Description = school.Description,
            StudentsCount = school.StudentsCount,
            Password = school.Password

        };
    }

    private School ConvertSchool(SchoolCreateDto school)
    {
        return new School()
        {
            Name = school.Name,
            Location = school.Location,
            Rating = school.Rating,
            Description = school.Description,
            StudentsCount = school.StudentsCount,
            Password = school.Password
        };
    }

    private SchoolGetDto ConvertSchool(School school)
    {
        return new SchoolGetDto()
        {
            Id = school.Id,
            Name = school.Name,
            Location = school.Location,
            Rating = school.Rating,
            Description = school.Description,
            StudentsCount = school.StudentsCount,
        };
    }


    private void ValidateSchoolCreateDto(SchoolCreateDto school)
    {
        if(string.IsNullOrWhiteSpace(school.Name) || school.Name.Length < 8)
        {
            throw new Exception("Error occured!!!");
        }

        if(string.IsNullOrWhiteSpace(school.Location))
        {
            throw new Exception("Error occured!!!");
        }

        if(school.Rating < 1 || school.Rating > 10)
        {
            throw new Exception("Error occured!!!");
        }

        if(school.StudentsCount < 20 || school.StudentsCount > 45)
        {
            throw new Exception("Error occured!!!");
        }

        if(school.Password.Length < 8)
        {
            throw new Exception("Error occured !!!");
        }
    }
}
