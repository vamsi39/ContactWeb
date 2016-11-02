namespace ContactWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactWeb.Models.ContactWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ContactWeb.Models.ContactWebContext";
        }

        protected override void Seed(ContactWeb.Models.ContactWebContext context)
        {
            /*
            UserIDs

            3120a154-6e6f-4f48-8f16-2d28b3d3be43
            5d4caff5-5296-463c-9d9f-fdbb20321658

            */


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Contacts.AddOrUpdate(
                p => p.Id,
                new Models.Contact { Id = 1, Birthday = new DateTime(1920, 01, 20), City = "Macclesfield"
                                    , Email = "doc.mccoy@starfleet.com", FirstName = "DeForest", LastName = "Kelley"
                                    , PhonePrimary = "123-456-7890", PhoneSecondary = "234-567-8901", County = "Cheshire"
                                    , StreetAddress1 = "Sickbay", StreetAddress2 = "Starship Enterprise NCC-1701"
                                    , UserId = new Guid("3120a154-6e6f-4f48-8f16-2d28b3d3be43")
                                    , PostCode = "98765" } 
                , new Models.Contact { Id = 2, Birthday = new DateTime(1920, 03, 03), City = "Durham"
                                    , Email = "i.beam.you.up@starfleet.com", FirstName = "James", LastName = "Doohan"
                                    , PhonePrimary = "345-678-9012", PhoneSecondary = "456-789-0123", County = "Yorkshire"
                                    , StreetAddress1 = "Engineering", StreetAddress2 = "Starship Enterprise NCC-1701"
                                    , UserId = new Guid("3120a154-6e6f-4f48-8f16-2d28b3d3be43")
                                    , PostCode = "87654" }
                , new Models.Contact { Id = 3, Birthday = new DateTime(1931, 03, 26), City = "Woking"
                                    , Email = "its.only.logic@starfleet.com", FirstName = "Leonard", LastName = "Nimoy"
                                    , PhonePrimary = "987-654-3210", PhoneSecondary = "876-543-2109", County = "Surrey"
                                    , StreetAddress1 = "Science Station 1", StreetAddress2 = "Starship Enterprise NCC-1701"
                                    , UserId = new Guid("5d4caff5-5296-463c-9d9f-fdbb20321658")
                                    , PostCode = "76543-2109" }
                , new Models.Contact { Id = 4, Birthday = new DateTime(1931, 03, 22), City = "Reading"
                                    , Email = "the.captain@starfleet.com", FirstName = "William", LastName = "Shatner"
                                    , PhonePrimary = "765-432-1098", PhoneSecondary = "654-321-0987", County = "Berkshire"
                                    , StreetAddress1 = "The Bridge", StreetAddress2 = "Starship Enterprise NCC-1701"
                                    , UserId = new Guid("5d4caff5-5296-463c-9d9f-fdbb20321658")
                                    , PostCode = "65432-0123" }
            );


        }
    }
}
