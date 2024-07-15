using AutoMapper;
using Datn.Application.DataTransferObj;
using Datn.Application.Interface;
using Datn.Domain.Database.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Datn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var userData = await userRepository.GetAll();
            if (userData == null)
            {
                return NotFound();
            }
            else
            {
                var userMap = mapper.Map<IEnumerable<UserDto>>(userData);
                return Ok(userMap);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var user = await userRepository.GetById(id);
            if (user == null)
            {
                return BadRequest("Không tìm thấy");
            }
            else
            {
                return Ok(user);
            }
        }

        // POST api/<UserController>
        [HttpPost("create")]
        public async Task<ActionResult> Post([FromBody] UserCreateRequest user)
        {
            await userRepository.Create(mapper.Map<User>(user));
            return Ok(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("update")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UserUpdateRequest userUpdate)
        {
            var userItem = await userRepository.GetById(id);
            if (userItem == null)
            {
                return BadRequest("Không tìm thấy");
            }
            else
            {
                userItem.UserName = userUpdate.UserName;
                userItem.PassWord = userUpdate.PassWord;
                await userRepository.Update(userItem);
                return Ok(userItem);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await userRepository.Delete(id);
            return Ok();
        }
    }
}
