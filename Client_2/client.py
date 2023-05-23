import grpc
import hello_pb2
import hello_pb2_grpc
import datetime

ip = 'localhost'
port = '50051'

def run():
    with grpc.insecure_channel(f"{ip}:{port}") as channel:
        stub = hello_pb2_grpc.SayStub(channel)
        response = stub.Send(hello_pb2.SayRequest(name='B4tiste'))
    print("Client received: " + response.message + " at " + str(datetime.datetime.now()))


if __name__ == '__main__':
    run()
