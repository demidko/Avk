## Avk
Кроссплатформенная утилита анализирует активность ВК в фоновом режиме и делает предположения кто с кем общается.
### Как запускать проект напрямую из исходного кода?
1. Установить [.NET](https://dot.net)
2. В директории репозитория выполнить: `dotnet run -- [login] [password]`.  
При последующих запусках передавать логин и пароль не нужно.
### Управляющие команды
* Проанализировать активность человека `analyze [ссылка]`
* Вывести список анализируемых людей в фоновом режиме (по умолчанию все друзья)  `analytic list`
* Прекратить анализировать человека  `stop analysis [ссылка]`
### TODO
* WebAssembly PWA

