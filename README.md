# DESAFIO_Escola-ALF
## Descrição do projeto
 Neste repositório há uma API RESTful criada com o intuito de responder a um desafio de um processo seletivo.
 A API foi desenvolvida com a linguagem de programação C#, utilizando o editor de código-fonte Visual Studio Code. 
 Para a disponibilização dos dados foi utilizado o Framework ASP.NET Core.
 Para criar as requisições foi utilizada a ferramenta Postman, que tem como objetivo testar serviços de WEB APIs por meio do envio de requisições HTTP, sendo possível avaliar as respostas das requisições. 

## Critérios
 ### O Desafio

 A escola Alf aplica provas de múltipla escolha para os alunos. A nota do aluno na prova é determinada pela média ponderada das questões com os pesos de cada questão. Cada questão correta soma 1 ponto multiplicada pelo peso e cada questão errada 0. A nota final é a média aritmética das notas de todas as provas.

 ### Requisitos obrigatórios:

 Crie uma API HTTP que permita à escola: 

 - Cadastrar o gabarito de cada prova;
 - Cadastrar as respostas de cada aluno para cada prova;
 - Verificar a nota final de cada aluno;
 - Listar os alunos aprovados;

 Restrições
 - A nota total da prova é sempre maior que 0 e menor que 10.
 - A quantidade máxima de alunos é 100.
 - O peso de cada questão é sempre um inteiro maior que 0.
 - Os alunos aprovados tem média de notas maior do que 7.
 - A entrada e saída de dados deverá ser em JSON.

## Como rodar a aplicação
 Para executar a API através do Visual Studio Code, basta abrir o Terminal com a combinação de teclas `Ctrl + Shift + '`, selecionar a pasta "EscolaAlf_API" com o comando `cd` e a tecla `TAB` e digitar o seguinte comando:
 ```
 dotnet run
 ```
 ou
 ```
 dotnet watch run
 ```

## Exemplo das tabelas
 ![](IMG/TablesExample.png)

