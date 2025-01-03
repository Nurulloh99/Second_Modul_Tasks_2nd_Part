namespace Restaurant.Api.DataAccess.Entities;

public class Restaurant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Rating { get; set; }
    public int Capacity { get; set; }
    public string OpenedDate { get; set; }
    public string Branches { get; set; }
    public double TotalPrice { get; set; }
    public string NationOfRestaurant { get; set; }
}
