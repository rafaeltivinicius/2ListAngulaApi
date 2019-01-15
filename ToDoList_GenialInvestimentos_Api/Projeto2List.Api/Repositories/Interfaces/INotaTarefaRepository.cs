using Projeto2List.Api.Models;
using Projeto2List.Api.ViewModels.ItemViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2List.Api.Repositories.Interfaces
{
    public interface INotaTarefaRepository
    {
        IEnumerable<NotaTarefa> Get();
        NotaTarefa Get(int id);
        void Save(NotaTarefa notaTarefa);
        void Update(NotaTarefa notaTarefa);
        void Delete(NotaTarefa notaTarefa);
    }
}
