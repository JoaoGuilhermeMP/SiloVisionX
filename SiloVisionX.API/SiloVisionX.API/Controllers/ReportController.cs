using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;

namespace SiloVisionX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly IReportApplication report;

        public ReportController(IReportApplication reportApplication)
        {
            report = reportApplication;
        }

        [HttpGet("GetReportData")]
        public async Task<ActionResult<Response<List<Geral>>>> GetReportData()
        {
            var data = report.ReportData();

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

    }
}
