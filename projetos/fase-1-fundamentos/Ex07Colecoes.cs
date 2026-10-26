using System.Globalization;

public static class Ex07Colecoes
{
    public static void Executar()
    {
        List<Projeto> projetos = Dados.Projetos();

        // ---------------------------------------------------------
        // 1. Dicionário de contagem de projetos por status
        // ---------------------------------------------------------

        Dictionary<StatusProjeto, int> contagemPorStatus = [];
        foreach (var projeto in projetos)
        {
            if (contagemPorStatus.TryGetValue(projeto.Status, out int quantidade))
                contagemPorStatus[projeto.Status] = quantidade + 1;
            else
                contagemPorStatus[projeto.Status] = 1;
        }

        foreach (var (status, quantidade) in contagemPorStatus)
            Console.WriteLine($"{status}: {quantidade}");

        // ---------------------------------------------------------
        // 2. Orçamento total dos projetos ativos
        // ---------------------------------------------------------

        decimal orcamentoAtivo = 0m;

        foreach (var projeto in projetos)
        {
            if (projeto.Status == StatusProjeto.Ativo)
                orcamentoAtivo += projeto.Orcamento;
        }

        Console.WriteLine($"Orçamento ativo: {orcamentoAtivo.ToString("C", new CultureInfo("pt-BR"))}");

        // ---------------------------------------------------------
        // 3. Gerente com mais projetos
        // ---------------------------------------------------------

        Dictionary<string, int> contagemPorGerente = [];
        int maxProjetos = 0;
        string gerenteComMaisProjetos = "";
        foreach (var projeto in projetos)
        {
            contagemPorGerente[projeto.Gerente] = contagemPorGerente.GetValueOrDefault(projeto.Gerente) + 1;
            // Empate: fica o primeiro gerente que chegou ao máximo, porque o ">" não troca.
            if (contagemPorGerente[projeto.Gerente] > maxProjetos)
            {
                gerenteComMaisProjetos = projeto.Gerente;
                maxProjetos = contagemPorGerente[projeto.Gerente];
            }
        }

        Console.WriteLine($"Gerente com mais projetos: {gerenteComMaisProjetos} ({maxProjetos})");
    }

    /*
    T1 - Ordem do Dictionary:
    A saída ficou "Ativo, Concluido, Suspenso" porque foi essa a ordem em que os status apareceram e foram inseridos primeiro. A documentação não garante essa ordem e não devemos confiar nela. Por exemplo, se fizermos um Remove e depois um Add, o novo item pode aparecer no meio da iteração, pois o dicionário reaproveita o espaço vazio deixado na memória.

    Para imprimir na ordem correta, iteramos no próprio Enum:

    foreach (var status in Enum.GetValues<StatusProjeto>())
    {
        int qtd = contagemPorStatus.GetValueOrDefault(status);
        if (qtd > 0)
            Console.WriteLine($"{status}: {qtd}");
    }
    */
}
