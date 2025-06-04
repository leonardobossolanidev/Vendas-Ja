// Gerenciador de Vendas

string mensagemDeBoasVindas = "Bem-vindo ao Gerenciador de Vendas!";
Dictionary<string, List<int>> lojasRegistradas = new Dictionary<string, List<int>>();
Dictionary<string, List<int>> vendedoresRegistrados = new Dictionary<string, List<int>>();
Dictionary<string, List<double>> vendasPorLoja = new Dictionary<string, List<double>>();

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░███████╗██████╗░███╗░░██╗███████╗███╗░░██╗░█████╗░███████╗██████╗░
██╔════╝░██╔════╝██╔══██╗████╗░██║██╔════╝████╗░██║██╔══██╗██╔════╝██╔══██╗
██║░░██╗░█████╗░░██████╔╝██╔██╗██║█████╗░░██╔██╗██║███████║█████╗░░██████╦╝
██║░░╚██╗██╔══╝░░██╔═══╝░██║╚████║██╔══╝░░██║╚████║██╔══██║██╔══╝░░██╔══██╗
╚██████╔╝███████╗██║░░░░░██║░╚███║███████╗██║░╚███║██║░░██║███████╗██████╦╝
░╚═════╝░╚══════╝╚═╝░░░░░╚═╝░░╚══╝╚══════╝╚═╝░░╚══╝╚═╝░░╚═╝╚══════╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\n1 - Registrar uma loja");
    Console.WriteLine("2 - Registrar um vendedor");
    Console.WriteLine("3 - Avaliar uma loja");
    Console.WriteLine("4 - Avaliar um vendedor");
    Console.WriteLine("5 - Registrar venda de uma loja");
    Console.WriteLine("6 - Mostrar todas as lojas");
    Console.WriteLine("7 - Mostrar todas os vendedores");
    Console.WriteLine("8 - Exibir média de avaliação da loja");
    Console.WriteLine("9 - Exibir média de avaliação do vendedor");
    Console.WriteLine("10 - Exibir média de vendas da loja");
    Console.WriteLine("-1 - Sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcao = int.Parse(opcaoEscolhida);

    switch (opcao)
    {
        case 1: RegistrarLoja(); break;
        case 2: RegistrarVendedor(); break;
        case 3: AvaliarLoja(); break;
        case 4: AvaliarVendedor(); break;
        case 5: RegistrarVenda(); break;
        case 6: MostrarLojas(); break;
        case 7: MostrarVendedores(); break;
        case 8: ExibirMediaAvaliacaoLoja(); break;
        case 9: ExibirMediaAvaliacaoVendedor(); break;
        case 10: ExibirMediaVendas(); break;
        case -1: Console.WriteLine("Saindo..."); break;
        default: Console.WriteLine("Opção inválida!"); break;
    }
}

void RegistrarLoja()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registrar Loja");
    Console.Write("Digite o nome da loja: ");
    string nomeDaLoja = Console.ReadLine()!;
    lojasRegistradas.Add(nomeDaLoja, new List<int>());
    vendasPorLoja.Add(nomeDaLoja, new List<double>());
    Console.WriteLine($"A loja {nomeDaLoja} foi registrada com sucesso!");
    VoltarMenu();
}

void RegistrarVendedor()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registrar Vendedor");
    Console.Write("Digite o nome do vendedor: ");
    string nomeDoVendedor = Console.ReadLine()!;
    vendedoresRegistrados.Add(nomeDoVendedor, new List<int>());
    Console.WriteLine($"O vendedor {nomeDoVendedor} foi registrado com sucesso!");
    VoltarMenu();
}

