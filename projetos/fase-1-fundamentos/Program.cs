// Program.cs — troque o número para rodar outro exercício
var exercicio = 3;

switch (exercicio)
{
    case 1: Ex01Tipos.Executar(); break;
    case 2: Ex02Condicionais.Executar(); break;
    case 3: Ex03Lacos.Executar(); break;
    default: Console.WriteLine("Exercício não encontrado"); break;
}