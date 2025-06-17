using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiloVisionX.Domain.DTO;
using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;

namespace SiloVisionX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserApplication _userApplication;

        public UsersController( IUserApplication user)
        {
            _userApplication = user;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<Response<User>>> GetAllUsers()
        {
            var data = await _userApplication.GetAllUsers();

            if (data == null || !data.Any())
            {
                return NotFound(new Response<User>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Nenhum usuário encontrado.",
                    Data = new List<User>(),
                    IsSuccess = false
                });
            }

            return Ok(new Response<User>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Usuários encontrados com sucesso.",
                Data = data,
                IsSuccess = true
            });
        }

        [HttpGet("GetUserByEmail")]
        public async Task<ActionResult<Response<User>>> GetUserByEmail(string email)
        {
            var data = _userApplication.GetUserByEmail(email);

            if (data == null)
            {
                return NotFound(new Response<User>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Usuário não encontrado.",
                    Data = new List<User>(),
                    IsSuccess = false
                });
            }

            return Ok(new Response<User>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Usuário encontrado com sucesso.",
                Data = new List<User> { data },
                IsSuccess = true
            });

        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<Response<User>>> CreateUser(UserDTO user)
        {
            var data = _userApplication.CreateUser(user);

            if (data == null)
            {
                return NotFound(new Response<User>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "falha ao criar usuário",
                    Data = new List<User>(),
                    IsSuccess = false
                });
            }

            return Ok(new Response<User>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Usuário criado com sucesso.",
                Data = new List<User> { data },
                IsSuccess = true
            });

        }

        [HttpPut("EditUser")]
        public async Task<ActionResult<Response<User>>> EditUser(UserDTO user)
        {
            var data = await _userApplication.EditUser(user);

            if (data == null)
            {
                return NotFound(new Response<User>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "falha ao editar usuário",
                    Data = new List<User>(),
                    IsSuccess = false
                });
            }

            return Ok(new Response<User>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Usuário editado com sucesso.",
                Data = new List<User> { data },
                IsSuccess = true
            });

        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<Response<User>>> DeleteUser(string email)
        {
            var data = _userApplication.DeleteUser(email);

            if (data == false)
            {
                return NotFound(new Response<User>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "falha ao deletar usuário",
                    Data = new List<User>(),
                    IsSuccess = false
                });
            }

            return Ok(new Response<User>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Usuário deletado com sucesso.",
                Data = new List<User>(),
                IsSuccess = true
            });

        }



    }
}
