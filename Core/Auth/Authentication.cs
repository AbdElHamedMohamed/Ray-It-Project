//using Microsoft.IdentityModel.Logging;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace Core.Auth
//{
//	public class Authentication
//	{
//		public Authentication()
//		{

//		}

//        //private async Task<string> CreateUserToken(UserDto employee, bool isAdmin)
//        //{
//        //    //set the time when it expires
//        //    int expirationInMin = (60* 8);

//        //    DateTime expires = DateTime.Now.AddMinutes(expirationInMin);
//        //    ClaimsIdentity claimsIdentity = new ClaimsIdentity();

//        //    claimsIdentity.AddClaim(new Claim("NameAr", employee.NameAr));
//        //    claimsIdentity.AddClaim(new Claim("NameEn", employee.NameEn));
//        //    claimsIdentity.AddClaim(new Claim("Email", employee.Email));
//        //    claimsIdentity.AddClaim(new Claim("Id", employee.Id.ToString()));
//        //    claimsIdentity.AddClaim(new Claim("MobileNumber", employee.MobileNumber ?? ""));
//        //    claimsIdentity.AddClaim(new Claim("CompanyId", employee.CompanyId.ToString()));
//        //    claimsIdentity.AddClaim(new Claim("CompanyNameAr", employee.Company.NameAr.ToString()));
//        //    claimsIdentity.AddClaim(new Claim("CompanyNameEn", employee.Company.NameEn.ToString()));
//        //    claimsIdentity.AddClaim(new Claim("IsDefaultPassword", employee.IsDefaultPassword.ToString()));
//        //    claimsIdentity.AddClaim(new Claim("UserType", "Employee"));
//        //    claimsIdentity.AddClaim(new Claim("IsAdmin", isAdmin.ToString()));

//        //    SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Ray-It Secret Key 2022"));
//        //    SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
//        //    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
//        //    {
//        //        Subject = new ClaimsIdentity(claimsIdentity),
//        //        SigningCredentials = credentials,
//        //        Expires = expires,
//        //        NotBefore = DateTime.Now
//        //    };
//        //    IdentityModelEventSource.ShowPII = true;
//        //    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
//        //    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
//        //    return tokenHandler.WriteToken(token);
//        //}

//    }
//}
