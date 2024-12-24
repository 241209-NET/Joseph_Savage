using PeriodicTable.API.Model;

namespace PeriodicTable.API.Repository;

public interface IPeriodicTableRepository
{
    //CRUD
    Element CreateNewElement(Element newElement); 
    IEnumerable<Element> GetAllElements(); 
    Element? GetElementByEnumber(int number); 
    IEnumerable<Element> GetElementByName(string name);
    void DeleteElementByEnumber(int number);    
}