using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeriodicTable.API.Model;

public class Element {

    //number of element on periodic table
    [Key]
    public int Enumber { get; set; }

    //name of element
    public string Ename { get; set; } = "";

    //abbreviation for name
    public string ESymbol { get; set; } = "";

    public double AtomicMass { get; set; }

    public double MeltingPoint { get; set; }

    public double BoilingPoint { get; set; }
    
    [ForeignKey("Gnumber")]
    public required Group Egroup { get; set; }

}