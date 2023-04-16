using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Car4EgarAPI.Models.Context;
using Car4EgarAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Claims;

namespace Car4EgarAPI.BL
{
    public static class JWTFunction
    {
        //This fun take (expired data of token key as integer ,username you need to sent as data in token,userid as data in token)
        //and return string with token sent to UI    "Generat Token with data"
        public static string JWTFun (int ExDate ,string UserName, string UserID)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("My_Token_Key_2468"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            //Sented Data
            var Data = new List<Claim>();
            Data.Add(new Claim("UserName", UserName));
            Data.Add(new Claim("UserID", UserID));
            ////////////
            var token = new JwtSecurityToken(
            claims:Data,
            expires: DateTime.Now.AddMinutes(ExDate),
            signingCredentials: credentials);
            return (new JwtSecurityTokenHandler().WriteToken(token));
        }




        //In Action you can read data in it using this//
        //var identity = User.Identity as ClaimsIdentity;
        //List<Claim> UserTokenData = identity.Claims.ToList();
        //string UserName = UserTokenData[0].Value;
        //string UserID = UserTokenData[1].Value;


        //Before Action you need Authorize 
        //Use This Atribute [Authorize]


        //From UI You Sent Token In Body in This Format

        //Authorization: Bearer token
        //replace token with you token key
    }
}
