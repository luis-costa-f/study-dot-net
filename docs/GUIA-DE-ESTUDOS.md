# Guia de estudos — de Mendix para .NET

> Objetivo: aprender C# e ASP.NET Core do zero refazendo, em código, um sistema parecido com o Atlante Master
> (projetos, riscos, ações, contratos, RDP). Ao final, você terá um projeto completo no seu GitHub para mostrar em
> entrevistas.
>
> Criado em 2026-10-16. Marque `[x]` conforme avançar.

---

## Como usar este guia

- **Uma fase por vez.** Cada fase termina com algo funcionando. Não pule para a próxima sem o "checkpoint".
- **Ritmo sugerido:** 1h por dia nos dias úteis + 3h no fim de semana ≈ 8h/semana. O guia todo leva de
  **4 a 6 meses** nesse ritmo. Não tem problema demorar mais.
- **Escreva o código você mesmo.** Use o Claude para explicar, revisar e destravar — não para gerar tudo pronto.
  Uma boa forma de pedir: *"me explique X como se eu fosse iniciante e me dê um exercício"* ou *"revise meu código
  e me diga o que um sênior mudaria"*.
- **Faça commit todo dia** no git, mesmo que pouco. Isso também vira histórico no seu GitHub.
- A coluna **"No Mendix era..."** liga cada conceito novo ao que você já sabe. Você não está começando do zero:
  já entende entidades, associações, regras, permissões e telas — só falta a sintaxe e as ferramentas.

---

## Sprint da entrevista — semana de 2026-10-19

> O guia completo leva uns 4 meses. Esta semana o objetivo é outro: chegar na entrevista da Objective sabendo
> **falar** sobre .NET e conseguindo resolver a **Rodada 1** do simulado. Se não der certo desta vez, nada se perde:
> tudo daqui faz parte das Fases 0 a 3.
>
> Lembre que as etapas do processo são inscrição → fit cultural → técnica com live coding. A primeira conversa
> costuma ser o **fit cultural**, e a parte técnica tende a vir alguns dias depois.

| Dia | Foco | Entregável |
|---|---|---|
| **Seg 19** | Inscrição + Fase 0 | Currículo enviado; SDK instalado; repositório no GitHub; `dotnet run` funcionando |
| **Ter 20** | Fase 1: tipos, `if`, laços, métodos, classes, `enum` | Exercícios do `Risco`/`Acao` em console |
| **Qua 21** | Fase 1: `List`, **LINQ**, `record`, nullable | Regra do AM-925 com LINQ; **Rodada 1** do simulado (1ª tentativa) |
| **Qui 22** | Fase 3 (relâmpago): `dotnet new webapi -f net8.0`, endpoints, DI, códigos HTTP | Um GET e um POST de entregas no Swagger |
| **Sex 23** | Teoria + história | Perguntas teóricas em voz alta; história "de Mendix para .NET"; Rodada 1 (2ª tentativa) |
| **Fim de semana** | Fase 2: xUnit | Testes para a regra do AM-925; ler a Rodada 3 e entender o pattern Strategy |

Prioridade se faltar tempo: **inscrição → Fase 0 → LINQ → Rodada 1 → perguntas teóricas → história Mendix → API**.

---

## Fase 0 — Preparar a máquina (1 dia)

| Ferramenta | Para quê | Status na sua máquina |
|---|---|---|
| **.NET 10 SDK** | compilar e rodar C# | ✅ 10.0.402 (instalado em 2026-10-19; o runtime 8 também está instalado, para projetos `net8.0`) |
| **Visual Studio 2022 Community** ou **VS Code + C# Dev Kit** | editor | VS Code instalado |
| **git** | versionamento | ✅ 2.49 |
| **Docker Desktop** | rodar o PostgreSQL | ✅ 29.6 |
| **Node.js** | só se escolher React na fase 7 | ✅ 24 |
| **PostgreSQL + pgAdmin** | banco de dados | ✅ você já usa |

- [x] Instalar o .NET 10 SDK: https://dotnet.microsoft.com/download (ou `winget install Microsoft.DotNet.SDK.10`).
- [x] Conferir: `dotnet --list-sdks` deve mostrar uma versão `10.x`.
- [x] No VS Code, instalar a extensão **C# Dev Kit**. (Se preferir uma IDE completa, o **Visual Studio 2022
      Community** é gratuito e muito usado nas empresas .NET.) → escolhido: **Visual Studio Community** (2026-10-19).
