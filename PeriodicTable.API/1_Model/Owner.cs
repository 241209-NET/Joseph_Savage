namespace PetTracker.API.Model;

public class Owner
{
    public int Id { get; set;}
    public string? Address { get; set; }

    public List<Pet> Pets { get; set; } = [];
}