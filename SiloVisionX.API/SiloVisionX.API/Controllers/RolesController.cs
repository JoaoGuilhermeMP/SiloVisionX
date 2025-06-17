using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;

namespace SiloVisionX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IRolesApplication _rolesApplication;

        public RolesController(IRolesApplication roles)
        {
            _rolesApplication = roles;
        }

        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<Response<Roles>>> GetAllRoles()
        {
            var data = _rolesApplication.GetAllRoles();

            if (data == null || !data.Any())
            {
                return NotFound(new Response<Roles>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Falha ao capturar as roles",
                    Data = new List<Roles>(),
                    IsSuccess = false
                });
            }

            return Ok(new Response<Roles>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Roles encontradas com sucesso.",
                Data = data,
                IsSuccess = true
            });

        }

        [HttpPost("CreateRole")]
        public async Task<ActionResult<Response<Roles>>> CreateRole(Roles role)
        {
            if (role == null)
            {
                return BadRequest(new Response<Roles>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Dados inválidos.",
                    Data = new List<Roles>(),
                    IsSuccess = false
                });
            }
            var data = _rolesApplication.CreateRoles(role);
            if (data == null)
            {
                return NotFound(new Response<Roles>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Erro ao criar função.",
                    Data = new List<Roles>(),
                    IsSuccess = false
                });
            }
            return Ok(new Response<Roles>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Função criada com sucesso.",
                Data = new List<Roles> { data },
                IsSuccess = true
            });
        }

        [HttpPut("UpdateRole")]
        public async Task<ActionResult<Response<Roles>>> UpdateRole(Roles role)
        {
            if (role == null)
            {
                return BadRequest(new Response<Roles>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Dados inválidos.",
                    Data = new List<Roles>(),
                    IsSuccess = false
                });
            }
            var data = await _rolesApplication.UpdateRoles(role);
            if (data == null)
            {
                return NotFound(new Response<Roles>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Erro ao atualizar função.",
                    Data = new List<Roles>(),
                    IsSuccess = false
                });
            }
            return Ok(new Response<Roles>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Função atualizada com sucesso.",
                Data = new List<Roles> { data },
                IsSuccess = true
            });
        }

        [HttpDelete("DeleteRole")]
        public async Task<ActionResult<Response<Roles>>> DeleteRole(Roles role)
        {
            var data = _rolesApplication.DeleteRoles(role);

            if (!data)
            {
                return NotFound(new Response<Roles>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Erro ao deletar função.",
                    Data = new List<Roles>(),
                    IsSuccess = false
                });
            }

            return Ok(new Response<Roles>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Função deletada com sucesso.",
                Data = new List<Roles>(),
                IsSuccess = true
            });


        }
    }
}

