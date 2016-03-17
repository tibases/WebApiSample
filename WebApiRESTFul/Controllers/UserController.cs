using DAL.Model;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using Utils;
using WebApiRESTFul.Models;

namespace WebApiRESTFul.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {

        private UnitOfWork _unitOfWork = new UnitOfWork();
        private Repository<User> _userRepository;


        [HttpPost]
        [Route("singup")]
        public HttpResponseMessage PostSingUp(UserModel userModel)
        {
            try
            {
                this._userRepository = this._unitOfWork.Repository<User>();

                if (this._userRepository.Table.Any(obj => obj.Email.ToLower() == userModel.Email))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Cadastro do usuário " + userModel.Name + " usuário já existe.");
                }

                var hash = new Hash(SHA512.Create());

                User user = new User()
                {
                    Name = userModel.Name,
                    Email = userModel.Email,
                    Password = hash.Cryptograph(userModel.Password),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    LastLogin = DateTime.Now
                };

                this._userRepository.Insert(user);

                userModel.ID = userModel.ID;

                return Request.CreateResponse(HttpStatusCode.OK, "Cadastro do usuário " + userModel.Name + " realizado.");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpPost]
        [Route("singin")]
        public HttpResponseMessage PostSingIn(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._userRepository = this._unitOfWork.Repository<User>();

                    User user = this._userRepository.Table.Where(obj => obj.Email.ToLower() == userModel.Email).FirstOrDefault();


                    if (user != null)
                    {
                        var hash = new Hash(SHA512.Create());

                        if (hash.PasswordValidate(userModel.Password, user.Password))
                        {
                            userModel.Name = user.Name;
                            userModel.ID = user.ID;
                            userModel.Phones = user.Phones.Select(obj => new PhoneModel() { DDD = obj.DDD, Number = obj.Number });

                        }
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Cadastro do usuário " + userModel.Name + " realizado.");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }






        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "WebApiSample SingIn SingUp" };
        }

        //// GET: api/User/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/User
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/User/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/User/5
        //public void Delete(int id)
        //{
        //}
    }
}
