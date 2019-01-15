using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto2List.Api.Models;
using Projeto2List.Api.Repositories.Interfaces;
using Projeto2List.Api.ViewModels;
using Projeto2List.Api.ViewModels.ItemViewModel;

namespace Projeto2List.Api.Controllers
{
    public class NotaTarefaController : Controller
    {

        private readonly INotaTarefaRepository _repository;

        public NotaTarefaController(INotaTarefaRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/notasTarefa")]
        [HttpGet]
        public IEnumerable<NotaTarefa> Get()
        {
            return _repository.Get();
        }

        [Route("v1/notasTarefa/{id}")]
        [HttpGet]
        public NotaTarefa Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/notasTarefa")]
        [HttpPost]
        public ResultViewModel Post([FromBody]NotaTarefa notaTarefa)
        {
            if (notaTarefa == null)
                return ReturnViewModel(false, "Não foi Cadastrado a Nota de Tarefara", notaTarefa);

            _repository.Save(notaTarefa);
            return ReturnViewModel(true, "Nota de Tarefara Cadastrada com sucesso", notaTarefa);
        }

        [Route("v1/notasTarefa")]
        [HttpPut]
        public ResultViewModel Put([FromBody]NotaTarefa notaTarefa)
        {
            if (string.IsNullOrEmpty(notaTarefa.Title))
                return ReturnViewModel(false, "Erro ao alterar Nota de Tarefara", notaTarefa);

            _repository.Update(notaTarefa);

            return ReturnViewModel(true, "Nota de Tarefara Alterada com sucesso", notaTarefa);
        }

        [Route("v1/notasTarefa/{id}")]
        [HttpDelete]
        public NotaTarefa Delete(int id)
        {
            var notaTarefa = _repository.Get(id);
            _repository.Delete(notaTarefa);

            return notaTarefa;
        }

        #region Metodos Comuns

        private ResultViewModel ReturnViewModel(bool sucesso, string mensagem, object product)
        {
            return new ResultViewModel
            {
                Success = sucesso,
                Message = mensagem,
                Data = product
            };
        }

        #endregion

    }
}
