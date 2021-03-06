using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _repo.getUsers();
            var userToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(userToReturn);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> GetUser(int id)
        {
            var user = await _repo.getUser(id);
            var userToReturn = _mapper.Map<UserForDetailedDto>(user);
            return Ok(userToReturn);
        }
    }
}