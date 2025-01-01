//using PeriodicTable.API.Data;
using PeriodicTable.API.Model;
using PeriodicTable.API.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace PeriodicTable.API.Repository;

public class GroupRepository : IGroupRepository
{
    // Need the DB Object to work with.
    private readonly PeriodicTableContext _periodicTableContext;

    // Constructor to inject the DbContext
    public GroupRepository(PeriodicTableContext periodicTableContext) => _periodicTableContext = periodicTableContext;

    public IEnumerable<Group> GetAllGroups()
    {
        return _periodicTableContext.Groups.ToList();
    }

    public Group? CreateNewGroup(Group newGroup)
    {
        // Insert new Group

        //_periodicTableContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Groups ON;");

        _periodicTableContext.Groups.Add(newGroup);
        _periodicTableContext.SaveChanges();

        //_periodicTableContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Groups OFF;");

        return newGroup;
    }



    IEnumerable<Group> IGroupRepository.GetAllGroups()
    {
        return _periodicTableContext.Groups.ToList();
    }

    Group? IGroupRepository.GetGroupByGnumber(int number)
    {
        return _periodicTableContext.Groups.Find(number);
    }

    Group? IGroupRepository.GetGroupByName(string name)
    {
        return _periodicTableContext.Groups
            .FirstOrDefault(g => g.Gname.ToLower() == name.ToLower());
    }




}