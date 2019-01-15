using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2List.Api.ViewModels.ItemViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int IdNotaTarefa { get; set; }
    }
}
