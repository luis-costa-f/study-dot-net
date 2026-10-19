# SOLID — teoria e prática

> Área dedicada ao SOLID, criada em 2026-10-19. Entra na **Fase 2** do [guia](GUIA-DE-ESTUDOS.md), mas pode ser
> estudada aos poucos desde a Fase 1. Cada princípio tem: **a ideia em uma frase**, **como era no Mendix**, um
> exemplo **ruim → bom** em C# e um **exercício** para você fazer.
>
> As soluções dos exercícios ficam em `projetos/fase-2-solid/` (uma pasta por exercício).

## Por que isso importa

SOLID são cinco princípios para escrever código **fácil de mudar sem quebrar**. Em entrevista, ninguém quer a
definição decorada: querem que você **reconheça o problema num código** e explique **o que mudaria e por quê**. Você
já viveu os problemas que o SOLID resolve no Mendix: microflows gigantes, splits repetidos em vários lugares e
integrações difíceis de testar. Use esses casos como exemplo nas respostas.

| Letra | Princípio | Em uma frase |
|---|---|---|
| **S** | Single Responsibility (responsabilidade única) | Uma classe deve ter **um só motivo para mudar**. |
| **O** | Open/Closed (aberto/fechado) | Dá para **acrescentar** comportamento novo **sem editar** o que já funciona. |
| **L** | Liskov Substitution (substituição de Liskov) | Uma classe filha deve poder **substituir a mãe** sem surpresas. |
| **I** | Interface Segregation (segregação de interfaces) | Prefira **interfaces pequenas** a uma interface que obriga a implementar o que não se usa. |
| **D** | Dependency Inversion (inversão de dependência) | Regras de negócio dependem de **abstrações** (interfaces), não de detalhes (banco, HTTP, e-mail). |

---

## S — Single Responsibility

**No Mendix era...** aquele `ACT_Risco_Salvar` que valida, calcula a severidade, faz o commit, grava o histórico e
manda e-mail, tudo no mesmo microflow. Qualquer mudança no e-mail obriga a mexer no microflow de salvar. A
solução no Mendix era quebrar em `SUB_`; no C#, em classes.

```csharp
// ❌ Ruim: quatro motivos para mudar (regra, persistência, histórico, notificação)
public class RiscoService
{
    public void Salvar(Risco risco)
    {
        if (string.IsNullOrWhiteSpace(risco.Descricao)) throw new ArgumentException("Descrição obrigatória");
        risco.Severidade = risco.Impacto * risco.Probabilidade;
        using var conexao = new SqlConnection("Server=...;"); // acesso a banco direto
        // INSERT ...
        File.AppendAllText("historico.txt", $"{DateTime.Now}: risco {risco.Id} salvo");
        new SmtpClient("smtp.empresa.com").Send("app@empresa.com", risco.EmailGerente, "Risco salvo", "...");
    }
}
```

```csharp
// ✅ Melhor: cada classe com uma responsabilidade; o service só orquestra
public class RiscoService(IRiscoValidador validador, IRiscoRepositorio repositorio,
                          IHistoricoRisco historico, INotificador notificador)
{
    public void Salvar(Risco risco)
    {
        validador.Validar(risco);
        risco.CalcularSeveridade();          // regra do próprio domínio
        repositorio.Salvar(risco);
        historico.Registrar(risco);
        notificador.RiscoSalvo(risco);
    }
}
```

**Atenção:** SRP não significa "uma classe com um método só". Significa agrupar o que muda junto e separar o que
muda por motivos diferentes.

---

## O — Open/Closed

**No Mendix era...** o Exclusive Split por enumeração repetido em vários microflows. Cada valor novo no enum
obrigava a caçar e editar todos os splits, e sempre faltava um.

```csharp
// ❌ Ruim: cada tipo novo de risco exige editar este método (e todos os outros switch parecidos)
public decimal CalcularReserva(Risco risco) => risco.Tipo switch
{
    TipoRisco.Financeiro  => risco.ValorExposto * 0.10m,
    TipoRisco.Prazo       => risco.DiasAtraso * 500m,
    TipoRisco.Tecnico     => 2_000m,
    _ => throw new ArgumentOutOfRangeException(nameof(risco.Tipo))
};
```

