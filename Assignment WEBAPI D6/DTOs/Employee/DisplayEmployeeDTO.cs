namespace Assignment_WEBAPI_D6.DTOs.Employee
{
    public class DisplayEmployeeDTO
    {
        public int EmployeeID { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }
        public DateOnly Hiredate { get; set; }
        public decimal Salary { get; set; }

        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }
}
