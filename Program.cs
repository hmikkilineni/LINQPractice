// ═══════════════════════════════════════════
// LINQ Practice
// ═══════════════════════════════════════════

// ── 1. LINQ with integers ──────────────────
Console.OutputEncoding = System.Text.Encoding.UTF8;

List<int> numbers = new List<int> { 3, 15, 7, 42, 1, 28, 9, 50 };

// Old way - foreach + if
List<int> bigNumbersOldWay = new List<int>();
foreach (int n in numbers)
{
    if (n > 10)
        bigNumbersOldWay.Add(n);
}

// LINQ way
List<int> bigNumbers = numbers.Where(n => n > 10).ToList();

Console.WriteLine("=== Numbers greater than 10 ===");
foreach (int n in bigNumbers)
    Console.WriteLine(n);

// ── 2. Chaining LINQ methods ───────────────
List<int> result = numbers
    .Where(n => n > 10)
    .Select(n => n * 2)
    .OrderBy(n => n)
    .ToList();

Console.WriteLine("\n=== Filtered, Doubled and Sorted ===");
Console.WriteLine($"Count: {result.Count()} | First: {result.First()}");
foreach (int n in result)
    Console.WriteLine(n);

// ── 3. LINQ with Objects ───────────────────
List<Employee> employees = new List<Employee>
{
    new Employee("Hari", "Developer", 50000),
    new Employee("Alex", "Consultant", 42000),
    new Employee("Sara", "Developer", 55000),
    new Employee("Tom", "Manager", 70000),
    new Employee("Lisa", "Consultant", 44000)
};

// Filter developers
var developers = employees.Where(e => e.Role == "Developer").ToList();
Console.WriteLine("\n=== Developers ===");
foreach (var e in developers)
    Console.WriteLine($"{e.Name} | €{e.Salary}");

// Filter by salary
var highEarners = employees.Where(e => e.Salary > 45000).ToList();
Console.WriteLine("\n=== Salary above €45000 ===");
foreach (var e in highEarners)
    Console.WriteLine($"{e.Name} | €{e.Salary}");

// Get names only
var names = employees.Select(e => e.Name).ToList();
Console.WriteLine("\n=== All Employee Names ===");
foreach (var name in names)
    Console.WriteLine(name);

// Order by salary
var sorted = employees.OrderBy(e => e.Salary).ToList();
Console.WriteLine("\n=== Employees by Salary (Low to High) ===");
foreach (var e in sorted)
    Console.WriteLine($"{e.Name} | €{e.Salary}");

// ── 4. GroupBy ─────────────────────────────
var grouped = employees.GroupBy(e => e.Role);
Console.WriteLine("\n=== Grouped by Role ===");
foreach (var group in grouped)
{
    Console.WriteLine($"\nRole: {group.Key} | Count: {group.Count()} | Avg Salary: €{group.Average(e => e.Salary)}");
    foreach (var emp in group)
        Console.WriteLine($"  - {emp.Name} | €{emp.Salary}");
}

// ── Employee Class ─────────────────────────
public class Employee
{
    public string Name { get; set; }
    public string Role { get; set; }
    public double Salary { get; set; }

    public Employee(string name, string role, double salary)
    {
        Name = name;
        Role = role;
        Salary = salary;
    }
}