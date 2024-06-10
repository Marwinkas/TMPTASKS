using Microsoft.AspNetCore.Mvc;
using TMPTASKWEB.Function;
using TMPTASKWEB.Models;
using Microsoft.Extensions.Configuration;
namespace TMPTASKWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReverseStringController : ControllerBase
    {
        ReverseStringModel forecast;
        private readonly IConfiguration _config;

        public ReverseStringController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]

        public IActionResult Get(string text, int sort)
        {
            string[] blacklist = _config.GetSection("Settings:BlackList").Get<string[]>();
            if (!StringManager.IsValid(text, blacklist)) return BadRequest(StringManager.ErrorMessage());
            else if(StringManager.isblackword) return BadRequest(StringManager.BlackWordMessage()); 
            else
            {
                StringManager._text = text;
                string sorted = "";
                if (sort == 0) sorted = QuickSort.Output();
                else if (sort == 1) sorted = TreeSort.Output();
                forecast = new ReverseStringModel()
                {
                    Text = text,
                    Reverse = ReverseString.Get(text),
                    OutputSymbol = RepetitionString.OutputSymbol(),
                    OutputVowelSubstring = RepetitionString.OutputVowelSubstring(),
                    Sort = sorted,
                    RemoveStroke = RemoveRandomSymbol.Get(_config.GetSection("RandomApi").Get<string>())
                };
                return Ok(forecast);
            }

        }

    }
}