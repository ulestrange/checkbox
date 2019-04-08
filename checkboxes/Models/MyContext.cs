using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkboxes.Models
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        { }

        public DbSet<Decor> Decors { get; set; }

    {
    }
}
