using _2._8_Lesson.Api.DataAccess.Entities;
using _2._8_Lesson.Api.DataAccess.Enums;
using _2._8_Lesson.Api.Services.DTOs;

namespace _2._8_Lesson.Api.Repositories;

public interface ISchoolRepositorie
{
    School WriteSchool(School school);
    School ReadSchoolById(Guid schoolId);
    List<School> ReadAllSchools();
    void RemoveSchool(Guid schoolId);
    void UpdateSchool(School school);
}
