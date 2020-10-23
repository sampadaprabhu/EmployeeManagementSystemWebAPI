using System;
using System.ComponentModel.DataAnnotations;

namespace EmpManagementML
{
    public class EmpManagementModelLayer
    {
        public int EmpID { get; set; }

        [Required(ErrorMessage ="First Name Is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name Is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email ID Is Required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please Enter Valid Email ID")]
        public string EmailID { get; set; }

        [Required(ErrorMessage ="Phone Number Is Required")]
        [RegularExpression(@"^([6-9]{1}[0-9]{9})$", ErrorMessage = "Please Enter Valid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Department ID Is Required")]
        public int DepartmentID { get; set; }
    }
}
