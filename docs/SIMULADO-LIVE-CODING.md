# Simulado de live coding — .NET Pleno (domínio: logística)

> Montado em 2026-10-19 a partir de uma vaga de **Desenvolvedor(a) .NET Pleno remoto**. O projeto da vaga é de melhoria contínua em **logística**, então todos os problemas usam o mesmo
> domínio: **entregas**.
>
> Faça cada rodada **depois** da fase indicada no `GUIA-DE-ESTUDOS.md`. Não tem problema refazer a mesma rodada
> várias vezes: na entrevista o que conta é a fluência.

---

## Regras (iguais às de uma entrevista de verdade)

1. **Cronômetro ligado.** Respeite o tempo da rodada. Se acabar, pare e anote até onde chegou.
2. **Fale em voz alta** o que está pensando, mesmo sozinho. Melhor ainda: grave a tela com o áudio (Win + G) e
   assista depois.
3. **Sem IA e sem copiar código pronto.** A documentação da Microsoft pode ser consultada.
4. **Antes de codar, gaste de 2 a 3 minutos** escrevendo as dúvidas e as suposições como comentário no topo do
   arquivo. É isso que você perguntaria ao entrevistador.
5. **Primeiro faça funcionar, depois melhore.** Uma solução simples e completa vale mais que uma elegante pela
   metade.

### Como fazer comigo (Claude como entrevistador)

- Diga *"começar simulado, rodada N"*. Eu apresento o problema como um entrevistador faria e respondo às suas
  perguntas de esclarecimento, sem entregar a solução.
- Durante a rodada, posso fazer as **perguntas de aprofundamento** no meio do caminho, como acontece de verdade.
- Faça cada tentativa numa pasta própria em `simulados/` (ex.: `simulados/rodada-1-2026-10-21/`).
- Ao terminar, diga *"terminei"* e informe a pasta. Eu reviso usando a **rubrica** do final deste arquivo e devolvo
  uma nota por critério, o que um entrevistador elogiaria e o que pesaria contra.

---

## Rodada 1 — Lógica com LINQ (30 min) · fazer após a Fase 1

**Problema.** Uma transportadora precisa de um relatório diário das entregas. Crie um app de console que receba a
lista abaixo e imprima:

1. A quantidade de entregas **atrasadas por transportadora**, da maior para a menor.
   Uma entrega está atrasada quando `DataEntrega > PrazoPrevisto` ou quando **ainda não foi entregue** e o prazo já
   passou (considere "hoje" = `2026-10-19`).
2. O **tempo médio de entrega em dias** por transportadora, só das entregas concluídas.
3. A **cidade com mais entregas canceladas**. Se houver empate, qualquer uma serve, mas diga isso em voz alta.

```csharp
// Dados de exemplo — copie para o seu Program.cs
public enum StatusEntrega { Criada, EmTransito, Entregue, Cancelada }

public record Entrega(
    int Id, string Transportadora, string CidadeDestino, StatusEntrega Status,
    DateTime DataPostagem, DateTime PrazoPrevisto, DateTime? DataEntrega);

var entregas = new List<Entrega>
{
    new(1, "RapidLog",  "Campinas",       StatusEntrega.Entregue,   new(2026,10,01), new(2026,10,05), new(2026,10,04)),
    new(2, "RapidLog",  "Santos",         StatusEntrega.Entregue,   new(2026,10,02), new(2026,10,06), new(2026,10,09)),
    new(3, "CargaSul",  "Curitiba",       StatusEntrega.EmTransito, new(2026,10,10), new(2026,10,15), null),
    new(4, "CargaSul",  "Curitiba",       StatusEntrega.Cancelada,  new(2026,10,11), new(2026,10,16), null),
    new(5, "RapidLog",  "Campinas",       StatusEntrega.Cancelada,  new(2026,10,12), new(2026,10,17), null),
    new(6, "ViaNorte",  "Belo Horizonte", StatusEntrega.Entregue,   new(2026,10,03), new(2026,10,08), new(2026,10,08)),
    new(7, "ViaNorte",  "Belo Horizonte", StatusEntrega.Criada,     new(2026,10,18), new(2026,10,23), null),
    new(8, "CargaSul",  "Florianópolis",  StatusEntrega.Entregue,   new(2026,10,05), new(2026,10,09), new(2026,10,12)),
    new(9, "CargaSul",  "Curitiba",       StatusEntrega.Cancelada,  new(2026,10,13), new(2026,10,18), null),
};
```

