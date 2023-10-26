using ProgramacaoDoZero.Common;
using ProgramacaoDoZero.Entitites;
using ProgramacaoDoZero.Models;
using ProgramacaoDoZero.Repositories;

public class UsuarioService
{
    private string _connectionString;

    public UsuarioService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public LoginResult Login(string email, string senha)
    {
        var result = new LoginResult();

        var usuarioExistente = new UsuarioRepository(_connectionString).ObterUsuarioPorEmail(email);

        if (usuarioExistente != null)
        {

            if (usuarioExistente.Senha == senha)
            {
                // faz o login
                result.sucesso = true;
                result.UsuarioGuid = usuarioExistente.UsuarioGuid;
            }
            else
            {
                result.sucesso = false;
                result.mensagem = "Usuário ou senha inválidos";
            }
        }
        else
        {
            result.sucesso = false;
            result.mensagem = "Usuário ou senha inválidos";
        }
   
        return result;
    }

    public CadastroResult Cadastro(string nome, string sobrenome, string telefone, string email, string genero, string senha)
    {
        var result = new CadastroResult();

        var usuarioRepository = new UsuarioRepository(_connectionString);

        var usuarioExistente = usuarioRepository.ObterUsuarioPorEmail(email);

        if (usuarioExistente != null) 
        {
            //usuário já existe
            result.sucesso = false;
            result.mensagem = "Usuário já existe";
        }
        else
        {
            //usuário não existe
            var usuario = new Usuario();

            usuario.Nome = nome;
            usuario.Sobrenome = sobrenome;
            usuario.Telefone = telefone;
            usuario.Email = email;
            usuario.Genero = genero;
            usuario.Senha = senha;
            usuario.UsuarioGuid = Guid.NewGuid();

            var affectedRows = usuarioRepository.Inserir(usuario);

            if (affectedRows > 0) 
            {
                // inseriu com sucesso
                result.sucesso = true;
                result.UsuarioGuid = usuario.UsuarioGuid;
            }
            else
            {
                //erro ao inserir
                result.sucesso = false;
                result.mensagem = "Erro ao inserir usuário.Tente novamente";
            }
        }

        return result;
    }

    public EsqueceuSenhaResult EsqueceuSenha(string email)
    {
        var result = new EsqueceuSenhaResult();

        var usuario = new UsuarioRepository(_connectionString).ObterUsuarioPorEmail(email);

        if (usuario == null)
        {
            //usuário não existe
            result.sucesso= false;
            result.mensagem = "Usuário não existe para esse e-mail";
        }
        else
        {
            //usuário existe
            var assunto = "Recuperação de senha";
            var corpo = "Sua senha é " + usuario.Senha;

            var emailSender = new EmailSender();

            emailSender.Enviar(assunto, corpo, usuario.Email);

            result.sucesso = true;
        }

        return result;
    }

    public Usuario ObterUsuario(Guid usuarioGuid)
    {
        var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

        return usuario;
    }

}