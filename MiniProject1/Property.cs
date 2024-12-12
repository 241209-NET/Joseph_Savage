//Properties are spaces that can purchased by the player
public class Property : Square {
    public double price;
    public int owner = -1;

    public Property(string name, double price, int owner) : base(name) {
        this.name = name;
        this.price = price;
        this.owner = owner;
    }
}