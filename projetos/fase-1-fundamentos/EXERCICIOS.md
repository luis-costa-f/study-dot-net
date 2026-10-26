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
2. **Tempo:** não preciso anotar. O Claude estima pelos horários de criação e de alteração dos arquivos e das
   validações (é tempo de relógio, com pausas incluídas).
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

Tipos: `impacto`, `probabilidade` e `peso` são **`int`**; a classificação devolvida é **`string`**.

1. Crie o método `static string ClassificarComIf(int peso)` usando **`if / else if / else`**.
2. Crie o método `static string ClassificarComSwitch(int peso)` com a **mesma regra**, agora usando uma **`switch`
   expression** com *relational patterns* (`<= 4 => ...`). As duas versões precisam dar sempre o mesmo resultado.
3. No `Executar()`, classifique os pares (1,3), (2,3), (3,4) e (5,5): primeiro todos com a versão `if`, depois todos
   com a versão `switch`.
4. Se impacto **ou** probabilidade estiver fora de 1–5, imprima `Valor inválido` em vez de classificar. A validação
   acontece **antes** de calcular o peso. Teste com (0,3).

**Saída esperada:**
```
Com if:
1 x 3 = 3 → Baixo
2 x 3 = 6 → Médio
3 x 4 = 12 → Médio
5 x 5 = 25 → Alto
0 x 3 → Valor inválido
Com switch:
1 x 3 = 3 → Baixo
2 x 3 = 6 → Médio
3 x 4 = 12 → Médio
5 x 5 = 25 → Alto
0 x 3 → Valor inválido
```

**Teoria** (comentário no fim do arquivo):
- **T1.** Por que validar impacto e probabilidade **antes** de calcular o peso, e não validar só o peso?
- **T2.** Quando você usaria `if / else` e quando usaria `switch` expression?

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

**Teoria** (comentário no fim do arquivo):
- **T1.** Por que `while` no item 3, e não `for`? E por que `foreach` no item 2, se um `for` com índice também
  resolveria?

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
- [x] Ex. 2 — Condicionais ✅ Domina (2026-10-19)
- [x] Ex. 3 — Laços ✅ Domina (2026-10-19)
- [x] Ex. 4 — Métodos ✅ Domina (2026-10-20)
- [x] Ex. 5 — Enums ✅ Domina (2026-10-20)
- [x] Ex. 6 — Classes ✅ Domina (2026-10-20)
- [x] Ex. 7 — Coleções sem LINQ ✅ Domina (2026-10-26)
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

### Ex. 2 — Condicionais (1ª: 🔴, 0/8 · 2ª: 🟡, 3/9 · 3ª: 🟡, 7/9 · 4ª: 🟡, 8/9 · **5ª validação, 2026-10-19: ✅ Domina, 9 de 9**)

Todos os itens resolvidos: validação na entrada, classificadores corretos sozinhos e iguais entre si, nomes claros, saída exata e teoria com exemplo.

**Código**
- [x] **C1. Validar a entrada antes do peso.** Resolvido na 3ª: o peso só é calculado no `else`.
- [x] **C2. As duas versões sempre iguais.** Resolvido na 2ª.
- [x] **C3. Sem gambiarra na impressão.** Resolvido na 2ª.
- [x] **C4. Nome do método de impressão.** Resolvido na 5ª (`ImprimirClassificacao`). "Classificacao" resolveu o "o que é impresso". Falta só o verbo:
      `ImprimeClassificacao` está no presente ("ele imprime"); o padrão do arquivo e do .NET é o imperativo/infinitivo
      (`Executar`, `Classificar...`, `Console.WriteLine`). Troque `Imprime` → `Imprimir` (declaração e 10 chamadas).
- [x] **C5. Sem índices mágicos.** Resolvido na 3ª.
- [x] **C6. "Alto" não pode ser o "resto".** Resolvido na 3ª: 13–25 explícito e fora de 1–25 tratado nos dois.

