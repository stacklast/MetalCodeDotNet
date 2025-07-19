/*using System;

var sale = new Sale(15);
//Sale sale = new ();
sale.Total = 15;

var saleWithTax = new SaleWithTax(15, 1.16m);

var message = saleWithTax.GetInfo();

Console.WriteLine(message);

class SaleWithTax : Sale
{
    public decimal Tax { get; set; }
    public SaleWithTax(decimal total, decimal tax) : base(total)
    {
        Tax = tax;
    }

    //override metodo del padre con virtual
    public override string GetInfo()
    {
        return "El total es " + Total + " Impuesto: " + Tax;
    }

    //sobrecarga metodos con el mismo nombre en la misma clase
    public string GetInfo(string message)
    {
        return message;
    }
}

class Sale
{
    public decimal Total { get; set; }
    private decimal _some;

    public Sale(decimal total)
    {
        Total = total;
        _some = 8;
    }

    //virtual para sobreescritura
    public virtual string GetInfo()
    {
        return "El total es " + Total + _some;
    }
}

*/