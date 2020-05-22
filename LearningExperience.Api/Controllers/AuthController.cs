﻿using Castle.Core.Configuration;
using LearningExperience.Models;
using LearningExperience.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LearningExperience.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        private readonly IJwtTokenSettings _jwtTokenSettings;

        public AuthController(IJwtTokenSettings jwtTokenSettings)
        {
            _jwtTokenSettings = jwtTokenSettings;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] AuthenticateUserDTO userDTO)
        {
            if (userDTO.Email == null) return Unauthorized();
            string tokenString = string.Empty;
            bool validUser = Authenticate(userDTO);
            if (validUser)
            {
                tokenString = BuildJWTToken();
            }
            else
            {
                return Unauthorized();
            }
            return Ok(new { Token = tokenString, TokenExpiresIn =_jwtTokenSettings.TokenExpiry });
        }



        private string BuildJWTToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = _jwtTokenSettings.Issuer;
            var audience = _jwtTokenSettings.Audience;
            var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(_jwtTokenSettings.TokenExpiry));

            var token = new JwtSecurityToken(issuer,
              audience,
              expires: jwtValidity,
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool Authenticate(AuthenticateUserDTO login)
        {
            bool validUser = false;

            if (login.Email == "teste123" && login.Password == "123")
            {
                validUser = true;
            }
            return validUser;
        }


    }
}
