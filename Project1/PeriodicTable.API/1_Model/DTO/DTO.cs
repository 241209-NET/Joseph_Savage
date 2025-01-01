//Data transfer object
using System.ComponentModel.DataAnnotations;
using PeriodicTable.API.Model;

namespace PeriodicTable.API.DTO;

public class ElementInDTO
{
    public required int Enumber { get; set; }

    public required string Ename { get; set; }

    /*public Element DTOToOwner()
    {
        return new Element { Enumber = this.Enumber, Ename = this.Ename };
    }
    */
}