using System.IO;
using DataLayer.Models.Block;
using DataLayer.Models.Container;
using DataLayer.Models.DutySchedule;
using DataLayer.Models.Person;
using DataLayer.Models.Row;
using DataLayer.Tables;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class MainDbContext: DbContext
    {
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Divisions> Divisions { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<DutySchedule> DutySchedule { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = GetCurrentFolder()+@"\database.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
        
        private static string GetCurrentFolder()
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            return path;
        }
    }
}