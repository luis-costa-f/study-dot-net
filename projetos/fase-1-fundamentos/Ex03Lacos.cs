// Ex03Lacos.cs
// tempo: 20 min

public static class Ex03Lacos
{
    static void ImprimirCompetencias()
    {
        int inicioCompetencia = 1;
        int fimCompetencia = 12;
        int ano = 2026;

        for (int i = inicioCompetencia; i <= fimCompetencia; i++)
        {
            Console.WriteLine($"{i:00}/{ano}");
        }
    }

    static void ImprimirEstatisticasDeHoras()
    {
        int[] horas = [8, 6, 9, 4, 7];
        int totalHoras = 0;
        int maiorValor = horas[0];

        foreach (var hora in horas)
        {
            totalHoras += hora;

            if (maiorValor < hora)
                maiorValor = hora;
        }

        decimal media = (decimal)totalHoras / horas.Length;

        Console.WriteLine($"Soma: {totalHoras} | Maior: {maiorValor} | Média: {media}");
    }

    static void ImprimirTempoParaDobrar()
    {
        decimal saldoAtual = 1_000m;
        decimal valorAlvo = 2_000m;
        decimal taxa = 0.01m;
        int qtdMeses = 0;

        while (saldoAtual < valorAlvo)
        {
            qtdMeses++;
            saldoAtual += saldoAtual * taxa;
        }
        Console.WriteLine($"Meses para dobrar: {qtdMeses}");
    }

    public static void Executar()
    {
        /*
            T1: Usamos o 'while' no item 3 porque o número exato de repetições (meses) é desconhecido
            no início; o laço depende de uma condição de parada (atingir 2.000). Usamos o 'foreach'
            no item 2 porque a intenção é ler todos os itens da lista, o que é mais legível e evita
            erros de índice (IndexOutOfRangeException) em comparação de usar um 'for' manualmente.
        */

        ImprimirCompetencias();
        ImprimirEstatisticasDeHoras();
        ImprimirTempoParaDobrar();
    }
}

