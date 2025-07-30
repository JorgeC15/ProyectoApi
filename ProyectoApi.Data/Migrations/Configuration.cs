namespace ProyectoApi.Data.Migrations
{
    using ProyectoApi.Data.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProyectoApi.Data.ApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProyectoApi.Data.ApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            Book book = new Book();
            book.Title = "Midnight Rain";
            book.Price = 14.95;
            book.Genre = "Fantasy";
            book.PublishDate = new DateTime(2000, 12, 16);
            book.Description = "A former architect battles an evil sorceress.";
            // insert into Book(dat1, dat,2dat3) Values("","","")
            context.Books.AddOrUpdate(book);
            // agregra
            //context.Books.Add(book);
            // consultar
            //context.Books.Find(book);
            //eliminar
            //context.Books.Remove(book);

            Author author = new Author();
            author.FirstName = "Jose";
            author.LastName = "Hernandez";
            context.Authors.AddOrUpdate(author);

            Author author1 = new Author();
            author1.FirstName = "Erick";
            author1.LastName = "Alonso";
            context.Authors.AddOrUpdate(author1);
        }
    }
}
