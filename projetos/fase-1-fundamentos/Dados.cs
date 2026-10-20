public enum StatusProjeto
{
    Planejado = 0,
    Ativo = 1,
    Suspenso = 2,
    Concluido = 3
}

public static class Dados
{
    public static List<Projeto> Projetos()
    {
        return
        [
            new Projeto("Portal RH", "Ana") { Status = StatusProjeto.Ativo, Orcamento = 150_000m },
            new Projeto("App Logística", "Bruno") { Status = StatusProjeto.Ativo, Orcamento = 320_000m },
            new Projeto("BI Financeiro", "Ana") { Status = StatusProjeto.Concluido, Orcamento = 90_000m },
            new Projeto("Migração ERP", "Carla") { Status = StatusProjeto.Suspenso, Orcamento = 500_000m },
            new Projeto("Site Institucional", "Bruno") { Status = StatusProjeto.Concluido, Orcamento = 40_000m },
            new Projeto("Chatbot Atendimento", "Ana") { Status = StatusProjeto.Ativo, Orcamento = 75_000m }
        ];
    }
}