# Funcionamento da API
Este tópico tem a função de explicar como efetuar a comunicação com a API, através da apresentação dos Endpoints. Também há a demonstração dos recursos usados no código para efetuar as restrições citadas no desafio.
Toda entrada e saída de dados é em JSON.
## Endpoints
### Student (Estudante)
Obter todos os estudantes:
```
"name": "Get",
"request": {
    "method": "GET",
    "url": {
        "raw": "https://localhost:5001/Student"
    }
}
```
Obter o estudante pelo id:
```
"name": "GetById",
"request": {
    "method": "GET",
    "url": {
        "raw": "https://localhost:5001/Student/id=1"
    }
}
```
Postar um estudante:
```
"name": "Post",
"request": {
    "method": "POST",
    "body": {
        "mode": "raw",
        "raw": "{\r\n    \"name\": \"Eduarda\",\r\n    \"birthdate\": \"2003-09-19T00:00:00\"\r\n}"
    },
    "url": {
        "raw": "https://localhost:5001/Student/"
    }
}
```
Editar um estudante:
```
"name": "Put",
"request": {
    "method": "PUT",
    "body": {
        "mode": "raw",
        "raw": "{\r\n    \"id\": 6,\r\n    \"name\": \"Eduardo\",\r\n    \"birthdate\": \"2003-09-19T00:00:00\"\r\n}"
        }
    },
    "url": {
        "raw": "https://localhost:5001/Student/id=6"
    }
```
Remover um estudante:
```
"name": "Delete",
"request": {
    "method": "DELETE",
    },
    "url": {
        "raw": "https://localhost:5001/Student/id=6"
    }
```
### Template (Gabarito)
Obter todos os gabaritos:
```
"name": "Get",
"request": {
    "method": "GET"
    },
    "url": {
        "raw": "https://localhost:5001/Template"
    }
```
Obter o gabarito pelo id:
```
"name": "GetById",
"request": {
    "method": "GET"
    },
    "url": {
        "raw": "https://localhost:5001/Template/id=1"
    }
```
Postar um gabarito:
```
"name": "Post",
"request": {
    "method": "POST",
    "body": {
        "mode": "raw",
        "raw": "{\r\n    \"testQuestionId\": 1,\r\n    \"optionId\": 1\r\n}"
        }
    },
    "url": {
        "raw": "https://localhost:5001/Template"
    }
```
Editar um gabarito:
```
"name": "Put",
"request": {
    "method": "PUT",
    "body": {
        "mode": "raw",
        "raw": "{\r\n    \"id\": 3,\r\n    \"testQuestionId\": 5,\r\n    \"optionId\": 1\r\n}"
        }
    },
    "url": {
        "raw": "https://localhost:5001/Template/id=3"
    }
```
Remover um gabarito:
```
"name": "Delete",
"request": {
    "method": "DELETE"
    },
    "url": {
        "raw": "https://localhost:5001/Template/id=2"
    }
```
### StudentReply (Resposta)
Obter todas as respostas:
```
"name": "Get",
"request": {
    "method": "GET"
    },
    "url": {
        "raw": "https://localhost:5001/StudentReply"
    }
```
Obter resposta pelo id:
```
"name": "GetById",
"request": {
    "method": "GET"
    },
    "url": {
        "raw": "https://localhost:5001/StudentReply/id=43"
    }
```
Postar uma resposta:
```
"name": "Post",
"request": {
    "method": "POST",
    "body": {
        "mode": "raw",
        "raw": "{\r\n    \"studentId\": 2,\r\n    \"testQuestionId\": 1,\r\n    \"optionId\": 1\r\n}"
        }
    },
    "url": {
        "raw": "https://localhost:5001/StudentReply"
    }
```
Editar uma resposta:
```
"name": "Put",
"request": {
    "method": "PUT",
    "body": {
        "mode": "raw",
        "raw": "{\r\n    \"id\": 44,\r\n    \"studentId\": 1,\r\n    \"testQuestionId\": 2,\r\n    \"testQuestion\": null,\r\n    \"optionId\": 14\r\n}"
        }
    },
    "url": {
        "raw": "https://localhost:5001/StudentReply/id=44"
    }
```
Remover uma resposta:
```
"name": "Delete",
"request": {
    "method": "DELETE",
    "body": {
        "mode": "raw",
        "raw": "{\r\n    \"studentId\": 5,\r\n    \"testQuestionId\": 2,\r\n    \"optionId\": 12\r\n}"
        }
    },
    "url": {
        "raw": "https://localhost:5001/StudentReply/id=16"
    }
```
### StudentGrade (Nota)
Obter todas as notas:
```
"name": "Get",
"request": {
    "method": "GET"
        }
    "url": {
        "raw": "https://localhost:5001/StudentGrade"
    }
```
Obter as notas pelo id do estudante:
```
"name": "GetByStudentId",
"request": {
    "method": "GET"
    },
    "url": {
        "raw": "https://localhost:5001/StudentGrade/studentid=2"
    }
```
Calcular e postar as notas de um estudante.
Este método utiliza um serviço de cálculo de notas no diretório `BackEnd/EscolaAlf_API/Data/Services/GradeCalculationService.cs`:
```
"name": "CalculateAndPostGrade",
"request": {
    "method": "POST",
    "body": {
        "mode": "raw",
        "raw": "{\r\n    \"studentId\": 2,\r\n    \"testQuestionId\": 1,\r\n    \"optionId\": 1\r\n}"
        }
    },
    "url": {
        "raw": "https://localhost:5001/StudentGrade/calculategrade_testid=2&studentid=2"
    }
```
Editar uma nota:
```
"name": "Put",
"request": {
    "method": "PUT",
    "body": {
        "mode": "raw",
        "raw": "{\r\n    \"id\": 11,\r\n    \"testId\": 1,\r\n    \"studentId\": 1,\r\n    \"grade\": 1.0\r\n}"
        }
    },
    "url": {
        "raw": "https://localhost:5001/StudentGrade/id=11"
    }
```
Remover uma nota:
```
"name": "Delete",
"request": {
    "method": "DELETE"
    },
    "url": {
        "raw": "https://localhost:5001/StudentGrade/id=4"
    }
```
### StudentSituation (Situação)
Obter todas as situações:
```
"name": "Get",
"request": {
    "method": "GET"
    },
    "url": {
        "raw": "https://localhost:5001/StudentSituation"
    }
```
Obter os estudantes aprovados:
```
"name": "GetApproved",
"request": {
    "method": "GET"
    },
    "url": {
        "raw": "https://localhost:5001/StudentSituation/approved"
    }
```
Calcular e postar a situação de um estudante.
Este método utiliza um serviço de cálculo de médias no diretório `BackEnd/EscolaAlf_API/Data/Services/AverageCalculationService.cs`:
```
"name": "CalculateAndPostAverage",
"request": {
    "method": "POST",
    "body": {
        "mode": "raw",
        "raw": "{\r\n    \"studentId\": 1,\r\n    \"average\": 0,\r\n    \"approval\": false\r\n}"
        }
    },
    "url": {
        "raw": "https://localhost:5001/StudentSituation/calculateaverage_studentid=1"
    }
```
Editar uma situação:
```
"name": "Put",
"request": {
    "method": "PUT",
    "body": {
        "mode": "raw",
        "raw": "{\r\n    \"id\": 6,\r\n    \"studentId\": 1,\r\n    \"average\": 8.0,\r\n    \"approval\": true\r\n}"
        }
    },
    "url": {
        "raw": "https://localhost:5001/StudentSituation/id=6"
    }
```
Remover uma situação:
```
"name": "Delete",
"request": {
    "method": "DELETE",
    "body": {
        "mode": "raw",
        "raw": "{\r\n    \"studentId\": 1,\r\n    \"average\": 0,\r\n    \"approval\": false\r\n}"
        }
    },
    "url": {
        "raw": "https://localhost:5001/StudentSituation/id=1"
    }
```
