namespace Washyn.ComprobantePdf.Templates;

public class ComprobanteModel
{
    
}

public class ComprobanteDetails
{
    public Guid ComprobanteId { get; set; }
    public string FullName { get; set; }
    public string Document { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public int Number { get; set; }
}
public class ComprobanteItems
{
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Cantidad { get; set; }
}
public class ComprobanteAndItems
{
    public ComprobanteDetails Details { get; set; }
    public List<ComprobanteItems> Items { get; set; }

    public ComprobanteAndItems()
    {
        Items = new List<ComprobanteItems>();
    }
}