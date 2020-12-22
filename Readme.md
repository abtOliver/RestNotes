
# Coding Challenge - Notizen REST API

Das Programm stellt eine Notizen REST API über
<http://localhost:5000/api/RestNotes> zur Verfügung.

Die Notizen werden im Speicher gehalten und sind nur verfügbar
solange das Programm läuft.

## API Dokumentation

Eine interaktive Dokumentation kann bei laufendem Programm auch über
<http://localhost:5000/swagger/index.html> aufgerufen werden.

### Notiz JSON Schema

```
{
  "id": 0,
  "text": "string"
}
```

### Funktionen

#### Übersicht

| Funktion          | Request-URL                                | HTTP-Methode |
|-------------------|--------------------------------------------|--------------|
| Notizen auflisten | <http://localhost:5000/api/RestNotes>      | GET          |
| Neue Notiz        | <http://localhost:5000/api/RestNotes>      | POST         |
| Notiz abrufen     | <http://localhost:5000/api/RestNotes/{id}> | GET          |
| Notitz ändern     | <http://localhost:5000/api/RestNotes/{id}> | PUT          |

#### Notizen auflisten

| Request         |                                                                                       |
|-----------------|---------------------------------------------------------------------------------------|
| HTTP - Method   | GET                                                                                   |
| Curl-Aufruf     |```curl -X GET "http://localhost:5000/api/Notes" -H  "accept: text/plain"```|
| Body            | *leer*                                                                                |

| Response        |                                                                                       |
|-----------------|---------------------------------------------------------------------------------------|
| Response Code   | 200 SUCCESS                                                                           |
| Body            | JSON Array mit Notizen                                                                |

#### Neue Notiz

| Request         |                                                                                       |
|-----------------|---------------------------------------------------------------------------------------|
| HTTP - Method   | POST                                                                                  |
| Curl-Aufruf     |```curl -X POST "http://localhost:5000/api/Notes" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":0,\"text\":\"string\"}"```|
| Body            | JSON Objekt mit der neuen Notiz<br>Die Id wird ignoriert                              |

| Response        |                                                                                       |
|-----------------|---------------------------------------------------------------------------------------|
| Response Code   | 201 CREATED                                                                           |
| Response Header | Location: http://localhost:5000/api/Notes/{id}                                        |
| Body            | JSON Objekt mit der neu angelegter Notiz<br>Die Id wird vom System vergeben           |

#### Notiz abrufen

| Request         |                                                                                       |
|-----------------|---------------------------------------------------------------------------------------|
| HTTP - Method   | GET                                                                                   |
| Curl-Aufruf     |```curl -X GET "http://localhost:5000/api/Notes/{id}" -H  "accept: */*"```  |
| Body            | *leer*                                                                                |

##### wenn erfolgreich:
| Response        |                                                                                       |
|-----------------|---------------------------------------------------------------------------------------|
| Response Code   | 200 SUCCESS                                                                           |
| Body            | JSON Objekt mit der abgefragten Notiz                                                     |

##### wenn Notiz nicht gefunden:
| Response        |                                                                                       |
|-----------------|---------------------------------------------------------------------------------------|
| Response Code   | 404 NOT FOUND                                                                         |
| Body            | *leer*                                                                                |

#### Notiz ändern

| Request         |                                                                                       |
|-----------------|---------------------------------------------------------------------------------------|
| HTTP - Method   | PUT                                                                                   |
| Curl-Aufruf     |```curl -X PUT "http://localhost:5000/api/Notes/{id}" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":1,\"text\":\"string\"}"```|
| Body            | JSON Objekt mit den neuen Notizwerten<br>Die Id wird überprüft, darf aber auch 0 sein |

##### wenn erfolgreich:
| Response        |                                                                                       |
|-----------------|---------------------------------------------------------------------------------------|
| Response Code   | 204 NO CONTENT                                                                        |
| Body            | *leer*                                                                                |

##### wenn Notiz Id und Pfad Id nicht übereinstimmen:
| Response        |                                                                                       |
|-----------------|---------------------------------------------------------------------------------------|
| Response Code   | 400 BAD REQUEST                                                                       |
| Body            | *leer*                                                                                |

##### wenn Notiz nicht gefunden:
| Response        |                                                                                       |
|-----------------|---------------------------------------------------------------------------------------|
| Response Code   | 404 NOT FOUND                                                                         |
| Body            | *leer*                                                                                |

