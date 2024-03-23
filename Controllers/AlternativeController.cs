using Microsoft.AspNetCore.Mvc;

namespace WebApiAtvd.Controllers;

[ApiController]
[Route("[controller]")]
public class AlternativeController : ControllerBase
{
    private readonly ILogger<AlternativeController> _logger;

    public AlternativeController(ILogger<AlternativeController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Alternativo")]
    public IEnumerable<object> CEP([FromHeader] string cidade) 
    {
        List<Cidade> cidades = DataLoad.Cidades();
        var objCidade = cidades.Where(c => c.name == cidade);
        var CEP = objCidade.Select(c => new {
            Cidade = c.name,
            Estado = c.state_name,
            País = c.country_name
            });
        return CEP; 
    }
}