# RPC_Experiment

- Johan Planchon ([Client_1](./Client_1/README.md))
- Julo Caposiena ([Server_2](./Server_2/README.md))
- Batiste LALOI ([Client_2](./Client_2/README.md))
- Alexis LONCHAMBON ([Server_1](./Server_1/README.md))

## Schéma de l'architecture

```mermaid
flowchart TB
    classDef clients fill:#b5b2f7;
    classDef servers fill:#f7b2b2;
    classDef services fill:#b2f7ce;
    classDef storages fill:#f7e9b2;

    %% Déclaration
    %% Server
    RustServer((gRPC Server - Rust\nJulien)):::servers
    RustStorage(Storage - RAM):::storages
    NETServer((gRPC Server - .NET\nAlexis)):::servers
    NETStorage(Storage - RAM):::storages

    %% Services
    UserService[User Service]:::services
    CardService[Card Service]:::services
    RoomService[Game Room Service]:::services
    HistoryService[History Service]:::services

    %% Clients
    Clients[\Clients/]:::clients
    RustClient[/Rust Client - Johan\]:::clients
    PythonClient[/Python Client - B4tiste\]:::clients

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