void AvaliarLoja()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Loja");
    Console.Write("Digite o nome da loja que deseja avaliar: ");
    string nome = Console.ReadLine()!;
    if (lojasRegistradas.ContainsKey(nome))
    {
        Console.Write("Digite a nota (0 a 10): ");
        int nota = int.Parse(Console.ReadLine()!);
        lojasRegistradas[nome].Add(nota);
        Console.WriteLine($"Nota {nota} registrada para a loja {nome}");
    }
    else
    {
        Console.WriteLine("Loja não encontrada.");
    }
    VoltarMenu();
}

void AvaliarVendedor()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Vendedor");
    Console.Write("Digite o nome do vendedor que deseja avaliar: ");
    string nome = Console.ReadLine()!;
    if (vendedoresRegistrados.ContainsKey(nome))
    {
        Console.Write("Digite a nota (0 a 10): ");
        int nota = int.Parse(Console.ReadLine()!);
        vendedoresRegistrados[nome].Add(nota);
        Console.WriteLine($"Nota {nota} registrada para o vendedor {nome}");
    }
    else
    {
        Console.WriteLine("Vendedor não encontrado.");
    }
    VoltarMenu();
}

void RegistrarVenda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registrar Venda");
    Console.Write("Digite o nome da loja: ");
    string nome = Console.ReadLine()!;
    if (vendasPorLoja.ContainsKey(nome))
    {
        Console.Write("Digite o valor da venda: ");
        double valor = double.Parse(Console.ReadLine()!);
        vendasPorLoja[nome].Add(valor);
        Console.WriteLine($"Venda de R${valor} registrada para a loja {nome}");
    }
    else
    {
        Console.WriteLine("Loja não encontrada.");
    }
    VoltarMenu();
}

void MostrarLojas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Lojas Registradas");
    foreach (string loja in lojasRegistradas.Keys)
    {
        Console.WriteLine($"Loja: {loja}");
    }
    VoltarMenu();
}

void MostrarVendedores()
{
    Console.Clear();
    ExibirTituloDaOpcao("Vendedores Registrados");
    foreach (string vendedor in vendedoresRegistrados.Keys)
    {
        Console.WriteLine($"Vendedor: {vendedor}");
    }
    VoltarMenu();
}

void ExibirMediaAvaliacaoLoja()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média de Avaliação da Loja");
    Console.Write("Digite o nome da loja: ");
    string nome = Console.ReadLine()!;
    if (lojasRegistradas.ContainsKey(nome))
    {
        var notas = lojasRegistradas[nome];
        Console.WriteLine(notas.Count > 0
            ? $"Média de avaliação da loja {nome}: {notas.Average():F2}"
            : "Esta loja ainda não tem avaliações.");
    }
    else
    {
        Console.WriteLine("Loja não encontrada.");
    }
    VoltarMenu();
}

void ExibirMediaAvaliacaoVendedor()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média de Avaliação do Vendedor");
    Console.Write("Digite o nome do vendedor: ");
    string nome = Console.ReadLine()!;
    if (vendedoresRegistrados.ContainsKey(nome))
    {
        var notas = vendedoresRegistrados[nome];
        Console.WriteLine(notas.Count > 0
            ? $"Média de avaliação do vendedor {nome}: {notas.Average():F2}"
            : "Este vendedor ainda não tem avaliações.");
    }
    else
    {
        Console.WriteLine("Vendedor não encontrado.");
    }
    VoltarMenu();
}

void ExibirMediaVendas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média de Vendas da Loja");
    Console.Write("Digite o nome da loja: ");
    string nome = Console.ReadLine()!;
    if (vendasPorLoja.ContainsKey(nome))
    {
        var vendas = vendasPorLoja[nome];
        Console.WriteLine(vendas.Count > 0
            ? $"Média de vendas da loja {nome}: R${vendas.Average():F2}"
            : "Esta loja ainda não possui vendas registradas.");
    }
    else
    {
        Console.WriteLine("Loja não encontrada.");
    }
    VoltarMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    string asteriscos = new string('*', titulo.Length);
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void VoltarMenu()
{
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

ExibirOpcoesDoMenu();