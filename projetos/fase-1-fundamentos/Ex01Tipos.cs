// Ex01Tipos.cs
// tempo: 20 min
using System.Globalization;

public static class Ex01Tipos
{

    public static void Executar()
    {
        string nome = "Portal RH";
        decimal orcamento = 150_000m;
        int horasPrevistas = 1200;
        bool ativo = true;

        DateTime dataInicio = new DateTime(year: 2026, month: 8, day: 1);
        DateTime hoje = new DateTime(2026, 10, 19);

        Console.WriteLine($"Projeto {nome}, orçamento {orcamento.ToString("C", new CultureInfo("pt-BR"))}, {horasPrevistas} horas, ativo: {ativo}, início: {dataInicio:dd/MM/yyyy}");
        Console.WriteLine($"Dias desde o início: {(hoje - dataInicio).Days}");

        // 7 / 2 (int / int): Quando você divide dois inteiros, o C# faz uma divisão inteira e simplesmente corta o que vem depois da vírgula. O resultado será 3, e não 3.5
        // 7 / 2.0 (int / double): O .0 transforma o número em double. Quando há um double na operação, o C# promove o inteiro para double também, e você tem o resultado com casas decimais (3.5)
        // 7m / 2 (decimal / int): O sufixo m (de money) força o número a ser um decimal. O inteiro é promovido a decimal, e a divisão ocorre com precisão (3.5)
        // 0.1 + 0.2 (double vs decimal): O tipo double é focado em performance e usa cálculos de ponto flutuante em base binária, o que não consegue representar alguns números fracionados perfeitamente. Somar 0.1 + 0.2 vai resultar em uma dízima estranha como 0.30000000000000004. Já o 0.1m + 0.2m usa o tipo decimal (base 10), garantindo a precisão exata de 0.3

        Console.WriteLine($"7 / 2 = {7 / 2} | 7 / 2.0 = {7 / 2.0} | 7m / 2 = {7m / 2}");
        // O risco de usar double é a perda de precisão em frações (base 2), o que acumula erros de arredondamento em grandes somas (sumindo centavos) e faz comparações exatas falharem (0.1 + 0.2 não dará exatamente 0.3).
        // Para dinheiro: use sempre decimal (sufixo m), equivalente ao tipo Decimal do Mendix.
        Console.WriteLine($"0.1 + 0.2 = {0.1 + 0.2} | 0.1m + 0.2m = {0.1m + 0.2m}");
    }
}

