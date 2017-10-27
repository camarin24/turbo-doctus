using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orquestador.Models;
using Orquestador.Clases;

namespace Orquestador.Controllers
{
    [Route("api/[controller]")]
    public class GitController : Controller
    {

        [HttpPost("[action]")]
        public Response<Git> Commit([FromBody]Git model)
        {
            GitHelper githelper = new GitHelper();
            var response = new Response<Git>();

            try
            {
                githelper.Init(model.Path, model.Repository);
                githelper.Commit(model.Path);
                //githelper.Checkout(model.Path, "master");
                githelper.Push(model.Path);
                response.Data = model;
                response.Data.Branch = "master";
            }
            catch (Exception ex)
            {
                response.Header.Code = 500;
                response.Header.Message = ex.Message;
            }


            return response;
        }
    }
}
