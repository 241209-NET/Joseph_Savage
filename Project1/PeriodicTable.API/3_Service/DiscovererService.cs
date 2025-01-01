using PeriodicTable.API.Model;
using PeriodicTable.API.Repository;

namespace PeriodicTable.API.Service
{
    public class DiscovererService : IDiscovererService
    {
        private readonly IDiscovererRepository _discovererRepository;

        public DiscovererService(IDiscovererRepository discovererRepository) => _discovererRepository = discovererRepository;

        public Discoverer CreateNewDiscoverer(Discoverer newDiscoverer)
        {
            return _discovererRepository.CreateNewDiscoverer(newDiscoverer);
        }

        public IEnumerable<Discoverer> GetAllDiscoverers()
        {
            return _discovererRepository.GetAllDiscoverers();
        }

        public Discoverer? DeleteDiscovererById(int Did)
        {
            var discoverer = GetDiscovererById(Did);
            
            if (discoverer is not null) {

                return _discovererRepository.DeleteDiscovererById(Did);

            };
            return discoverer;

        }

        public Discoverer? GetDiscovererByLastName(string name)
        {
            var Discoverer = _discovererRepository.GetDiscovererByLastName(name);
            return Discoverer;
        }

        public Discoverer? GetDiscovererById(int number)
        {
            if(number < 0) return null;
            return _discovererRepository.GetDiscovererById(number);
        }

        public Discoverer? GetDiscovererOfElement(int number)
        {
            if(number < 1) return null;
            return  _discovererRepository.GetDiscovererOfElement(number);
        }

    }
}