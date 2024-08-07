// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;
using System.Globalization;

Console.Write("Enter department's name: ");
string departmentName = Console.ReadLine()!;
Console.WriteLine("Enter worker data:");
Console.Write("Name: ");
string name = Console.ReadLine()!;
Console.Write("Level (Junior/MidLevel/Senior): ");
WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()!);
Console.Write("Base salary: ");
double baseSalary = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

Department dept = new(departmentName);
Worker worker = new(name, level, baseSalary, dept);

Console.Write("How many contracts to this worker? ");
int numberOfContracts = int.Parse(Console.ReadLine()!);

for (int i = 1; i <= numberOfContracts; i++)
{
  Console.WriteLine($"Enter #{i} contract data:");

  Console.Write("Date (DD/MM/YYYY): ");
  DateTime date = DateTime.Parse(Console.ReadLine()!);
  Console.Write("Value per hour: ");
  double valuePerHour = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
  Console.Write("Duration (hours): ");
  int hours = int.Parse(Console.ReadLine()!);

  HourContract contract = new(date, valuePerHour, hours);

  worker.AddContract(contract);
}

Console.Write("\nEnter month and year to calculate income (MM/YYYY): ");
string monthAndYear = Console.ReadLine()!;

int month = int.Parse(monthAndYear.Split("/")[0]);
int year = int.Parse(monthAndYear.Split("/")[1]);

Console.WriteLine($"Name: {worker.Name}");
Console.WriteLine($"Department: {worker.Department!.Name}");
Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");