# Estudos .NET — de Mendix para C#

Este é o meu caminho de **desenvolvedor Mendix para desenvolvedor .NET**. Vou refazendo em C# e ASP.NET Core um
sistema parecido com o que já construí em low-code (gestão de projetos, riscos, ações, contratos e relatórios),
sempre ligando cada conceito novo ao que eu já conhecia no Mendix.

- **Duração prevista:** cerca de 4 meses, a partir de 2026-10-19.
- **Primeira vaga-alvo:** Desenvolvedor(a) .NET Pleno, remoto, na Objective. A entrevista é na semana de
  2026-10-19. Faço o que der; se não der certo desta vez, o estudo fica para as próximas.
- **Fontes:** este repositório, a documentação da Microsoft (Microsoft Learn), YouTube e outras plataformas.

## Estrutura

```
estudos-dotnet/
├── README.md                    # este resumo: o que já fiz e o que falta
├── docs/
│   ├── GUIA-DE-ESTUDOS.md       # plano completo, fases 0–8, sprint e diário de estudos
│   ├── SIMULADO-LIVE-CODING.md  # 3 rodadas de live coding, rubrica e histórico
│   ├── SOLID.md                 # teoria + exercícios dos 5 princípios
│   ├── COMANDOS.md              # cola de comandos dotnet e git para o terminal
│   └── PROMPT-TUTOR-IA.md       # prompt para usar o Gemini como tutor de C#/.NET
├── projetos/                    # mini projetos, um por fase (fase-0-ola, fase-1-...)
└── simulados/                   # minhas soluções dos simulados, uma pasta por tentativa
```

