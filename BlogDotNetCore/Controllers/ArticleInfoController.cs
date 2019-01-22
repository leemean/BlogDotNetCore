using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogDotNetCore.Domain.IService;
using Newtonsoft.Json.Linq;

namespace BlogDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleInfoController : ControllerBase
    {
        private IArticleInfoService _articleInfoService;
        public ArticleInfoController(IArticleInfoService articleInfoService)
        {
            _articleInfoService = articleInfoService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //return new string[] { "value1", "value2" };
            return new JsonResult(_articleInfoService.GetArticleInfoById(Guid.Parse("")));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]JObject value)
        {
            var result = _articleInfoService.CreateArticleInfo();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
