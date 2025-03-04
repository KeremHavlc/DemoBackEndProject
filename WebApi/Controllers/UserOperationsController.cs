using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationsController : ControllerBase
    {
        private readonly IUserOperationClaimService _userOperationClaimService;

        public UserOperationsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService; 
        }
        [HttpPost("add")]
        public IActionResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimService.Add(userOperationClaim);
            return Ok("Kullanıcı Yetkilendirme İşlemi Başarıyla Tamamlandı!");
        }
    }
}
