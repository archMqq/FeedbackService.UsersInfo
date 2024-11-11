using FeedbackService.UserInfo.UserInfoModels.Models;
using FeedbackService.UsersInfo.Services;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackService.UsersInfo.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDataService _service;
        public UserController(UserDataService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SetUserData([FromBody] User user)
        {
            var res = await _service.SaveUserDefaultData(user);
            if (res.InternalServerError)
                return StatusCode(500);

            return Ok(res.Result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserName([FromBody] User user)
        {
            var res = await _service.UpdateUserInfo(user);

            if (res.InternalServerError)
                return StatusCode(500);
            if (res.NotFound)
                return NotFound(res.Errors.Error);

            return Ok();
        }
    }
}