**Saída**
- [x] **S1.** Resolvido na 2ª.

**Teoria**
- [x] **T1.** Resolvido na 4ª: validar a entrada evita falsos positivos; (-1, -3) dá peso 3 → "Baixo" e esconde o
      erro nos dados.
- [x] **T2.** Resolvido na 3ª: `switch` expression para mapear um valor em outro, `if / else` para executar ações.
      (Para enriquecer, não bloqueia: a validação da linha 33 junta duas variáveis diferentes com `||`, um caso
      clássico de `if`.)

*Sugestões que não bloqueiam:* declarar o peso já com valor, dentro do `else` (`int peso = impacto * probabilidade;`),
em vez de `int peso;` lá em cima; colocar o comentário de teoria no fim do arquivo, e não dentro do `Executar`;
chaves `{ }` também nos `if` de uma linha.

### Ex. 3 — Laços (1ª: 🟡, 0/6 · 2ª: 🟡, 2/5 · 3ª: 🟡, 2/5 · 4ª: 🟡, 4/5 · **5ª validação, 2026-10-19: ✅ Domina, 5 de 5**)

Todos os itens resolvidos: laço certo para cada caso, maior valor sem caso de borda, nomes que dizem o que cada
método e cada variável são, conversão explícita e teoria com as próprias palavras.

**Código**
- ~~**C1. Tempo anotado.**~~ Retirado: o tempo passa a ser estimado pelo Claude (decisão de 2026-10-19).
- [x] **C2. Valor inicial do maior.** Resolvido na 2ª: `horas[0]`.
- [x] **C3. Nomes das variáveis do investimento.** Resolvido na 5ª: `saldoAtual` e `valorAlvo`. Sem mudança até a 4ª. `investimentoInicial` é
      alterado dentro do laço (linha 47): no mês 1 já não é mais o inicial, e no fim vale ~2.006. O que essa
      variável guarda mês a mês? E `investimentoLimite` é o quê para quem investe?
- [x] **C4. Nomes dos métodos.** Resolvido na 4ª: `ImprimirCompetencias`, `ImprimirEstatisticasDeHoras`,
      `ImprimirTempoParaDobrar`.
- [x] **C5. Conversão explícita.** Resolvido na 2ª: `(decimal)totalHoras`.

**Teoria**
- [x] **T1.** Resolvido na 4ª: `while` porque o número de voltas é desconhecido e depende de uma condição de
      parada; `foreach` porque a intenção é ler todos os itens, sem risco de erro de índice. Linhas até ~100.

*Sugestões que não bloqueiam:* chaves `{ }` no `if` da linha 28; linha em branco antes do `Console.WriteLine` da
linha 49; formatar a média com casas fixas (`:N1`); comentário de teoria no fim do arquivo, fora do `Executar`.

### Ex. 4 — Métodos (1ª: 🟡, 1/6 · 2ª: 🟡, 5/6 · **3ª validação, 2026-10-20: ✅ Domina, 6 de 6**)

Todos os itens resolvidos: cada regra no método certo (faixa 1–5 dentro do `TentarLerNota`), exceção com `nameof` e
mensagem pura, `out int` na chamada, nomes no infinitivo e arquivo limpo.

**Código**
- [x] **C1. A regra 1–5 fica dentro do `TentarLerNota`.** Resolvido na 2ª. O enunciado pede que o método "só aceite notas de 1 a 5",
      mas ele só faz o `int.TryParse`. Hoje `TentarLerNota("9", out n)` devolve `true`, e quem chama precisa lembrar
      de checar a faixa (linha 42). Se outro lugar usar o método (o Ex. 10 vai usar), a validação se perde. O método
      deve devolver `false` para `"9"`, e o `ImprimirResultadoDasNotas` fica só com `if (TentarLerNota(...))`.
