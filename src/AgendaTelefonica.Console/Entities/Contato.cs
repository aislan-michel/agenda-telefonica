using AgendaTelefonica.Console.Extensions;

namespace AgendaTelefonica.Console.Entities;

public class Contato : Notification
{
    public Contato(string nome, string telefone, string email)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }

    private Guid Id { get; }

    private readonly string _nome = string.Empty;
    public string Nome
    {
        get => _nome;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _notifications.Add("nome vázio");
                return;
            }

            _nome = value;
        }
    }

    private readonly string _telefone = string.Empty;
    public string Telefone
    {
        get => _telefone;
        private init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _notifications.Add("telefone vázio");
            }

            if (value.Length != 11)
            {
                _notifications.Add("telefone inválido");
            }

            if (!value.IsDigitsOnly())
            {
                _notifications.Add("formato inválido, deve-se informar apenas números");
            }

            if (HaveNotifications)
            {
                return;
            }

            _telefone = value;
        }
    }

    private readonly string _email = string.Empty;
    public string Email
    {
        get => _email;
        private init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _notifications.Add("e-mail vázio");
            }
            
            if (!value.IsValidEmail())
            {
                _notifications.Add("e-mail inválido");
            }

            if (HaveNotifications)
            {
                return;
            }

            _email = value;
        }
    }
    
    public override string ToString() 
    {
        return $"Nome: {_nome} | Telefone: {_telefone} | E-mail: {_email}";
    }
}