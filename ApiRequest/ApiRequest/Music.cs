using System.Text.Json.Serialization;

namespace ApiRequest;

public class Music
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public double MB { get; set; }
    public string AuthorName { get; set; }
    public string Description { get; set; }
    public int QuentityLikes { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, MB: {MB}, Author name: {AuthorName}, Description: {Description}, Quentity likes: {QuentityLikes}";
    }


}
