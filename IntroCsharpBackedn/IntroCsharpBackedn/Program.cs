﻿var sale = new Sale(15);
//Sale sale = new ();
sale.Total = 15;

var message = sale.GetInfo();

Console.WriteLine(message);

class Sale
{
    public decimal Total { get; set; }
    private decimal _some;

    public Sale(decimal total)
    {
        Total = total;
        _some = 8;
    }

    public string GetInfo()
    {
        return "El total es " + Total;
    }
}
