using AgendaTelefonica.Console.Data;
using AgendaTelefonica.Console.Entities;
using AgendaTelefonica.Console.Entities.Enums;
using AgendaTelefonica.Console.Extensions;

var agenda = new List<Contato>();
const string agendaPath = @"../../../Data/agenda.txt";

var txtRepository = new TxtRepository(agendaPath);

string ReadLine() => Console.ReadLine() ?? string.Empty;

void Cadastrar(Contato contato)
{
    if (!contato.HaveNotifications)
    {
        agenda.Add(contato);
        
        txtRepository.Write($"- {contato}\n");
        
        return;
    }
    
    foreach (var notification in contato.Notifications)
    {
        Console.WriteLine(notification);
    }
}

Contato? Obter(string termo)
{
    if (agenda == null)
    {
        throw new NullReferenceException(nameof(agenda));
    }

    if (string.IsNullOrWhiteSpace(termo))
    {
        return null;
    }
    
    if (termo.IsValidEmail())
    {
        return agenda.FirstOrDefault(x => x.Email == termo);
    }
    
    if (termo.IsDigitsOnly())
    {
        return agenda.FirstOrDefault(x => x.Telefone == termo);
    }
    
    return agenda.FirstOrDefault(x => x.Nome == termo);
}

Console.WriteLine("\t\t\t\t==================AGENDA TELEFÔNICA==================\n");
Console.WriteLine("\t\t\t\t Cadastrar                                      - [1]\n");
Console.WriteLine("\t\t\t\t Buscar                                         - [2]\n");
Console.WriteLine("\t\t\t\t Listar                                         - [3]\n");
Console.WriteLine("\t\t\t\t Editar                                         - [4]\n");
Console.WriteLine("\t\t\t\t Remover                                        - [5]\n");
Console.WriteLine("\t\t\t\t Sair                                           - [0]\n");
Console.WriteLine("\t\t\t\t=====================================================\n");
Console.Write("\t\t\t\t          Entre com a opção desejada: ");

var opcao = Enum.Parse<Opcao>(ReadLine());

while (opcao != 0) 
{
    switch (opcao)
    {
        case Opcao.Cadastrar:
            Console.Write("\t\t\t\tInforme o nome: ");
            var nome = ReadLine();
            
            Console.Write("\t\t\t\tTelefone (apenas numeros com ddd): ");
            var telefone = ReadLine();
            
            Console.Write("\t\t\t\tE-mail: ");
            var email = ReadLine();
            
            Cadastrar(new Contato(nome, telefone, email));
            
            break;
        case Opcao.Buscar:
            if (!agenda.Any()) 
            {
                Console.WriteLine("\n\t\t\t\tAgenda vazia");
            } 
            else 
            {
                Console.Write("\t\t\t\tInforme o nome, telefone ou e-mail:");
            
                var termo = ReadLine();

                var contato = Obter(termo);

                if (contato == null)
                {
                    Console.WriteLine("Contato não encontrado");
                    break;
                }

                Console.WriteLine($"\n\t\t\t\t{contato}\n");
            }
            break;
        case Opcao.Listar:
            if (!agenda.Any()) 
            {
                Console.WriteLine("\n\t\t\t\tLista vazia\n");
            } 
            else 
            {
                Console.WriteLine("\n\t\t\t\tContatos cadastrados: ");

                foreach (var contato in agenda)
                {
                    Console.WriteLine($"\t\t\t\t#{agenda.IndexOf(contato) + 1} - {contato.ToString()}\n");
                }
            }
            break;
        case Opcao.Editar:
            break;
        case Opcao.Remover:
            if (!agenda.Any()) 
            {
                Console.WriteLine("\n\t\t\t\tAgenda vazia");
            } 
            else 
            {
                Console.WriteLine("\n\t\t\t\tDeletar contato: ");
                Console.Write("\t\t\t\tInforme o nome, telefone ou e-mail:");

                var termo = ReadLine();

                var contato = Obter(termo);
            
                if (contato == null)
                {
                    Console.WriteLine("Contato não encontrado");
                    break;
                }

                agenda.Remove(contato);
            
                Console.WriteLine("\n\t\t\t\tContato deletado com sucesso\n");
            }
            break;
        case Opcao.Limpar:
            txtRepository.Clear();
            
            agenda.Clear();
            break;
        default:
            Console.WriteLine("\n\n\t\t\t\t\t\tOpção Inválida\n\n");
            throw new ArgumentOutOfRangeException(nameof(opcao));
            
    }

    Console.WriteLine("\t\t\t\t==================AGENDA TELEFÔNICA==================\n");
    Console.WriteLine("\t\t\t\t Cadastrar                                      - [1]\n");
    Console.WriteLine("\t\t\t\t Buscar                                         - [2]\n");
    Console.WriteLine("\t\t\t\t Listar                                         - [3]\n");
    Console.WriteLine("\t\t\t\t Editar                                         - [4]\n");
    Console.WriteLine("\t\t\t\t Remover                                        - [5]\n");
    Console.WriteLine("\t\t\t\t Sair                                           - [0]\n");
    Console.WriteLine("\t\t\t\t=====================================================\n");
    Console.Write("\t\t\t\t          Entre com a opção desejada: ");
    
    opcao = Enum.Parse<Opcao>(ReadLine());

}

Console.WriteLine("\n\t\t\t\tPrograma finalizado");

        

