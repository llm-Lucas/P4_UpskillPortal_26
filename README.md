# Portal Upskill – Meta Digital

## Projeto Final – Desenvolvimento Web com .NET

### Equipa

* Eduardo Gomes
* Pedro Matias
* Lucas Lemos Marcelo

---

# 1. Introdução

O Portal Upskill foi desenvolvido no âmbito do Projeto Final do curso Upskill – Digital Skills & Jobs, na área de Desenvolvimento Web com .NET.

O projeto teve como objetivo a evolução e manutenção evolutiva de uma plataforma web de gestão de entidades formativas previamente iniciada por uma equipa de desenvolvimento anterior.
A equipa realizou um conjunto significativo de correções e expansão da solução existente, através da implementação de novas funcionalidades,
otimização de processos, correção de problemas identificados e melhoria da experiência de utilização.
A plataforma resultante permite atualmente a gestão integrada de cursos, turmas, módulos, formadores, coordenadores, formandos e candidatos.

A aplicação foi concebida para responder às necessidades de diferentes tipos de utilizadores através de perfis distintos,
garantindo controlo de acessos, organização da informação e automatização de diversos processos administrativos e pedagógicos.

---

# 2. Objetivos do Projeto

Os principais objetivos definidos para o projeto foram:

* Centralizar a gestão da formação numa única plataforma.
* Permitir diferentes níveis de acesso conforme o perfil do utilizador.
* Gerir cursos, módulos e turmas.
* Gerir formandos, formadores e coordenadores.
* Permitir candidaturas online a cursos.
* Avaliar e aprovar candidatos.
* Gerir assiduidade e justificações de faltas.
* Disponibilizar calendários e horários.
* Recolher inquéritos de satisfação.
* Disponibilizar exportação de dados para Excel.
* Melhorar a comunicação entre os diversos intervenientes da formação.

---

# 3. Tecnologias Utilizadas

## Backend

* ASP.NET Core
* Blazor Server
* C#
* Dapper
* SQL Server

## Frontend

* Razor Components
* HTML5
* CSS3
* Radzen Components

## Ferramentas

* Visual Studio 2022
* SQL Server Management Studio
* Git
* GitHub
* Jira
* InterServer
* ClosedXML

---

# 4. Perfis de Utilizador

A aplicação suporta diferentes perfis de acesso:

## Candidato

Permite:

* Registo de conta
* Submissão de candidatura
* Upload de documentação
* Consulta do estado da candidatura
* Consulta de cursos disponíveis

## Formando

Permite:

* Consulta da turma
* Consulta do calendário
* Consulta de avaliações
* Consulta de faltas
* Submissão de justificações
* Resposta a inquéritos
* Consulta dos seus dados pessoais

## Formador

Permite:

* Consulta das turmas atribuídas
* Registo de sumários
* Gestão de presenças
* Consulta de calendário
* Consulta dos módulos atribuídos

## Coordenador

Permite:

* Gestão das turmas sob coordenação
* Consulta de calendários
* Gestão de formadores associados
* Acompanhamento da formação

## Administrador

Permite:

* Gestão completa da plataforma
* Gestão de utilizadores
* Gestão de cursos
* Gestão de módulos
* Gestão de turmas
* Gestão de candidaturas
* Gestão de inquéritos
* Gestão de avaliações
* Aprovação de justificações
* Exportação de informação

---

# 5. Alterações/Updates Implementados

## PORTAL - INTERFACE

* FIX: Reformulação do comportamento de barra lateral
* FIX: Layout de barra lateral actualizado
* NEW: Icon de perfil no Header
* NEW: HUB perfil no icon com dropdown
* NEW: Área pessoal com edição de dados pessoais
* NEW: Área pessoal com alteração de Password
* NEW: Update Icon MetaDigital

## LOGIN

* NEW: Recuperação de Password
* NEW: Ver a Password
* NEW: Lembrar Login
* NEW: Botão de Registo


## PORTAL DO USER: FORMANDO

* NEW: Registo informação formando
* NEW: Edição de informação formando
* NEW: Consulta respectivo calendário de aulas
* NEW: Consulta respectiva turma
* NEW: Consulta respectivas avaliações
* NEW: Consulta respectivas Faltas
* NEW: Justificações de respectivas Faltas
* NEW: Preenchimento de Inquérito sobre curso

## PORTAL DO USER: CANDIDATO

* NEW: Registo de candidatos
* NEW: Upload documental
* NEW: Nova Submissão de candidatura
* NEW: Aprovação ou reprovação
* NEW: Progressão automática de estados

* NEW: Abertura e fecho de candidaturas
* FIX: Criação de cursos
* FIX: Edição de cursos
* FIX: Remoção de cursos
* FIX: Exportação de informação

## Gestão de Módulos

