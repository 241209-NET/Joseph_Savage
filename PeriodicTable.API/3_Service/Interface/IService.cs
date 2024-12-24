using PeriodicTable.API.Model;

namespace PeriodicTable.API.Service;

public interface IPeriodicTableService
{
    Element CreateNewElement(Element newElement);
    IEnumerable<Element> GetAllElements();
    Element? GetElementByEnumber(int Enumber);
    IEnumerable<Element> GetElementByName(string name);
    Element? DeleteElementByEnumber(int Enumber);
}