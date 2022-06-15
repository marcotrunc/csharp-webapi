using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace csharp_webapi.Models
{
    public class SingleActivityContext : DbContext
    {
        public SingleActivityContext(DbContextOptions<SingleActivityContext> options) : base(options) { }
        public DbSet<SingleActivity> ListActivities {get; set;} = null!;
    }
}
