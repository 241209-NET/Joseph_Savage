using System.ComponentModel.DataAnnotations;

namespace PeriodicTable.API.Model;

public class Group {

    [Key]
    public int Gnumber { get; set; }
    public string Gname { get; set; } = "";

}