/*
            Uma simples agenda telefônica, com nome, telefone, email e talvez alguns dados a mais.
            O usuário acessa/instala e seus dados ficam salvos
            Deve ser possível realizar buscas.
            */

using AgendaTelefonica.App.Entities;

List<Agenda> list = new List<Agenda>();

            Agenda valor;
            Agenda agenda = new Agenda();

            int quant = 0;
            int i;

            Console.WriteLine("\t\t\t\t=====================================================\n");
            Console.WriteLine("\t\t\t\t==================AGENDA TELEFÔNICA==================\n");
            Console.WriteLine("\t\t\t\t Cadastrar Novo Contato                         - [1]\n");
            Console.WriteLine("\t\t\t\t Buscar Contato                                 - [2]\n");
            Console.WriteLine("\t\t\t\t Contatos Cadastrados                           - [3]\n");
            Console.WriteLine("\t\t\t\t Remover Contatos                               - [4]\n");
            Console.WriteLine("\t\t\t\t Sair                                           - [0]\n");
            Console.WriteLine("\t\t\t\t=====================================================\n");
            Console.Write("\t\t\t\t          Entre com a opção desejada: ");
            int op = int.Parse(Console.ReadLine());

            

            valor = new Agenda(op);

            while (valor.Opcao != 0) {

                if (valor.Opcao == 1) {

                    //Inserção de contatos
                    Console.Write("\n\t\t\t\tInforme quantos contatos deseja cadastrar: ");
                    quant = int.Parse(Console.ReadLine());

                    for (i = 0; i < quant; i++) {

                        Console.WriteLine("\n\n\t\t\t\tCadastro de novo contato:");
                        Console.Write("\t\t\t\tInforme um ID para este contato: ");
                        int id = int.Parse(Console.ReadLine());
                        agenda.Id = id;
                        Console.Write("\t\t\t\tInforme o nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("\t\t\t\tTelefone: ");
                        string telefone = Console.ReadLine();
                        Console.Write("\t\t\t\tEmail: ");
                        string email = Console.ReadLine();

                        Console.Write("\n\t\t\t\tConfimar? ");
                        string resp = Console.ReadLine();

                        if (resp == "s" || resp == "S") {
                            list.Add(new Agenda(agenda.Id, nome, telefone, email));
                            Console.WriteLine("\t\t\t\tContato cadastrado com sucesso!\n\n");

                        } else if (resp == "n" || resp == "N") {
                            
                            Console.WriteLine("\n\t\t\t\tInforamções corrigidas do contato:");
                            Console.Write("\t\t\t\tID: ");
                            int idCorrigido = int.Parse(Console.ReadLine());
                            agenda.Id = idCorrigido;
                            Console.Write("\t\t\t\tNome: ");
                            nome = Console.ReadLine();
                            Console.Write("\t\t\t\tTelefone: ");
                            telefone = Console.ReadLine();
                            Console.Write("\t\t\t\tEmail: \n");
                            email = Console.ReadLine();

                            list.Add(new Agenda(agenda.Id, nome, telefone, email));

                        } else {
                            Console.WriteLine("\t\t\t\tResponda apenas com 's' ou 'n'. \n");
                            Console.Write("\n\t\t\t\tConfimar? ");
                            resp = Console.ReadLine();
                            valor.Opcao = 1;

                        }

                    }

                }

                if (valor.Opcao == 2) {

                    //Consultar unico contato
                    bool isEmpty = !list.Any(); //verifica se a lista é vazia

                    if (isEmpty) {
                        Console.WriteLine("\n\t\t\t\tLista vazia!");

                    } else {
                        Console.WriteLine("\n\t\t\t\tBuscar contato: ");
                        Console.Write("\t\t\t\tInforme o ID do contato:");
                        int? searchId = int.Parse(Console.ReadLine());

                        Agenda searchContato = list.Find(x => x.ID == searchId);

                        if (searchContato != null) {

                            Console.WriteLine($"\n\t\t\t\t{searchContato}\n");

                        } else {
                            Console.WriteLine("\n\t\t\t\tID não existe!");
                            searchId = null;
                            Console.Write("\n\t\t\t\tInforme outro ID valido: ");
                            searchId = int.Parse(Console.ReadLine());

                            if (searchId < 0) {
                                Console.WriteLine("\n\t\t\t\tID não existe!");

                            } else {
                                searchContato = list.Find(z => z.ID == searchId);
                                Console.WriteLine($"\n\t\t\t\t{searchContato}");

                            }

                        }

                    }


                } else if (valor.Opcao == 3) {

                    //Consultar todos os contatos
                    bool isEmpty = !list.Any(); //verifica se a lista é vazia

                    if (isEmpty) {
                        Console.WriteLine("\n\t\t\t\tLista vazia!\n");

                    } else {
                        Console.WriteLine("\n\t\t\t\tContatos cadastrados: ");

                        for (i = 0; i < list.Count; i++) {
                            Console.WriteLine($"\t\t\t\t#{i+1} - {list[i]}\n");

                        }

                    }

                } else if (valor.Opcao == 4) {

                    //Deleção de contatos
                    bool isEmpty = !list.Any(); //verifica se a lista é vazia

                    if (isEmpty) {
                        Console.WriteLine("\n\t\t\t\tLista vazia!");

                    } else {
                        Console.Write("\n\t\t\t\tInforme quantos contatos deseja deletar: ");
                        int del = int.Parse(Console.ReadLine());

                        if (del == 1) {

                            Console.Write("\n\t\t\t\tInforme o ID do contato:");
                            int searchId = int.Parse(Console.ReadLine());

                            list.RemoveAll(x => x.ID == searchId);

                            Console.WriteLine("\n\t\t\t\tContato deletado com sucesso!\n");
                         
                        } else if (del > 1) {

                            for (i = 0; i < del; i++) {
                                Console.Write("\n\t\t\t\tInforme o ID do contato:");
                                int searchId = int.Parse(Console.ReadLine());

                                list.RemoveAll(y => y.ID == searchId);

                                Console.WriteLine("\n\t\t\t\tContato deletado com sucesso!\n");

                            }

                        }

                    }

                } else if (valor.Opcao > 4 || valor.Opcao < 0){
                    Console.WriteLine("\n\n\t\t\t\t\t\tOpção Inválida!\n\n");

                }

                Console.WriteLine("\t\t\t\t=====================================================\n");
                Console.WriteLine("\t\t\t\t==================AGENDA TELEFÔNICA==================\n");
                Console.WriteLine("\t\t\t\t Cadastrar Novo Contato                         - [1]\n");
                Console.WriteLine("\t\t\t\t Buscar Contato                                 - [2]\n");
                Console.WriteLine("\t\t\t\t Contatos Cadastrados                           - [3]\n");
                Console.WriteLine("\t\t\t\t Remover Contatos                               - [4]\n");
                Console.WriteLine("\t\t\t\t Sair                                           - [0]\n");
                Console.WriteLine("\t\t\t\t=====================================================\n");
                Console.Write("\t\t\t\t          Entre com a opção desejada: ");
                op = int.Parse(Console.ReadLine());
                valor = new Agenda(op);

            }

            Console.WriteLine("\n\t\t\t\tPrograma finalizado! ");
            Console.WriteLine("\t\t\t\tObrigado!!!");

        

