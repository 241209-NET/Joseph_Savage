//using PeriodicTable.API.Data;
using PeriodicTable.API.Model;
using PeriodicTable.API.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PeriodicTable.API.Repository;

public class ElementRepository : IElementRepository
{
    // Need the DB Object to work with.
    private readonly PeriodicTableContext _periodicTableContext;

    // Constructor to inject the DbContext
    public ElementRepository(PeriodicTableContext periodicTableContext) => _periodicTableContext = periodicTableContext;

    public IEnumerable<Element> GetAllElements()
    {
        return _periodicTableContext.Elements
        .OrderBy(e => e.Enumber)
        .Include(e => e.Egroup)  // Eagerly load the related 'Group' entity
        .ToList();
    }
    public Element? GetElementByEnumber(int number)
    {
        return _periodicTableContext.Elements
            .Include(e => e.Egroup)
            .FirstOrDefault(e => e.Enumber == number);
    }



    public Element? DeleteElementByEnumber(int number)
    {
        var element = GetElementByEnumber(number);
        if (element != null)
        {
            _periodicTableContext.Elements.Remove(element);
            _periodicTableContext.SaveChanges();
            return element;
        }
        else {

            return null;

        }
    }
    public Element? GetElementByName(string name)
    {
        return _periodicTableContext.Elements
        .Include(e => e.Egroup)
        .FirstOrDefault(e => e.Ename.ToLower() == name.ToLower());
    }
    public Element CreateNewElement(Element newElement)
    {
        
        using var transaction = _periodicTableContext.Database.BeginTransaction();

        try
        {
            _periodicTableContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Elements ON");

            var existingGroup = _periodicTableContext.Groups
            .FirstOrDefault(g => g.Gnumber == newElement.Egroup.Gnumber);

            if (existingGroup != null)
            {
                newElement.Egroup = existingGroup;
            }

            _periodicTableContext.Elements.Add(newElement);
            _periodicTableContext.SaveChanges();

            _periodicTableContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Elements OFF");

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;

        }

        return newElement;
        
    }

}