- [x] Criar uma conta no GitHub (se ainda não tiver) e um repositório `estudos-dotnet`.
      → https://github.com/luis-costa-f/study-dot-net (2026-10-19).

**Checkpoint:** `dotnet new console -n Ola` → `cd Ola` → `dotnet run` imprime "Hello, World!".
✅ **Fase 0 concluída em 2026-10-19** (`projetos/Ola`). Comandos do dia a dia em [`COMANDOS.md`](COMANDOS.md).

---

## Fase 1 — C# básico (3 a 4 semanas)

| Conceito | No Mendix era... |
|---|---|
| Variáveis e tipos (`int`, `decimal`, `string`, `bool`, `DateTime`) | tipos de atributo (Integer, Decimal, String, Boolean, Date and time) |
| `if` / `else`, `switch` | Exclusive Split (decisão) |
| `for`, `foreach`, `while` | Loop |
| Métodos (funções) com parâmetros e retorno | Sub-microflow com parâmetros e return |
| `enum` | Enumeration |
| `class`, propriedades, construtor | Entity (não persistente) e seus atributos |
| `List<T>`, `Dictionary<K,V>` | listas de objetos |
| **LINQ** (`Where`, `Select`, `OrderBy`, `Count`, `Any`) | List operations (Filter, Sort, Find) e Aggregate list |
| `null` e `?` (nullable) | `empty` |
| Exceções (`try` / `catch`, `throw`) | Error handling (custom with/without rollback) |
| Interfaces e herança | Generalização de entidade (ex.: herdar de `System.FileDocument`) |
| `async` / `await` | (não tem equivalente direto — chamadas que esperam I/O) |

**Fundamentos com validação:** os 10 exercícios de
[`projetos/fase-1-fundamentos/EXERCICIOS.md`](../projetos/fase-1-fundamentos/EXERCICIOS.md), com saída esperada e
nota (✅ / 🟡 / 🔴) dada na revisão.

**Exercícios do domínio** (console, sem banco, em `projetos/fase-1-riscos-console`):
- [ ] Criar o enum `NaturezaRisco { Positivo, Negativo }` e o enum `StatusRisco` com os status que você conhece.
- [ ] Criar as classes `Risco` e `Acao` (um risco tem uma lista de ações).
- [ ] Escrever o método `bool ExigeAcaoEmAndamento(Risco r)` com a **regra do AM-925**
      (Negativo + Contingência/Mitigação/Transferência).
- [ ] Escrever `bool PodeSalvar(Risco r)` usando LINQ: `r.Acoes.Any(a => a.Status == StatusAcao.EmAndamento)`.
- [ ] Calcular a severidade (peso = impacto × probabilidade → Baixo/Médio/Alto) como no `ACT_Risco_Edit`.
- [ ] Listar no console os riscos ordenados por severidade.

**Estudar:**
- Microsoft Learn — *"Get started with C#"*: https://learn.microsoft.com/dotnet/csharp/tour-of-csharp/
- Microsoft Learn — *LINQ*: https://learn.microsoft.com/dotnet/csharp/linq/

**Checkpoint:** um programa de console que cria 5 riscos fictícios, valida cada um e mostra quais podem ser salvos e
por quê.

---

## Fase 2 — Organização de código e testes (2 semanas)

| Conceito | No Mendix era... |
|---|---|
| **Solution** (`.sln`) com vários **projects** (`.csproj`) | App com vários módulos |
| `namespace` | módulo (`AtlanteMasterMain.`) |
| Pacotes **NuGet** | Marketplace |
| Testes unitários com **xUnit** | (o Mendix não tem; você testava com F6 e clicando) |
| Princípios **SOLID** (teoria e prática em [`SOLID.md`](SOLID.md)) | separar Controller/View, `SUB_` reaproveitáveis |

- [ ] Estudar a teoria do [`SOLID.md`](SOLID.md) e fazer os 5 exercícios em `projetos/fase-2-solid/`.
- [ ] Criar uma solution com dois projetos: `Riscos.Dominio` (classes e regras) e `Riscos.Testes` (xUnit).
- [ ] Escrever testes para a regra do AM-925 — um teste por linha da tabela de testes do
      `docs/AM-925-riscos-aceitos-ou-positivos.md`.
