using Microsoft.EntityFrameworkCore;
using Projeto2List.Api.Data.Maps;
using Projeto2List.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2List.Api.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Item> Itens { get; set; }
        public DbSet<NotaTarefa> NotasTarefas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projetos\ToDoList_GenialInvestimentos\ToDoList_GenialInvestimentos_Api\BancoLocal\bd2List.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ItemMap());
            builder.ApplyConfiguration(new NotaTarefaMap());
        }
    }
}