- [x] **C2. Nome e formato do `retornaSeveridade`.** Resolvido na 2ª (`ClassificarPeso`). Método em C# é PascalCase, e sem espaço antes do `(`. Além disso,
      "retorna" não diz nada: todo método com retorno "retorna". O nome deve dizer o que ele faz com o peso.
- [x] **C3. Mensagem da exceção sem "Erro:" e com `nameof`.** Resolvido na 2ª. A exceção descreve o problema; quem decide como mostrar
      é o `catch`. Tire o `"Erro: "` das duas mensagens e coloque-o no `Console.WriteLine` do `catch`. E troque
      `"impacto"` / `"probabilidade"` por `nameof(impacto)` / `nameof(probabilidade)`: se alguém renomear o
      parâmetro, o texto acompanha.
- [x] **C4. `out` declarado na chamada.** Resolvido na 2ª. Em vez de `int nota;` numa linha e `out nota` na outra, o C# moderno
      declara direto: `out int nota`. (Junto com o C1, a variável `resultado` deixa de ser necessária.)
- [x] **C5. Limpeza e formatação.** Resolvido na 3ª. Remover o `using System.Runtime.InteropServices;` (não é usado; o VS colocou
      sozinho) e o `// tempo: X min` (não anotamos mais tempo). Tirar o espaço em `impacto > 5 )` e as linhas em
      branco antes da `}` (linhas 29, 50 e 61). `Ctrl+K, Ctrl+D` resolve a maior parte.
      → *2ª validação:* `using`, comentário, espaço e as linhas 29 e 50 resolvidos. Falta a linha em branco antes da
      `}` do `try` (agora linha 59, logo depois do `Console.WriteLine(resultado2);`) e a linha vazia extra no fim do
      arquivo, depois da última `}`.

**Saída**
- [x] **S1.** Idêntica à esperada, caractere por caractere.

*Sugestões que não bloqueiam:* deixar só a chamada `(0, 3)` dentro do `try` (o `(5, 4)` não deveria falhar, e o
`resultado2` nunca é impresso); chaves `{ }` nos `if` do `throw`; como a entrada já foi validada, o `_` do `switch`
nunca acontece: dá para lançar uma exceção ali (`_ => throw new UnreachableException()`) em vez de devolver um texto.

### Ex. 5 — Enums (1ª: 🟡, 1/6 · 2ª: 🟡, 4/6 · 3ª: 🟡, 5/6 · **4ª validação, 2026-10-20: ✅ Domina, 6 de 6**)

Todos os itens resolvidos: enum no nível do arquivo, leitura que só aceita nomes existentes (`IsDefined` + nome
igual ao texto), `_` tratado como argumento inválido, nomes pelo propósito, arquivos limpos e saída exata.

Na 1ª: a saída estava idêntica à esperada, e `Enum.GetValues<T>()`, a `switch` expression e o `Enum.TryParse` com `out` estavam
certos. Mas testei o `TentarLerStatusProjetoEnum` com outras entradas, e um enum não é tão "fechado" quanto parece.

**Código**
- [x] **C1. `TryParse` aceita status que não existem.** Resolvido na 2ª (`Enum.IsDefined` + nome igual ao texto). Testei: `"9"` → `true` com valor `9`; `"Ativo,Suspenso"` →
      `true` com valor `3` (`Concluido`!), porque o `TryParse` aceita números e combina nomes com vírgula. Com `"9"`,
      o programa **quebra** no `Descrever`. Mesma lição do C1 do Ex. 4: a regra "só status válidos" fica dentro do
      `TentarLer...`. Pesquise `Enum.IsDefined`.
- [x] **C2. O `_` do `switch` de enum é alcançável.** Resolvido na 2ª. No Ex. 4 o `UnreachableException` estava certo, porque o peso já
      tinha sido validado. Aqui não: um enum é um `int` por baixo, e `(StatusProjeto)9` compila e roda. O caso `_`
      deve lançar a exceção de argumento inválido que você já usou no Ex. 4 (com `nameof`).
