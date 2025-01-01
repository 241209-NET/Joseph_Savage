namespace PeriodicTable.API.PetException;

public class NoElementException : Exception
{
    public NoElementException(){}
    public NoElementException(string message) : base(message){}
    public NoElementException(string message, Exception inner) : base(message, inner){}
}