# RPC_Experiment

- Johan Planchon ([Client_1](./Client_1/README.md))
- Julo Caposiena ([Server_2](./Server_2/README.md))
- Batiste LALOI ([Client_2](./Client_2/README.md))
- Alexis LONCHAMBON ([Server_1](./Server_1/README.md))

## Première approche théorique de conception de l'architecture logicielle

```mermaid
flowchart TB
    %%classDef clients fill:#b5b2f7;
    classDef clients color:#a0a0a0,stroke:#b5b2f7,stroke-width:2px;
    %% classDef servers fill:#f7b2b2;
    classDef servers color:#a0a0a0,stroke:#f7b2b2,stroke-width:2px;
    %% classDef services fill:#b2f7ce;
    classDef services color:#a0a0a0,stroke:#b2f7ce,stroke-width:2px;
    %% classDef storages fill:#f7e9b2;
    classDef storages color:#a0a0a0,stroke:#f7e9b2,stroke-width:2px;

    %% Déclaration
    %% Server
    RustServer((gRPC Server - Rust)):::servers
    RustStorage(Storage - RAM):::storages
    NETServer((gRPC Server - .NET)):::servers
    NETStorage(Storage - RAM):::storages

    %% Services
    UserService[User Service]:::services
    CardService[Card Service]:::services
    RoomService[Game Room Service]:::services
    HistoryService[History Service]:::services

    %% Clients
    Clients[\Clients/]:::clients
    RustClient[/Rust Client\]:::clients
    PythonClient[/Python Client\]:::clients

    %% Relations
    %% Services
    UserService ---|Manage users| RustServer
    CardService ---|Manage cards| RustServer
    HistoryService ---|Manage History| RustServer
    RoomService ---|Manage game rooms| NETServer

    %% Stockage
    RustServer -.-|Data Saves| RustStorage
    NETServer -.-|Data Saves| NETStorage

    %% Relations inter-serveurs
    RustServer -.-|gRPC| NETServer

    %% Clients
    RustClient -.- Clients
    PythonClient -.- Clients
    Clients ---|Python/Rust| RustServer
    Clients ---|Python/Rust| NETServer
```

Mise en place d'un serveur en Rust et de deux clients en Python et Rust. Le serveur Rust gère les utilisateurs, les cartes et les historiques de transactions. Le serveur .NET gère les salles de jeu. Les deux serveurs communiquent entre eux via gRPC.

Si on utilise trois ordinateurs connectés au même réseau wifi, on peut lancer le serveur Rust, le client Python et le client Rust sur trois ordinateurs différents. Le client Python et le client Rust peuvent communiquer avec le serveur Rust sur la base d'une simple interaction de type "Hello [Nom du client]".

### Voila par exemple le l'éxécution du client Rust : 

![Exécution du client Rust](https://cdn.discordapp.com/attachments/959542735516352562/1110659994753445918/image.png)

- Terminal 1 : Serveur Rust gRPC

- Terminal 2 : Client_1 Rust

- Terminal3 : Utilisation de la commande `ss -lntup` pour voir les ports utilisés par les processus et voir que le serveur Rust écoute sur le port 50051

### Voici l'éxécution du client Python :

![Exécution du client Python](https://cdn.discordapp.com/attachments/1110462911127748668/1110662812512043099/image.png)

- Terminal 1 : Serveur de test en Python

- Terminal 2 : Client_2 Python qui se connecte au serveur de test

## Diagramme de séquence de l'interaction avec une salle de jeu

![Diagramme de séquence de l'interaction avec une salle de jeu](https://kroki.io/plantuml/png/eNqFUktuwjAQ3fsUo3TBpizIkkUFohX7RBxg6kyokWNH_qAep1vOkYt1bMK_olIWVuZ9PV74gC7ETguUwTrYzAA9FJugtPIYKDqYFadZ-TArC9EzX0nVowlQVxlRk9unaRV9uAWsqzoj1tgRVNZ2kLBKUiEEW0_fWGIO79ShaQj4k244kINoCDxqnf_tKAp2YjDLzWGVIKDxFpCcpqPeyppWuQ6DsiYrHk8PggzfzJ7DXwFDIBOYZGO-AQ5e3gfvLU8c7awyjcvZ8iXQdewlCwRoJswefp7Gr9XWYBoNh0-mHKUA9yQZHb_HJB7OHUq4K4HZ68pGCGO5g1PbrwC2TYt76dlj64gMs5djSV584jfkTy6XPcHVoiYj8FKQpx9tSzJE7j856yR8WheXSG_tqicTKjJ7y9U026muZ5IHiVpGPRzu6v0FxTiGvCzzPyQIsSDTpPf_C7wcAdU=)


## Diagramme de classe des données

```mermaid
classDiagram
    User --> Transaction
    Card --> Transaction
    User --> Game
    Card --> Game
    Transaction <.. TransactionType

    class User {
      +int id
      +String name
    }

    class Card {
        +int id
        +String name
        +int health_points
        +int attack
        +int defense
    }

    class TransactionType {
        <<Enumeration>>
        SELL
        BUY
    }

    class Transaction {
        +int id
        +TransactionType transaction_type
        +int user_id
        +int card_id
    }

    class Game {
        +int id
        +int user1_id
        +int user2_id
        +int card1_id
        +int card2_id
    }
```