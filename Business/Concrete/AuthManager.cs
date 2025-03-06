using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Hashing;
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

        public List<string> Register(RegisterAuthDto registerDto)
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

            UserValidator userValidator = new UserValidator();
            ValidationResult validationresult = userValidator.Validate(registerDto);

            List<string> results = new List<string>();

            if (validationresult.IsValid)
            {
                _userService.Add(registerDto);
                results.Add("Kullanıcı kaydı başarıyla tamamlandı");
                return results;
            }
           
            results = validationresult.Errors.Select(p => p.ErrorMessage).ToList();
            return results;
        }
    }
}
