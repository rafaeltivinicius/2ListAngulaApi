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
    public class ItemController : Controller
    {

        private readonly IItemRepository _repository;

        public ItemController(IItemRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/itens")]
        [HttpGet]
        public  IEnumerable<ItemViewModel> Get()
        {
            return _repository.Get();
        }

        [Route("v1/itens/{id}")]
        [HttpGet]
        public ItemViewModel Get(int id)
        {
            var item = _repository.Get(id);

            return new ItemViewModel()
            {
                Id = item.Id,
                Description = item.Description,
                IdNotaTarefa = item.IdNotaTarefa,
            };
        }

        [Route("v1/itens")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorItemViewModel model)
        {
            model.Validate();

            if (model.Invalid)
                return ReturnViewModel(false, "Não foi Cadastrado o Item", model.Notifications);

            var item = PopularProductInsert(model);

            _repository.Save(item);

            return ReturnViewModel(true, "Item Cadastrado com sucesso", item);
        }

        [Route("v1/itens")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorItemViewModel model)
        {
            model.Validate();

            if (model.Invalid)
                return ReturnViewModel(false, "Erro ao alterar Item", model.Notifications);

            var item = PopularItemUpdate(model);

            _repository.Update(item);

            return ReturnViewModel(true, "Item Alterado com sucesso", item);
        }

        [Route("v1/itens/{id}")]
        [HttpDelete]
        public Item Delete(int id)
        {
            var item = _repository.Get(id);
            _repository.Delete(item);

            return item;
        }

        #region Metodos Comuns

        private Item PopularProductInsert(EditorItemViewModel model)
        {
            return new Item()
            {
                Description = model.Description,
                DataCreate = DateTime.Now,
                IdNotaTarefa = model.IdNotaTarefa,
                Status = true
            };
        }

        private Item PopularItemUpdate(EditorItemViewModel model)
        {
            var item = _repository.Get(model.Id);

            item.Description = model.Description;
            item.Status = true;

            return item;
        }

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
