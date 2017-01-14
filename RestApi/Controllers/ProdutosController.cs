using System;
using System.Web.Http;
using RestApi.DataAccess;

namespace RestApi.Controllers
{
    [Authorize]
    public class ProdutosController : ApiController
    {
        private DomainDbContext db = new DomainDbContext();

        // GET: api/Produtos
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(db.Produtos);
        }
    }
}