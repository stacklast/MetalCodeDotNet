var names = new List<string>()
{
    "Edwin", "Javier", "Luis", "Juan", "Ana"
};

var namesResult = from n in names
                  where n.Length > 3 && n.Length < 5
                  orderby n descending
                  select n;

var nameResult2 = names
    .Where(n => n.Length > 3 && n.Length < 5)
    .OrderByDescending(n => n)
    .Select(d=>d);

foreach (var name in namesResult)
{
    Console.WriteLine(name);
}

Console.ReadKey();