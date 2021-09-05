using DatabaseGateway.RestApi.Model;
using DatabaseGateway.RestApi.QueryRunner;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseGateway.RestApi.Controllers
{
    [Route("api/public-query")]
    [ApiController]
    public class PublicQueryController : ControllerBase
    {
        private readonly IQueryRunner _queryRunner;

        public PublicQueryController(IQueryRunner queryRunner)
        {
            _queryRunner = queryRunner;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(RequestData requestData)
        {
            return Created(Url.Action(nameof(Read)), _queryRunner.RunQuery(requestData.QueryText));
        }

        [HttpPost]
        [Route("read")]
        public IActionResult Read(RequestData requestData)
        {
            return Ok(_queryRunner.RunQuery(requestData.QueryText));
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(RequestData requestData)
        {
            return Ok(_queryRunner.RunQuery(requestData.QueryText));
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(RequestData requestData)
        {
            _queryRunner.RunQuery(requestData.QueryText).GetEnumerator().MoveNext();
            return NoContent();
        }
    }
}
