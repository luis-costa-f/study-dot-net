// Ex02Condicionais.cs
// tempo: 20 min

public static class Ex02Condicionais
{

    static string ClassificarComIf(int peso)
    {
        if (peso >= 1 && peso <= 4)
            return "Baixo";
        else if (peso >= 5 && peso <= 12)
            return "Médio";
        else if (peso >= 13 && peso <= 25)
            return "Alto";
        else
            return "Valor não esperado pelo sistema";
    }

    static string ClassificarComSwitch(int peso)
    {
        return peso switch
        {
            >= 1 and <= 4 => "Baixo",
            >= 5 and <= 12 => "Médio",
            >= 13 and <= 25 => "Alto",
            _ => "Valor não esperado pelo sistema"
        };
    }

    static void ImprimirClassificacao(int impacto, int probabilidade, Func<int, string> classificador)
    {
        int peso;
        if (impacto < 1 || impacto > 5 || probabilidade < 1 || probabilidade > 5)
            Console.WriteLine($"{impacto} x {probabilidade} → Valor inválido");
        else
        {
            peso = impacto * probabilidade;
            Console.WriteLine($"{impacto} x {probabilidade} = {peso} → {classificador(peso)}");
        }
    }

    public static void Executar()
    {
        /*
            T1: Validamos antes para evitar falsos positivos. Por exemplo, um impacto -1 e probabilidade -3 resultam num peso 3 (risco Baixo), mascarando o erro nos dados de entrada.
            T2: O switch expression foi desenhado para mapear e retornar valores diretamente. O if / else é estrutural e deve ser usado para executar ações ou lógicas complexas.
        */
        Console.WriteLine("Com if:");
        ImprimirClassificacao(1, 3, ClassificarComIf);
        ImprimirClassificacao(2, 3, ClassificarComIf);
        ImprimirClassificacao(3, 4, ClassificarComIf);
        ImprimirClassificacao(5, 5, ClassificarComIf);
        ImprimirClassificacao(0, 3, ClassificarComIf);
        Console.WriteLine("Com switch:");
        ImprimirClassificacao(1, 3, ClassificarComSwitch);
        ImprimirClassificacao(2, 3, ClassificarComSwitch);
        ImprimirClassificacao(3, 4, ClassificarComSwitch);
        ImprimirClassificacao(5, 5, ClassificarComSwitch);
        ImprimirClassificacao(0, 3, ClassificarComSwitch);
    }
}

