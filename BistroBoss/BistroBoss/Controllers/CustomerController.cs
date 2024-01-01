using BLL.DTOs.CustomerDTOs;
using BLL.Services.CustomerServices;
using BistroService.Authenticate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BistroService.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("api/customers")]
        public HttpResponseMessage Customers()
        {
            try
            {
                var data = CustomerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/customers/{username}")]
        public HttpResponseMessage Customers( string username)
        {
            try
            {
                var data = CustomerService.Get(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/customers/add")]
        public HttpResponseMessage CustomersAdd(CustomerDTO customer)
        {
            try
            {
                // Send welcome email
               // SendWelcomeEmail(customer);

                // Insert customer into the database
                var data = CustomerService.Insert(customer);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                Console.WriteLine(ex.ToString());

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        //private void SendWelcomeEmail(CustomerDTO customer)
        //{
        //    string senderEmail = "admin@gmail.com";
        //    string senderPassword = "oulcgsufebduckez";
        //    string recipientEmail = customer.Email;
        //    string subject = "Welcome to Our Bistro Boss And!";
        //    string body = $@"
        //        <div style=""font-family: Arial, sans-serif; font-size: 14px; color: #0d0d0d; font-weight: 300;"">
        //            <h4>Dear {customer.Name},</h4>
        //            <p>Thank you for signing up with Bistro Boss And. We are thrilled to have you as a member of our community! 
        //            We believe that our service will benefit, and we can't wait to see the impact that you'll make with it. 
        //            If you have any questions or need assistance, please don't hesitate to reach out to us at BistrosBoss@gmail.com. We're here to help!</p>
        //            <p>Once again, welcome to Bistro Boss And, and thank you for choosing us.</p>
        //            <h4>Best regards,</h4>
        //            <h3>Bistro Boss AND</h3>
        //        </div>";

        //    using (var smtpClient = new SmtpClient("smtp.gmail.com"))
        //    {
        //        smtpClient.Port = 587;
        //        smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
        //        smtpClient.EnableSsl = true;

        //        var message = new MailMessage(senderEmail, recipientEmail, subject, body)
        //        {
        //            IsBodyHtml = true
        //        };

        //        smtpClient.Send(message);
        //    }
        //}
        [HttpPost]
        [Route("api/customers/{username}/update")]
        public HttpResponseMessage CustomersUpdate(CustomerDTO username)
        {
            try
            {
                var data = CustomerService.Update(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/customers/{username}/delete")]
        public HttpResponseMessage CustomersDelete(string username)
        {
            try
            {
                var data = CustomerService.Delete(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/customers/{username}/order")]
        public HttpResponseMessage CustomersOrder(string username)
        {
            try
            {
                var data = CustomerService.CustomersOrders(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/customers/{username}/order/delete")]
        public HttpResponseMessage CustomersOrdesDelete(string username)
        {
            try
            {
                var data = CustomerService.OrderDelete(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/customers/{username}/Bossorder")]
        public HttpResponseMessage CustomersBossOrder(string username)
        {
            try
            {
                var data = CustomerService.CustomersOrders(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/customers/{username}/Bossorder/delete")]
        public HttpResponseMessage CustomersBossOrdesDelete(string username)
        {
            try
            {
                var data = CustomerService.OrderDelete(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/customers/count")]
        public HttpResponseMessage CustomersCount()
        {
            try
            {
                var data = CustomerService.Get().Count;
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

    }
}
