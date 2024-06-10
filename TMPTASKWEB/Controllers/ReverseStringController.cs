using Microsoft.AspNetCore.Mvc;
using TMPTASKWEB.Function;
using TMPTASKWEB.Models;

namespace TMPTASKWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReverseStringController : ControllerBase
    {
        ReverseStringModel forecast;
        [HttpGet]
        public IActionResult Get(string text, int sort)
        {

            if (!StringManager.IsValid(text)) return BadRequest(StringManager.ErrorMessage());
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
                    RemoveStroke = RemoveRandomSymbol.Get()
                };
                return Ok(forecast);
            }

        }

    }
}