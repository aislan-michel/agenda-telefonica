namespace AgendaTelefonica.App.Entities;

public class Contato : Notification
{
    public Contato(string nome, string telefone, string email)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }

    public Guid Id { get; private set; }

    private readonly string _nome = string.Empty;
    private string Nome
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
    private string Telefone
    {
        get => _telefone;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _notifications.Add("telefone vázio");
            }

            if (value.Length != 11)
            {
                _notifications.Add("telefone inválido");
            }

            if (HaveNotifications)
            {
                return;
            }

            _telefone = value;
        }
    }
    
    

    private string Email { get; set; }
    
    public override string ToString() 
    {
        return $"Nome: {Nome} | Telefone: {Telefone} | E-mail: {Email}";
    }
}