using Microsoft.AspNetCore.Mvc;

namespace WebApiAtvd.Controllers;

[ApiController]
[Route("[controller]")]
public class CitiesController : ControllerBase
{
    private readonly ILogger<CitiesController> _logger;

    public CitiesController(ILogger<CitiesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Cidade")]
    public IEnumerable<string> Cidades([FromHeader] string UF, [FromHeader] string sigla)    
    {
        List<Cidade> cidades = DataLoad.Cidades();
        var objCidade = cidades.Where(c => c.state_code == UF && c.country_code == sigla);
        var nome = objCidade.Select(c => c.name);
        return nome; 
    }
}