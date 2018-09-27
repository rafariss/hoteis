using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util;

namespace DAL.reservas.dal
{
    public class ViaCepDAO
    {
       

        public ViaCep buscarEndereco(int cep) {

            WebApiClient client = new WebApiClient("https://viacep.com.br");

            // https://viacep.com.br/ws/0000000/json

            string s = String.Format("ws/{0:00000000}/json", cep);
            
            ViaCep viaCep = client.GetJson<ViaCep>(s);

            return viaCep;


        }
    }
        
    public class ViaCep
    {

        public string cep { get; set; } 
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }

    }


}
        /*
         
         {
  "cep": "82200-070",
  "logradouro": "Rua Lívio Moreira",
  "complemento": "",
  "bairro": "São Lourenço",
  "localidade": "Curitiba",
  "uf": "PR",
  "unidade": "",
  "ibge": "4106902",
  "gia": ""
}
         
         
         
         */
   
