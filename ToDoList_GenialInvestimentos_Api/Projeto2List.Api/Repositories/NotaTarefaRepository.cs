using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Projeto2List.Api.Data;
using Projeto2List.Api.Models;
using Projeto2List.Api.Repositories.Interfaces;
using Projeto2List.Api.ViewModels.ItemViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2List.Api.Repositories
{
    public class NotaTarefaRepository : Notifiable, INotaTarefaRepository
    {
        private readonly StoreDataContext _context;

        public NotaTarefaRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<NotaTarefa> Get()
        {
            var notas = _context.NotasTarefas.AsNoTracking().ToList();
            var itens = _context.Itens.AsNoTracking().ToList();

            foreach (var nota in notas)
                nota.Itens = itens.Where(a => a.IdNotaTarefa == nota.Id).ToList();

            return notas;
        }

        public NotaTarefa Get(int id)
        {
            List<Item> titleItens = new List<Item>();    

            var itens = _context.Itens.Where(a => a.IdNotaTarefa == id).AsNoTracking().ToList();
            var notaTarefa = _context.NotasTarefas.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();

            notaTarefa.Itens = itens;

            return notaTarefa;
        }

        public void Save(NotaTarefa notaTarefa)
        {
            _context.NotasTarefas.Add(notaTarefa);
            _context.SaveChanges();
        }

        public void Update(NotaTarefa notaTarefa)
        {
            _context.Entry<NotaTarefa>(notaTarefa).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(NotaTarefa notaTarefa)
        {
            var itens = _context.Itens.Where(a => a.IdNotaTarefa == notaTarefa.Id).AsNoTracking().ToList();

            _context.Itens.RemoveRange(itens);
            _context.NotasTarefas.Remove(notaTarefa);
            _context.SaveChanges();
        }
    }
}
