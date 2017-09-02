namespace AirTicketsService.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AirTicketsService.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AirTicketsService.Models.ApplicationDbContext";
        }

        protected override void Seed(AirTicketsService.Models.ApplicationDbContext context)
        {
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

            context.Roles.AddOrUpdate(new IdentityRole()
            {
                Id = "Admin",
                Name = "Admin"
            });

            context.CityModels.AddOrUpdate(
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "�����-���������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "����" },
                new CityModel() { Name = "���" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "��������" },
                new CityModel() { Name = "����" },
                new CityModel() { Name = "��������" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "���������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "��������" },
                new CityModel() { Name = "���������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "���������" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "��������" },
                new CityModel() { Name = "����" },
                new CityModel() { Name = "���������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "���������" },
                new CityModel() { Name = "��������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "����" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "���������" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "��������" },
                new CityModel() { Name = "����" },
                new CityModel() { Name = "�����������" },
                new CityModel() { Name = "���������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "��������" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "��������" },
                new CityModel() { Name = "ø������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "��������" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "����������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "���������" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "��������" },
                new CityModel() { Name = "����" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "���������" },
                new CityModel() { Name = "���������" },
                new CityModel() { Name = "������" },
                new CityModel() { Name = "����" },
                new CityModel() { Name = "�������" },
                new CityModel() { Name = "�����" },
                new CityModel() { Name = "������-��-����" }
                );
        }
    }
}
