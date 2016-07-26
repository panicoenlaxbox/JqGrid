using System.Web.Mvc;
using JqGrid.Infrastructure;
using JqGrid.Models.Services;

namespace JqGrid.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomersService _customersService;

        public HomeController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customers(Infrastructure.JqGrid jqGrid)
        {
            var data = _customersService.GetPaginated(jqGrid.SortExpression(),
                jqGrid.GetPaginatedConfiguration());
            return new JqGridResult(jqGrid.Data(data));
        }
    }
}