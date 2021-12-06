using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcProjectWmp101.Models.Manager
{
    public class studentDatabaseContext : DbContext
    {
        public DbSet<Students> Students { get; set; }

        public DbSet<Classes> Classes { get; set; }

        public studentDatabaseContext()
        {
            Database.SetInitializer(new studentDataBaseCreator());
        }
    }
    public class studentDataBaseCreator : CreateDatabaseIfNotExists<studentDatabaseContext>
    {
        public override void InitializeDatabase(studentDatabaseContext context)
        {
            base.InitializeDatabase(context);
        }
        protected override void Seed(studentDatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                
                Classes cls = new Classes();
                cls.Name = FakeData.NameData.GetCompanyName();
                
                context.Classes.Add(cls);
            }
            context.SaveChanges();
            List<Classes> AllClasses = context.Classes.ToList();

            foreach (Classes clas in AllClasses)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1, 5); i++)
                {
                    Students std = new Students();
                    std.Name = FakeData.NameData.GetFirstName();
                    std.SurName = FakeData.NameData.GetSurname();
                    std.Number = FakeData.NumberData.GetNumber(1, 250);
                    std.Classes = clas;
                    context.Students.Add(std);
                }
            }
            context.SaveChanges();

        }

    }
}