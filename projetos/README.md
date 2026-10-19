# Projetos

Mini projetos, um por pasta, com o número da fase do [guia](../docs/GUIA-DE-ESTUDOS.md) no começo do nome:

```
projetos/
├── fase-0-ola/              # dotnet new console -n Ola -o fase-0-ola
├── fase-1-riscos-console/   # regras do Risco/Acao com LINQ
├── fase-2-riscos-testes/    # solution: Riscos.Dominio + Riscos.Testes
└── fase-3-riscos-api/       # Web API
```

Para criar um projeto já na pasta certa:

```
cd projetos
dotnet new console -n Ola -o fase-0-ola
```

A partir da Fase 4, os projetos passam a evoluir em cima do anterior. Nesse caso, copie a pasta da fase
anterior (por exemplo, `fase-3-riscos-api` → `fase-4-riscos-ef`) para manter o histórico de cada etapa.
