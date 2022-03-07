// See https://aka.ms/new-console-template for more information

using Generics.Data;
using Generics.Entities;
using Generics.Extensions;
using Generics.Repositories;

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
employeeRepository.ItemAdded += EmployeeAdded;

AddEmployees(employeeRepository);
AddManagers(employeeRepository);

GetEmployeeById(employeeRepository);
WriteAllToConsole(employeeRepository);

var organizationRepository = new ListRepository<Organization>();
AddOrganizations(organizationRepository);
WriteAllToConsole(organizationRepository);

Console.ReadLine();

void EmployeeAdded(object? sender, Employee employee)
{
    Console.WriteLine($"Employee added => {employee.FirstName}");
}

void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Sara" });
    managerRepository.Add(new Manager { FirstName = "Henry" });
    managerRepository.Save();
}

void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

void GetEmployeeById(IRepository<Employee> employeeRepo)
{
    var employee = employeeRepo.GetById(2);
    Console.WriteLine($"Employee with Id 2: {employee?.FirstName}");
}

void AddEmployees(IRepository<Employee> sqlRepository)
{
    var employees = new[]
    {
        new Employee { FirstName = "Ana" },
        new Employee { FirstName = "Julia" },
        new Employee { FirstName = "Thomas" }
    };

    sqlRepository.AddBatch(employees);
}

void AddOrganizations(IRepository<Organization> organizationRepo)
{
    var organizations = new[]
    {
        new Organization { Name = "PluralSight" },
        new Organization { Name = "Udemy" }

    };

    organizationRepo.AddBatch(organizations);
}