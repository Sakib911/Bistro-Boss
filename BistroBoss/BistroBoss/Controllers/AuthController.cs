﻿using BLL.Services.CustomerServices;
using BistroService.Authenticate;
using BistroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Services.Description;

namespace BistroService.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        string userName;
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                var res = AuthenticateService.Authenticate(login.Username, login.Password);
                userName = login.Username;
                if(res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new  { Message = "User not Found!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            Console.WriteLine(token);
            try
            {
                var res = AuthenticateService.Logout(token);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {Message = ex.Message});  
            }
        }
    }
}
