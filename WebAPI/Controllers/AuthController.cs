﻿using Application.Auths.Commands.Login;
using Application.Auths.Commands.Register;
using Application.Auths.Dtos;
using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisterDto result = await Mediator.Send(registerCommand);

            SetRefreshTokenToCookie(result.RefreshToken);

            return Created("", result.AccessToken);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Register([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand registerCommand = new()
            {
                UserForLoginDto = userForLoginDto,
                IpAddress = GetIpAddress()
            };

            LoginDto result = await Mediator.Send(registerCommand);

            SetRefreshTokenToCookie(result.RefreshToken);

            return Ok(result.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new()
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7),
            };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
