# RPC_Experiment
Johan Planchon

## `client_1 --help`
```sh
The best client to play, manage cards and manage users

Usage: client_1 [OPTIONS] <COMMAND>

Commands:
  say    Say something
  users  Manage the remote users
  help   Print this message or the help of the given subcommand(s)

Options:
      --users-host <USERS_HOST>  [env: GRPC_USER_HOST=] [default: http://0.0.0.0:50051]
      --hello-host <HELLO_HOST>  [env: GRPC_HELLO_HOST=] [default: http://0.0.0.0:50051]
  -h, --help                     Print help
  -V, --version                  Print version
```

## `client_1 say --help`
```sh
Say something

Usage: client_1 say --content <CONTENT>

Options:
  -c, --content <CONTENT>  
  -h, --help               Print help
  -V, --version            Print version
```

## `client_1 users --help`
```sh
Manage the remote users

Usage: client_1 users <COMMAND>

Commands:
  get     Get a remote users (unimplemented)
  create  Create a users
  list    List the remote users (unimplemented)
  help    Print this message or the help of the given subcommand(s)

Options:
  -h, --help     Print help
  -V, --version  Print version
```