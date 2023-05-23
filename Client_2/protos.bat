python -m grpc_tools.protoc -I..\protos\ --python_out=. --grpc_python_out=. hello.proto
python -m grpc_tools.protoc -I..\protos\ --python_out=. --grpc_python_out=. transaction.proto
python -m grpc_tools.protoc -I..\protos\ --python_out=. --grpc_python_out=. basic.proto
python -m grpc_tools.protoc -I..\protos\ --python_out=. --grpc_python_out=. card.proto
python -m grpc_tools.protoc -I..\protos\ --python_out=. --grpc_python_out=. user.proto