**Para você se conferir depois** (não olhe antes):
- Atrasadas, **sem** contar as canceladas → CargaSul 2, RapidLog 1, ViaNorte 0. **Com** as canceladas →
  CargaSul 4, RapidLog 2, ViaNorte 0. Uma entrega cancelada conta como atrasada? Essa é justamente a pergunta que
  você deveria ter feito ao entrevistador; anote qual suposição você escolheu.
- Tempo médio → RapidLog 5 dias, ViaNorte 5 dias, CargaSul 7 dias.
- Mais canceladas → Curitiba (2).

**Perguntas de aprofundamento que podem aparecer:**
- Por que você usou `record` e não `class`? (aqui o `record` já veio pronto, mas saiba explicar)
- Se fossem 10 milhões de entregas vindas do banco, o que mudaria? (`IQueryable` x `IEnumerable`, filtrar no
  SQL e não em memória)
- Como você testaria a regra de "atrasada" sem depender da data de hoje? (injetar a data ou um `TimeProvider`)

---

## Rodada 2 — API REST com regra de negócio (45 min) · fazer após a Fase 3 (ideal: Fase 4)

**Problema.** Crie uma Web API em **.NET 8** (`dotnet new webapi -n Entregas.Api -f net8.0`) com:

| Verbo | Rota | Comportamento |
|---|---|---|
| `POST` | `/entregas` | Cria uma entrega com status `Criada`. Valida: transportadora e cidade obrigatórias; prazo maior que a data de postagem. |
| `GET` | `/entregas/{id}` | Retorna a entrega, ou **404**. |
| `GET` | `/entregas?status=EmTransito` | Lista as entregas, com filtro opcional por status. |
| `PATCH` | `/entregas/{id}/status` | Muda o status seguindo a **máquina de estados** abaixo. |

Máquina de estados (no Mendix seria um Exclusive Split com validação no `ACT_`):

```
Criada ──► EmTransito ──► Entregue
  │
  └──► Cancelada        (só é possível cancelar a partir de Criada)
```

- Transição inválida → **409 Conflict** (ou 400, desde que você saiba justificar a escolha) com uma mensagem clara.
- Ao mudar para `Entregue`, preencha `DataEntrega` automaticamente.
- A regra de transição deve ficar num **service** ou no próprio domínio, **nunca no controller/endpoint**.
- Comece com uma lista em memória. Se sobrar tempo, troque por EF Core. Na vaga o banco é **SQL Server**:
  `docker run -e ACCEPT_EULA=Y -e MSSQL_SA_PASSWORD=Senha@Forte123 -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest`

**Perguntas de aprofundamento que podem aparecer:**
- Por que 409 e não 400? Por que 201 no POST, e o que vai no header `Location`?
- Qual o tempo de vida (`AddSingleton` / `AddScoped` / `AddTransient`) do seu service, e por quê? E o do `DbContext`?
- **(Pergunta-chave da vaga)** "Quando a entrega virar `Entregue`, outro sistema precisa ser avisado. Como você
  faria com **Service Bus**?" → publicar um evento `EntregaConcluida` numa fila ou tópico; consumidor separado;
  **idempotência** (a mensagem pode chegar duas vezes); dead-letter queue; o problema de salvar no banco e
  publicar a mensagem de forma consistente (padrão **Outbox**).
- "Essa API ficou lenta em produção. Como você investigaria?" → logs estruturados, métricas e traces (DataDog),
  query lenta, N+1, índices.

---

## Rodada 3 — Refatoração + testes (30 min) · fazer após a Fase 2

