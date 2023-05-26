using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task.Contracts.Basket;
using task.Contracts.Ordering;

namespace task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private IOrderingService _orderingService;
        public OrderingController(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }
        /// <summary>
        /// Получение списка всех заказов БД
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderingService.GetAll());
        }
        /// <summary>
        /// Возвращение айди всех заказов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _orderingService.GetById(id);
            var response = new GetOrderingRequest()
            {
                OrderNumber = result.OrderNumber,
                UserIdd = result.UserIdd,
                NumberProduct = result.NumberProduct,
                DateAndTimeReferences = result.DateAndTimeReferences,
                Statuss = result.Statuss,
                Quantity = result.Quantity
            };
            return Ok(await _orderingService.GetById(id));
        }

        /// <summary>
        /// Создание нового заказа
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
        /// <param name="model">Заказ</param>
        /// <returns></returns>
        // POST api/<OrderingController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderingRequest request)
        {
            var orderingto = request.Adapt<Ordering>();
            await _orderingService.Create(orderingto);
            return Ok();
        }
        /// <summary>
        /// Изменение сущностей записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Ordering ordering)
        {
            await _orderingService.Update(ordering);
            return Ok();
        }

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderingService.Delete(id);
            return Ok();
        }
    }
}
