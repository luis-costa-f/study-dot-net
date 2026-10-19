// Program.cs — troque o número para rodar outro exercício
var exercicio = 2;

switch (exercicio)
{
    case 1: Ex01Tipos.Executar(); break;
    case 2: Ex02Condicionais.Executar(); break;
    default: Console.WriteLine("Exercício não encontrado"); break;
}