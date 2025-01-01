using PeriodicTable.API.Model;
using PeriodicTable.API.Repository;

namespace PeriodicTable.API.Service
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository) => _groupRepository = groupRepository;

   

        public IEnumerable<Group> GetAllGroups()
        {
            return _groupRepository.GetAllGroups();
        }


        public Group? GetGroupByName(string name)
        {
            var group = _groupRepository.GetGroupByName(name);
            return group;
        }

        public Group? GetGroupByGnumber(int number)
        {
            if(number < 0) return null;
            return _groupRepository.GetGroupByGnumber(number);
        }



    }
}