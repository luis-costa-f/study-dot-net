using static Dados;

public static class Ex06Classes
{
    public static void Executar()
    {
        foreach (var projeto in Projetos())
        {
            Console.WriteLine(projeto);
        }

        try
        {
            _ = new Projeto("", "");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
