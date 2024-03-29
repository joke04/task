﻿using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task.Contracts.Basket;

namespace task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        /// <summary>
        /// Получение списка всех корзин БД
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _basketService.GetAll());
        }
        /// <summary>
        /// Возвращение айди всех корзины
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _basketService.GetById(id);
            var response = new GetBasketRequest()
            {
                UserIdd = result.UserIdd,
                ProductId = result.BasketNumber,
                QuantityOfGoods = result.QuantityOfGoods,
            };
            return Ok(await _basketService.GetById(id));
        }

        /// <summary>
        /// Создание новой корзины
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
        /// <param name="model">Корзина</param>
        /// <returns></returns>
        // POST api/<BasketController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateBasketRequest request)
        {
            var basketto = request.Adapt<Basket>();
            await _basketService.Create(basketto);
            return Ok();
        }
        /// <summary>
        /// Изменение сущностей записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Basket basket)
        {
            await _basketService.Update(basket);
            return Ok();
        }

        /// <summary>
        /// Удаление корзины
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _basketService.Delete(id);
            return Ok();
        }
    }
}
