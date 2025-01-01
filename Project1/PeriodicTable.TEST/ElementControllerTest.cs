using Moq;
using PeriodicTable.API.Model;
using PeriodicTable.API.Repository;
using PeriodicTable.API.Service;

namespace PeriodicTable.TEST;

public class ElementControllerTest
{

    [Fact]
    public void CreateNewElementCreatesCorrectly()
    {
        //Arrange
        var element = new Element
            {
                Enumber = 1,
                Ename = "Hydrogen",
                ESymbol = "H",
                AtomicMass = 1.008,
                Phase = "Gas",
                Appearance = "colorless gas",
                MeltingPoint = 14.175,
                BoilingPoint = 20.28,
                Gnumber = 1,
                Egroup = new Group 
                    {

                        Gnumber = 1,
                        Gname = "Alkali_Metals"

                    }
            };

        var mockRepo = new Mock<IElementRepository>();

        mockRepo.Setup(repo => repo.CreateNewElement(element)).Returns(element);
        mockRepo.Setup(repo => repo.GetElementByEnumber(element.Enumber)).Returns(element);

        var elementService = new ElementService(mockRepo.Object);

        //Act
        var result = elementService.CreateNewElement(element);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(element, result);
    }

    [Fact]
    public void ElementReturnsCorrect()
    {
        //Arrange
        var mockRepo = new Mock<IElementRepository>();
        mockRepo.Setup(repo => repo.GetElementByEnumber(1))
            .Returns(new Element
            {
                Enumber = 1,
                Ename = "Hydrogen",
                ESymbol = "H",
                AtomicMass = 1.008,
                Phase = "Gas",
                Appearance = "colorless gas",
                MeltingPoint = 14.175,
                BoilingPoint = 20.28,
                Gnumber = 1,
                Egroup = new Group 
                    {

                        Gnumber = 1,
                        Gname = "Alkali_Metals"

                    }
            });
        var elementService = new ElementService(mockRepo.Object);

        //Act
        var result = elementService.GetElementByEnumber(1);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Enumber);
        Assert.Equal("Hydrogen", result.Ename);
        Assert.Equal("H", result.ESymbol);
        Assert.Equal(1.008, result.AtomicMass);
        Assert.Equal("Gas", result.Phase);
        Assert.Equal("colorless gas", result.Appearance);
        Assert.Equal(14.175, result.MeltingPoint);
        Assert.Equal(20.28, result.BoilingPoint);
        Assert.Equal(1, result.Gnumber);
        Assert.NotEqual("Oxygen", result.Ename);
    }

    [Fact]
    public void ElementReturnsCorrect2()
    {
        //Arrange
        var mockRepo = new Mock<IElementRepository>();
        mockRepo.Setup(repo => repo.GetElementByName("Hydrogen"))
            .Returns(new Element
            {
                Enumber = 1,
                Ename = "Hydrogen",
                ESymbol = "H",
                AtomicMass = 1.008,
                Phase = "Gas",
                Appearance = "colorless gas",
                MeltingPoint = 14.175,
                BoilingPoint = 20.28,
                Gnumber = 1,
                Egroup = new Group 
                    {

                        Gnumber = 1,
                        Gname = "Alkali_Metals"

                    }
            });
        var elementService = new ElementService(mockRepo.Object);

        //Act
        var result = elementService.GetElementByName("Hydrogen");

        //Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Enumber);
        Assert.Equal("Hydrogen", result.Ename);
        Assert.Equal("H", result.ESymbol);
        Assert.Equal(1.008, result.AtomicMass);
        Assert.Equal("Gas", result.Phase);
        Assert.Equal("colorless gas", result.Appearance);
        Assert.Equal(14.175, result.MeltingPoint);
        Assert.Equal(20.28, result.BoilingPoint);
        Assert.Equal(1, result.Gnumber);
        Assert.NotEqual("Oxygen", result.Ename);
    }


    [Fact]
    public void DeleteElementByEnumberDeletesElement()
    {
        //Arrange
        var mockRepo = new Mock<IElementRepository>();
        mockRepo.Setup(repo => repo.GetElementByEnumber(1))
            .Returns(new Element
            {
                Enumber = 1,
                Ename = "Hydrogen",
                ESymbol = "H",
                AtomicMass = 1.008,
                Phase = "Gas",
                Appearance = "colorless gas",
                MeltingPoint = 14.175,
                BoilingPoint = 20.28,
                Gnumber = 1,
                Egroup = new Group 
                    {

                        Gnumber = 1,
                        Gname = "Alkali_Metals"

                    }
            });
        var elementService = new ElementService(mockRepo.Object);

        //Act
        var result = elementService.DeleteElementByEnumber(1);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Enumber);
        Assert.Equal("Hydrogen", result.Ename);
        Assert.Equal("H", result.ESymbol);
        Assert.Equal(1.008, result.AtomicMass);
        Assert.Equal("Gas", result.Phase);
        Assert.Equal("colorless gas", result.Appearance);
        Assert.Equal(14.175, result.MeltingPoint);
        Assert.Equal(20.28, result.BoilingPoint);
        Assert.Equal(1, result.Gnumber);
        Assert.NotEqual("Oxygen", result.Ename);
    }

}
