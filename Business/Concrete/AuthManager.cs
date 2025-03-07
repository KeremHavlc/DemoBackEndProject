using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Hashing;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Dtos;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public string Login(LoginAuthDto loginDto)
        {
            var user = _userService.GetByEmail(loginDto.Email);
            var result = HashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt);
            if(result)
            {
                return "Kullanıcı girişi Başarılı";
            }
            return "Kullanıcı bilgileri hatalı";
        }

        public IResult Register(RegisterAuthDto registerDto)
        {
            //FluentValidation paketi ile aşağıdaki karmaşayı engelleyebiliriz.
            //if (registerDto.Name == "")
            //    return "Kullanıcı Adı boş olamaz!";
            //if (registerDto.Email == "")
            //    return "Email adresi boş olamaz!";
            //if (registerDto.ImageUrl == "")
            //    return "Resim boş olamaz!";
            //if (registerDto.Password == "")
            //    return "Şifre boş olamaz!";
            //if (registerDto.Password.Length < 6)
            //    return "Şifre en az 6 karakter olmalıdır!";

            //Cross Cutting Concerns - Uygulama Dikine Kesme 
            //AOP

            UserValidator userValidator = new UserValidator();
            ValidationTool.Valide(userValidator, registerDto);

            bool isExist = CheckIfEmailExists(registerDto.Email);

            if(isExist)
            {
                _userService.Add(registerDto);
                return new Result(true, "Kullanıcı kaydı başarıyla tamamlandı"); ;
            }
            else
            {
                return new Result(false, "Bu email adresi zaten kullanılmaktadır."); 
            }
            
        }
        bool CheckIfEmailExists(string email)
        {
            var list = _userService.GetByEmail(email);
            if(list != null)
            {
                return false;
            }
            return true;

        }
    }
}