- [ ] Rodar com `dotnet test`.

**Checkpoint:** `dotnet test` passando com pelo menos 6 testes. Você acabou de fazer em segundos o que no Mendix
exigia F6 + 4 cliques por cenário.

---

## Fase 3 — API web com ASP.NET Core (3 semanas)

| Conceito | No Mendix era... |
|---|---|
| **Web API** e **controllers** / **Minimal APIs** | Published REST service |
| Rotas (`GET /riscos/{id}`) e verbos HTTP | operações do REST publicado |
| **DTOs** (objetos de entrada/saída) | entidades não persistentes / mappings |
| **Injeção de dependência** (`builder.Services.Add...`) | (automático no Mendix — chamar um sub-microflow) |
| **Services** (camada de regras) | microflows `ACT_` / `SUB_` |
| `appsettings.json` e **User Secrets** | Constants e Configurations |
| **Swagger / OpenAPI** | documentação do REST publicado |
| Validação (Data Annotations / FluentValidation) | `ACT_Validate_*` |
| Códigos HTTP (200, 201, 400, 404) | mensagens de validação / erro |

- [ ] `dotnet new webapi -n Riscos.Api` e abrir o Swagger no navegador.
- [ ] Endpoints em memória (lista estática): listar, buscar, criar, editar e excluir riscos.
- [ ] Criar um `RiscoService` e injetá-lo no controller.
- [ ] Retornar **400** com a mensagem *"Para o status selecionado, é obrigatório cadastrar ao menos uma ação 'Em
      Andamento'."* quando a regra falhar.
- [ ] Guardar configurações em `appsettings.json` e segredos com `dotnet user-secrets` (é exatamente o que você
      queria para o banco no Mendix: **fora do git**).

**Estudar:** Microsoft Learn — *"Create a web API with ASP.NET Core"*:
https://learn.microsoft.com/aspnet/core/tutorials/first-web-api

**Checkpoint:** CRUD completo de riscos e ações pelo Swagger, com a validação funcionando.

---

## Fase 4 — Banco de dados com Entity Framework Core + PostgreSQL (3 a 4 semanas)

| Conceito | No Mendix era... |
|---|---|
| **DbContext** e **DbSet** | Domain model |
| Entidade com `Id` | Entity persistente (o Mendix cria o ID sozinho) |
| Relacionamento 1-N (`List<Acao>` + `RiscoId`) | Association Reference |
| Relacionamento N-N | Association Reference set |
| **Migrations** (`dotnet ef migrations add`) | sincronização automática do banco no F6 |
| `Include()` | retrieve por associação |
| `Where()` no `IQueryable` | XPath constraint |
| `SaveChanges()` | Commit |
| **Transações** | rollback do microflow |
| Problema **N+1** | *retrieve dentro de loop* (regra M02 da catraca!) |
| `AsNoTracking`, índices | boas práticas de performance (MXP003/007 do Recommender) |

- [ ] Subir o PostgreSQL no Docker (ou usar o seu local na 5432) com um banco novo `estudos_riscos`.
- [ ] Adicionar `Npgsql.EntityFrameworkCore.PostgreSQL` e criar o `AppDbContext`.
- [ ] Connection string em **User Secrets**, nunca no `appsettings.json` versionado.
- [ ] Criar a migration inicial e ver as tabelas no pgAdmin.
- [ ] Trocar a lista em memória da fase 3 pelo banco.
- [ ] Criar a tabela de **histórico** do risco (como o `RiscoHistorico`) gravada a cada edição.
- [ ] Provocar um N+1 de propósito, ver as queries no log e corrigir com `Include`.

**Estudar:** Microsoft Learn — *EF Core*: https://learn.microsoft.com/ef/core/get-started/overview/first-app

**Checkpoint:** a API da fase 3 gravando no PostgreSQL, com histórico, e você consegue explicar o que é uma
migration.

---

## Fase 5 — Autenticação e permissões (2 a 3 semanas)

