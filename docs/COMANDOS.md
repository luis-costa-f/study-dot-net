# Comandos básicos — .NET CLI e git

> Cola rápida para quando eu quiser fazer tudo pelo terminal, sem abrir o Visual Studio. Funciona no PowerShell,
> no terminal do VS Code e no Git Bash. Criado em 2026-10-19.

## Conferir o ambiente

```
dotnet --version          # versão do SDK em uso
dotnet --list-sdks        # SDKs instalados
dotnet --list-runtimes    # runtimes instalados (preciso do 8 para projetos net8.0)
dotnet new list           # templates disponíveis (console, webapi, xunit, sln...)
```

## Criar projetos

Sempre a partir da pasta `projetos/`:

```
cd D:\dev\estudos-dotnet\projetos
```

| Para quê | Comando |
|---|---|
| App de console | `dotnet new console -n NomeDoProjeto -o fase-1-nome` |
| Console em **.NET 8** (versão da vaga) | `dotnet new console -n NomeDoProjeto -o fase-1-nome -f net8.0` |
| Web API com controllers | `dotnet new webapi -n Riscos.Api -o fase-3-riscos-api --use-controllers` |
| Web API mínima (Minimal API) | `dotnet new webapi -n Riscos.Api -o fase-3-riscos-api` |
| Biblioteca de classes | `dotnet new classlib -n Riscos.Dominio` |
| Projeto de testes xUnit | `dotnet new xunit -n Riscos.Testes` |
| Solution (`.sln`) | `dotnet new sln -n Riscos` |
| `.gitignore` padrão do .NET | `dotnet new gitignore` |

- `-n` é o **nome** do projeto (vira o nome do `.csproj` e do namespace).
- `-o` é a **pasta** onde ele é criado. Sem `-o`, a pasta ganha o mesmo nome do projeto.
- `-f` é o **framework** (`net8.0`, `net10.0`). Sem `-f`, usa a versão do SDK (10).

## Rodar, compilar e limpar

Dentro da pasta do projeto (onde está o `.csproj`):

| Para quê | Comando |
|---|---|
| Rodar | `dotnet run` |
| Rodar e reiniciar sozinho a cada alteração salva | `dotnet watch run` |
| Rodar um projeto de outra pasta | `dotnet run --project ..\Ola` |
| Passar argumentos para o programa | `dotnet run -- 8` (o que vem depois de `--` vai para o `args`) |
| Só compilar | `dotnet build` |
| Apagar `bin/` e `obj/` (resolve muito erro estranho) | `dotnet clean` |
| Restaurar pacotes | `dotnet restore` (o `build` e o `run` já fazem isso) |

Para parar um programa ou um `dotnet watch`: `Ctrl + C`.

## Solution com vários projetos (Fase 2)

*No Mendix era o app com vários módulos.*

```
mkdir fase-2-riscos
cd fase-2-riscos
dotnet new sln -n Riscos
dotnet new classlib -n Riscos.Dominio
dotnet new xunit -n Riscos.Testes
dotnet sln add Riscos.Dominio Riscos.Testes
dotnet add Riscos.Testes reference Riscos.Dominio     # o projeto de testes enxerga o domínio
dotnet build
```

O `.sln` é o arquivo que o Visual Studio abre: dá para começar no terminal e continuar na IDE.

## Testes

| Para quê | Comando |
|---|---|
| Rodar todos os testes | `dotnet test` |
| Rodar só os testes cujo nome contém um texto | `dotnet test --filter "FullyQualifiedName~Severidade"` |
| Ver o nome de cada teste na saída | `dotnet test --logger "console;verbosity=normal"` |
| Rodar os testes a cada alteração | `dotnet watch test` |

## Pacotes NuGet

*No Mendix era o Marketplace.*

| Para quê | Comando |
|---|---|
| Adicionar um pacote | `dotnet add package Microsoft.EntityFrameworkCore.SqlServer` |
| Adicionar numa versão específica | `dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.11` |
| Listar os pacotes do projeto | `dotnet list package` |
| Ver pacotes desatualizados | `dotnet list package --outdated` |
| Remover um pacote | `dotnet remove package NomeDoPacote` |

## Segredos (Fase 3 em diante)

*No Mendix eram as Constants por ambiente. Aqui o segredo fica **fora** do projeto e fora do git.*

```
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:Padrao" "Server=localhost;Database=estudos;..."
dotnet user-secrets list
```

## Entity Framework Core (Fase 4)

Instalar a ferramenta uma vez na máquina:

```
dotnet tool install --global dotnet-ef
```

| Para quê | Comando |
|---|---|
| Criar uma migration | `dotnet ef migrations add CriarTabelaRiscos` |
| Aplicar no banco | `dotnet ef database update` |
| Desfazer a última migration (se ainda não aplicada) | `dotnet ef migrations remove` |
| Listar as migrations | `dotnet ef migrations list` |

## git do dia a dia

```
git status                        # o que mudou
git add .                         # preparar tudo para o commit
git commit -m "feat: fase 1 - exercício 3 (laços)"
git push                          # enviar para o GitHub
git log --oneline -10             # últimos 10 commits
git diff                          # ver as mudanças antes de dar add
```

Prefixos de commit: `feat:` código novo · `test:` testes · `docs:` guia, diário e README · `fix:` correção ·
`refactor:` melhoria sem mudar o comportamento.

## Quando algo dá errado

| Sintoma | O que fazer |
|---|---|
| `'dotnet' não é reconhecido` | Fechar e abrir o terminal (ou o VS Code) depois de instalar o SDK |
| `Couldn't find a project to run` | Você não está na pasta do `.csproj`: use `cd` ou `--project` |
| `MSB1011: more than one project or solution file` | Há um `.sln` e um `.csproj` na mesma pasta: informe qual, ex.: `dotnet build Riscos.sln` |
| Erro estranho depois de mexer em pacotes ou no `.csproj` | `dotnet clean` e depois `dotnet build` |
| `The current .NET SDK does not support targeting .NET X` | O `-f` pede uma versão maior que o SDK instalado |
| Porta em uso ao rodar uma API | Já existe outra execução aberta: feche com `Ctrl + C` no outro terminal |
