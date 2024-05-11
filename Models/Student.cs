using System;
using System.Collections.Generic;

namespace ASPCoreWebApiCRUD.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
