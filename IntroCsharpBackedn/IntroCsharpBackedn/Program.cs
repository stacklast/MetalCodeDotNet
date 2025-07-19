var numbers = new MyList<int>(5);
var names = new MyList<string>(5);
var beers = new MyList<Beer>(3);

numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(5);
numbers.Add(6);

Console.WriteLine(numbers.GetContent());

names.Add("nombres1");
names.Add("nombres2");
names.Add("nombres3");
names.Add("nombres4");
names.Add("nombres5");
names.Add("nombres6");

Console.WriteLine(names.GetContent());

beers.Add(new Beer()
{
     Name = "Erdinger",
     Price = 5
});

beers.Add(new Beer()
{
    Name = "Corona",
    Price = 5
});

beers.Add(new Beer()
{
    Name = "Pilsener",
    Price = 5
});

beers.Add(new Beer()
{
    Name = "Club",
    Price = 5
});

Console.WriteLine(beers.GetContent());

Console.ReadKey();

public class MyList<T>
{
    private List<T> _list;
    private int _limit;

    public MyList(int limit) 
    { 
        _limit = limit;
        _list = new List<T>();
    }

    public void Add(T element)
    {
        if (_list.Count < _limit)
        {
            _list.Add(element);
        }
    }

    public string GetContent()
    {
        string content = "";
        foreach (var element in _list)
        {
            content += element + ", ";
        }
        return content;
    }
}

public class Beer
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        return "Name: " + Name + " Price: "+ Price;
    }
}