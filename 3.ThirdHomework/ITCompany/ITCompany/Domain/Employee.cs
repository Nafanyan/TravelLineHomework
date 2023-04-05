namespace ITCompany.Domain
{
    public class Employee
    {
        public long EmployeeId { get; init; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeePost { get; set; }
        public long ProjectTaskId { get; set; }

        public Employee (long employeeId, string employeeName, string employeeSurname, string employeePost, long employeeDepartamentId)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            EmployeeSurname = employeeSurname;
            EmployeePost = employeePost;
            ProjectTaskId = employeeDepartamentId;
        }
    }
}
