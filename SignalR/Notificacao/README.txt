Instalar o SignalR pelo nuget ou pelo manager console

Install-Package Microsoft.AspNET.SignalR

neste caso como � projeto MVC, basta incluir o "app.MapSignalR();" na classe Startup.Auth

Criar a classe Hub

neste caso como � projeto MVC vamos utilizar o _layout.cshtml

incluir o script que ser� criado em tempo de execucao, no html, neste caso _layout.cshtml
<script src="/signalr/hubs"></script>