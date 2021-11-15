using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookCatalogMvc.Models;

namespace BookCatalog.Data
{
    public class BookCatalogContext : DbContext
    {
        public BookCatalogContext (DbContextOptions<BookCatalogContext> options)
            : base(options)
        {
        }

        public DbSet<BookCatalogMvc.Models.Book> Books { get; set; }
        public DbSet<BookCatalogMvc.Models.Author> Authors { get; set; }
        public DbSet<BookCatalogMvc.Models.LibraryUser> LibraryUsers { get; set; }        
        public DbSet<RecordOfLoan> LoanRecords { get; set;  }
    }
}
