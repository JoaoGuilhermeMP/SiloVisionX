using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;

namespace SiloVisionX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthApplication _authApplication;

        public AuthController(IAuthApplication auth)
        {
            _authApplication = auth;    
        }


        [HttpGet("CreateToken")]
        public async Task<ActionResult<Response<Token>>> CreateToken(string Email)
        {
            var data =  await _authApplication.CreateToken(Email);

            if (data == null)
            {
                return NotFound(new Response<Token>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Usuário não encontrado ou erro ao gerar token.",
                    Data = new List<Token>(),
                    IsSuccess = false
                });
            }

            return Ok(new Response<Token>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Token criado com sucesso.",
                Data = new List<Token> { data },
                IsSuccess = true
            });
        }

        [HttpGet("GetToken")]
        public async Task<ActionResult<Response<Token>>> GetToken(string Email)
        {

            var data = await _authApplication.GetToken(Email);

            if (data == null)
            {
                return NotFound(new Response<Token>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Usuário não encontrado ou erro ao gerar token.",
                    Data = new List<Token>(),
                    IsSuccess = false
                });
            }

            return Ok(new Response<Token>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Token criado com sucesso.",
                Data = new List<Token> { data },
                IsSuccess = true
            });

        }

    }
}
