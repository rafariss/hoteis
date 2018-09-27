using BLL.reservas.bll;
using Data.reservas.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class HotelAPIController : ApiController
    {
        static HotelService service = new HotelService();
        [HttpGet]
        public HttpResponseMessage ObterEndereco([FromUri] Parametros param)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Formato incorreto2: " + param.Cep);
            }
            int icep;
            bool b = int.TryParse(param.Cep.Replace("-", ""), out icep);
            if (!b)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Formato incorreto: " + param.Cep);
            }
            logradouros logradouro = service.ObterEndereco(icep);
            if (logradouro == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "CEP não encontrado: " + param.Cep);
            }
            Endereco end = new Endereco
            {
                Logradouro = logradouro.desc_logradouro,
                Cidade = logradouro.bairros.cidades.desc_cidade,
                Uf = logradouro.bairros.cidades.flg_estado
            };
            return Request.CreateResponse(HttpStatusCode.OK, end);
        }
    }
    public class Endereco
    {
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
    }
    public class Parametros
    {
        [RegularExpression(@"\d\d\d\d\d-\d\d\d", ErrorMessage = "CEP deve estar no formato 00000-000")]
        public string Cep { get; set; }
        public string Texto { get; set; }
    }
}
