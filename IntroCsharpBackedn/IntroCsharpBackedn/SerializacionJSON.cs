/*
 using System.Text.Json;

var edwin = new People()
{
    Name = "Edwin",
    Age = 666,
};

string json = JsonSerializer.Serialize(edwin);

Console.WriteLine(json);

string myJson = @"{
    ""Name"":""Juan"",
    ""Age"":666
    }";

People? juan = JsonSerializer.Deserialize<People>(myJson);

Console.WriteLine(juan?.Name);
Console.WriteLine(juan?.Age);

Console.ReadKey();

public class People
{
    public string Name { get; set; }
    public int Age { get; set; }

}
 */