using System;

public class Projeto
{
    public string Nome { get; private set; }
    public string Gerente { get; private set; }
    public StatusProjeto Status { get; set; }

    private decimal _orcamento;
    public decimal Orcamento
    {
        get => _orcamento;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Orcamento), "O orçamento não pode ser negativo.");

            _orcamento = value;
        }
    }

    public Projeto(string nome, string gerente)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do projeto é obrigatório.");

        Nome = nome;
        Gerente = gerente;
    }

    public override string ToString() => $"{Nome} ({Status}) - {Gerente}";
}