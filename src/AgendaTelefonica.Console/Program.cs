using AgendaTelefonica.Console.Entities;
using AgendaTelefonica.Console.Entities.Enums;
using AgendaTelefonica.Console.Extensions;

var agenda = Obter();
const string agendaPath = @"../../../Data/agenda.csv";

string ReadLine() => Console.ReadLine() ?? string.Empty;

void Cadastrar(Contato contato)
{
    if (!contato.HaveNotifications)
    {
        agenda.Add(contato);
        
        File.AppendAllText(agendaPath, "\n" + (string) contato);
        
        return;
    }
    
    foreach (var notification in contato.Notifications)
    {
        Console.WriteLine(notification);
    }
}

Contato? Buscar(string termo)
{
    if (agenda == null || agenda.Equals(new List<Contato>()))
    {
        agenda = Obter();
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

List<Contato> Obter()
{
    var registros = File.ReadLines(agendaPath);

    return registros.Select(linha => (Contato)linha).ToList();
}

Console.WriteLine("\t\t\t\t==================AGENDA TELEFÔNICA==================\n");
Console.WriteLine("\t\t\t\t Cadastrar                                      - [1]\n");
Console.WriteLine("\t\t\t\t Buscar                                         - [2]\n");
Console.WriteLine("\t\t\t\t Listar                                         - [3]\n");
Console.WriteLine("\t\t\t\t Editar                                         - [4]\n");
Console.WriteLine("\t\t\t\t Remover                                        - [5]\n");
Console.WriteLine("\t\t\t\t Limpar                                         - [6]\n");
Console.WriteLine("\t\t\t\t Sair                                           - [0]\n");
Console.WriteLine("\t\t\t\t=====================================================\n");
Console.Write("\t\t\t\t          Entre com a opção desejada: ");

try
{
    var opcao = Enum.Parse<Opcao>(ReadLine());

    while (opcao != 0)
    {
        switch (opcao)
        {
            case Opcao.Cadastrar:
                Console.Write("\n\t\t\t\tInforme o nome: ");
                var nome = ReadLine();

                Console.Write("\t\t\t\tTelefone (apenas numeros com ddd): ");
                var telefone = ReadLine();

                Console.Write("\t\t\t\tE-mail: ");
                var email = ReadLine();

                Cadastrar(new Contato(nome, telefone, email));
                
                Console.WriteLine("\n");

                break;
            case Opcao.Buscar:
                {
                    Console.Write("\n\t\t\t\tInforme o nome, telefone ou e-mail: ");

                    var termo = ReadLine();

                    var contato = Buscar(termo);

                    if (contato == null)
                    {
                        Console.WriteLine("\n\t\t\t\tContato não encontrado\n");
                        break;
                    }

                    Console.WriteLine($"\n\t\t\t\t{(string) contato}\n");
                }

                break;
            case Opcao.Listar:
                {
                    Console.WriteLine("\n");
                    
                    foreach (var contato in agenda)
                    {
                        Console.WriteLine($"\t\t\t\t#{agenda.IndexOf(contato) + 1} - {(string) contato}");
                    }
                    
                    Console.WriteLine("\n");
                }

                break;
            case Opcao.Editar:
                break;
            case Opcao.Remover:
                {
                    Console.Write("\t\t\t\tInforme o nome, telefone ou e-mail: ");

                    var termo = ReadLine();

                    var contato = Buscar(termo);

                    if (contato == null)
                    {
                        Console.WriteLine("\n\t\t\t\tContato não encontrado\n");
                        break;
                    }
                    
                    agenda.Remove(contato);

                    var lines = File.ReadLines(agendaPath).ToList();

                    var line = lines.FirstOrDefault(x => x.Contains(termo));

                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        lines.Remove(line);
                    }
                    
                    File.WriteAllText(agendaPath, string.Join("\n", lines));

                    Console.WriteLine("\n\t\t\t\tContato deletado com sucesso\n");
                }
                
                break;
            case Opcao.Limpar:
                File.Delete(agendaPath);

                File.Create(agendaPath);

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
        Console.WriteLine("\t\t\t\t Limpar                                         - [6]\n");
        Console.WriteLine("\t\t\t\t Sair                                           - [0]\n");
        Console.WriteLine("\t\t\t\t=====================================================\n");
        Console.Write("\t\t\t\t          Entre com a opção desejada: ");

        opcao = Enum.Parse<Opcao>(ReadLine());
    }
}
catch (Exception e)
{
    Console.WriteLine($"\n\t\t\t\t{e.Message}");
}
finally
{
    Console.WriteLine("\n\t\t\t\tPrograma finalizado");
    Console.ReadKey();
}




        

