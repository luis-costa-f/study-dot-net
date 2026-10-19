# Fase 1 — Fundamentos: exercícios de validação

> Criado em 2026-10-19. Dez exercícios, do mais simples ao mais completo. Cada um tem a **saída esperada** para você
> conferir sozinho e depois ser validado por mim. Todos os dados são **fictícios**.

## Como organizar o código

Um arquivo por exercício, cada um com um método `Executar()`. O `Program.cs` só escolhe qual rodar:

```csharp
// Ex01Tipos.cs
public static class Ex01Tipos
{
    public static void Executar()
    {
        // seu código aqui
    }
}
```

```csharp
// Program.cs — troque o número para rodar outro exercício
var exercicio = 1;

switch (exercicio)
{
    case 1: Ex01Tipos.Executar(); break;
    // case 2: Ex02Condicionais.Executar(); break;
    default: Console.WriteLine("Exercício não encontrado"); break;
}
```

Os dados que se repetem (projetos, enums) podem ficar num arquivo `Dados.cs`, criado no exercício 6.

## Regras para a validação valer

1. **Digite, não copie e cole.** Pode consultar a documentação; IA e soluções prontas, não.
2. **Anote o tempo** de cada exercício no comentário do topo do arquivo: `// tempo: 25 min`.
3. Se travar, escreva a dúvida num comentário `// DÚVIDA:` e siga em frente. Eu respondo na revisão.
4. Commit a cada exercício: `feat: fase 1 - exercício 3 (laços)`.
5. Ao terminar um bloco, diga **"valida os exercícios 1 a N"**.

## Como eu vou validar

Para cada exercício, eu leio o código, rodo o projeto e confiro a saída. Depois dou uma nota:

| Nota | Significa |
|---|---|
| ✅ **Domina** | Saída certa, código limpo e idiomático, e você saberia explicar numa entrevista. |
| 🟡 **Funciona** | Saída certa, mas tem algo que um sênior mudaria (nome, duplicação, tipo errado, jeito "não C#"). |
| 🔴 **Rever** | Saída errada ou conceito mal entendido. Recebe uma explicação e um mini exercício de reforço. |

No fim, eu monto um **mapa de habilidades** (o que está firme e o que precisa de reforço) e atualizo o guia.

**Antes de pedir validação** (para tirar ✅ já na primeira vez):

- [ ] Rodei e comparei a saída **caractere por caractere** com a esperada.
- [ ] O resultado não depende do dia nem da máquina: nada de `DateTime.Now`, e a formatação usa uma cultura explícita.
- [ ] Os dados ficam no menor escopo possível (variável local, e não campo `static`).
- [ ] Os nomes dizem o que a variável **é** (`dataReferencia`, e não `dataFim`).
- [ ] Rodei `Ctrl+K, Ctrl+D` e conferi com `Ctrl+R, Ctrl+W` que não sobrou espaço no fim das linhas.
- [ ] Os operadores têm espaço dos dois lados, inclusive dentro de `{...}` na interpolação.
- [ ] Respondi **todas as partes** de cada pergunta de teoria, com as minhas palavras, em linhas de até ~120
      caracteres.
- [ ] Ao corrigir, **acrescentei** a resposta em vez de apagar o que já estava aprovado.
- [ ] Anotei `// tempo: X min`.

