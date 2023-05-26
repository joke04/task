using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task.Contracts.Basket;
using task.Contracts.Filter;

namespace task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private IFilterService _filterService;
        public FilterController(IFilterService filterService)
        {
            _filterService = filterService;
        }
        /// <summary>
        /// Получение списка всех фильтров БД
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _filterService.GetAll());
        }



        /// <summary>
        /// Возвращение айди всех фильтров
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _filterService.GetById(id);
            var response = new GetFilterRequest()
            {
                IdCategories = result.IdCategories,
                ProductAvailability = result.ProductAvailability,
                ReleaseForm = result.ReleaseForm,
                AvailabilityOfDiscounts = result.AvailabilityOfDiscounts,
                Discounts = result.Discounts,
                VacationFromThePharmacy = result.VacationFromThePharmacy,
                Indications = result.Indications,
                Producer = result.Producer,
                ExpirationDate = result.ExpirationDate,
                BrandName = result.ExpirationDate,
                QuantityInPack = result.QuantityInPack,
                Price = result.Price
            };
            return Ok(await _filterService.GetById(id));
        }

        /// <summary>
        /// Создание нового фильтра
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "login" : "A4Tech Bloody B188",
        ///         "password" : "!Pa$$word123@",
        ///         "firstname" : "Иван",
        ///         "lastname" : "Иванов",
        ///         "middlename" : "Иванович"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Фильтр</param>
        /// <returns></returns>
        // POST api/<FilterController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateFilterRequest request)
        {
            var filterto = request.Adapt<Filter>();
            await _filterService.Create(filterto);
            return Ok();
        }
        /// <summary>
        /// Изменение сущностей записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Filter filter)
        {
            await _filterService.Update(filter);
            return Ok();
        }

        /// <summary>
        /// Удаление фильтра
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _filterService.Delete(id);
            return Ok();
        }
    }
}