- [x] **C3. Enum fora da classe.** Resolvido na 2ª (`Dados.cs`). Declarado dentro da `static class`, o nome completo vira
      `Ex05Enums.StatusProjeto`, e o Ex. 6 vai precisar dele no `Dados.cs`. Tipos como enum ficam no nível do arquivo
      (fora da classe), como uma Enumeration do Mendix fica no módulo, e não dentro de um microflow.
- [x] **C4. Nomes.** Resolvido na 2ª (`TentarLerStatusProjeto`, `ImprimirStatusValidado`, `status`). `TentarLerStatusProjetoEnum`: o tipo não vai no nome ("Enum" já está na assinatura).
      `ImprimirTesteDeConversaoDeStringParaStatusProjeto`: descreve a técnica e é longo; como no Ex. 3, o nome responde
      "o que aparece na tela?". `enumProjeto`: a variável do `foreach` é um **status**, não um "enum de projeto".
- [x] **C5. Formatação.** Resolvido na 4ª. Os comentários `// 0`, `// 1`... estão desalinhados e repetem o que o C# já faz sozinho:
      tire-os (ou, se quiser deixar o número explícito, use `Planejado = 0` no próprio enum). E o cast fica sem
      espaço, como no Ex. 3: `(int)status`.
      → *2ª validação:* o cast foi corrigido. Os comentários `// 0`... foram junto com o enum para o `Dados.cs` e
      continuam lá, desalinhados. O `Dados.cs` também começa com uma linha em branco.
      → *3ª validação:* comentários trocados por `Planejado = 0`... ✅. A linha em branco na linha 1 do `Dados.cs`
      continua.

**Saída**
- [x] **S1.** Idêntica à esperada, caractere por caractere. Resolvido na 3ª.
      → *2ª validação:* as linhas 48–49 (`Console.WriteLine((StatusProjeto)9)` e `(StatusProjeto)3`) imprimem `9` e
      `Concluido` a mais. Testar é ótimo, mas o teste sai do código entregue (ou vira chamada com saída prevista).

*Sugestões que não bloqueiam:* chaves `{ }` no `if` do `TentarLerStatusProjeto`; a versão genérica
`Enum.IsDefined(status)` dispensa o `typeof`; passar os textos direto (`ImprimirX("Suspenso")`), sem as variáveis `testeSuspenso` e
`testeCancelado`; no `out`, `status` em vez de `s` (o `s` do `Descrever` veio do enunciado e pode ficar).

### Ex. 6 — Classes (1ª: 🟡, 1/6 · 2ª: 🟡, 4/6 · 3ª: 🟡, 5/6 · 4ª: 🟡, 5/6 · **5ª validação, 2026-10-20: ✅ Domina, 6 de 6**)

Todos os itens resolvidos: enum no nível do arquivo, estado protegido (`private set` e setter que valida), exceções
com o construtor certo e `catch` específico, inicializador de objeto formatado e saída exata.

Na 1ª: a saída está idêntica à esperada, compila sem avisos, e a estrutura é boa: construtor com validação, `ToString()`
sobrescrito, setter com campo `_orcamento` e lista com collection expression `[...]`. Os pontos abaixo são o que um
sênior apontaria, e o C2 é a pergunta clássica de entrevista sobre encapsulamento.

**Código**
- [x] **C1. O enum voltou para dentro de uma classe.** Resolvido na 2ª (o `using static Dados;` que ficou no
      `Ex06Classes.cs` é para o `Projetos()`, e esse uso está certo). Regressão do C3 do Ex. 5: no `Dados.cs` ele agora está dentro
      de `public static class Dados`, e por isso o `using static Dados;` virou obrigatório no `Ex05Enums.cs` e no
      `Projeto.cs`. O enum fica no nível do arquivo, e a classe `Dados` só com o método `Projetos()`. Depois disso, os
      `using static Dados;` deixam de ser necessários para o enum.
