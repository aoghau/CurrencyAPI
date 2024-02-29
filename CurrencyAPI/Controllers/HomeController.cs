using CurrencyAPI.Data;
using CurrencyAPI.Data.Interfaces;
using CurrencyAPI.Interfaces;
using CurrencyAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CurrencyAPI.Controllers
{
    public class HomeController : Controller
    {
        private ICurrencyDataContext _context;
        private IAuthService _authService;
        public int currentPage = 1;
        public const int MAX_PER_PAGE = 10;

        public HomeController(ICurrencyDataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<IActionResult> LoadItems()
        {
            var client = new HttpClient();
            var request = await client.GetStringAsync("http://api.coincap.io/v2/assets");
            Wrapper<Currency> currencies = JsonConvert.DeserializeObject<Wrapper<Currency>>(request);
            foreach(var currency in currencies.data) 
            {
                _context.Currencies.Add(currency);
            }
            _context.SaveChanges();
            return new OkObjectResult(request);
        }

        public IActionResult DisplayItems()
        {
            int startIndex = (currentPage - 1) * MAX_PER_PAGE;            
            var items = _context.Currencies.ToList().Slice(startIndex, MAX_PER_PAGE);
            var wrapper = new Wrapper<Currency>() { data = items };
            return new JsonResult(wrapper);
        }

        public void PageUp()
        {
            currentPage++;
            DisplayItems();
        }

        public void PageDown() 
        {
            if(currentPage > 1){
                currentPage--;
                DisplayItems();
            }
        }

        public IActionResult OrderByName()
        {            
            _context.Currencies.OrderBy(x => x.name);
            _context.SaveChanges();
            var wrapper = new Wrapper<Currency>() { data = _context.Currencies.ToList()};
            return new JsonResult(wrapper);
        }

        public IActionResult OrderByPrice()
        {
            _context.Currencies.OrderBy(x => x.priceUsd);
            _context.SaveChanges();
            var wrapper = new Wrapper<Currency>() { data = _context.Currencies.ToList() };
            return new JsonResult(wrapper);
        }

        public IActionResult OrderBySupply()
        {
            _context.Currencies.OrderBy(x => x.supply);
            _context.SaveChanges();
            var wrapper = new Wrapper<Currency>() { data = _context.Currencies.ToList() };
            return new JsonResult(wrapper);
        }


    }
}
