
using Microsoft.EntityFrameworkCore;
using CRUD_Mini_Project.Models;


namespace CRUD_Mini_Project.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Method> MethodsRepository { get; set; }
        public DbSet<Parameter> ParametersRepository { get; set; }
        public DbSet<SampleType> SampleTypesRepository { get; set; }
        public DbSet<Analyse> AnalysesRepository { get; set; }

    }
}