- [x] **C2. A validação do construtor pode ser contornada.** Resolvido na 2ª (`private set`). `Nome` e `Gerente` têm `set` público: depois de criado,
      `projeto.Nome = "";` funciona e o projeto fica inválido. O construtor garante o estado só na criação; a
      propriedade precisa garantir depois. Qual é a forma de deixar o `Nome` só para leitura de fora da classe?
      (No Mendix, é como a regra de validação da entidade: vale em todo commit, não só no "New".)
- [x] **C3. `nameof` no lugar certo.** Resolvido na 3ª. No construtor, o `nameof(nome)` está **dentro do texto** da mensagem: se alguém
      renomear o parâmetro para `nomeProjeto`, a mensagem vira "O nomeProjeto do projeto é obrigatório.". O `nameof`
      serve para o parâmetro `paramName` da exceção; o texto para o usuário fica escrito à mão. E no `Orcamento`,
      `nameof(value)` diz "value" para quem recebe o erro: o que estava errado foi o `Orcamento`.
      → *2ª validação:* o construtor ficou certo (texto escrito à mão). No `Orcamento`, o `nameof` saiu, mas sobrou
      `new ArgumentOutOfRangeException("O orçamento não pode ser negativo.")`, e o construtor com **um** texto dessa
      exceção recebe o `paramName`, não a mensagem. Testei: a mensagem vira `Specified argument was out of the range
      of valid values. (Parameter 'O orçamento não pode ser negativo.')`. Use o construtor com dois parâmetros, como
      no Ex. 4: primeiro `nameof(Orcamento)`, depois a mensagem.
      → *3ª validação:* resolvido.
- [x] **C4. `catch` específico.** Resolvido na 2ª. `catch (Exception ex)` pega qualquer erro, inclusive bugs que não têm nada a ver com o
      teste. O construtor lança `ArgumentException`: capture essa (como você fez no Ex. 4 com a
      `ArgumentOutOfRangeException`).
- [x] **C5. Formatação.** Resolvido na 5ª. No `Dados.cs`: `"Ana"){    Status` tem espaços irregulares depois do `{` e nenhum antes; o
      padrão é `new Projeto("Portal RH", "Ana") { Status = ..., Orcamento = ... }`. Os valores ficam com separador,
      como no C4 do Ex. 1: `150_000m`. No `Ex06Classes.cs`: linha em branco entre o `using` e a classe.
      → *2ª validação:* `150_000m`, a linha em branco e o espaço depois do `{` resolvidos. Falta o espaço **antes**
      do `{`: `"Ana"){` → `"Ana") {` (nas 6 linhas).
      → *3ª validação:* as 6 linhas ficaram `"Ana" ){`: o espaço foi para dentro do parêntese, e o `{` continua
      colado. O certo é `"Ana") {`, sem espaço antes do `)` e com um espaço antes do `{`.
      → *4ª validação:* o `{` foi corrigido, mas as 6 linhas estão `"Ana" ) {`. Falta apagar o espaço entre a
      última aspa e o `)`.

**Saída**
- [x] **S1.** Idêntica à esperada, caractere por caractere.

