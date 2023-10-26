using Microsoft.AspNetCore.Mvc;
using ProgramacaoDoZero.Models;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase
    {
        [Route("obterVeiculo")]
        [HttpGet]
        public Veiculo obterVeiculo() 
        {
            var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "Amarelo";
            meuVeiculo.Marca = "Ford";
            meuVeiculo.Placa = "FGD-9224";
            meuVeiculo.Modelo = "Ônix";

            meuVeiculo.Acelerar();



            return meuVeiculo;  
        }

        [Route("obterCarro")]
        [HttpGet]
        public Carro obterCarro() 
        {
            var meuCarro = new Carro();

            meuCarro.Marca = "Forda";
            meuCarro.Modelo = "Fusion";
            meuCarro.Placa = "44456980";
            meuCarro.Cor = "Azul carcinha";

            meuCarro.Acelerar();

            return meuCarro;
        }

        [Route("obterMoto")]
        [HttpGet]
        public Moto obterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.Marca = "Honda";
            minhaMoto.Modelo = "Bizinha";
            minhaMoto.Placa = "CHERES-123";
            minhaMoto.Cor = "Bege";

            minhaMoto.Acelerar();

            return minhaMoto;
        }
    }
}