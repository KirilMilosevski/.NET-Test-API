using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? EnrollmentDate { get; set; }

        public DateTime? DOB { get; set; }

        public string Mail { get; set; }

        public string StudentIndex { get; set; }

        public decimal? GPA { get; set; }

        public int AddressId { get; set; }

        public virtual AddressDTO Address { get; set; }
    }
}
