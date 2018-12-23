using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultaCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultaCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);//troca o cep informado no param{0} da url

            WebClient wc = new WebClient();//instancia client para fazer download do conteudo da pagina
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);//Desserializa o obj para json.

            if (end == null) return null;

            return end;
        }
    }
}
