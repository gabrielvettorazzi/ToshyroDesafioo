# Toshyro
Máquina de Fornecedor Console App
Este é um aplicativo de máquina de fornecedor simples, desenvolvido em C#, que simula a interação com uma máquina de venda automática. Os clientes podem inserir moedas, solicitar produtos e obter alteração.

Pré-requisitos
Certifique-se de ter o seguinte instalado em seu sistema:

Git
.NET SDK
Como Executar o Aplicativo
Clone o Repositório:

bash
Copy code
git clone https://github.com/seu-usuario/maquina-fornecedor.git
Navegue para o Diretório:

bash
Copy code
cd maquina-fornecedor
Execute o Aplicativo:

bash
Copy code
dotnet run
O aplicativo será iniciado e você verá a mensagem "Bem-vindo à Máquina de Fornecedor!".

Como Interagir com o Aplicativo
Inserir Moedas:

Digite os valores das moedas separados por espaço. Por exemplo: 0.25 1.00 0.10.
Solicitar Produto:

Digite o nome do produto desejado. Por exemplo: Coca-Cola.
Obter Alteração:

Digite CHANGE para obter a alteração.
Exemplos de Uso
Inserir moedas e solicitar um produto:

Entrada:
bash
Copy code
0.50 1.00 Coca-Cola
Saída:
Copy code
Coca-Cola = 0.00
Inserir moedas, solicitar um produto e obter a alteração:

Entrada:
bash
Copy code
1.00 Água CHANGE
Saída:
Copy code
Água = 0.00
0.25 0.10 0.05
