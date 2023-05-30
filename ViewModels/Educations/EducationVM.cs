using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels.Educations
{
    public class EducationVM
    {
        public Guid? Guid { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }

        [Range(0,4)]
        public float GPA { get; set; }
        public Guid UniversityGuid { get; set; }

        /*public static EducationVM ToVM(Education education)
        {
            return new EducationVM
            {
                Guid = education.Guid,
                Major = education.Major,
                Degree = education.Degree,
                GPA = education.GPA,
                UniversityGuid = education.UniversityGuid
            };
        }*/
    }
}
