using Projeto2List.Api.Models;
using Projeto2List.Api.ViewModels.ItemViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2List.Api.Repositories.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<ItemViewModel> Get();
        Item Get(int id);
        void Save(Item item);
        void Update(Item item);
        void Delete(Item item);
    }
}