**Problema.** O código abaixo calcula o frete e "funciona", mas o time quer adicionar novas modalidades sem mexer
num `switch` gigante. Refatore aplicando um **Design Pattern** e escreva **testes xUnit** que garantam que o
comportamento não mudou. Escreva os testes **antes** de refatorar.

```csharp
public class CalculadoraFrete
{
    public decimal Calcular(string modalidade, decimal pesoKg, decimal distanciaKm, bool clienteVip)
    {
        decimal valor = 0;
        if (modalidade == "economica")
        {
            valor = pesoKg * 0.5m + distanciaKm * 0.10m;
        }
        else if (modalidade == "expressa")
        {
            valor = pesoKg * 0.9m + distanciaKm * 0.25m;
            if (distanciaKm > 500) valor += 30;
        }
        else if (modalidade == "agendada")
        {
            valor = pesoKg * 0.7m + distanciaKm * 0.15m + 15;
        }
        else
        {
            throw new Exception("modalidade invalida");
        }

        if (clienteVip) valor = valor * 0.9m;
        if (valor < 20) valor = 20;
        return Math.Round(valor, 2);
    }
}
```

**O que um entrevistador espera ver:**
- Testes de caracterização primeiro: um por modalidade, a regra do VIP, o valor mínimo, a modalidade inválida e a
  borda `distanciaKm = 500` x `501`.
- **Strategy** (uma classe por modalidade atrás de uma interface `IModalidadeFrete`), com a escolha feita por
  dicionário ou por injeção de dependência, e não por `if`.
- `string` mágica → `enum`; `Exception` genérica → `ArgumentException` (ou uma exceção de domínio).
- As regras comuns (VIP e mínimo) num só lugar, e não repetidas em cada estratégia.

**Perguntas de aprofundamento que podem aparecer:**
- Qual princípio SOLID essa refatoração resolve? (aberto/fechado)
- E se o desconto VIP passasse a depender da modalidade? Onde você mexeria?
- Diferença entre teste unitário e teste de integração. Como você testaria a Rodada 2 de ponta a ponta?
  (`WebApplicationFactory`, banco em container com Testcontainers)

---

## Perguntas teóricas rápidas (5 a 10 min, costumam vir antes ou depois do código)

Responda em voz alta em no máximo 1 minuto cada:

- [ ] `class` x `struct` x `record`
- [ ] `IEnumerable` x `IQueryable`
- [ ] O que `async/await` resolve? O que acontece se eu usar `.Result`?
- [ ] `Singleton`, `Scoped` e `Transient`: dê um exemplo de cada
- [ ] SOLID: explique dois princípios com exemplos seus (vale um exemplo do Mendix!)
- [ ] REST: idempotência de GET/PUT/DELETE x POST
- [ ] EF Core: tracking, `AsNoTracking`, N+1, migrations
- [ ] Mensageria: fila x tópico, at-least-once, idempotência, dead-letter
- [ ] Observabilidade: logs x métricas x traces
- [ ] Docker: imagem x container; para que serve o `docker compose`
- [ ] "Me conte um problema difícil que você resolveu" → use um caso real do Atlante Master (ex.: performance de
      queries, regra do AM-925, SSO do AM-637), no formato **situação → o que você fez → resultado**

---

## Rubrica (como eu vou avaliar)

| Critério | 1 — fraco | 3 — ok | 5 — forte |
|---|---|---|---|
| **Entendimento** | começou a codar sem perguntar nada | perguntou o básico | levantou casos de borda e suposições |
| **Comunicação** | silêncio | narrou às vezes | narrou o raciocínio o tempo todo |
| **Solução** | não roda | roda com falhas | roda e cobre as bordas |
| **Qualidade** | tudo num método | nomes ok, alguma separação | responsabilidades claras, sem duplicação |
| **Testes** | nenhum | só o caminho feliz | caminho feliz, bordas e erros |
| **Aprofundamento** | não soube responder | respondeu o básico | respondeu e trouxe trade-offs |

## Histórico dos simulados

| Data | Rodada | Tempo usado | Nota média | O que melhorar |
|---|---|---|---|---|
| | | | | |