*Sugestões que não bloqueiam:* `Console.WriteLine(projeto)` já chama o `ToString()` sozinho; a variável `projeto1` nunca
é usada (basta `new Projeto("", "Meu Gerente");`); validar também o gerente vazio; pasta `Models/` (no .NET as pastas
são PascalCase, porque viram parte do namespace); chaves `{ }` nos `if` do `throw`. E o commit `384864e` ("adicionado
exerc6") na verdade é o Ex. 5: no próximo, use uma mensagem que diga o que entrou.

### Ex. 7 — Coleções sem LINQ (1ª: 🟡, 1/6 · 2ª: 🟡, 5/7 · **3ª validação, 2026-10-26: ✅ Domina, 7 de 7**)

Todos os itens resolvidos: moeda pela cultura, desconstrução no `foreach`, escopo e formatação, comentário do empate
claro e teoria com as suas palavras (inclusive o `Remove` + `Add` reaproveitando o espaço livre).

A saída está idêntica à esperada e o raciocínio está certo: `TryGetValue` com `out` para contar (uma busca só no
dicionário), `0m` no acumulador e o gerente com mais projetos calculado **no mesmo laço** da contagem, sem uma segunda
volta. Os pontos abaixo são o que um sênior apontaria; o C1 é uma regressão do Ex. 1.

**Código**
- [x] **C1. Moeda pela cultura (regressão do C1 do Ex. 1).** Resolvido na 2ª. `R$ {orcamentoAtivo:N2}` tem o `R$ ` escrito à mão e o
      `N2` usa a cultura **da máquina**. Testei com `en-US`: sai `R$ 545,000.00`. Use
      `orcamentoAtivo.ToString("C", new CultureInfo("pt-BR"))` (com `using System.Globalization;`) e tire o `R$ ` do texto.
- [x] **C2. Nome da variável do laço.** Resolvido na 2ª (desconstrução `(status, quantidade)`). `kpv` parece um erro de digitação de `kvp` (*key-value pair*), e abreviação
      não diz o que tem dentro. Use um nome como `par` ou, melhor, desconstrua:
      `foreach (var (status, quantidade) in contagemPorStatus)`.
- [x] **C3. Menor escopo.** Resolvido na 2ª. `contagemPorStatus` é declarado na linha 6, antes do comentário da seção 1. Declare dentro
      da seção, perto do uso, como você já fez com `orcamentoAtivo` e `contagemPorGerente`.
- [x] **C4. Formatação.** Resolvido na 2ª (a linha em branco depois do comentário agora está nas três seções, o que também é consistente). Linha 5: dois espaços em `=  Dados`. Linha 51: `){` colado. O resto do arquivo usa a chave
      na linha de baixo, e você também pode colocá-la ali. Linha 26: o separador tem um `-` a menos que os outros.
      Linha 40: linha em branco entre o comentário e o código, que as seções 1 e 2 não têm.
- [x] **C5. O comentário do empate e o padrão do arquivo.** Resolvido na 3ª. *(novo na 2ª)* A linha 49 está como
      `/*Aqui vai assegura o primeiro que chegou a maior marca não tenho tratativa para empate*/`. A frase não fecha
      ("vai assegura") e, para uma linha só, o C# usa `//` com espaço depois. Algo como
      `// Empate: fica o primeiro gerente que chegou ao máximo, porque o ">" não troca.` Na linha 43 sobrou
      `new Dictionary<string, int>()`, enquanto a linha 13 usa `[]`. Escolha um jeito e use nos dois. Ponha também uma
      linha em branco entre o `}` do método (linha 58) e o bloco de comentário da teoria.

**Saída**
- [x] **S1.** Idêntica à esperada, caractere por caractere (na máquina `pt-BR`; só fica garantida em qualquer
      máquina depois do C1).

**Teoria** (responder com as suas palavras, num comentário no fim do `Ex07Colecoes.cs`)
- [x] **T1. Ordem do `Dictionary`.** Resolvido na 3ª. A saída sai `Ativo, Concluido, Suspenso`. Por que nessa ordem? A documentação do
      `Dictionary` **garante** essa ordem? Se a saída precisasse seguir a ordem do enum (`Planejado, Ativo, Suspenso,
      Concluido`), como você faria? Dica: você já usou `Enum.GetValues<T>()` no Ex. 5.
      → *2ª validação:* o conteúdo está certo nas três partes (ordem de inserção, a documentação diz que a ordem é
      indefinida, laço no `Enum.GetValues<StatusProjeto>()` buscando no dicionário). Mas a regra da teoria é **com as
      suas palavras**, e esse texto não soa como o seu: tem moldura de `====`, "afirma categoricamente", "um
      desenvolvedor Sênior nunca baseia...". Compare com o comentário da linha 49, que é a sua voz. Na entrevista você
      vai ter que falar isso sem apoio. Reescreva em 3 ou 4 frases curtas, do seu jeito, e responda também: **depois de
      um `Remove` seguido de um `Add`, onde a chave nova pode aparecer, e por quê?** (Pense no espaço que o `Remove`
      deixou livre.) No exemplo de código, o `TryGetValue(...) ? valor : 0` é o `GetValueOrDefault` que você já usou
      na linha 48.

*Sugestões que não bloqueiam:* o "conta mais um" fica numa linha com
`contagem[chave] = contagem.GetValueOrDefault(chave) + 1;`; `new Dictionary<StatusProjeto, int>()` pode ser só `new()`
ou `[]` (como no `Dados.cs`); se Bruno também tivesse 3 projetos, o seu `>` mostraria Ana (quem chegou primeiro).
Saiba explicar isso, porque o empate é uma pergunta comum no live coding.

## Resultado da validação

| Exercício | Data | Tempo | Nota | Observações |
|---|---|---|---|---|
| **Ex. 1 — Tipos (7ª)** | 2026-10-19 | 20 min | **✅ Domina** | 10/10. Tipos corretos, moeda pela cultura, saída determinística, escopo e nomes certos, teoria completa (divisão inteira, promoção de tipos, ponto flutuante binário, risco do `double` com dinheiro). |
| **Ex. 2 — Condicionais (5ª)** | 2026-10-19 | 20 min + correções | **✅ Domina** | 9/9. Validação da entrada antes do peso, faixas explícitas em `if` e `switch` (padrões relacionais `and`), classificadores corretos sozinhos, `Func<int, string>` para reaproveitar a impressão, teoria com exemplo de falso positivo. |
| **Ex. 3 — Laços** | 2026-10-19 | ~1h05 (relógio) | **✅ Domina** (5 validações) | `for` / `foreach` / `while` cada um no seu caso, maior valor começando em `horas[0]`, cast explícito `(decimal)`, nomes pelo propósito (`ImprimirEstatisticasDeHoras`, `saldoAtual`, `valorAlvo`). |
| **Ex. 4 — Métodos** | 2026-10-20 | ~1h05 (relógio) | **✅ Domina** (3 validações) | `throw new ArgumentOutOfRangeException(nameof(...))` tratado no `catch`, padrão `TryXxx` com `out int` e a regra de negócio dentro do método, `UnreachableException` no ramo impossível do `switch`. |
| **Ex. 5 — Enums** | 2026-10-20 | ~55 min (relógio) | **✅ Domina** (4 validações) | `Enum.GetValues<T>()`, `TryParse` endurecido com `IsDefined` e comparação do nome (barra `"9"` e `"Ativo,Suspenso"`), enum aceita qualquer `int` → `_` lança `ArgumentOutOfRangeException`, enum no `Dados.cs`. |
| **Ex. 6 — Classes** | 2026-10-20 | ~50 min (relógio) | **✅ Domina** (5 validações) | Construtor que exige o obrigatório, `private set` para não contornar a validação, setter com campo privado, `ArgumentOutOfRangeException(nameof(Orcamento), mensagem)` (o construtor de um texto recebe o `paramName`), `catch` específico, `ToString()` sobrescrito, collection expression. |
| **Ex. 7 — Coleções sem LINQ** | 2026-10-26 | ~1h10 (relógio) | **✅ Domina** (3 validações) | Contagem com `TryGetValue` / `GetValueOrDefault`, máximo no mesmo laço (empate explicado), desconstrução `(status, quantidade)`, moeda com `CultureInfo` explícita, ordem do `Dictionary` não garantida → iterar no `Enum.GetValues<T>()`. |
