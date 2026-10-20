public static class Ex05Enums
{
    static string Descrever(StatusProjeto s)
    {
        return s switch
        {
            StatusProjeto.Planejado => "Planejado",
            StatusProjeto.Ativo => "Ativo",
            StatusProjeto.Suspenso => "Suspenso",
            StatusProjeto.Concluido => "Concluído",
            _ => throw new ArgumentOutOfRangeException(nameof(s), "Status de projeto inválido.")
        };
    }

    static bool TentarLerStatusProjeto(string texto, out StatusProjeto status)
    {
        bool convertido = Enum.TryParse(texto, out status);

        if (convertido && Enum.IsDefined(typeof(StatusProjeto), status) && status.ToString() == texto)
            return true;

        status = default;
        return false;
    }

    static void ImprimirStatusValidado(string texto)
    {
        if (TentarLerStatusProjeto(texto, out StatusProjeto s))
        {
            Console.WriteLine($"\"{texto}\" → {Descrever(s)}");
        }
        else
        {
            Console.WriteLine($"\"{texto}\" → status inexistente");
        }
    }

    public static void Executar()
    {
        foreach (var status in Enum.GetValues<StatusProjeto>())
        {
            Console.WriteLine($"{(int)status} - {Descrever(status)}");
        }

        ImprimirStatusValidado("Suspenso");
        ImprimirStatusValidado("Cancelado");
    }
}
