using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Lab10.Models;


namespace EF_Lab10.Data
{
    public class DBInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //context.Database.EnsureCreated();

            //// Look for any students.
            //if (context.EBooks.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //var authors = new Author[]
            //{
            //new Author{ID=1, Name ="Reymond"},
            //new Author{ID=2, Name ="Pia"},

            //};
            //foreach (Author s in authors)
            //{
            //    context.Authors.Add(s);
            //}
            //context.SaveChanges();

            //var ebooks = new EBook[]
            //{
            //new EBook{ID =1, BookName = "Basics of C#", Genre="Technology"},
            //new EBook{ID =2, BookName = "Basics of .Net Core", Genre="Technology"},

            //};
            //foreach (EBook c in ebooks)
            //{
            //    context.EBooks.Add(c);
            //}
            //context.SaveChanges();

       
        }

    }
}
