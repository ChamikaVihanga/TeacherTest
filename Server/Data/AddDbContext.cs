using Microsoft.EntityFrameworkCore;
using TeacherTest.Client.Pages;
using TeacherTest.Shared;

namespace TeacherTest.Server.Data
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> opctions) : base(opctions)
        {

        }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }
    }
}
