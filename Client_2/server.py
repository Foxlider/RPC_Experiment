import grpc
from concurrent import futures
import hello_pb2
import hello_pb2_grpc
import datetime


class Say(hello_pb2_grpc.SayServicer):

    def Send(self, request, context):
        print("Server received: " + request.name + " at " + str(datetime.datetime.now()))
        return hello_pb2.SayResponse(message="Hello, " + request.name)


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    hello_pb2_grpc.add_SayServicer_to_server(Say(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    server.wait_for_termination()


if __name__ == '__main__':
    serve()
