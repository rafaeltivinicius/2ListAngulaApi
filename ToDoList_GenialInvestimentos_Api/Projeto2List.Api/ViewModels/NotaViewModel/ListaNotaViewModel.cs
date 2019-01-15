using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2List.Api.ViewModels.NotaViewModel
{
    public class ListaNotaViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> ItensDescription { get; set; }
    }
}