```csharp
// ✅ Melhor: um tipo novo = uma classe nova; nenhum código existente é editado
public interface IRegraReserva
{
    TipoRisco Tipo { get; }
    decimal Calcular(Risco risco);
}

public class ReservaFinanceira : IRegraReserva
{
    public TipoRisco Tipo => TipoRisco.Financeiro;
    public decimal Calcular(Risco risco) => risco.ValorExposto * 0.10m;
}

public class CalculadoraReserva(IEnumerable<IRegraReserva> regras)
{
    private readonly Dictionary<TipoRisco, IRegraReserva> _regras = regras.ToDictionary(r => r.Tipo);

    public decimal Calcular(Risco risco) =>
        _regras.TryGetValue(risco.Tipo, out var regra)
            ? regra.Calcular(risco)
            : throw new InvalidOperationException($"Sem regra de reserva para {risco.Tipo}");
}
```

Esse é o pattern **Strategy**, o mesmo da **Rodada 3** do [simulado](SIMULADO-LIVE-CODING.md).

**Atenção:** um `switch` pequeno, num lugar só e que quase nunca muda, **não é problema**. O OCP vale a pena
quando o mesmo `switch` se repete ou cresce o tempo todo. Dizer isso em entrevista mostra maturidade.

---

## L — Liskov Substitution

**No Mendix era...** a especialização (generalização) de entidade. Se `Documento` herda de `System.FileDocument`,
todo lugar que espera um `FileDocument` precisa continuar funcionando com um `Documento`.

```csharp
// ❌ Ruim: a filha "não serve" para o que a mãe promete
public class Entrega
{
    public virtual DateTime CalcularPrevisao(DateTime postagem) => postagem.AddDays(5);
}

public class RetiradaNaLoja : Entrega
{
    public override DateTime CalcularPrevisao(DateTime postagem) =>
        throw new NotSupportedException("Retirada não tem previsão"); // quem usa Entrega quebra aqui
}
```

```csharp
// ✅ Melhor: só herda quem cumpre o contrato; o que é diferente vira outra abstração
public abstract class Pedido { public int Id { get; init; } }

public interface IComPrevisao { DateTime CalcularPrevisao(DateTime postagem); }

public class Entrega : Pedido, IComPrevisao
{
    public DateTime CalcularPrevisao(DateTime postagem) => postagem.AddDays(5);
}

public class RetiradaNaLoja : Pedido { } // não promete previsão, então não pode quebrar ninguém
```

**Sinais de violação:** `throw new NotSupportedException()` num `override`, `if (x is TipoFilho)` espalhado pelo
código, ou uma filha que **exige mais** (aceita menos entradas) ou **entrega menos** (devolve menos) do que a mãe.
O exemplo clássico dos livros é o do Quadrado que herda de Retângulo; vale conhecer.

---

## I — Interface Segregation

**No Mendix era...** o perfil de **Auditor** do AM-948: ele só podia **ler**, mas as telas e microflows tinham sido
feitos pensando em quem edita, e foi preciso tirar permissão em vários lugares. Com interfaces separadas, quem só lê
nem recebe os métodos de escrita.

```csharp
// ❌ Ruim: quem só precisa consultar é obrigado a "implementar" escrita
public interface IRiscoRepositorio
{
    Risco? ObterPorId(int id);
    IReadOnlyList<Risco> Listar();
    void Salvar(Risco risco);
    void Excluir(int id);
    byte[] ExportarPdf();
}

public class RiscoRepositorioAuditoria : IRiscoRepositorio
{
    // ... ObterPorId e Listar implementados ...
    public void Salvar(Risco risco) => throw new NotSupportedException(); // cheiro de ISP (e de LSP)
    public void Excluir(int id) => throw new NotSupportedException();
    public byte[] ExportarPdf() => throw new NotSupportedException();
}
```

```csharp
// ✅ Melhor: cada consumidor depende só do que usa
public interface IConsultaRiscos
{
    Risco? ObterPorId(int id);
    IReadOnlyList<Risco> Listar();
}

public interface IEdicaoRiscos
{
    void Salvar(Risco risco);
    void Excluir(int id);
}

public interface IExportacaoRiscos { byte[] ExportarPdf(); }

// A classe concreta pode implementar várias; quem a usa enxerga só a que precisa
public class RiscoRepositorio : IConsultaRiscos, IEdicaoRiscos { /* ... */ }
```

---

## D — Dependency Inversion

**No Mendix era...** o microflow que chama o REST do **TOTVS** ou do **Minerva** direto, no meio da regra de
negócio. Para testar a regra era preciso o serviço externo no ar, e trocar de fornecedor significava mexer na regra.

```csharp
// ❌ Ruim: a regra de negócio cria e depende do detalhe (HttpClient, URL, formato do TOTVS)
public class SincronizacaoColaboradores
{
    public async Task Executar()
    {
        var http = new HttpClient();
        var json = await http.GetStringAsync("https://totvs.empresa.com/api/colaboradores");
        // desserializa, compara, grava...
    }
}
```

