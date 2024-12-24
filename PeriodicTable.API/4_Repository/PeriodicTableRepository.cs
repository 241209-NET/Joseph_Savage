//using PeriodicTable.API.Data;
using PeriodicTable.API.Model;
using PeriodicTable.API.Data;

namespace PeriodicTable.API.Repository;

public class PeriodicTableRepository : IPeriodicTableRepository
{
    // Need the DB Object to work with.
    private readonly PeriodicTableContext _periodicTableContext;

    // Constructor to inject the DbContext
    public PeriodicTableRepository(PeriodicTableContext periodicTableContext) => _periodicTableContext = periodicTableContext;

    public IEnumerable<Element> GetAllElements()
    {
        return _periodicTableContext.Elements.ToList();
    }

    public Element CreateNewElement(Element newElement)
    {
        // Insert new element
        _periodicTableContext.Elements.Add(newElement);
        _periodicTableContext.SaveChanges();
        return newElement;
    }

    public Element? GetElementByEnumber(int number)
    {
        return _periodicTableContext.Elements.Find(number);
    }

    public void DeleteElementByEnumber(int number)
    {
        var element = GetElementByEnumber(number);
        if (element != null)
        {
            _periodicTableContext.Elements.Remove(element);
            _periodicTableContext.SaveChanges();
        }
    }

    public IEnumerable<Element> GetElementByName(string name)
    {
        return _periodicTableContext.Elements
            .Where(e => e.Ename.Equals(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}