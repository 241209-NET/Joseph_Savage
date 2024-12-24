
namespace PetTracker.API.Model;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Type { get; set; }
    public DateOnly? Birthday { get; set; }

    public List<Owner> Owners { get; set; } = [];
}