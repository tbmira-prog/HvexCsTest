# HvexCsTest
![image](https://user-images.githubusercontent.com/118115911/208239826-a8ab36de-9142-4469-bc3a-a8ff137f3656.png)

## Descrição do teste
O teste consiste em implementar uma aplicação web backend Rest Api, no qual o usuário deseja realizar ensaios no seu transformador e posteriormente emitir relatórios dos ensaios realizados.

## Regras de negócio
- Um usuário possui no mínimo zero ou muitos transformadores
- Cada transformador pode ter zero ou muitos ensaios de rotina. 
- Para emitir um relatório deve seguir a seguinte regra:
  - Um transformador que possui um ensaio pode emitir um ou muitos relatórios;
  - Um relatório contendo um ensaio pertence a um ou muitos transformadores;
  - Um transformador com relatório emitido possui um único ensaio.

## Regras de implementação
- Devem ser implementados os cruds das entidades listadas no Modelo de entidade relacionamento;
- Banco de dados NoSQL MongoDB;
- Atentar para o versionamento de código, tentar não escrever códigos direto na main/master e utilizar os comandados básicos do GIT. Criar branchs por funcionalidades;
- Criar os campos de default TimeStamp;
- Não é necessário implementar o Login.

## Diferenciais
- Utilização de docker
- Injeção de dependência
