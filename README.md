# Тествое задание по созданию REST API для игры в крестики нолики

## Задание:
Спроектируйте и реализуйте REST API для игры в крестики нолики

## Описание реализованного REST API
Созданный Web API реализует 4 запроса: 
+ GET - возвращает все ходы из БД
+ GET/id - возвращает ход по указанному id в БД
+ POST - добавляет ход в БД
+ DELETE/id - удаляет по указаному id ход из БД

### Реализованный REST API работает с SQLite
В БД хранится таблица с 5 полями
+ id - хранит id хода
+ Type - хранит тип хода крестик или нолик
+ x - хранит координату x
+ y - хранит координату y 
+ GameId - хранит id игры для данного хода