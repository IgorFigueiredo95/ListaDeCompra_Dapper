# ListaDeCompra_Dapper
#Estudo - Aplicação para controle de lista de compras  por usuário utilizando Dapper

<h1>Layouts</h1> 
<h5 width>Tela principal</h5>
<span><img src="https://github.com/IgorFigueiredo95/ListaDeCompra_Dapper/blob/master/Assets/Tela_Principal.PNG" alt="Tela principal" width=50% ><img src="https://github.com/IgorFigueiredo95/ListaDeCompra_Dapper/blob/master/Assets/Tela_logada.PNG" alt="Tela logada" width=50%></span>

<h5>Lista de Compras</h5>
<img src="https://github.com/IgorFigueiredo95/ListaDeCompra_Dapper/blob/master/Assets/Lista_Compras.png" alt="Lista de compras" width=60%>


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





