## Запуск через .NET CLI

`dotnet run --project src/LoanCalculator.Web`

Интерфейс: http://localhost:5000


## Запуск в Docker

```ps
docker build -t loan-calculator .
docker run --rm -it -p 8080:8080 loan-calculator
```

Интерфейс: http://localhost:8080


## Запуск юнит-тестов

`dotnet test`


## Скриншоты

<img width="892" height="510" alt="image" src="https://github.com/user-attachments/assets/0e77cc8e-b30f-4b1b-9410-a758aca6df47" />
<img width="892" height="510" alt="image" src="https://github.com/user-attachments/assets/32515e89-8e6d-4aa7-bced-396a57c26ae2" />
<img width="1108" height="818" alt="image" src="https://github.com/user-attachments/assets/ebd9aee0-d898-43d2-8b58-38cae6dba5c3" />
<img width="1108" height="663" alt="image" src="https://github.com/user-attachments/assets/f5b4c6eb-29d9-48a8-a77f-75ab0d08990a" />
