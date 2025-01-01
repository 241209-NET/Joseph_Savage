using Moq;
using PeriodicTable.API.Model;
using PeriodicTable.API.Repository;
using PeriodicTable.API.Service;

namespace PeriodicTable.TEST;

public class DiscovererControllerTest
{

        [Fact]
    public void CreateNewDiscovererCreatesCorrect()
    {
        //Arrange
        var discoverer = new Discoverer
        {
            Did = 1,
            Fname = "Henry",
            DoB = DateTime.Parse("1731-10-10"),
            Lname = "Cavendish",
            ElementDiscovered = new Element
            {
                Enumber = 1,
                Ename = "Hydrogen",
                ESymbol = "H",
                AtomicMass = 1.008,
                Phase = "Gas",
                Appearance = "colorless gas",
                MeltingPoint = 14.175,
                BoilingPoint = 20.28,
                Egroup = new Group
                {
                    Gnumber = 1,
                    Gname = "Alkali_Metals"
                }
            }
        };

        var mockRepo = new Mock<IDiscovererRepository>();
        mockRepo.Setup(repo => repo.CreateNewDiscoverer(discoverer)).Returns(discoverer);
        mockRepo.Setup(repo => repo.GetDiscovererById(discoverer.Did)).Returns(discoverer);

        var discovererService = new DiscovererService(mockRepo.Object);

        //Act
        var result = discovererService.CreateNewDiscoverer(discoverer);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(discoverer, result);
        mockRepo.Verify(repo => repo.CreateNewDiscoverer(discoverer), Times.Once);
    }
    
    [Fact]
    public void DiscovererReturnsCorrect()
    {
        //Arrange
        var discoverer = new Discoverer
        {
            Did = 1,
            Fname = "Henry",
            DoB = DateTime.Parse("1731-10-10"),
            Lname = "Cavendish",
            ElementDiscovered = new Element
            {
                Enumber = 1,
                Ename = "Hydrogen",
                ESymbol = "H",
                AtomicMass = 1.008,
                Phase = "Gas",
                Appearance = "colorless gas",
                MeltingPoint = 14.175,
                BoilingPoint = 20.28,
                Egroup = new Group
                {
                    Gnumber = 1,
                    Gname = "Alkali_Metals"
                }
            }
        };

        var mockRepo = new Mock<IDiscovererRepository>();
        mockRepo.Setup(repo => repo.GetDiscovererByLastName("Cavendish")).Returns(discoverer);

        var discovererService = new DiscovererService(mockRepo.Object);

        //Act
        var result = discovererService.GetDiscovererByLastName("Cavendish");

        //Assert
        Assert.NotNull(result);
        Assert.Equal(discoverer, result);
        mockRepo.Verify(repo => repo.GetDiscovererByLastName("Cavendish"), Times.Once);
    }

    [Fact]
    public void DiscovererReturnsCorrect2()
    {
        //Arrange
        var discoverer = new Discoverer
        {
            Did = 1,
            Fname = "Henry",
            DoB = DateTime.Parse("1731-10-10"),
            Lname = "Cavendish",
            ElementDiscovered = new Element
            {
                Enumber = 1,
                Ename = "Hydrogen",
                ESymbol = "H",
                AtomicMass = 1.008,
                Phase = "Gas",
                Appearance = "colorless gas",
                MeltingPoint = 14.175,
                BoilingPoint = 20.28,
                Egroup = new Group
                {
                    Gnumber = 1,
                    Gname = "Alkali_Metals"
                }
            }
        };

        var mockRepo = new Mock<IDiscovererRepository>();
        mockRepo.Setup(repo => repo.GetDiscovererById(1)).Returns(discoverer);

        var discovererService = new DiscovererService(mockRepo.Object);

        //Act
        var result = discovererService.GetDiscovererById(1);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(discoverer, result);
        mockRepo.Verify(repo => repo.GetDiscovererById(1), Times.Once);
    }

    [Fact]
    public void DiscovererReturnsCorrect3()
    {
        //Arrange
        var discoverer = new Discoverer
        {
            Did = 1,
            Fname = "Henry",
            DoB = DateTime.Parse("1731-10-10"),
            Lname = "Cavendish",
            ElementDiscovered = new Element
            {
                Enumber = 1,
                Ename = "Hydrogen",
                ESymbol = "H",
                AtomicMass = 1.008,
                Phase = "Gas",
                Appearance = "colorless gas",
                MeltingPoint = 14.175,
                BoilingPoint = 20.28,
                Egroup = new Group
                {
                    Gnumber = 1,
                    Gname = "Alkali_Metals"
                }
            }
        };

        var mockRepo = new Mock<IDiscovererRepository>();
        mockRepo.Setup(repo => repo.GetDiscovererOfElement(1)).Returns(discoverer);

        var discovererService = new DiscovererService(mockRepo.Object);

        //Act
        var result = discovererService.GetDiscovererOfElement(1);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(discoverer, result);
        mockRepo.Verify(repo => repo.GetDiscovererOfElement(1), Times.Once);
    }

    [Fact]
    public void DeleteDiscovererByIdDeletesDiscoverer()
    {
        //Arrange
        var discoverer = new Discoverer
        {
            Did = 1,
            Fname = null,
            DoB = null,
            Lname = "Test Discoverer",
            ElementDiscovered = new Element
            {
                Enumber = 1,
                Ename = "Hydrogen",
                ESymbol = "H",
                AtomicMass = 1.008,
                Phase = "Gas",
                Appearance = "colorless gas",
                MeltingPoint = 14.175,
                BoilingPoint = 20.28,
                Egroup = new Group
                {
                    Gnumber = 1,
                    Gname = "Alkali_Metals"
                }
            }
        };

        var mockRepo = new Mock<IDiscovererRepository>();
        mockRepo.Setup(repo => repo.GetDiscovererById(1)).Returns(discoverer);
        mockRepo.Setup(repo => repo.DeleteDiscovererById(1)).Returns(discoverer);

        var discovererService = new DiscovererService(mockRepo.Object);

        //Act
        var result = discovererService.DeleteDiscovererById(1);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(discoverer.Lname, result.Lname);
        mockRepo.Verify(repo => repo.DeleteDiscovererById(1), Times.Once);
    }

}
