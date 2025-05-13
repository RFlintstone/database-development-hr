using EFCore.Models;

namespace EFCore.DataStore
{
    public static class DatabaseSeeder
    {
        public static void Seed(this DatabaseContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();
            
            // Seed Employees
            if (!context.Employees.Any())
            {
                var employee1 = new Employee
                {
                    Fname = "John",
                    Minit = "A",
                    Lname = "Doe",
                    Ssn = "123456789",
                    Bdate = new DateTime(1985, 5, 1).ToUniversalTime(),
                    Address = "123 Elm St, NY",
                    Sex = "M",
                    Salary = 60000,
                    Super_ssn = null, // No supervisor initially
                    Dno = 1 // Assigned to Research department
                };

                var employee2 = new Employee
                {
                    Fname = "Jane",
                    Minit = "B",
                    Lname = "Smith",
                    Ssn = "987654321",
                    Bdate = new DateTime(1990, 7, 10).ToUniversalTime(),
                    Address = "456 Oak St, LA",
                    Sex = "F",
                    Salary = 75000,
                    Super_ssn = "123456789", // John is her supervisor
                    Dno = 2 // Assigned to Sales department
                };

                context.Employees.AddRange(employee1, employee2);
                context.SaveChanges();
            }

            // Seed Locations
            if (!context.Locations.Any())
            {
                var location1 = new Location
                {
                    Name = "New York Office",
                    Address = "789 Broadway, NY"
                };

                var location2 = new Location
                {
                    Name = "Los Angeles Office",
                    Address = "321 Sunset Blvd, LA"
                };

                context.Locations.AddRange(location1, location2);
                context.SaveChanges();
            }

            // Seed Departments
            if (!context.Departments.Any())
            {
                var department1 = new Department
                {
                    Dnumber = 1,
                    Dname = "Research",
                    Mgr_ssn = "123456789", // John is the manager
                    Mgr_start_date = new DateTime(1985, 5, 1).ToUniversalTime()
                };

                var department2 = new Department
                {
                    Dnumber = 2,
                    Dname = "Sales",
                    Mgr_ssn = "987654321", // Jane is the manager
                    Mgr_start_date = new DateTime(1985, 5, 1).ToUniversalTime()
                };

                context.Departments.AddRange(department1, department2);
                context.SaveChanges();
            }

            // Seed DeptLocations (Department-Location relationship)
            if (!context.DeptLocations.Any())
            {
                var deptLocation1 = new DeptLocations
                {
                    Dnumber = 1,
                    Dlocation = "New York Office"
                };

                var deptLocation2 = new DeptLocations
                {
                    Dnumber = 2,
                    Dlocation = "Los Angeles Office"
                };

                context.DeptLocations.AddRange(deptLocation1, deptLocation2);
                context.SaveChanges();
            }

            // Seed Projects
            if (!context.Projects.Any())
            {
                var project1 = new Project
                {
                    Pnumber = 101,
                    Pname = "Project Alpha",
                    Plocation = "New York",
                    Dnum = 1 // Assigned to Research department
                };

                var project2 = new Project
                {
                    Pnumber = 102,
                    Pname = "Project Beta",
                    Plocation = "Los Angeles",
                    Dnum = 2 // Assigned to Sales department
                };

                context.Projects.AddRange(project1, project2);
                context.SaveChanges();
            }

            // Seed WorksOn (Many-to-Many between Employee and Project)
            if (!context.WorksOn.Any())
            {
                var worksOn1 = new WorksOn
                {
                    Essn = "123456789", // John
                    Pno = 101 // Project Alpha
                };

                var worksOn2 = new WorksOn
                {
                    Essn = "987654321", // Jane
                    Pno = 102 // Project Beta
                };

                context.WorksOn.AddRange(worksOn1, worksOn2);
                context.SaveChanges();
            }

            // Seed Dependents
            if (!context.Dependents.Any())
            {
                var dependent1 = new Dependent
                {
                    Essn = "123456789", // John
                    Dependent_name = "Alice",
                    Sex = "F",
                    Bdate = new DateTime(2015, 4, 20).ToUniversalTime(),
                    Relationship = "Daughter"
                };

                var dependent2 = new Dependent
                {
                    Essn = "987654321", // Jane
                    Dependent_name = "Bob",
                    Sex = "M",
                    Bdate = new DateTime(2018, 9, 15).ToUniversalTime(),
                    Relationship = "Son"
                };

                context.Dependents.AddRange(dependent1, dependent2);
                context.SaveChanges();
            }
        }
    }
}