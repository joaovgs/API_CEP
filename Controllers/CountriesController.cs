using Microsoft.AspNetCore.Mvc;

namespace WebApiAtvd.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ILogger<CountriesController> _logger;

    public CountriesController(ILogger<CountriesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Países")]
    public IEnumerable<string> Paises()    
    {
        List<Pais> paises = DataLoad.Paises();
        var nome = paises.Select(p => p.name);
        return nome; 
    }
}