* FIX: Criação de módulos
* FIX: Associação a cursos
* FIX: Edição e remoção
* NEW: Exportação de informação

## Gestão de Turmas

* FIX: Criação de turmas
* FIX: Associação de formandos
* NEW: Associação de coordenadores
* NEW: Associação de formadores
* FIX: Consulta de calendário

## Gestão de Candidatos

* NEW: Avaliação de Candidatura
* NEW: Aprovação/Reprovação Candidatura
* NEW: Inserção em bulk de candidatos em novas turmas

## Gestão de Formandos

* FIX: Criação e edição
* FIX: Consulta de avaliações
* NEW: Consulta de faltas
* NEW: Alteração de estado
* NEW: Remoção de registos inativos

## Gestão de Formadores

* FIX: Criação e edição
* FIX: Associação a módulos
* NEW: Associação a turmas
* FIX: Consulta de horários

## Gestão de Coordenadores

* FIX: Criação e edição
* NEW: Associação a cursos
* FIX: Associação a turmas

## Sistema de Avaliações

* FIX: Avaliações modulares
* FIX: Avaliações finais
* NEW: Avaliações de candidatura

## Gestão de Faltas

* FIX: Registo de faltas
* NEW: Justificação de faltas
* NEW: Aprovação ou rejeição de justificações

## Inquéritos

* NEW: Inquéritos aos módulos
* NEW: Inquéritos aos formadores
* NEW: Avaliação global da formação

## Exportação

* NEW: Exportação de cursos
* NEW: Exportação de módulos
* NEW: Exportação de candidatos aprovados
* FIX: Exportação de listagens administrativas

---

# 6. Metodologia de Desenvolvimento

O projeto foi desenvolvido recorrendo a uma abordagem iterativa baseada em sprints.

Durante o desenvolvimento foram utilizadas ferramentas de controlo de versões e gestão de tarefas, nomeadamente GitHub e Jira,
permitindo acompanhar a evolução do projeto, corrigir erros identificados e implementar melhorias contínuas.

Foram concluídas mais de uma centena de tarefas, incluindo desenvolvimento de novas funcionalidades, correção de bugs, melhorias de interface e otimizações do sistema.

---

# 7. Testes Realizados

Foram efetuados testes funcionais a todas as áreas principais da aplicação:

* Autenticação
* Gestão de utilizadores
* Gestão de cursos
* Gestão de turmas
* Gestão de módulos
* Gestão de candidaturas
* Sistema de avaliações
* Sistema de faltas
* Inquéritos
* Exportação de dados

Foram ainda corrigidos diversos problemas identificados durante a fase de testes finais, garantindo a estabilidade da versão entregue.

---

# 8. Conclusão

O Portal Upskill permitiu consolidar conhecimentos adquiridos ao longo da formação, aplicando conceitos de desenvolvimento web,
bases de dados, arquitetura por camadas, autenticação, autorização e gestão de informação.

O projeto resultou numa aplicação funcional e completa para apoio à gestão de formação, disponibilizando diferentes experiências de utilização para candidatos,
formandos, formadores, coordenadores e administradores.

A solução desenvolvida cumpre os requisitos funcionais definidos e constitui uma base sólida para futuras evoluções e melhorias.

---

# 9. Melhorias Futuras


Foram identificadas as seguintes funcionalidades que poderão ser implementadas numa futura evolução da plataforma:

## Gestão Académica

* Emissão automática de certificados de conclusão de curso com média final.
* Emissão de certificados detalhados com discriminação das classificações por módulo.
* Inclusão de novas etapas no ciclo de vida do formando, como acompanhamento de estágio e integração profissional.

## Processo de Candidatura

* Separação entre o registo de candidato e a candidatura a cursos, permitindo o registo mesmo quando não há cursos aberto.
* Expansão da progressão do candidato para incluir fases adicionais do processo de seleção.

## Calendário e Planeamento

* Inclusão de salas de aula na visualização do calendário.
* Integração automática dos feriados nacionais portugueses nos calendários.
* Melhoria da interface de criação e gestão de aulas.
* Possibilidade de edição de eventos por coordenadores e formadores, sujeita a aprovação administrativa.

## Comunicação e Notificações

* Implementação de um centro de notificações interno para alertas e comunicações relevantes aos utilizadores.

## Digitalização de Processos

* Integração de folhas de presenças digitais com recolha de assinatura eletrónica.

## Integrações Externas

* Integração com plataformas externas utilizadas pelo programa Upskill para realização de testes e avaliações.

## Inteligência Artificial

* Exploração de ferramentas de Inteligência Artificial para apoio à análise e seleção de candidatos, bem como e-mail de feedback automático.

## Experiência de Utilização

* Implementação de temas visuais alternativos (modo claro e modo escuro).
* Melhorias contínuas de acessibilidade e usabilidade da plataforma.
