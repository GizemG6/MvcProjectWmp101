
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcProjectWmp101.Models.Manager
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Addresses> Addresses{ get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Addresses>()
        //        .HasOptional(a => a.Persons)
        //        .WithOptionalDependent()
        //        .WillCascadeOnDelete(true);
        //}
        public DatabaseContext()
        {
            Database.SetInitializer(new DataBaseCreator());
        }

    }
    public class DataBaseCreator : CreateDatabaseIfNotExists<DatabaseContext>
    {
        //initialize database ==> database olusmadan once yapilmasi gereken islemleri eklemek icin kullanilir.
        public override void InitializeDatabase(DatabaseContext context)
        {
            base.InitializeDatabase(context);
        }
        //Seed Database ==> database olustuktan sonra eklenmesi gereken islemler icin kullanilir.
       
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Persons per = new Persons();
                per.Name = FakeData.NameData.GetFirstName();
                per.SurName = FakeData.NameData.GetSurname();
                per.Age = FakeData.NumberData.GetNumber(10,99);

                context.Persons.Add(per);
            }
            context.SaveChanges();

            List<Persons> AllPersons = context.Persons.ToList();

            foreach (Persons person in AllPersons)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                {
                    Addresses adr = new Addresses();
                    adr.Description = FakeData.PlaceData.GetAddress();
                    adr.City = FakeData.PlaceData.GetCity();
                    adr.Persons = person;
                    context.Addresses.Add(adr);
                }
            }
            context.SaveChanges();

        }
    }
}