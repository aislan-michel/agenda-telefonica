namespace AgendaTelefonica.App.Entities;

public class Contato 
{
    public Contato(string nome, string telefone, string email)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Telefone = telefone;
        Email = email;

    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Telefone { get; private set; }
    public string Email { get; private set; }
    
    public override string ToString() 
    {
        return $"Nome: {Nome} | Id: {Id} | Telefone: {Telefone} | E-mail: {Email}";
    }
}