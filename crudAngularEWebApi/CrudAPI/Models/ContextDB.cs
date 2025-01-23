using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Models
{
    public class ContextDB : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }   

        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
            
        }     
    }
}