using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2List.Api.ViewModels.ItemViewModel
{
    public class EditorItemViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int IdNotaTarefa { get; set; }
        public void Validate()
        {
            AddNotifications(
            new Contract()
            .HasMaxLen(Description, 120, "Title", "O Titulo deve conter no maximo 120 caracter")
            .HasMinLen(Description, 3, "Title", "O titulo deve conter no minimo 3 caracter")
            .IsGreaterThan(IdNotaTarefa,1,"IdNotaTarefa","O item precisa esta vinculado a uma nota")
            );
        }
    }
}
