using PeriodicTable.API.Model;
using PeriodicTable.API.Repository;

namespace PeriodicTable.API.Service
{
    public class ElementService : IElementService
    {
        private readonly IElementRepository _elementRepository;

        public ElementService(IElementRepository elementRepository) => _elementRepository = elementRepository;

        public IEnumerable<Element> GetAllElements()
        {
            return _elementRepository.GetAllElements();
        }

        

        public Element CreateNewElement(Element newElement)
        {
            return _elementRepository.CreateNewElement(newElement);
        }

        public Element? GetElementByEnumber(int number)
        {
            if(number < 1) return null;
            return _elementRepository.GetElementByEnumber(number);
        }

        public Element? DeleteElementByEnumber(int Enumber)
        {
            var Element = GetElementByEnumber(Enumber);
            if (Element is not null) _elementRepository.DeleteElementByEnumber(Enumber);
            return Element;

        }

        public Element? GetElementByName(string name)
        {
            var element = _elementRepository.GetElementByName(name);
            return element;
        }
        
    }
}