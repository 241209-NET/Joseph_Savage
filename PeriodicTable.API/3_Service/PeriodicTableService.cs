using PeriodicTable.API.Model;
using PeriodicTable.API.Repository;

namespace PeriodicTable.API.Service
{
    public class PeriodicTableService : IPeriodicTableService
    {
        private readonly IPeriodicTableRepository _PeriodicTableRepository;

        public PeriodicTableService(IPeriodicTableRepository PeriodicTableRepository) => _PeriodicTableRepository = PeriodicTableRepository;

        public IEnumerable<Element> GetAllElements()
        {
            return _PeriodicTableRepository.GetAllElements();
        }

        public Element CreateNewElement(Element newElement)
        {
            return _PeriodicTableRepository.CreateNewElement(newElement);
        }

        public Element? GetElementByEnumber(int number)
        {
            if(number < 1) return null;
            return _PeriodicTableRepository.GetElementByEnumber(number);
        }

        public Element? DeleteElementByEnumber(int Enumber)
        {
            var Element = GetElementByEnumber(Enumber);
            if(Element is not null) _PeriodicTableRepository.DeleteElementByEnumber(Enumber);
            return Element;

        }

        public IEnumerable<Element> GetElementByName(string name)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Element> IPeriodicTableService.GetAllElements()
        {
            throw new NotImplementedException();
        }

        Element? IPeriodicTableService.GetElementByEnumber(int Enumber)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Element> IPeriodicTableService.GetElementByName(string name)
        {
            throw new NotImplementedException();
        }

        Element? IPeriodicTableService.DeleteElementByEnumber(int Enumber)
        {
            throw new NotImplementedException();
        }
    }
}