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
    public class ItemRepository : Notifiable, IItemRepository
    {
        private readonly StoreDataContext _context;

        public ItemRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<ItemViewModel> Get()
        {
            return  _context.Itens
                                .Select(x => new ItemViewModel
                                {
                                    Id = x.Id,
                                    Description = x.Description,
                                    IdNotaTarefa = x.IdNotaTarefa,
                                }).AsNoTracking().ToList();
        }

        public Item Get(int id)
        {
            var item = _context.Itens.Find(id);
            var nota = _context.NotasTarefas.Find(item.IdNotaTarefa);

            item.NotaTarefa = nota;

            return _context.Itens.Find(id);

        }

        public void Save(Item item)
        {
            _context.Itens.Add(item);
            _context.SaveChanges();
        }

        public void Update(Item product)
        {
            _context.Entry<Item>(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Item item)
        {
            _context.Itens.Remove(item);
            _context.SaveChanges();
        }
    }
}
