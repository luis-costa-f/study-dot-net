using System.Globalization;

public static class Ex08Linq
{
    public static void Executar()
    {
        List<Projeto> projetos = Dados.Projetos();
        var culturaBR = new CultureInfo("pt-BR");

        // 1. Ativos por orçamento, do maior para o menor (Where + OrderByDescending)
        // Usamos o Select no final para extrair apenas o Nome e facilitar a impressão na mesma linha
        var ativosPorOrcamento = projetos
            .Where(p => p.Status == StatusProjeto.Ativo)
            .OrderByDescending(p => p.Orcamento)
            .Select(p => p.Nome);

        Console.WriteLine($"Ativos por orçamento: {string.Join(", ", ativosPorOrcamento)}");

        // 2. Quantidade por status (GroupBy)
        // Agrupamos pelo enum e transformamos num texto "Status: Count"
        var qtdPorStatus = projetos
            .GroupBy(p => p.Status)
            .Select(grupo => $"{grupo.Key}: {grupo.Count()}");

        Console.WriteLine(string.Join(" | ", qtdPorStatus));

        // 3. Gerente com mais projetos (GroupBy + Select + OrderByDescending + First)
        var gerenteComMaisProjetos = projetos
            .GroupBy(p => p.Gerente)
            .Select(grupo => new { Nome = grupo.Key, Quantidade = grupo.Count() })
            .OrderByDescending(g => g.Quantidade)
            .First();

        Console.WriteLine($"Gerente com mais projetos: {gerenteComMaisProjetos.Nome} ({gerenteComMaisProjetos.Quantidade})");

        // 4. Any e All
        // Any verifica se PELO MENOS UM atende à regra. All verifica se TODOS atendem.
        bool algumAcimaDe400 = projetos.Any(p => p.Orcamento > 400_000m);
        bool todosTemGerente = projetos.All(p => !string.IsNullOrWhiteSpace(p.Gerente));

        Console.WriteLine($"Algum acima de 400 mil? {algumAcimaDe400} | Todos têm gerente? {todosTemGerente}");

        // 5. Nomes dos concluídos em maiúsculas (Where + Select)
        var concluidosMaiusculos = projetos
            .Where(p => p.Status == StatusProjeto.Concluido)
            .Select(p => p.Nome.ToUpper(culturaBR));

        Console.WriteLine($"Concluídos: {string.Join(", ", concluidosMaiusculos)}");

        // 6. Orçamento médio (Average)
        decimal media = projetos.Average(p => p.Orcamento);

        Console.WriteLine($"Orçamento médio: {media.ToString("C", culturaBR)}");

        // 7. Primeiro projeto Planejado (FirstOrDefault)
        // No Mendix, um Find que não acha nada retorna 'empty'. No C#, retorna 'null'.
        var primeiroPlanejado = projetos.FirstOrDefault(p => p.Status == StatusProjeto.Planejado);
        string nomePlanejado = primeiroPlanejado?.Nome ?? "nenhum";

        Console.WriteLine($"Primeiro planejado: {nomePlanejado}");
    }

    /*
        O Empate (Ordenação Estável):
        E se houvesse um empate? Por exemplo, se o Bruno também tivesse 3 projetos, por que a Ana ainda ganharia?

        O LINQ usa o que chamamos de "Ordenação Estável". Isso significa que, num empate, ele simplesmente respeita a "fila" original dos dados. Ele não tira cara ou coroa nem bagunça a lista: quem apareceu primeiro lá nos dados originais (Ana) mantém o seu lugar na frente de quem chegou depois (Bruno).
    */

    /*
        Reflexão: O uso do LINQ deixou a leitura do código muito mais direta. Para achar o gerente com
        mais projetos, o Ex. 7 precisou de umas 12 linhas com dicionário, controle de variáveis e if,
        enquanto o LINQ resolveu tudo encadeado em 4 linhas. A contagem de status também caiu de 6
        linhas no foreach para apenas 2. Eu só voltaria a usar o foreach clássico se precisasse realizar
        ações dentro da iteração, como gravar no banco de dados e chamar uma API ao mesmo tempo, já que o
        LINQ é focado apenas em consultar e transformar os dados.
    */

    /*
        T2 - Execução Adiada (Deferred Execution):
        A consulta 'ativosPorOrcamento' não roda no momento em que é declarada; ela só é executada de
        verdade mais abaixo, quando o string.Join começa a ler e extrair os dados. Por causa disso,
        se adicionarmos um novo projeto na lista original entre a declaração da consulta e o string.Join,
        ele vai aparecer normalmente na saída, já que o LINQ só vai ler os dados no último segundo.
        Se colocássemos um .ToList() no final da consulta (logo após o .Select), forçaríamos a execução
        imediata ali mesmo; a consulta seria resolvida e guardada na memória, e qualquer projeto
        adicionado depois seria ignorado.
    */
}
