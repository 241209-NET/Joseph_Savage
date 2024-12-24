using Microsoft.EntityFrameworkCore;
using PeriodicTable.API.Model;

namespace PeriodicTable.API.Data;

public partial class PeriodicTableContext : DbContext
{
    public PeriodicTableContext(){}
    public PeriodicTableContext(DbContextOptions<PeriodicTableContext> options) : base(options){}

    public virtual DbSet<Element> Elements { get; set; }
    public virtual DbSet<Group> Groups { get; set; }

}