```csharp
// ✅ Melhor: a regra depende de uma interface; o detalhe é injetado
public interface IFonteColaboradores
{
    Task<IReadOnlyList<Colaborador>> ObterAtivosAsync(CancellationToken ct);
}

public class SincronizacaoColaboradores(IFonteColaboradores fonte, IColaboradorRepositorio repositorio)
{
    public async Task Executar(CancellationToken ct)
    {
        var ativos = await fonte.ObterAtivosAsync(ct);
        // compara e grava — testável com uma fonte falsa, sem rede
    }
}

// Program.cs — no Mendix isso era automático; aqui você registra quem implementa o quê
builder.Services.AddHttpClient<IFonteColaboradores, FonteColaboradoresTotvs>();
builder.Services.AddScoped<SincronizacaoColaboradores>();
```

**Não confunda:** *Dependency Inversion* é o **princípio** (depender de abstrações). *Dependency Injection* é a
**técnica** (receber as dependências pelo construtor). O contêiner de DI do ASP.NET Core é a **ferramenta**.
Essa diferença cai muito em entrevista.

---

## Prática

Crie cada exercício em `projetos/fase-2-solid/` com um projeto de testes xUnit ao lado. **Escreva os testes antes de
refatorar**: eles provam que o comportamento não mudou. Leve a solução para revisão dizendo
*"revisa o exercício SOLID N"*.

- [ ] **Exercício 1 — S.** Pegue o `RiscoService` ❌ do exemplo S e separe as responsabilidades. Troque banco,
      arquivo e e-mail por implementações **em memória** (ex.: `RiscoRepositorioEmMemoria`). Teste: salvar um risco
      válido grava o histórico e dispara uma notificação; um risco inválido não grava nada.
- [ ] **Exercício 2 — O.** Implemente as três regras de reserva do exemplo O e depois **acrescente** um
      `TipoRisco.Reputacional` (reserva fixa de 5.000) **sem editar** nenhuma classe existente, só registrando uma
      nova. Teste: um caso por tipo e o erro para um tipo sem regra.
- [ ] **Exercício 3 — L.** Escreva um método `ListarPrevisoes(IEnumerable<Entrega> entregas)` usando a versão ❌ e
      veja o teste quebrar com uma `RetiradaNaLoja` na lista. Depois corrija o modelo e explique, num comentário,
      por que quebrava.
- [ ] **Exercício 4 — I.** Crie um `RelatorioAuditoriaService` que recebe só `IConsultaRiscos`. Mostre que é
      **impossível**, pelo compilador, ele chamar `Excluir`. É o AM-948 resolvido em tempo de compilação.
- [ ] **Exercício 5 — D.** Implemente a `SincronizacaoColaboradores` ✅ com uma `FonteColaboradoresFalsa` nos
      testes (sem rede). Teste: colaborador novo é inserido; colaborador que sumiu da fonte é inativado.
- [ ] **Desafio final.** Faça a **Rodada 3** do [simulado](SIMULADO-LIVE-CODING.md) (frete) e diga, em voz alta,
      quais princípios a sua solução aplicou.

## Perguntas de entrevista

Responda em voz alta, com no máximo 1 minuto cada, usando **um exemplo seu**:

- [ ] Explique SOLID. Qual princípio você mais aplica no dia a dia?
- [ ] Me dê um exemplo real de violação de SRP que você corrigiu. (o microflow gigante do Mendix serve!)
- [ ] Quando **não** vale a pena aplicar Open/Closed?
- [ ] O que tem de errado em lançar `NotSupportedException` num `override`?
- [ ] Qual a diferença entre Dependency Inversion e Dependency Injection?
- [ ] Como o SOLID ajuda a escrever testes unitários?
- [ ] SOLID demais pode atrapalhar? (sim: interfaces para tudo, classes demais e indireção sem necessidade; o
      objetivo é facilitar a mudança, não seguir regra)

## Para estudar

- Microsoft Learn — *Architectural principles*:
  https://learn.microsoft.com/dotnet/architecture/modern-web-apps-azure/architectural-principles
- Microsoft Learn — *Dependency injection in ASP.NET Core*:
  https://learn.microsoft.com/aspnet/core/fundamentals/dependency-injection
- Refactoring Guru — padrões de projeto com exemplos em C# (Strategy, Factory, Adapter):
  https://refactoring.guru/pt-br/design-patterns/csharp