- [Guia de estudos](docs/GUIA-DE-ESTUDOS.md)
- [Simulado de live coding](docs/SIMULADO-LIVE-CODING.md)
- [SOLID: teoria e prática](docs/SOLID.md)
- [Comandos básicos (dotnet e git)](docs/COMANDOS.md)
- [Prompt de tutor de C#/.NET para IA](docs/PROMPT-TUTOR-IA.md)
- [Exercícios de validação da Fase 1](projetos/fase-1-fundamentos/EXERCICIOS.md)
- [Como organizar os projetos](projetos/README.md) · [Como organizar os simulados](simulados/README.md)

---

## ✅ O que já foi feito

- [x] Montei o guia de estudos "de Mendix para .NET", com 8 fases e a coluna "No Mendix era..." (2026-10-16).
- [x] Analisei a vaga da Objective e comparei o que ela pede com o guia: .NET 8, SQL Server, Service Bus, DataDog,
      Docker e testes de integração (2026-10-19).
- [x] Criei o simulado de live coding com três rodadas, perguntas teóricas e rubrica (2026-10-19).
- [x] Planejei o sprint da semana da entrevista (2026-10-19).
- [x] Criei o `.gitignore` para .NET e organizei o repositório em `docs/`, `projetos/` e `simulados/`
      (2026-10-19).
- [x] **Fase 0 concluída:** .NET SDK 10, Visual Studio Community, repositório no GitHub e Hello World (2026-10-19).
- [x] **Fase 1, Ex. 1 (tipos e variáveis): ✅ Domina** depois de 7 validações (2026-10-19).
- [x] **Fase 1, Ex. 2 (condicionais): ✅ Domina** depois de 5 validações (2026-10-19).
- [x] **Fase 1, Ex. 3 (laços): ✅ Domina** depois de 5 validações (2026-10-19).
- [x] **Fase 1, Ex. 4 (métodos): ✅ Domina** depois de 3 validações (2026-10-20).
- [x] **Fase 1, Ex. 5 (enums): ✅ Domina** depois de 4 validações (2026-10-20).
- [x] **Fase 1, Ex. 6 (classes): ✅ Domina** depois de 5 validações (2026-10-20).
- [x] **Fase 1, Ex. 7 (coleções sem LINQ): ✅ Domina** depois de 3 validações (2026-10-26).
- [x] **Fase 1, Ex. 8 (LINQ ⭐): ✅ Domina** depois de 3 validações (2026-10-26).

---

## 📊 Progresso e tempo

> Atualizado em **2026-10-26 às 15:25**, depois do Ex. 8. ⚠️ Os tempos gastos até aqui são **tempo de relógio**
> (horários dos arquivos e das validações) e incluem momentos em que eu estava lendo, trabalhando ou almoçando: são um
> **teto**, não o tempo focado. Eu não anoto o tempo: o Claude estima pelos horários de criação e de alteração dos arquivos e das validações.
> Por isso, o número confiável é o saldo de **conteúdo entregue**.

### Calendário: estou adiantado ou atrasado?

Meta: **4 meses**, de 2026-10-19 a **2027-02-19** (123 dias). A trilha soma ~**180h**, então o ritmo necessário é
**~1h30 por dia** (≈10h30 por semana, contando fins de semana).

Comparo duas coisas a cada exercício:
- **Horas investidas:** quanto tempo eu estudei × quanto o calendário pedia até hoje.
- **Conteúdo entregue:** quanto da trilha eu concluí (em horas *previstas*) × quanto o calendário pedia. Esse é o
  saldo que importa: é ele que diz se termino em 4 meses.

| Depois de | Dia | Calendário pedia | Horas investidas (saldo) | Conteúdo entregue (saldo) |
|---|---|---|---|---|
| Fase 0 | 1 (19/10) | 1h30 | 10 min | 1h00 |
| Ex. 1 | 1 (19/10) | 1h30 | 1h45 | 1h20 |
| Ex. 2 | 1 (19/10) | 1h30 | até 2h55 (teto) | 1h40 (+10 min) |
| Ex. 3 | 1 (19/10) | 1h30 | até 4h00 (teto) | 2h05 (+35 min) |
| Ex. 4 | 2 (20/10) | 3h00 até o fim do dia | até 5h05 (teto) | 2h30 (−30 min) |
| Ex. 5 | 2 (20/10) | 3h00 até o fim do dia | até 6h00 (teto) | 2h45 (−15 min) |
| Ex. 6 | 2 (20/10) | 3h00 até o fim do dia | até 6h50 (teto) | 3h15 (+15 min) |
| Ex. 7 | 8 (26/10) | 12h00 até o fim do dia | até 8h00 (teto) | 3h40 (−8h20) |
| **Ex. 8** | **8 (26/10)** | **12h00 até o fim do dia** | **até 11h50 (teto, com almoço)** | **4h15 (−7h45 🔴)** |

*Conteúdo entregue = Fase 0 (1 dia ≈ 1h) + o tempo previsto de cada exercício concluído (Ex. 1–2: 20 min; Ex. 3–4: 25 min; Ex. 5: 15 min; Ex. 6: 30 min; Ex. 7: 25 min; Ex. 8: 35 min).
O planejamento (~1h10) não entra: não é conteúdo da trilha.*

**Leitura:** o saldo que vale é o de **conteúdo: −7h45 em relação ao fim do dia 8**. Até o dia 2 estava +15 min; a
diferença veio dos dias 3 a 7 (21 a 25/10) sem exercício concluído. São ~5 dias do ritmo de 1h30. Ele não depende do tempo gasto, só do que foi
concluído, então não muda com as pausas. As horas investidas e o fator de cada exercício estão superestimados até eu
descontar as pausas (o Claude estima pelo relógio).

### Exercícios: previsto × gasto

| Exercício | Previsto | Gasto (relógio, teto) | Fator (teto) | Validações |
|---|---|---|---|---|
| Ex. 1 — Tipos | 20 min | ~1h35 (20 min de código + 1h15 de correções) | 4,8× | 7 |
| Ex. 2 — Condicionais | 20 min | ~1h10 (35 min de código + 35 min de correções) | 3,5× | 5 |
| Ex. 3 — Laços | 25 min | ~1h05 (15:43 → 16:50) | 2,6× | 5 |
| Ex. 4 — Métodos | 25 min | ~1h05 (14:06 → 15:12) | 2,6× | 3 |
| Ex. 5 — Enums | 15 min | ~55 min (15:15 → 16:11) | 3,7× | 4 |
| Ex. 6 — Classes | 30 min | ~50 min (16:15 → 17:06) | 1,7× | 5 |
| Ex. 7 — Coleções sem LINQ | 25 min | ~1h10 (10:07 → 11:18) | 2,8× | 3 |
| Ex. 8 — LINQ ⭐ | 35 min | até ~3h50 (11:32 → 15:20, **com almoço**) | até 6,6× | 3 |
| **Total** | **195 min** | **até ~11h40** | **até 3,6×** | |

- **A tendência é boa:** 4,8× → 3,5× → 2,6× → 2,6× → 3,7× → 1,7× → 2,8× → (Ex. 8 sem dado confiável: o relógio inclui o almoço) e 7 → 5 → 5 → 3 → 4 → 5 → 3 → **3** validações (o número de validações é exato; o tempo, não). O Ex. 5 subiu porque o previsto era curto (15 min) e o
  `TryParse` escondia um caso de borda. O Ex. 6 foi o **primeiro abaixo da meta de 2×**. A meta continua sendo **no máximo 2×** por exercício.
- **O que falta na Fase 1 de fundamentos:** Ex. 9 (20 min) e Ex. 10 (30 min cronometrados), ~50 min previstos.
- **Onde o tempo vai:** no Ex. 1, formatação e detalhes; no Ex. 2, lógica e nomes; no Ex. 3, nomes (C3 e C4 levaram 4 das 5 rodadas); no Ex. 4, formatação (o C5 levou a última rodada sozinho); no Ex. 5, caso de borda do `TryParse` e depois
  formatação (2 rodadas só para linhas em branco e comentários); no Ex. 6, o construtor da
  `ArgumentOutOfRangeException` e depois 3 rodadas para o espaço em `"Ana") {`; no Ex. 7, a regressão da moeda
  (C1 do Ex. 1) e a teoria reescrita com as próprias palavras; no Ex. 8, a teoria
  com as próprias palavras de novo e números de linha que deixaram de bater depois das correções. O checklist "Antes de pedir
  validação" do `EXERCICIOS.md` corta a maior parte das rodadas extras.

### Visão geral

| Escopo | Previsto | Gasto | Progresso |
|---|---|---|---|
| **Trilha completa** (Fases 0–8) | ~180h (21–24 semanas a 8h, ou 4 meses a ~10h30) | ~11h50 (teto) | **~2%** · prazo: 2027-02-19 |
| **Fase 0** | 1 dia | ~10 min (+ instalações) | ✅ 100% |
| **Fase 1** | 3–4 semanas ≈ 24–32h · até ~2026-11-07 no ritmo de 4 meses (28h ÷ 10h30 por semana) | ~11h40 (teto) | 8 de 10 exercícios de fundamentos · 0 de 6 do domínio |
| **Sprint da entrevista** (Ex. 1–5 até terça) | 1h45 previstas | 5 de 5 feitos (Ex. 4–5 na terça) | ✅ concluído no prazo |

**Para manter os 4 meses:** ~1h30 por dia em média. Com 8h por semana, a trilha termina por volta de
**março/abril de 2027** (21–24 semanas). Nenhum dos dois está errado; é uma escolha de ritmo.

---

## 🎯 Sprint da entrevista (semana de 2026-10-19)

- [ ] **Seg 19:** currículo enviado, .NET SDK instalado, repositório no GitHub e `dotnet run` funcionando
      → SDK ✅ · GitHub ✅ · `dotnet run` ✅ · **currículo e inscrição ainda pendentes**
- [x] **Ter 20:** C# básico (tipos, `if`, laços, métodos, classes, `enum`)
      → Ex. 1 (tipos), Ex. 2 (condicionais) e Ex. 3 (laços) ✅ na segunda; Ex. 4 (métodos), Ex. 5 (enums) e Ex. 6 (classes) ✅ na terça
- [ ] **Qua 21:** `List`, **LINQ** e `record`, mais a **Rodada 1** do simulado (1ª tentativa)
- [ ] **Qui 22:** primeira Web API em .NET 8 com GET e POST no Swagger
- [ ] **Sex 23:** perguntas teóricas em voz alta, história "de Mendix para .NET" e Rodada 1 (2ª tentativa)
- [ ] **Fim de semana:** primeiros testes com xUnit e leitura da Rodada 3 (pattern Strategy)

## 🗺️ Trilha completa (cerca de 4 meses)

- [x] **Fase 0 — Máquina pronta** (1 dia): SDK, editor, git e GitHub (concluída em 2026-10-19)
- [ ] **Fase 1 — C# básico** (3–4 sem.): tipos, classes, coleções, LINQ, exceções e `async`
- [ ] **Fase 2 — Organização e testes** (2 sem.): solution com vários projetos, NuGet e xUnit
- [ ] **SOLID** (junto com a Fase 2): teoria dos 5 princípios, 5 exercícios e as perguntas de entrevista
- [ ] **Fase 3 — Web API** (3 sem.): endpoints, DTOs, injeção de dependência, validação e Swagger
- [ ] **Fase 4 — Banco de dados** (3–4 sem.): EF Core, migrations, relacionamentos e o problema N+1.
      Fazer com PostgreSQL **e** com SQL Server
- [ ] **Fase 5 — Autenticação e permissões** (2–3 sem.): Identity, JWT, login com Google e perfis
- [ ] **Fase 6 — Front-end** (4 sem.): Blazor ou React
- [ ] **Fase 7 — Agendamentos e integrações** (2 sem.): `BackgroundService`, `HttpClient`, Polly e logs.
      Extra da vaga: mensageria com Service Bus e observabilidade
- [ ] **Fase 8 — Docker, CI e deploy** (2 sem.): `docker compose`, GitHub Actions e deploy opcional
- [ ] **Projeto final de portfólio:** "Gestão de Projetos" com dados fictícios, relatório em PDF, dashboard e um
      README caprichado

## 🧪 Simulados de live coding

- [ ] Rodada 1: lógica com LINQ (30 min)
- [ ] Rodada 3: refatoração + testes (30 min)
- [ ] Rodada 2: API REST com máquina de estados (45 min)
- [ ] Média 4 ou mais na rubrica em todas as rodadas

## 💼 Preparação para vagas

- [ ] Inscrição na vaga da Objective
- [ ] Currículo ajustado para vagas .NET
- [ ] História "de Mendix para .NET" pronta para contar em entrevista
- [ ] LinkedIn e GitHub atualizados
- [ ] (Opcional) Certificação AZ-204

---

## Como uso este repositório

1. Um commit por dia de estudo, mesmo que pequeno.
2. Marco os `[x]` aqui e no guia conforme avanço e anoto o dia no **Diário de estudos**, com o tempo da sessão.
3. Eu escrevo o código; uso IA para explicar, revisar e destravar, não para gerar tudo pronto.
4. Uso só dados **fictícios**, nada de dados de empresas ou clientes reais.
