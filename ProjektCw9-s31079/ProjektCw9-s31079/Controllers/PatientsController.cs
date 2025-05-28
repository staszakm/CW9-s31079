using Microsoft.AspNetCore.Mvc;
using ProjektCw9_s31079.DTOs;
using ProjektCw9_s31079.Exceptions;
using ProjektCw9_s31079.Models;
using ProjektCw9_s31079.Services;

namespace ProjektCw9_s31079.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientsController(IDbService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPatients()
    {
        return Ok(await service.GetPatientsAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionCreateDTO prescription)
    {
        try
        {
            var prescriptionId = await service.AddPrescriptionAsync(prescription);
            
            return Created("", new { IdPrescription = prescriptionId, Message = "Recepta została utworzona pomyślnie." });
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
}