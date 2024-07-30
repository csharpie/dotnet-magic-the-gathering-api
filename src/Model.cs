using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class MagicTheGatheringContext : DbContext
{
    public DbSet<Card> Cards { get; set; }

    public string DbPath;

    public MagicTheGatheringContext()
    {
        DbPath = Environment.GetEnvironmentVariable("MAGIC_THE_GATHERING_DB_PATH");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

[Table("cards")]
public class Card
{
    [Key]
    public required string Number { get; set; }
    public required string Name { get; set; }
    public string? Subtypes { get; set; }
    public string? Text { get; set; }
}