using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MagicTheGatheringApi.Model;

public class MagicTheGatheringContext : DbContext
{
    private readonly string _dbPath;

    public DbSet<Card> Cards { get; set; }

    public MagicTheGatheringContext()
    {
        _dbPath = Environment.GetEnvironmentVariable("MAGIC_THE_GATHERING_DB_PATH") ?? string.Empty;
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={_dbPath}");
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