# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
"""Client and server classes corresponding to protobuf-defined services."""
import grpc

import hello_pb2 as hello__pb2


class SayStub(object):
    """service which can be executed
    """

    def __init__(self, channel):
        """Constructor.

        Args:
            channel: A grpc.Channel.
        """
        self.Send = channel.unary_unary(
                '/hello.Say/Send',
                request_serializer=hello__pb2.SayRequest.SerializeToString,
                response_deserializer=hello__pb2.SayResponse.FromString,
                )


class SayServicer(object):
    """service which can be executed
    """

    def Send(self, request, context):
        """function which can be called
        """
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')


def add_SayServicer_to_server(servicer, server):
    rpc_method_handlers = {
            'Send': grpc.unary_unary_rpc_method_handler(
                    servicer.Send,
                    request_deserializer=hello__pb2.SayRequest.FromString,
                    response_serializer=hello__pb2.SayResponse.SerializeToString,
            ),
    }
    generic_handler = grpc.method_handlers_generic_handler(
            'hello.Say', rpc_method_handlers)
    server.add_generic_rpc_handlers((generic_handler,))


 # This class is part of an EXPERIMENTAL API.
class Say(object):
    """service which can be executed
    """

    @staticmethod
    def Send(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/hello.Say/Send',
            hello__pb2.SayRequest.SerializeToString,
            hello__pb2.SayResponse.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)