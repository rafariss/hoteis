using DAL;
using DAL.reservas.dal;
using Data.reservas.model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.reservas.bll
{
    public class HotelService
    {
        static readonly HotelDAO hotelDao = new HotelDAO();
        static readonly UfDAO ufDao = new UfDAO();
        static readonly QuartoDAO quartoDao = new QuartoDAO();
        static readonly CepDAO cepDAO = new CepDAO();
        static readonly ViaCepDAO ViacepDAO = new ViaCepDAO();
        static readonly ReservaDAO reservaDAO = new ReservaDAO();

        public List<Hotel> ListarHoteis()
        {
            return hotelDao.ListarTodos();
        }


        public void IncluirHotel(Hotel hotel)
        {
            hotelDao.Incluir(hotel);
        }
        public void AlterarHotel(Hotel hotel)
        {
            hotelDao.Alterar(hotel);
        }
        public List<ufs> ListarUfs()
        {
            return ufDao.ListarTodos();
        }
        public Hotel DetalharHotel(int id)
        {
            return hotelDao.Detalhar(id);
        }
        public void ExcluirHotel(int id)
        {
            hotelDao.Excluir(id);
        }
        public List<Quarto> ListarQuartosHotel(int idHotel)
        {
            return quartoDao.ListarPorHotel(idHotel);
        }

        public Quarto buscarQuartoPorId(int id)
        {
            return quartoDao.buscarPorId(id);
        }

        public List<Reserva> listarReserva()
        {
            return reservaDAO.listaReserva();
        }
        public void incluiReserva(Reserva reserva)
        {
            reservaDAO.Incluir(reserva);
        }

        public logradouros ObterEndereco(int cep)
        {

            logradouros logradouro = cepDAO.ObterLogradouro(cep);

            if(logradouro == null)
            {

                // caso nao ache cep na base executa esse metodo viacep

                ViaCep vc = ViacepDAO.buscarEndereco(cep);
                if(vc != null && vc.uf != null)
                {
                    cidades cidade = new cidades
                    {
                        desc_cidade = RemoveDiacritics(vc.localidade).ToUpper(),
                        flg_estado = RemoveDiacritics(vc.uf).ToUpper()
                    };
                    int cidadeid = cepDAO.incluirCidadeInexistente(cidade);
                    bairros bairro = new bairros
                    {
                        desc_bairro = RemoveDiacritics(vc.bairro).ToUpper(),
                        cidade_id = cidadeid
                    };
                    int bairroid = cepDAO.incluirBairroInexistente(bairro);
                    logradouros log = new logradouros
                    {
                        desc_logradouro = RemoveDiacritics( vc.logradouro.Substring(vc.logradouro.IndexOf(' ') + 1)).ToUpper(),
                        desc_tipo = RemoveDiacritics(vc.logradouro.Substring(0, vc.logradouro.IndexOf(' '))).ToUpper(),
                        bairro_id = bairroid,
                        num_cep = cep
                        


                    };
                    cepDAO.incluirLogradouro(log);
                    bairro.cidades = cidade;
                    log.bairros = bairro;
                    return log;

                }                               
            }
            return logradouro;
        }
        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }


    }
}
