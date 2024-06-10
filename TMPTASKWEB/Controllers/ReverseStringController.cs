using Microsoft.AspNetCore.Mvc;
using TMPTASKWEB.Function;
using TMPTASKWEB.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
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
        
        private readonly static string REQUEST_COUNTER = "REQUEST_COUNTER";
        private static readonly object _lockObj = new object();
        private static int CountUser = 0;
        private static DateTime[] userTimeRequest = new DateTime[3];
        private static bool[] IsUserStopped = new bool[3];
        
        [HttpGet]
        public IActionResult Get(string text, int sort)
        {
            if(userTimeRequest.Length < 5) userTimeRequest = new DateTime[_config.GetSection("ParallelLimit").Get<int>()];
            if(IsUserStopped.Length < 5) IsUserStopped = new bool[_config.GetSection("ParallelLimit").Get<int>()];
            for (int i = 0; i < userTimeRequest.Length; i++)
            {

                if (DateTime.Now.Subtract(userTimeRequest[i]).Seconds > 5 && IsUserStopped[i])
                {
                    IsUserStopped[i] = false;
                    CountUser--;
                }
            }
            lock (_lockObj )
            {
                if(IsUserStopped.Length - 1 > CountUser)
                {
                    int? count = HttpContext.Session.GetInt32(REQUEST_COUNTER);
                    if (count == null || count == 0)
                    {
                        CountUser++;
                        count = CountUser;
                        IsUserStopped[CountUser] = true;
                        userTimeRequest[CountUser] = DateTime.Now;
                        HttpContext.Session.SetInt32(REQUEST_COUNTER, CountUser);
                        Console.WriteLine(CountUser);
                    }
                    else
                    {
                        Console.WriteLine(DateTime.Now.Subtract(userTimeRequest[count.Value]).Seconds);
                        if (DateTime.Now.Subtract(userTimeRequest[count.Value]).Seconds > 5 && IsUserStopped[count.Value])
                        {
                            IsUserStopped[count.Value] = false;
                            CountUser--;
                            count = null;
                            HttpContext.Session.SetInt32(REQUEST_COUNTER, 0);
                        }
                        if (count != null && IsUserStopped[count.Value])
                        {
                            return StatusCode(StatusCodes.Status429TooManyRequests, "TooManyRequests");
                        }
                        else { count = null; HttpContext.Session.SetInt32(REQUEST_COUNTER, 0); }

                        }
                    
                }
                else return StatusCode(StatusCodes.Status503ServiceUnavailable, "ServiceUnavailable");
            }
            
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