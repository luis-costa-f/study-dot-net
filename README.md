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

---

## 📊 Progresso e tempo

> Atualizado em **2026-10-19 às 11:53**. Os tempos são estimados pelos horários dos commits e dos arquivos e incluem
> pausas. A partir de agora, anoto o tempo real de cada sessão no diário.

### Tempo gasto até agora

| Data | O quê | Tempo |
|---|---|---|
| 2026-10-19 | Planejamento: vaga, guia, simulado, SOLID, organização do repositório | ~1h10 |
| 2026-10-19 | Fase 0: SDK, Visual Studio, GitHub, Hello World | ~10 min |
| 2026-10-19 | Fase 1, Ex. 1: 20 min de código + ~1h15 de correções (7 validações) | ~1h35 |
| | **Total** | **~3h** |

### Tempo gasto × tempo previsto

| Escopo | Previsto | Gasto | Progresso |
|---|---|---|---|
| **Trilha completa** (Fases 0–8, sem o projeto final) | 21–24 semanas × 8h ≈ **170–190h** | ~3h | **~2%** |
| **Fase 0** | 1 dia | ~10 min (+ instalações) | ✅ 100% |
| **Fase 1** | 3–4 semanas × 8h ≈ **24–32h** | ~1h35 | ~5% do tempo · 1 de 10 exercícios de fundamentos e 0 de 6 do domínio |
| **Exercícios de fundamentos** (Ex. 1–10) | **~4h05** somando as estimativas | ~1h35 | 1 de 10 |
| **Ex. 1** | 20 min | ~1h35 | ✅ **4,8× o previsto** |

### O que os números dizem

- **O código em si saiu no tempo** (20 min). O que estourou foram as correções: 6 rodadas por detalhes de
  formatação, um `DateTime.Now` e respostas de teoria incompletas. O checklist "Antes de pedir validação" do
  `EXERCICIOS.md` existe para cortar isso.
- **Meta para os próximos exercícios: no máximo 2× o tempo previsto.** Os Ex. 2–5 somam 85 min previstos: no ritmo
  do Ex. 1 levariam ~6h45; com 2×, ~2h50, o que cabe no plano de terça.
- **"4 meses" é otimista para 8h por semana.** As fases somam 21–24 semanas (~5 a 5,5 meses). Para fechar em
  4 meses, seria preciso estudar ~10–11h por semana. Nenhum dos dois está errado; é uma escolha de ritmo.

---

## 🎯 Sprint da entrevista (semana de 2026-10-19)

- [ ] **Seg 19:** currículo enviado, .NET SDK instalado, repositório no GitHub e `dotnet run` funcionando
      → SDK ✅ · GitHub ✅ · `dotnet run` ✅ · **currículo e inscrição ainda pendentes**
- [ ] **Ter 20:** C# básico (tipos, `if`, laços, métodos, classes, `enum`)
      → adiantado: Ex. 1 (tipos) ✅ já na segunda; faltam os Ex. 2–5
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
