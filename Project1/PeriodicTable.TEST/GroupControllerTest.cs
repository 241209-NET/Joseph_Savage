using Moq;
using PeriodicTable.API.Model;
using PeriodicTable.API.Repository;
using PeriodicTable.API.Service;

namespace PeriodicTable.TEST;

public class GroupControllerTest
{

    [Fact]
    public void GetAllGroupsReturnsAllGroups()
    {
        //Arrange
        var groups = new List<Group>
        {
            new Group { Gnumber = 1, Gname = "Alkali Metals" },
            new Group { Gnumber = 2, Gname = "Alkaline Earth Metals" },
            new Group { Gnumber = 17, Gname = "Halogens" },
            new Group { Gnumber = 18, Gname = "Noble Gases" }
        };

        var mockRepo = new Mock<IGroupRepository>();
        mockRepo.Setup(repo => repo.GetAllGroups()).Returns(groups);

        var groupService = new GroupService(mockRepo.Object);

        //Act
        var result = groupService.GetAllGroups();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(groups.Count, result.Count()); 
        Assert.Equal(groups, result); 
        mockRepo.Verify(repo => repo.GetAllGroups(), Times.Once);
        
    }

[Fact]
public void GetGroupsByGroupNumberReturnsCorrectly()
{
    // Arrange
    var group = new Group
    { 
        Gnumber = 1, 
        Gname = "Alkali Metals" 
    };

    var mockRepo = new Mock<IGroupRepository>();
    // Return the group when GetGroupByGnumber(1) is called
    mockRepo.Setup(repo => repo.GetGroupByGnumber(1)).Returns(group);

    var groupService = new GroupService(mockRepo.Object);

    // Act
    var result = groupService.GetGroupByGnumber(1);

    // Assert
    Assert.NotNull(result);  // Ensure that the result is not null
    Assert.Equal(group, result); // Compare the actual group with the returned result
    mockRepo.Verify(repo => repo.GetGroupByGnumber(1), Times.Once); // Verify the method was called once
}

}

