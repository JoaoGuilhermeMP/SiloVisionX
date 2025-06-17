using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;

namespace SiloVisionX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {

        private readonly IDashboardApplication _dashboardApplication;

        public DashboardController(IDashboardApplication dashboard)
        {
            _dashboardApplication = dashboard;
        }

        [HttpGet("GetDashboardData")]
        public async Task<ActionResult<Response<List<Geral>>>> GetDashboardData()
        {
            var data = _dashboardApplication.GetDashboardData();

            if (data == null) 
            {
                return NotFound(new Response<Geral>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Falha ao capturar as roles",
                    Data = new List<Geral>(),
                    IsSuccess = false
                });
            }

            return Ok(new Response<Geral>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Dados do dashboard encontrados com sucesso.",
                Data = data,
                IsSuccess = true
            });

        }

        [HttpPost("CreateData")]
        public async Task<ActionResult<Response<Geral>>> CreateData([FromBody] Geral data)
        {
            if (data == null)
            {
                return BadRequest(new Response<Geral>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Dados inválidos",
                    Data = null,
                    IsSuccess = false
                });
            }

            try
            {
                await _dashboardApplication.CreateDataAsync(data); 
                return Ok(new Response<Geral>
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Dados criados com sucesso.",
                    Data = new List<Geral> { data },
                    IsSuccess = true
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response<Geral>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Erro ao criar dados: {ex.Message}",
                    Data = null,
                    IsSuccess = false
                });
            }
        }

    }
}