**Regra de aprovação:** um exercício só recebe ✅ e tem o checkbox marcado quando **todos** os itens da sua lista de
correção estiverem resolvidos. Não existe "aprovado com ressalvas": 🟡 e 🔴 geram uma lista em
[Correções pendentes](#correções-pendentes), e a revalidação confere item por item.

---

## Bloco A — Sintaxe básica (Ter 20)

### Ex. 1 — Tipos e variáveis · `Ex01Tipos.cs` · ~20 min

*No Mendix eram os tipos de atributo: String, Integer, Decimal, Boolean, Date and time.*

1. Declare as variáveis de um projeto: `nome` ("Portal RH"), `orcamento` (150000,00), `horasPrevistas` (1200),
   `ativo` (true) e `dataInicio` (1º de agosto de 2026). **Escolha o tipo certo para cada uma.**
2. Imprima tudo numa frase só usando **interpolação** (`$"..."`), com o orçamento em reais e a data em `dd/MM/yyyy`.
3. Calcule e imprima quantos dias se passaram entre `dataInicio` e 19/10/2026.
4. Imprima o resultado de `7 / 2`, `7 / 2.0` e `7m / 2`, e de `0.1 + 0.2` (double) e `0.1m + 0.2m` (decimal).
   Escreva num comentário **por que** os resultados são diferentes e qual tipo usar para dinheiro.

**Saída esperada** (o espaço depois de `R$` pode variar; num Windows em português os decimais saem com vírgula):
```
Projeto Portal RH, orçamento R$ 150.000,00, 1200 horas, ativo: True, início: 01/08/2026
Dias desde o início: 79
7 / 2 = 3 | 7 / 2.0 = 3,5 | 7m / 2 = 3,5
0.1 + 0.2 = 0,30000000000000004 | 0.1m + 0.2m = 0,3
```
*Dica: para o formato em reais, pesquise `ToString("C", new CultureInfo("pt-BR"))`.*

### Ex. 2 — Condicionais · `Ex02Condicionais.cs` · ~20 min

*No Mendix era o Exclusive Split.*

A severidade de um risco é calculada pelo **peso = impacto × probabilidade** (cada um de 1 a 5). As faixas abaixo
são fictícias, criadas para este exercício: **1–4 → Baixo**, **5–12 → Médio**, **13–25 → Alto**.

1. Escreva a classificação com **`if / else if / else`**.
2. Escreva de novo com uma **`switch` expression** e *pattern matching* (`<= 4 => ...`).
3. Imprima a classificação dos pares (1,3), (2,3), (3,4) e (5,5).
4. Se impacto ou probabilidade estiver fora de 1–5, imprima `Valor inválido` em vez de classificar. Teste com (0,3).

**Saída esperada:**
```
1 x 3 = 3 → Baixo
2 x 3 = 6 → Médio
3 x 4 = 12 → Médio
5 x 5 = 25 → Alto
0 x 3 → Valor inválido
```

### Ex. 3 — Laços · `Ex03Lacos.cs` · ~25 min

*No Mendix era o Loop, mas aqui existem três tipos, e escolher o certo faz parte do exercício.*

1. **`for`:** imprima as 12 competências de 2026 no formato `01/2026` até `12/2026`, uma por linha.
2. **`foreach`:** dado `int[] horas = { 8, 6, 9, 4, 7 };`, calcule a soma, o maior valor e a média **sem LINQ**.
3. **`while`:** um investimento de R$ 1.000,00 rende 1% ao mês. Quantos meses até chegar a R$ 2.000,00 ou mais?

**Saída esperada:**
```
01/2026
02/2026
... (até 12/2026)
Soma: 34 | Maior: 9 | Média: 6,8
Meses para dobrar: 70
```

### Ex. 4 — Métodos · `Ex04Metodos.cs` · ~25 min

*No Mendix era o sub-microflow com parâmetros e retorno.*

1. Transforme a classificação do Ex. 2 num método `static string ClassificarSeveridade(int impacto, int probabilidade)`.
2. Se um valor estiver fora de 1–5, **lance** `ArgumentOutOfRangeException` (em vez de imprimir). Chame o método
   com (0,3) dentro de um `try / catch` e imprima a mensagem do erro.
3. Crie um método `static bool TentarLerNota(string texto, out int nota)` que use `int.TryParse` e só aceite notas de
   1 a 5. Teste com `"4"`, `"abc"` e `"9"`.

**Saída esperada** (a mensagem do erro pode variar):
```
Alto
Erro: Impacto deve estar entre 1 e 5. (Parameter 'impacto')
"4" → válida: 4
"abc" → inválida
"9" → inválida
```

### Ex. 5 — Enums · `Ex05Enums.cs` · ~15 min

*No Mendix era a Enumeration.*

1. Crie `enum StatusProjeto { Planejado, Ativo, Suspenso, Concluido }`.
2. Escreva `static string Descrever(StatusProjeto s)` com `switch` expression, devolvendo um texto amigável
   (ex.: `Concluido` → `"Concluído"`).
3. Liste todos os valores do enum com `Enum.GetValues<StatusProjeto>()`, mostrando o número e a descrição.
4. Converta a string `"Suspenso"` para o enum com `Enum.TryParse`, e tente também `"Cancelado"`.

**Saída esperada:**
```
0 - Planejado
1 - Ativo
2 - Suspenso
3 - Concluído
"Suspenso" → Suspenso
"Cancelado" → status inexistente
```

---

## Bloco B — Objetos e coleções (Qua 21)

### Ex. 6 — Classes · `Ex06Classes.cs` + `Dados.cs` · ~30 min

*No Mendix era a Entity com atributos e regras de validação.*

1. Crie a classe `Projeto` com as propriedades `Nome`, `Gerente`, `Status` (`StatusProjeto`) e `Orcamento` (decimal).
2. Use um **construtor** que exija nome e gerente. Se o nome vier vazio, lance `ArgumentException`.
3. O orçamento **não pode ser negativo**: proteja a propriedade (setter com validação ou método `DefinirOrcamento`).
4. Sobrescreva o `ToString()` para mostrar `Nome (Status) - Gerente`.
5. Em `Dados.cs`, crie um método `static List<Projeto> Projetos()` que devolva esta lista (vai ser usada nos
   próximos exercícios):

| Nome | Gerente | Status | Orçamento |
|---|---|---|---|
| Portal RH | Ana | Ativo | 150000 |
| App Logística | Bruno | Ativo | 320000 |
| BI Financeiro | Ana | Concluido | 90000 |
| Migração ERP | Carla | Suspenso | 500000 |
| Site Institucional | Bruno | Concluido | 40000 |
| Chatbot Atendimento | Ana | Ativo | 75000 |

6. Imprima os projetos usando o `ToString()` e tente criar um projeto com nome vazio dentro de um `try / catch`.

**Saída esperada:**
```
Portal RH (Ativo) - Ana
App Logística (Ativo) - Bruno
... (os 6)
Erro: O nome do projeto é obrigatório.
```

### Ex. 7 — Coleções sem LINQ · `Ex07Colecoes.cs` · ~25 min

*No Mendix eram as listas e o Aggregate list.*

Usando `Dados.Projetos()`, **só com `foreach`, `List` e `Dictionary`** (nada de LINQ ainda):

1. Monte um `Dictionary<StatusProjeto, int>` com a quantidade de projetos por status e imprima.
2. Calcule o orçamento total dos projetos ativos.
3. Descubra o gerente com mais projetos.

**Saída esperada:**
```
Ativo: 3
Concluido: 2
Suspenso: 1
Orçamento ativo: R$ 545.000,00
Gerente com mais projetos: Ana (3)
```

### Ex. 8 — LINQ · `Ex08Linq.cs` · ~35 min ⭐ (o que mais cai no live coding)

*No Mendix eram as List operations (Filter, Sort, Find) e o Aggregate list.*

Refaça o Ex. 7 **com LINQ** e responda também:

1. Projetos ativos ordenados por orçamento, do maior para o menor (`Where` + `OrderByDescending`).
2. Quantidade por status (`GroupBy`).
3. Gerente com mais projetos (`GroupBy` + `OrderByDescending` + `First`).
4. Existe algum projeto acima de R$ 400.000? Todos têm gerente? (`Any` e `All`)
5. Nomes dos projetos concluídos em maiúsculas (`Select`).
6. Orçamento médio de todos os projetos (`Average`), com 2 casas decimais.
7. Primeiro projeto `Planejado` (`FirstOrDefault`). Não existe nenhum: trate o `null` sem quebrar.

**Saída esperada:**
```
Ativos por orçamento: App Logística, Portal RH, Chatbot Atendimento
Ativo: 3 | Concluido: 2 | Suspenso: 1
Gerente com mais projetos: Ana (3)
Algum acima de 400 mil? True | Todos têm gerente? True
Concluídos: BI FINANCEIRO, SITE INSTITUCIONAL
Orçamento médio: R$ 195.833,33
Primeiro planejado: nenhum
```
*Ao terminar, compare o tamanho do Ex. 7 e do Ex. 8 e escreva num comentário quando você preferiria cada um.*

### Ex. 9 — Records e nullable · `Ex09RecordsNullable.cs` · ~20 min

1. Crie `record Contato(string Nome, string Email, string? Telefone);`.
2. Crie dois contatos com **os mesmos dados** e compare com `==`. Faça o mesmo com uma `class` equivalente e
   escreva num comentário por que o resultado muda.
3. Crie uma cópia do contato trocando só o e-mail, usando `with`.
4. Imprima o telefone de cada contato usando `?.` e `??`, mostrando `"sem telefone"` quando for `null`.

**Saída esperada** (os nomes são exemplo):
```
record: iguais? True
class: iguais? False
Cópia: Contato { Nome = Ana, Email = ana.nova@exemplo.com, Telefone =  }
Ana: sem telefone
Bruno: (11) 99999-0000
```

### Ex. 10 — Desafio de fechamento · `Ex10Desafio.cs` · **30 min cronometrados**

Um mini programa interativo, como num live coding:

1. Mostre um menu em loop: `1 - Listar projetos`, `2 - Filtrar por gerente`, `3 - Classificar risco`, `0 - Sair`.
2. A opção 2 pede o nome do gerente (sem diferenciar maiúsculas e minúsculas) e lista os projetos dele, ou
   `Nenhum projeto encontrado`.
3. A opção 3 pede impacto e probabilidade, valida com o `TentarLerNota` do Ex. 4 e mostra a severidade.
4. Uma opção inválida mostra `Opção inválida` e volta ao menu, **sem nunca quebrar o programa**.

Não tem saída esperada fixa. Nesse aqui eu vou avaliar organização, validação de entrada e tratamento de erros.

---

## Checklist

- [x] Ex. 1 — Tipos e variáveis ✅ Domina (2026-10-19)
- [ ] Ex. 2 — Condicionais
- [ ] Ex. 3 — Laços
- [ ] Ex. 4 — Métodos
- [ ] Ex. 5 — Enums
- [ ] Ex. 6 — Classes
- [ ] Ex. 7 — Coleções sem LINQ
- [ ] Ex. 8 — LINQ ⭐
- [ ] Ex. 9 — Records e nullable
- [ ] Ex. 10 — Desafio de fechamento

## Correções pendentes

### Ex. 1 — Tipos e variáveis (1ª: 🟡 · 2ª: 🟡, 3/10 · 3ª: 🟡, 6/10 · 4ª: 🟡, 8/10 · 5ª: 🟡, 9/10 · 6ª: 🟡, 9/10 · **7ª validação, 2026-10-19: ✅ Domina, 10 de 10**)

Para ser aprovado, **todos** os itens precisam estar marcados. Eu marco cada um na revalidação.

**Código**
- [x] **C1. Moeda formatada pela cultura.** Trocar o `R$ {orcamento}` escrito à mão por
      `orcamento.ToString("C", new CultureInfo("pt-BR"))`, com `using System.Globalization;`. A saída precisa ser
      `R$ 150.000,00`, com o ponto de milhar.
      → *2ª validação:* o `ToString("C", ...)` entrou, mas o `R$ ` escrito à mão continuou no texto, e a saída ficou
      `R$ R$ 150.000,00`.
- [x] **C2. Variáveis locais.** Mover `nome`, `orcamento`, `horasPrevistas`, `ativo`, `dataInicio` e a data de
      referência para **dentro** do `Executar()`. A classe não deve ter mais nenhum campo `static`.
- [x] **C3. Nome claro.** Renomear `dataFim` para `dataReferencia` (ou outro nome que deixe claro que é o "hoje" do
      exercício, e não o fim do projeto).
      → *2ª validação:* a variável foi removida e trocada por `DateTime.Now`. Hoje dá 79, mas amanhã dá 80, e o
      enunciado pede a diferença até **19/10/2026**. Volte a usar uma variável `dataReferencia` com a data fixa.
      → *3ª validação:* a variável voltou com o nome `hoje`, mas ainda recebe `DateTime.Now`. O problema não é só o
      nome: o **valor** precisa ser a data fixa `new DateTime(2026, 10, 19)`.
- [x] **C4. Literal de decimal.** Escrever o orçamento como `150_000m`, com sufixo minúsculo e separador `_`.
- [x] **C5. Formatação.** Rodar `Ctrl+K, Ctrl+D` no arquivo: sem espaços sobrando no fim das linhas, sem linha em
      branco antes da `}` final e com espaços em volta dos operadores (`7 / 2`, `7m / 2`).
      → *2ª validação:* ainda há espaços no fim das linhas 6, 13, 18 e 19, e os operadores dentro das chaves
      continuam sem espaço: `{7/2}`, `{7/2.0}`, `{7m/2}`. Ajuste esses três à mão; o `Ctrl+K, Ctrl+D` não mexe
      dentro da interpolação.
      → *3ª validação:* nada mudou. Ainda há espaços no fim das linhas 6, 13 e 21, e `{7/2}`, `{7/2.0}` e `{7m/2}`
      continuam sem espaço.
      → *4ª validação:* os operadores foram corrigidos. Faltam os espaços no fim das linhas 6 (`{    `),
      15 (`dataInicio = ...;   `) e 26 (`Console.WriteLine(...); `), e a linha em branco logo depois do `{` da classe.
      Use `Ctrl+R, Ctrl+W` no Visual Studio para enxergar os espaços (aparecem como pontinhos).
- [x] **C6. Tempo anotado.** Comentário `// tempo: X min` no topo do arquivo.

**Saída**
- [x] **S1.** O programa imprime exatamente a saída esperada do Ex. 1, incluindo `R$ 150.000,00`.
      → *2ª validação:* falha por causa do `R$ R$` (C1).
      → *3ª validação:* a saída de hoje está idêntica à esperada, mas a linha dos dias muda amanhã por causa do
      `DateTime.Now`. Este item só fecha junto com o C3.

**Teoria** (responder com as suas palavras, num comentário no fim do `Ex01Tipos.cs`)
- [x] **T1.** Por que `7 / 2` dá `3`, e não `3,5`? O que muda em `7 / 2.0` e em `7m / 2`?
      → *2ª validação:* a resposta começou ("inteiro com inteiro sempre vai usar o inteiro"), mas está incompleta.
      Falta dizer **o que acontece com a parte decimal** (ela é arredondada ou descartada? teste `-7 / 2` para ter
      certeza) e explicar o caso `7 / 2.0`, que não tem `m` e mesmo assim dá `3,5`. Qual é o tipo de `2.0`, e o que
      acontece quando um dos lados da conta não é inteiro?
- [x] **T2.** Por que `0.1 + 0.2` em `double` dá `0,30000000000000004`, e em `decimal` dá exatamente `0,3`?
      → *2ª validação:* sem resposta.
- [x] **T3.** Que tipo usar para dinheiro no C# (e qual era o equivalente no Mendix), e por que **não** usar `double`?
      → *2ª validação:* sem resposta.
      → *3ª validação:* ainda sem resposta direta. A explicação do T2 ajuda, mas a pergunta tem três partes que
      precisam aparecer: **qual tipo** no C#, **qual tipo** no Mendix e **qual o risco** de usar `double` num valor
      financeiro (pense em somar milhares de parcelas de um contrato).
      → *4ª validação:* ainda sem resposta no arquivo.
      → *5ª validação:* partes 1 e 2 respondidas (`decimal` no C#, `Decimal` no Mendix). Falta a parte 3: **qual é o
      risco concreto** de usar `double` com dinheiro. "O decimal garante exatidão" diz o que o `decimal` faz, mas
      não o que dá errado com o `double`. Uma frase basta.
      → *6ª validação:* a parte 3 ficou ótima (erros acumulados em somas grandes, centavos sumindo, comparação exata
      falhando). Mas a linha antiga com as partes 1 e 2 foi **substituída**, em vez de mantida, e o arquivo deixou de
      dizer qual tipo usar no C# e no Mendix. Volte com a frase das partes 1 e 2 junto com a nova.

## Resultado da validação

| Exercício | Data | Tempo | Nota | Observações |
|---|---|---|---|---|
| Ex. 1 — Tipos | 2026-10-19 | não anotado | 🟡 Funciona | Tipos todos certos. Ajustar: moeda com `ToString("C", pt-BR)` (hoje sem separador de milhar), variáveis locais em vez de campos `static`, `dataFim` → `dataReferencia`, e escrever o porquê de `7 / 2` e de `double` × `decimal`. |
| Ex. 1 — Tipos (2ª) | 2026-10-19 | 20 min | 🟡 Funciona | Resolvidos: C2, C4, C6. Pendentes: C1 (`R$ R$`), C3 (`DateTime.Now` no lugar da data fixa), C5, S1, T1 (incompleta), T2, T3. |
| Ex. 1 — Tipos (3ª) | 2026-10-19 | 20 min | 🟡 Funciona | Resolvidos: C1, T1, T2 (total 6/10). Pendentes: C3 (`hoje = DateTime.Now`), C5 (formatação), S1 (depende do C3), T3. |
| Ex. 1 — Tipos (4ª) | 2026-10-19 | 20 min | 🟡 Funciona | Resolvidos: C3, S1 (total 8/10). Pendentes: C5 (espaços no fim das linhas 6, 15 e 26), T3 (sem resposta). |
| Ex. 1 — Tipos (5ª) | 2026-10-19 | 20 min | 🟡 Funciona | Resolvido: C5 (total 9/10). Pendente: T3, parte 3 (o risco de usar `double` com dinheiro). |
| Ex. 1 — Tipos (6ª) | 2026-10-19 | 20 min | 🟡 Funciona | T3: a parte 3 foi respondida, mas a frase das partes 1 e 2 (`decimal` / `Decimal` no Mendix) foi apagada. Total 9/10. |
| **Ex. 1 — Tipos (7ª)** | 2026-10-19 | 20 min | **✅ Domina** | 10/10. Tipos corretos, moeda pela cultura, saída determinística, escopo e nomes certos, teoria completa (divisão inteira, promoção de tipos, ponto flutuante binário, risco do `double` com dinheiro). |
