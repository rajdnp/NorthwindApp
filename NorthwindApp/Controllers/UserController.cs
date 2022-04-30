using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindApp.DTOs;
using NorthwindApp.Entities;
using NorthwindApp.Events;
using NorthwindApp.Interfaces;

namespace NorthwindApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IGenericEventHandler<UserEvent> eventHandler;
        private readonly IEventService service;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper, IGenericEventHandler<UserEvent> eventHandler, IEventService service)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.eventHandler = eventHandler;
            this.service = service;

            // subscriber listens to events
            this.eventHandler.Event += service.OnEvent;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int userId)
        {
            var user = await unitOfWork.UserRepository.Get(userId);
            return Ok(user);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var users = await unitOfWork.UserRepository.GetAllUsers(true);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserDto user)
        {
            var result = mapper.Map<User>(user);
            await unitOfWork.UserRepository.Add(result);
            await unitOfWork.SaveChanges();
            eventHandler.TriggerEvent(new UserEvent { UserId = result.Id, EventSource = string.Empty, EventType = Helpers.EventTypeEnum.ADD });
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {
            var user = await unitOfWork.UserRepository.Get(userId);
            unitOfWork.UserRepository.Delete(user);
            await unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int userId, [FromBody] UserDto user)
        {
            var res = await unitOfWork.UserRepository.Get(userId);
            res.Name = user.Name;
            unitOfWork.UserRepository.Update(res);
            await unitOfWork.SaveChanges();
            return Ok();
        }
    }
}