| Conceito | No Mendix era... |
|---|---|
| **Autenticação** (quem é você) | Login / módulo OIDC / SSO Google |
| **Autorização** (o que pode fazer) | User roles e module roles |
| `[Authorize(Roles = "...")]` / **Policies** | Allowed roles do microflow / página |
| Filtro por usuário nas queries | Entity access com XPath (`[%CurrentUser%]`) |
| **JWT** | sessão do Mendix |
| **ASP.NET Core Identity** | Administration / Account |

- [ ] Login com usuário e senha usando Identity.
- [ ] Login com **Google** (OpenID Connect) — você já conhece o fluxo pelo AM-637/AM-809.
- [ ] Criar os perfis `Admin`, `GerenteProjeto` e `Auditor` (somente leitura).
- [ ] Garantir que o Auditor não consegue criar, editar nem excluir (lembra do AM-948?).

**Checkpoint:** chamadas sem login retornam **401**; Auditor tentando editar retorna **403**.

---

## Fase 6 — Front-end (4 semanas)

Escolha **uma** trilha:

| | **Blazor** (recomendado para começar) | **React** |
|---|---|---|
| Linguagem | C# + Razor | JavaScript/TypeScript |
| Curva | menor — você continua em C# | maior — outra linguagem e ecossistema |
| Mercado | cresce em empresas .NET | muito pedido em vagas full-stack |
| No Mendix era... | páginas, snippets, data views | idem |

Mapeamento de telas:

| Tela .NET | No Mendix era... |
|---|---|
| Página com lista (tabela, filtro, paginação) | `_Overview` com Data Grid 2 |
| Formulário de edição em modal | `_NewEdit` em `PopupLayout` |
| Confirmação de exclusão | `_ConfirmacaoDelete` |
| Componente reutilizável | Snippet |
| CSS / tema | `atlantemasterstyle` + Atlas Core |

- [ ] Tela de lista de riscos com filtro por natureza e status.
- [ ] Modal de novo/editar risco com aba de ações (como `Riscos_Edit`).
- [ ] Mostrar a mensagem de validação vinda da API.
- [ ] Usar como referência visual o **Figma "Novo design"** (dados fictícios) — fase ótima para treinar
      layout.

**Checkpoint:** cadastrar um risco pela tela, do começo ao fim, com login.

---

## Fase 7 — Tarefas agendadas e integrações (2 semanas)

| Conceito | No Mendix era... |
|---|---|
| `BackgroundService` / **Hangfire** / **Quartz** | Scheduled events (`SE_`) |
| `HttpClient` + `IHttpClientFactory` | Call REST service (consumed REST) |
| Desserializar JSON (`System.Text.Json`) | JSON structure + Import mapping (`IM_`) |
| **Polly** (retry, timeout) | error handling customizado (regra M03) |
| **Logging** (`ILogger`, Serilog) | log nodes / Console do Studio Pro |

- [ ] Uma rotina agendada que consome uma API pública fictícia (ex.: JSONPlaceholder) e grava no banco.
- [ ] Tratamento de erro com retry e log quando a API falhar.

**Checkpoint:** a rotina roda sozinha a cada X minutos e você vê os logs.

---

## Fase 8 — Docker, CI e deploy (2 semanas)

| Conceito | No Mendix era... |
|---|---|
| `Dockerfile` e `docker compose` (API + banco) | Run locally / Mendix Cloud |
| **GitHub Actions** (build + testes a cada push) | (não tinha — a catraca de boas práticas é parecida) |
| Variáveis de ambiente por ambiente | Configurations / constants por ambiente |

- [ ] `docker compose up` sobe API + PostgreSQL + front.
- [ ] GitHub Actions rodando `dotnet build` e `dotnet test` em cada push.
- [ ] (Opcional) Publicar no Azure App Service ou Render com plano gratuito.

**Checkpoint:** alguém clona o seu repositório, roda `docker compose up` e o sistema funciona.

---

## Projeto final de portfólio — "Gestão de Projetos" (fictício)

Juntar tudo num sistema só, com dados **fictícios**:

- [ ] Projetos, com status e gerente.
- [ ] Riscos e Ações (fases 1–6).
- [ ] Contratos com vagas e alocação mensal.
- [ ] Um relatório mensal (como o RDP) com indicadores e **export em PDF** (QuestPDF).
- [ ] Dashboard com gráficos.
- [ ] README caprichado: prints, como rodar, arquitetura, decisões técnicas.

