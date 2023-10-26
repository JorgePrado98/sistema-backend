using Microsoft.AspNetCore.Mvc;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class Aula8Controller : ControllerBase
    {
        [Route("olaMundo")]
        [HttpGet]
        public string OlaMundo()
        {
            var mensagem = "Olá Mundo via API";

            return mensagem;
        }

        [Route("olaMundoPersonalizado")]
        [HttpGet]
        public string OlaMundoPersonalizado(string nome) 
        {
            var mensagem = "Olá " + nome + ", eu sou uma API FIIII";

            return mensagem;
        }

        [Route("somar")]
        [HttpGet]
        public string Somar(int valor1,int valor2)
        {
            var soma = valor1 + valor2;

            var mensagem = "A soma é " + soma;

            return mensagem;
        }

        [Route("media")]
        [HttpGet]
        public string Media(decimal valor1, decimal valor2)
        {
            var media = (valor1 + valor2) / 2;

            var mensagem = "A média é " + media;

            return mensagem;

        }

        [Route("terreno")]
        [HttpGet]
        public string Terreno(decimal largura, decimal comprimento, decimal valorM2)
        {
            var areaTerreno = largura * comprimento;

            var valorTerreno = areaTerreno * valorM2;

            var mensagem = "A área do terreno é de " + areaTerreno + "m2. O valor do terreno é de R$ " + valorTerreno; 
            
            return mensagem;
           
        }

        [Route("troco")]
        [HttpGet]
        public string Troco(decimal valorP, decimal quantP, decimal valorC)
        {
            var valorCompra = valorP * quantP;

            var trocoC = valorC - valorCompra;

            var mensagem = "O total da compra foi de R$ " + valorCompra + ",00. Volte R$ " + trocoC + ",00 para o cliente";

            return mensagem;
        }

        [Route("pagamento")]
        [HttpGet] 
        public string Pagamento(string nome, decimal valorH, decimal horaT)
        {
            var valorReceber = valorH * horaT;

            var mensagem = nome + " deverá receber R$ " + valorReceber;

            return mensagem;
        }

        [Route("consumoMedio")]
        [HttpGet]
        public string consumoMedio(decimal distP, decimal qtdComb)
        {
            var consumoMedio = distP / qtdComb;

            var mensagem = "O consumo médio do carro é de " + consumoMedio + "Km/L";

            return mensagem;

        }

    }
}
