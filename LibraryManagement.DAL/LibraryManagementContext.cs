using LibraryManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DAL {
    public class LibraryManagementContext : IdentityDbContext<IdentityUser> {
        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options) : base(options) { }

        public DbSet<Book> Books { set; get; }
        public DbSet<BookReview> BookReviews { set; get; }
        public DbSet<Event> Events { set; get; }
        public DbSet<EventReview> EventReviews { set; get; }
        public DbSet<CheckOut> CheckOuts { set; get; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

        }

    }
}
