using AgendaTelefonica.App.Entities;

Console.WriteLine("\t\t\t\t=====================================================\n");
Console.WriteLine("\t\t\t\t==================AGENDA TELEFÔNICA==================\n");
Console.WriteLine("\t\t\t\t Cadastrar Novo Contato                         - [1]\n");
Console.WriteLine("\t\t\t\t Buscar Contato                                 - [2]\n");
Console.WriteLine("\t\t\t\t Contatos Cadastrados                           - [3]\n");
Console.WriteLine("\t\t\t\t Remover Contatos                               - [4]\n");
Console.WriteLine("\t\t\t\t Sair                                           - [0]\n");
Console.WriteLine("\t\t\t\t=====================================================\n");
Console.Write("\t\t\t\t          Entre com a opção desejada: ");

var opcao = int.Parse(Console.ReadLine());

var contatos = new List<Contato>();

while (opcao != 0) {

    if (opcao == 1) {

        //Inserção de contatos
        Console.Write("\n\t\t\t\tInforme quantos contatos deseja cadastrar: ");
        var quant = int.Parse(Console.ReadLine());

        for (var i = 0; i < quant; i++) {

            Console.WriteLine("\n\n\t\t\t\tCadastro de novo contato:");
            Console.Write("\t\t\t\tInforme o nome: ");
            var nome = Console.ReadLine();
            Console.Write("\t\t\t\tTelefone: ");
            var telefone = Console.ReadLine();
            Console.Write("\t\t\t\tEmail: ");
            var email = Console.ReadLine();

            Console.Write("\n\t\t\t\tConfimar? ");
            var resp = Console.ReadLine();

            if (resp == "s" || resp == "S") 
            {
                contatos.Add(new Contato(nome, telefone, email));
                Console.WriteLine("\t\t\t\tContato cadastrado com sucesso!\n\n");

            } 
            else if (resp == "n" || resp == "N") 
            {
                
                Console.WriteLine("\n\t\t\t\tInforamções corrigidas do contato:");
                Console.Write("\t\t\t\tNome: ");
                nome = Console.ReadLine();
                Console.Write("\t\t\t\tTelefone: ");
                telefone = Console.ReadLine();
                Console.Write("\t\t\t\tEmail: \n");
                email = Console.ReadLine();

                contatos.Add(new Contato(nome, telefone, email));

            } 
            else
            {
                Console.WriteLine("\t\t\t\tResponda apenas com 's' ou 'n'. \n");
                Console.Write("\n\t\t\t\tConfimar? ");
                opcao = 1;

            }
        }

    }

    if (opcao == 2) 
    {
        //Consultar unico contato
        var isEmpty = !contatos.Any(); 

        if (isEmpty) 
        {
            Console.WriteLine("\n\t\t\t\tLista vazia!");
        } 
        else 
        {
            Console.WriteLine("\n\t\t\t\tBuscar contato: ");
            Console.Write("\t\t\t\tInforme o ID do contato:");
            var searchId = Console.ReadLine();

            var searchContato = contatos.Find(x => x.Id.ToString() == searchId);

            if (searchContato != null) 
            {
                Console.WriteLine($"\n\t\t\t\t{searchContato}\n");
            } 
            else 
            {
                Console.WriteLine("\n\t\t\t\tID não existe!");
                searchId = null;
                Console.Write("\n\t\t\t\tInforme outro ID valido: ");
                searchId = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(searchId)) 
                {
                    Console.WriteLine("\n\t\t\t\tID não existe!");

                } 
                else 
                {
                    searchContato = contatos.Find(z => z.Id.ToString() == searchId);
                    Console.WriteLine($"\n\t\t\t\t{searchContato}");
                }
            }
        }
    } 
    else if (opcao == 3) 
    {

        //Consultar todos os contatos
        bool isEmpty = !contatos.Any(); 

        if (isEmpty) 
        {
            Console.WriteLine("\n\t\t\t\tLista vazia!\n");

        } 
        else 
        {
            Console.WriteLine("\n\t\t\t\tContatos cadastrados: ");

            for (var i = 0; i < contatos.Count; i++) 
            {
                Console.WriteLine($"\t\t\t\t#{i+1} - {contatos[i]}\n");

            }

        }

    } else if (opcao == 4) {

        //Deleção de contatos
        var isEmpty = !contatos.Any(); 

        if (isEmpty) 
        {
            Console.WriteLine("\n\t\t\t\tLista vazia!");

        } else 
        {
            Console.Write("\n\t\t\t\tInforme quantos contatos deseja deletar: ");
            int del = int.Parse(Console.ReadLine());

            if (del == 1) 
            {

                Console.Write("\n\t\t\t\tInforme o ID do contato:");
                var searchId = Console.ReadLine();

                contatos.RemoveAll(x => x.Id.ToString() == searchId);

                Console.WriteLine("\n\t\t\t\tContato deletado com sucesso!\n");
             
            } 
            else if (del > 1) 
            {

                for (var i = 0; i < del; i++) 
                {
                    Console.Write("\n\t\t\t\tInforme o ID do contato:");
                    var searchId = Console.ReadLine();

                    contatos.RemoveAll(y => y.Id.ToString() == searchId);

                    Console.WriteLine("\n\t\t\t\tContato deletado com sucesso!\n");

                }
            }
        }
    } 
    else if (opcao > 4 || opcao < 0)
    {
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
    opcao = int.Parse(Console.ReadLine());

}

Console.WriteLine("\n\t\t\t\tPrograma finalizado! ");
Console.WriteLine("\t\t\t\tObrigado!!!");

        

