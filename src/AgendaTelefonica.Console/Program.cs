using AgendaTelefonica.Console.Entities;
using AgendaTelefonica.Console.Entities.Enums;

string ReadLine() => Console.ReadLine() ?? string.Empty;

try
{
    var agenda = new Agenda();

    var opcao = Opcao.MostrarOperacoes;

    while (opcao != Opcao.Sair)
    {
        switch (opcao)
        {
            case Opcao.Cadastrar:
                {
                    Console.Write("\n\tInforme o nome: ");
                    var nome = ReadLine();

                    Console.Write("\tTelefone (apenas numeros com ddd): ");
                    var telefone = ReadLine();

                    Console.Write("\tE-mail: ");
                    var email = ReadLine();

                    var contato = new Contato(nome, telefone, email);

                    if (!contato.HaveNotifications)
                    {
                        agenda.AdicionarContato(contato);
                        break;
                    }

                    Console.WriteLine("\n");
    
                    foreach (var notification in contato.Notifications)
                    {
                        Console.WriteLine($"\t{notification}");
                    }
                    
                    Console.WriteLine("\n");
                }

                break;
            case Opcao.Buscar:
                {
                    Console.Write("\n\tInforme o nome, telefone ou e-mail: ");

                    var termo = ReadLine();

                    var contato = agenda.ObterContato(termo);

                    if (contato == null)
                    {
                        Console.WriteLine("\n\tContato não encontrado\n");
                        break;
                    }

                    Console.WriteLine($"\n\t{(string) contato}\n");
                }

                break;
            case Opcao.Listar:
                {
                    Console.WriteLine("\n");
                    
                    foreach (var contato in agenda.Contatos)
                    {
                        Console.WriteLine($"\t#{agenda.Contatos.ToList().IndexOf(contato) + 1} - {(string) contato}");
                    }
                    
                    Console.WriteLine("\n");
                }

                break;
            case Opcao.Atualizar:
                {
                    Console.WriteLine("\n");
                    
                    Console.Write("\tInforme o nome, telefone ou e-mail: ");

                    var termo = ReadLine();

                    var contato = agenda.ObterContato(termo);
                    
                    if (contato == null)
                    {
                        Console.WriteLine("\n\tContato não encontrado\n");
                        break;
                    }
                    
                    Console.WriteLine($"\n\t{(string) contato}");
                    
                    Console.Write("\n\tInforme o nome: ");
                    var nome = ReadLine();

                    Console.Write("\tTelefone (apenas numeros com ddd): ");
                    var telefone = ReadLine();

                    Console.Write("\tE-mail: ");
                    var email = ReadLine();

                    contato.Atualizar(nome, telefone, email);

                    if (contato.HaveNotifications)
                    {
                        Console.WriteLine("\n");
                        
                        foreach (var notification in contato.Notifications)
                        {
                            Console.WriteLine($"\t{notification}");
                        }
                    }

                    Console.WriteLine($"\n\t{(string) contato}");
                    
                    Console.WriteLine("\n");
                }
                
                break;
            case Opcao.Remover:
                {
                    Console.Write("\n\tInforme o nome, telefone ou e-mail: ");

                    var termo = ReadLine();

                    var contato = agenda.ObterContato(termo);

                    if (contato == null)
                    {
                        Console.WriteLine("\n\tContato não encontrado\n");
                        break;
                    }
                    
                    agenda.DeletarContato(contato);

                    Console.WriteLine("\n\tContato deletado com sucesso\n");
                }
                
                break;
            case Opcao.Limpar:
                agenda.LimparContatos();
                
                break;
            case Opcao.MostrarOperacoes:
                {
                    Console.WriteLine("\t==================AGENDA TELEFÔNICA==================\n");
                    Console.WriteLine("\t Cadastrar                                      - [1]\n");
                    Console.WriteLine("\t Buscar                                         - [2]\n");
                    Console.WriteLine("\t Listar                                         - [3]\n");
                    Console.WriteLine("\t Atualizar                                      - [4]\n");
                    Console.WriteLine("\t Deletar                                        - [5]\n");
                    Console.WriteLine("\t Limpar                                         - [6]\n");
                    Console.WriteLine("\t Sair                                           - [0]\n");
                    Console.WriteLine("\t=====================================================\n");
                    Console.Write("\t          Entre com a opção desejada: ");

                    opcao = Enum.Parse<Opcao>(ReadLine());
                }
                
                break;
            default:
                Console.WriteLine("\n\nOpção Inválida\n\n");
                throw new ArgumentOutOfRangeException(nameof(opcao));
        }       
    }
}
catch (Exception e)
{
    Console.WriteLine($"\n\t{e.Message}");
}
finally
{
    Console.WriteLine("\n\tPrograma finalizado");
    Console.ReadKey();
}




        

