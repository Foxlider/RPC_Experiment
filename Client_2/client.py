import grpc
import hello_pb2
import hello_pb2_grpc


def run():
    with grpc.insecure_channel('192.168.133.166:8081') as channel:
        stub = hello_pb2_grpc.SayStub(channel)
        response = stub.Send(hello_pb2.SayRequest(name='B4tiste'))
    print("Client received: " + response.message)


if __name__ == '__main__':
    run()
