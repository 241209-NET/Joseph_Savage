using PeriodicTable.API.Model;

namespace PeriodicTable.API.Repository;

public interface IElementRepository {
    //CRUD
    Element CreateNewElement(Element newElement); 
    IEnumerable<Element> GetAllElements(); 
    Element? GetElementByEnumber(int number); 
    Element? GetElementByName(string name);
    Element? DeleteElementByEnumber(int number);

}

public interface IGroupRepository {

    IEnumerable<Group> GetAllGroups();
    Group? GetGroupByName(string name);
    Group? GetGroupByGnumber(int number);
}

public interface IDiscovererRepository {

    Discoverer CreateNewDiscoverer(Discoverer newDiscoverer);

    IEnumerable<Discoverer> GetAllDiscoverers();

    Discoverer? GetDiscovererById(int id);

    Discoverer? GetDiscovererByLastName(string Lname);

    Discoverer? DeleteDiscovererById(int id);

    Discoverer? GetDiscovererOfElement(int Enumber);
    
}