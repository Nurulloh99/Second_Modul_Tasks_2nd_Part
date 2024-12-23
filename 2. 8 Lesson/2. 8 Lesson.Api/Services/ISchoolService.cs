using _2._8_Lesson.Api.DataAccess.Enums;
using _2._8_Lesson.Api.Services.DTOs;

namespace _2._8_Lesson.Api.Services;

public interface ISchoolService
{
    SchoolGetDto AddSchool(SchoolCreateDto school);
    SchoolGetDto GetSchoolById(Guid schoolId);
    List<SchoolGetDto> GetAllSchools();
    void RemoveSchool(Guid schoolId);
    void UpdateSchool(SchoolUpdateDto school);
    string GetLocationBySchool(string school);
    List<SchoolGetDto> GetSchoolsByLocation(string location);
    int GetStudentsAmountByGender(Gender studentGender, string school);
}
