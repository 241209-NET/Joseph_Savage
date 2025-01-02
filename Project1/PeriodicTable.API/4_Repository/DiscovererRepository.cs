//using PeriodicTable.API.Data;
using PeriodicTable.API.Model;
using PeriodicTable.API.Data;
using Microsoft.EntityFrameworkCore;

namespace PeriodicTable.API.Repository;

public class DiscovererRepository : IDiscovererRepository
{
    // Need the DB Object to work with.
    private readonly PeriodicTableContext _periodicTableContext;

    // Constructor to inject the DbContext
    public DiscovererRepository(PeriodicTableContext periodicTableContext) => _periodicTableContext = periodicTableContext;

    public IEnumerable<Discoverer> GetAllDiscoverers()
    {
        return _periodicTableContext.Discoverers.Include(d => d.ElementDiscovered).Include(g => g.ElementDiscovered.Egroup).ToList();
    }




    public Discoverer? GetDiscovererById(int number)
    {
        return _periodicTableContext.Discoverers.Include(d => d.ElementDiscovered).Include(g => g.ElementDiscovered.Egroup).FirstOrDefault(d => d.Did == number);
    }

    public Discoverer? GetDiscovererByLastName(string name)
    {
        return _periodicTableContext.Discoverers.Include(d => d.ElementDiscovered).Include(g => g.ElementDiscovered.Egroup)
        .FirstOrDefault(d => d.Lname.ToLower() == name.ToLower());
    }

    public Discoverer? DeleteDiscovererById(int number)
    {
        var Discoverer = GetDiscovererById(number);
        if (Discoverer != null)
        {
            _periodicTableContext.Discoverers.Remove(Discoverer);
            _periodicTableContext.SaveChanges();
            return Discoverer;
        }
        else {

            return null;

        }
    }

    //RAN out of time to implement!
    public Discoverer? GetDiscovererOfElement(int Enumber)
    {

         return _periodicTableContext.Discoverers.Include(d => d.ElementDiscovered).Include(g => g.ElementDiscovered.Egroup).FirstOrDefault(d => d.Enumber == Enumber);
         
    }

    //NOTE TO Leave remove line ""did": 0," to prevent error
    public Discoverer CreateNewDiscoverer(Discoverer newDiscoverer)
    {
        //Ensure the provided Discoverer is not null
        if (newDiscoverer == null || newDiscoverer.ElementDiscovered == null)
        {
            throw new ArgumentException("Invalid Discoverer or ElementDiscovered data");
        }
        else 
        {

            var existingElement = _periodicTableContext.Elements
            .FirstOrDefault(e => e.Enumber == newDiscoverer.ElementDiscovered.Enumber);

            if (existingElement == null)
            {
                throw new InvalidOperationException("The specified Element does not exist in the database");
            }
            else 
            {

                // Link the existing Element to the Discoverer
                newDiscoverer.ElementDiscovered = existingElement;

                // Add and save the Discoverer
                _periodicTableContext.Discoverers.Add(newDiscoverer);
                _periodicTableContext.SaveChanges();

            }


        }


        return newDiscoverer;
    }
}