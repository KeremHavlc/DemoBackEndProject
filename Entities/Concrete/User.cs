using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User
    {
        public int Id { get; set; }
        public string Email{ get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //byte ifadesini array tanımlama sebebimiz gelecek olan PasswordHash byte olduğu için 
        //örneğin şu şekilde gelmektedir ; 1234 1234 1234 1234 ... bu yüzden array tipinde tutuyoruz.
    }
}
