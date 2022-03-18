# ListaDeCompra_Dapper
#Estudo - Aplicação para controle de lista de compras  por usuário utilizando Dapper

<h2> Objetivo do Repositório</h2>
Este repositório foi criado com o objetivo de acompanhar o meu progresso pessoal no desenvolvimento de aplicações C# e praticar meus conhecimentos adquiridos em relação
a interfaces, boas práticas em nomeação de variáveis, persistência de dados atravpes do  Dapper, desenvolvimento assincrono e etc..

<h2> O projeto </h2>
O projeto <b>ListaDeCompra_Dapper</b> é uma aplicação para controle de lista de itens de usuários onde é possível cadastrar diversos itens por usuário,
consultar os itens e cadastrar novos usuários.<br><br>

Novas funcionalidades estão previstas para serem implementadas no código, conforme descrito na seção "objetivo do reposítório", esta aplicação é para aprendizagem de novas
técnicas e funcionalidades do C#. COnforme meus conhecimentos forem evoluindo, novos releases serão apresentados.

<h2> Estrutura atual da aplicação</h2>

A aplicação foi dividida em quatro partes com diferentes responsabilidades:<br>

<dl>
<dt>View</dt>
  <dd>Responsável pela exibição e coleta das informações dos usuários</dd>
<dt>Command</dt>
<dd>Responsável pela intermediação da comunicação entre o banco de dados e as solicitações feitas pela camada View.</dd>
<dt>Repository</dt>
<dd>Responsável em abstrair o acesso ao banco de dados em relação as camadas anteriores.</dd>
<dt>Model</dt>
<dd>Responsável em armazenar as classes utilizadas como models para o mapping do Dapper e armazenar as entidades principais da aplicação.</dd>
</dl>

<h1>Layouts</h1> 
<h3>Tela principal</h3>
![Tela principal](https://user-images.githubusercontent.com/96360281/158928527-4f083358-b8b2-4a66-ae17-bbf924564f6e.png)
Tela de cadastro ou acesso ao usuário.
<br>
<h3> Tela principal Logada</h3>
![image](https://user-images.githubusercontent.com/96360281/158929954-e06cba6d-bb44-46a0-bdba-fecd06d240ed.png)




