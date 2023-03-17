# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Muitos usuários têm dificuldade em gerenciar suas senhas e acabam utilizando a mesma senha em várias contas, o que pode colocar a segurança em risco. Além disso, as senhas são frequentemente esquecidas, o que pode causar a perda de acesso à conta e exigir a criação de novas senhas, que podem ser difíceis de lembrar.
 
Criar um sistema de salvar senhas para usuários que permita que eles armazenem todas as suas senhas de maneira segura e fácil de acessar. Esse sistema pode ser um aplicativo de navegador que criptografa as senhas do usuário e as armazena em um cofre seguro na nuvem ou no dispositivo do usuário. O sistema também pode incluir recursos de gerenciamento de senha, como geradores de senhas seguros e lembretes de senha expirada.
 
Com um sistema de salvar senha, os usuários podem gerenciar suas senhas de maneira mais eficaz e segura, sem a necessidade de memorizar ou reutilizar. Isso pode ajudar a proteger suas informações pessoais e financeiras de hackers e outros cibercriminosos. Além disso, os usuários podem economizar tempo ao não precisar redefinir senhas esquecidas ou criar novas senhas seguras a cada vez que se inscreverem em um novo serviço online.


## Personas

Pedro Paulo tem 26 anos, é arquiteto recém-formado e autônomo. Pensa em se desenvolver profissionalmente através de um mestrado fora do país, pois adora viajar, é solteiro e sempre quis fazer um intercâmbio. Está buscando uma agência que o ajude a encontrar universidades na Europa que aceitem alunos estrangeiros.

Enumere e detalhe as personas da sua solução. Para tanto, baseie-se tanto nos documentos disponibilizados na disciplina e/ou nos seguintes links:

> **Links Úteis**:
> - [Rock Content](https://rockcontent.com/blog/personas/)
> - [Hotmart](https://blog.hotmart.com/pt-br/como-criar-persona-negocio/)
> - [O que é persona?](https://resultadosdigitais.com.br/blog/persona-o-que-e/)
> - [Persona x Público-alvo](https://flammo.com.br/blog/persona-e-publico-alvo-qual-a-diferenca/)
> - [Mapa de Empatia](https://resultadosdigitais.com.br/blog/mapa-da-empatia/)
> - [Mapa de Stalkeholders](https://www.racecomunicacao.com.br/blog/como-fazer-o-mapeamento-de-stakeholders/)
>
Lembre-se que você deve ser enumerar e descrever precisamente e personalizada todos os clientes ideais que sua solução almeja.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Anderson Oliveira         |Um modo de gerar e administrar senhas criadas para o trabalho | Para não perder tempo de trabalho criando senhas |
|Alexandra de Souza Maroca | Um meio para guardar suas senhas num único lugar |Para não ter que precisar realizar processos de recuperação de senhas em diferentes sites, com os quais tem dificuldade |
|Eleonora Silva Campos  | Ter um registro atualizado com as senhas dos diferentes perfis profissionais que administra  | Não esquecer de fazê-las             |
|Tais Lopes Schneider      | Ter um meio para armazenar senhas e dados específicos, ligados às contas dessas senhas  | Permitir que possam administrar contas |
|William Sabino  | Um meio rápido para acessar suas múltiplas senhas. | Para não precisar automatizar senhas em sites cujos mecanismos de segurança desconhece |


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| O usuário poderá se registrar no site | ALTA | 
|RF-002| O usuário deve ser capaz de gerenciar perfis  | ALTA |
|RF-003| O sistema precisa ser capaz de permitir que o usuário troque a senha master | ALTA |
|RF-004| O usuário deve ser capaz de gerenciar campos personalizados em cada perfil | MÉDIA |
|RF-005| O sistema deve fornecer um gerador de senhas | BAIXA |
|RF-006| O usuário deve ser capaz de gerenciar plataformas em cada perfil | ALTA |
|RF-007| O usuário deve ser capaz de efetuar login no site | ALTA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O site deve ser publicado em um ambiente acessível publicamente na Internet (Repl.it, GitHub Pages, Heroku) | ALTA | 
|RNF-002| O site deverá ser responsivo permitindo a visualização em um celular de forma adequada |  ALTA | 
|RNF-003| O site deve ter bom nível de contraste entre os elementos da tela em conformidade |MÉDIA |
|RNF-004| O site deve ser compatível com os principais navegadores do mercado (Google Chrome, Firefox, Microsoft Edge) | ALTA |
|RNF-005| O site deve ter criptografia para as senhas dos usuários cadastrados (bcrypt) | ALTA |
|RNF-006| O site deve contar com cookies de login para segurança de sessão (jsonwebtoken) | ALTA |





## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|RE-01| O projeto deverá ser entregue no final do semestre letivo, não podendo extrapolar a data de 19/03/2023 |
|RE-02| O aplicativo deve se restringir às tecnologias básicas da Web no Backend |
|RE-03| A equipe não pode subcontratar o desenvolvimento do trabalho |



## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

![image](https://user-images.githubusercontent.com/81201021/225466632-f4b4dbcf-83e7-4ff2-bc86-da4f466b8d63.png)

