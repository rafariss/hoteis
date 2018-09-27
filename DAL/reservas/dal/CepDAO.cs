using Data.reservas.model;
using System;
using System.Data.Entity;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.reservas.dal
{
    public class CepDAO
    {
        public logradouros ObterLogradouro(int cep)
        {
            using (var ctx = new ReservasModelDb())
            {
                return ctx.logradouros
                    .Include(l => l.bairros.cidades.ufs)
                    .Where(l => l.num_cep == cep).FirstOrDefault();
            }

        }

        public int incluirCidadeInexistente(cidades cidade)
        {
            using (var ctx = new ReservasModelDb())
            {

                cidades c = ctx.cidades.Where(cid => cid.desc_cidade == cidade.desc_cidade).FirstOrDefault();
                if (c == null)
                {
                    ctx.cidades.Add(cidade);
                    ctx.SaveChanges();                                  

                }
                return c.cidade_id;
            }
        }

        public int incluirBairroInexistente(bairros bairro)
        {
            using (var ctx = new ReservasModelDb())
            {

                bairros b = ctx.bairros.Where(bai => bai.desc_bairro == bairro.desc_bairro).FirstOrDefault();
                if (b == null)
                {
                    ctx.bairros.Add(bairro);
                    ctx.SaveChanges();

                }
                return b.bairro_id;
            }
        }

        public void incluirLogradouro(logradouros logradouro)
        {
            using (var ctx = new ReservasModelDb())
            {


                ctx.logradouros.Add(logradouro);
                ctx.SaveChanges();
                       
                
            }
        }
    }
}
