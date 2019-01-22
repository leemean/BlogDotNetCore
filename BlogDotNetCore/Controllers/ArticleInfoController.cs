using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogDotNetCore.Domain.IService;
using Newtonsoft.Json.Linq;
using BlogDotNetCore.Domain;
using Newtonsoft.Json;

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

        [HttpGet("Get")]
        public ActionResult<ResponseData<List<articleInfoDto>>> Get([FromQuery]string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new ResponseData<List<articleInfoDto>> { code = "0", message = null, data = _articleInfoService.GetAllArticleInfos() };
            }
            else
            {
                return new ResponseData<List<articleInfoDto>> { code = "0", message = null, data = new List<articleInfoDto> { _articleInfoService.GetArticleInfoById(Guid.Parse(id)) } };
            }
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost("Commit")]
        public void Post([FromBody]RequestData<articleInfoDto> value)
        {
            string type = value.type;
            articleInfoDto data = value.data;
            bool result;
            if(type == "0")
            {
                //var input = JsonConvert.DeserializeObject<articleInfoDto>(data.ToString());
                result = _articleInfoService.CreateArticleInfo(data);
            }
            else if(type == "1")
            {
                //var input = JsonConvert.DeserializeObject<articleInfoDto>(data.ToString());
                result = _articleInfoService.UpdateArticleInfo(data);
            }
            else if(type == "2")
            {
                var delId = data.id;
                result = _articleInfoService.DeleteArticleInfo(delId);
            }
        }
    }
}
