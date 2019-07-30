using BackEnd.BLL;
using BackEnd.DAL;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class UserInfoController : ApiController
    {
        UserInfoBll business = new UserInfoBll();

        // GET(查询): api/UserInfo/getUserInfoes/
        [HttpGet]
        public async Task<IHttpActionResult> getUserInfoes()
        {
            return Ok(await business.getUserInfoes());
        }

        // GET(查询): api/UserInfo/getUserInfoByID/1
        [HttpGet]
        public async Task<IHttpActionResult> getUserInfoByID(int id)
        {
            return Ok(await business.getUserInfoByID(id));
        }

        // POST(增加): api/UserInfo/addUserInfo/
        [HttpPost]
        public async Task<IHttpActionResult> addUserInfo(UserInfo obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await business.addUserInfo(obj);

            if (result)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        // DELETE(删除): api/UserInfo/destroyUserInfo/1
        [HttpDelete]
        public async Task<IHttpActionResult> destroyUserInfo(int id)
        {
            bool result = await business.destroyUserInfo(id);

            if (result)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        // PUT(修改): api/UserInfo/modifyUserInfo
        [HttpPut]
        public async Task<IHttpActionResult> modifyUserInfo(UserInfo obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await business.modifyUserInfo(obj);

            if (result)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }
    }
}
