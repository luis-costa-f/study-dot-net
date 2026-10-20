using System.Diagnostics;

public static class Ex04Metodos
{
    static string ClassificarPeso(int peso)
    {
        return peso switch
        {
            >= 1 and <= 4 => "Baixo",
            >= 5 and <= 12 => "Médio",
            >= 13 and <= 25 => "Alto",
            _ => throw new UnreachableException("Não era para você chegar aqui")
        };
    }

    public static string ClassificarSeveridade(int impacto, int probabilidade)
    {
        if (impacto < 1 || impacto > 5)
            throw new ArgumentOutOfRangeException(nameof(impacto), "Impacto deve estar entre 1 e 5.");

        if (probabilidade < 1 || probabilidade > 5)
            throw new ArgumentOutOfRangeException(nameof(probabilidade), "Probabilidade deve estar entre 1 e 5.");

        int peso = impacto * probabilidade;
        return ClassificarPeso(peso);
    }

    static bool TentarLerNota(string texto, out int nota)
    {
        if (int.TryParse(texto, out nota) && nota >= 1 && nota <= 5)
        {
            return true;
        }

        nota = 0;
        return false;
    }

    static void ImprimirResultadoDasNotas(string texto)
    {
        if (TentarLerNota(texto, out int nota))
        {
            Console.WriteLine($"\"{texto}\" → válida: {nota}");
        }
        else
        {
            Console.WriteLine($"\"{texto}\" → inválida");
        }
    }

    public static void Executar()
    {
        try
        {
            string resultado1 = ClassificarSeveridade(5, 4);
            Console.WriteLine(resultado1);
            string resultado2 = ClassificarSeveridade(0, 3);
            Console.WriteLine(resultado2);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        ImprimirResultadoDasNotas("4");
        ImprimirResultadoDasNotas("abc");
        ImprimirResultadoDasNotas("9");
    }
}
