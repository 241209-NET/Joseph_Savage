using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeriodicTable.API.Model;

public class Discoverer {

    [Key]
    public int Did { get; set; }

    public string? Fname { get; set; } = "";

    //Lname will be used for companies or organizations if not a specific person
    public string Lname { get; set; } = "";
    public DateTime? DoB { get; set; }

    public int Enumber { get; set; }

    [ForeignKey("Enumber")]
    public required Element ElementDiscovered { get; set; }

}