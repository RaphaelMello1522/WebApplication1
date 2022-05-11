using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Enrollment
    {
        public enum Grade
        {
            A, B, C, D, F
        }

        public class enrollment
        {
            [Key]
            public int EnrollmentID { get; set; }
            public int CourseID { get; set; }
            public int alunoID { get; set; }
            public Grade? Grade { get; set; }

            public virtual curso Curso { get; set; }
            public virtual aluno Aluno { get; set; }
        }
    }
}
