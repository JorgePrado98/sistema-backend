using Microsoft.AspNetCore.Mvc;
using ProgramacaoDoZero.Models;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;
        private string? mensagem;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
           var result = new LoginResult();

            if (request == null) 
            {
                result.sucesso = false;
                result.mensagem = "Request veio nulo";
            }
            else if (request.email == "")
            {
                result.sucesso = false;
                result.mensagem = "E-mail obrigatório";
            }
            else if (request.senha == "")
            {
                result.sucesso= false;
                result.mensagem = "Senha obrigatória";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Login(request.email, request.senha);
            }

            return Ok(result);
        }

        [Route("cadastro")]
        [HttpPost]
       
        public IActionResult Cadastro(CadastroRequest request) 
        {
            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrWhiteSpace(request.nome) ||
                string.IsNullOrWhiteSpace(request.sobrenome) ||
                string.IsNullOrWhiteSpace(request.telefone) ||
                string.IsNullOrWhiteSpace(request.genero) ||
                string.IsNullOrWhiteSpace(request.email) ||
                string.IsNullOrWhiteSpace(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "Todos os campos são obrigatórios";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                result = new UsuarioService(connectionString).Cadastro(
                    request.nome,
                    request.sobrenome,
                    request.telefone,
                    request.email,
                    request.genero,
                    request.senha);
            }

            return Ok(result);

        }

        [Route("esqueceuSenha")]
        [HttpPost]
        public IActionResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if (request == null ||
                string.IsNullOrWhiteSpace(request.email))
            {
                result.mensagem = "E-mail obrigatório";

                return Ok (result);
            }
            
            var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

            result = new UsuarioService(connectionString).EsqueceuSenha(request.email);

            return Ok(result);
        }

        [Route("ObterUsuario")]
        [HttpGet]
        public ObterUsuarioResult ObterUsuario (Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.mensagem = "Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);
                
                if (usuario == null)
                {
                    result.mensagem = "Usuário não existe";
                }
                else
                {
                    result.sucesso = true;
                    result.Nome = usuario.Nome;
                }
            }

            return result;
        }

    }
}
