using PeriodicTable.API.Model;

namespace PeriodicTable.API.Service;

public interface IElementService
{
    Element CreateNewElement(Element newElement);
    IEnumerable<Element> GetAllElements();
    Element? GetElementByEnumber(int Enumber);
    Element? GetElementByName(string name);
    Element? DeleteElementByEnumber(int Enumber);
    
}

public interface IGroupService {

    IEnumerable<Group> GetAllGroups();
    Group? GetGroupByGnumber(int Gnumber);
    Group? GetGroupByName(string name);

}

public interface IDiscovererService {

    Discoverer CreateNewDiscoverer(Discoverer newDiscoverer);
    IEnumerable<Discoverer> GetAllDiscoverers();

    Discoverer? GetDiscovererById(int id);

    Discoverer? GetDiscovererByLastName(string Lname);

    Discoverer? GetDiscovererOfElement(int Enumber);

    Discoverer? DeleteDiscovererById(int id);

}