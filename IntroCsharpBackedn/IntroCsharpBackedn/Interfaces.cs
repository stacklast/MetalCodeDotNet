/*
 using System;

var sale = new Sale();
var beer = new Beer();

Some(sale);
Some(beer);

void Some(ISave save) 
{ 
    save.Save();
}

interface ISale
{
    decimal Total { get; set; }
}

interface ISave
{
    public void Save();
}

public class Sale : ISale, ISave
{
    public Sale() { }

    public decimal Total { get; set; }

    public void Save()
    {
        Console.WriteLine("se guardo en DB");
    }
}

public class Beer: ISave
{
    public Beer() { }
    public void Save()
    {
        Console.WriteLine("se guardo en Servicio");
    }
}
 */