---

## Preparação para vagas (em paralelo, a partir da fase 4)

- [ ] **Assuntos que mais caem em entrevista .NET:** diferença entre `class` e `struct`, `IEnumerable` x
      `IQueryable`, `async/await`, ciclo de vida da injeção de dependência (`Singleton`, `Scoped`, `Transient`),
      SOLID, REST, EF Core (tracking, N+1, migrations), SQL (JOIN, GROUP BY, índices), testes unitários, git.
- [ ] **Como contar sua experiência Mendix:** você já trabalhou com modelagem de dados, regras de negócio,
      permissões por perfil, integrações REST, SSO/OIDC, performance de queries e revisão de código. Isso é
      experiência de desenvolvimento real — só muda a ferramenta.
- [ ] LinkedIn e GitHub atualizados com o projeto final.
- [ ] Certificação opcional: **Microsoft Certified: Azure Developer Associate (AZ-204)**, depois de dominar a
      base.

### Simulados de live coding

Estão em [`SIMULADO-LIVE-CODING.md`](SIMULADO-LIVE-CODING.md): três rodadas cronometradas no domínio de logística,
mais perguntas teóricas e uma rubrica. Para fazer comigo, diga *"começar simulado, rodada N"*.

- [ ] **Rodada 1:** lógica com LINQ (30 min), depois da Fase 1.
- [ ] **Rodada 3:** refatoração com Strategy e testes xUnit (30 min), depois da Fase 2.
- [ ] **Rodada 2:** API REST com máquina de estados (45 min), depois da Fase 3, de preferência após a Fase 4.
- [ ] Refazer a rodada que tiver a nota mais baixa até chegar a uma média 4 na rubrica.
- [ ] Responder em voz alta todas as perguntas teóricas rápidas, com no máximo 1 minuto cada.

### Vaga-alvo: Desenvolvedor(a) .NET PL, Objective (inscrição em 2026-10-19)

Vaga em `vagas/links.txt` (posição 1), com o PDF salvo em `vagas/`. Essa pasta fica fora do git. O guia já cobre a base. Os itens abaixo
cobrem o que a vaga pede **além** do guia:

| A vaga pede | Onde entra no guia | O que fazer a mais |
|---|---|---|
| .NET **8** | Fases 1–4 (o guia usa .NET 10) | Criar os projetos com `-f net8.0`; o código é praticamente igual |
| **SQL Server** + EF | Fase 4 (o guia usa PostgreSQL) | Repetir a Fase 4 com SQL Server no Docker: só muda o provider `Microsoft.EntityFrameworkCore.SqlServer` |
| Testes **de integração** | Fase 2 (só unitários) | `WebApplicationFactory` + Testcontainers na API da Fase 4 |
| Microsserviços + **Service Bus** | não tem | Fase 7 extra: a API publica `EntregaConcluida` e um worker consome. Para estudar localmente, use o emulador do Service Bus no Docker (ou o RabbitMQ, só para treinar o conceito) |
| Observabilidade (**DataDog**) | Fase 7 (logging) | Logs estruturados com Serilog + OpenTelemetry; entender a diferença entre logs, métricas e traces |
| Docker | Fase 8 | Antecipar o `docker compose` (API + SQL Server) para logo depois da Fase 4 |
| Diferencial: Azure, KeyCloak, Azure DevOps | Fases 5 e 8 | Opcional: KeyCloak no Docker como provedor OIDC na Fase 5 (é o mesmo fluxo do SSO do Google) |

- [ ] Inscrição feita com o currículo ajustado para a vaga.
- [ ] Preparar a história *"de Mendix para .NET"*: o que você já fazia (modelagem, regras, REST, SSO, performance)
      e o que está estudando, com o link do GitHub.

---

## Diário de estudos

| Data | Fase | O que aprendi | Dúvidas |
|---|---|---|---|
| 2026-10-19 | Planejamento | Vaga da Objective analisada; simulado de live coding e sprint da semana montados | |
| 2026-10-19 | 0 e 1 | Fase 0 concluída (SDK, Visual Studio, GitHub, Hello World). Ex. 1 (tipos) ✅ Domina após 7 validações: divisão inteira, promoção de tipos, `double` × `decimal`, formatação de moeda por cultura, evitar `DateTime.Now` | |
