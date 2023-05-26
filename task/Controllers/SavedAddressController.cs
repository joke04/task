using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task.Contracts.Basket;
using task.Contracts.SavedAddress;

namespace task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedAddressController : ControllerBase
    {
        private ISavedAddressService _addressService;
        public SavedAddressController(ISavedAddressService addressService)
        {
            _addressService = addressService;
        }
        /// <summary>
        /// Получение списка всех сохраннных адресов БД
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _addressService.GetAll());
        }
        /// <summary>
        /// Возвращение айди всех адресов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _addressService.GetById(id);
            var response = new GetSavedAddressRequest()
            {
                UserIdd = result.UserIdd,
                City = result.City,
                Street = result.Street,
                House = result.House,
                Construction = result.Construction,
                Flat = result.Flat,
                AddressName = result.AddressName
            };
            return Ok(await _addressService.GetById(id));
        }

        /// <summary>
        /// Создание нового адреса
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
        /// <param name="model">Адрес</param>
        /// <returns></returns>
        // POST api/<SavedAddrressController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateSavedAddressRequest request)
        {
            var addressto = request.Adapt<SavedAddress>();
            await _addressService.Create(addressto);
            return Ok();
        }
        /// <summary>
        /// Изменение сущностей записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(SavedAddress savedAddress)
        {
            await _addressService.Update(savedAddress);
            return Ok();
        }

        /// <summary>
        /// Удаление адреса
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _addressService.Delete(id);
            return Ok();
        }
    }
}
