using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using task.Contracts.Users;

namespace task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получение данных о пользователях
        /// </summary>
        [HttpGet] /* для получения данных */
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        /// <summary>
        /// Получение данных о пользователях
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetBasketRequest()
            {
                UserNumber = result.UserNumber,
                Namee = result.Namee,
                Patronymic = result.Patronymic,
                LastName = result.LastName,
                Birthdate = result.Birthdate,
                Nickname = result.Nickname,
                Mail = result.Mail,
                PhoneNumber = result.PhoneNumber,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///      POST /Todo
        ///         {
        ///              "login" : "A4Tech Bloody B188",
        ///              "password" : "!Pa$$word123@",
        ///              "firstname" : "Иван",
        ///              "lastname" : "Иванов",
        ///              "middlename" : "Иванович"
        ///         }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersControllers>
        [HttpPost] /* для отправки сущностей к определенному ресурсу */
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<User>();
            await _userService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменение данных о пользователях
        /// </summary>
        [HttpPut] /* для изменения существующей записи */
        public async Task<IActionResult> Update(User user)
        {
            await _userService.Update(user);
            return Ok();
        }

        /// <summary>
        /// Удаление данных о пользователях
        /// </summary>
        [HttpDelete] /* для удаления данных */
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
