# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: hello.proto
"""Generated protocol buffer code."""
from google.protobuf import descriptor as _descriptor
from google.protobuf import descriptor_pool as _descriptor_pool
from google.protobuf import symbol_database as _symbol_database
from google.protobuf.internal import builder as _builder
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor_pool.Default().AddSerializedFile(b'\n\x0bhello.proto\x12\x05hello\"\x1a\n\nSayRequest\x12\x0c\n\x04name\x18\x01 \x01(\t\"\x1e\n\x0bSayResponse\x12\x0f\n\x07message\x18\x01 \x01(\t24\n\x03Say\x12-\n\x04Send\x12\x11.hello.SayRequest\x1a\x12.hello.SayResponseb\x06proto3')

_globals = globals()
_builder.BuildMessageAndEnumDescriptors(DESCRIPTOR, _globals)
_builder.BuildTopDescriptorsAndMessages(DESCRIPTOR, 'hello_pb2', _globals)
if _descriptor._USE_C_DESCRIPTORS == False:

  DESCRIPTOR._options = None
  _globals['_SAYREQUEST']._serialized_start=22
  _globals['_SAYREQUEST']._serialized_end=48
  _globals['_SAYRESPONSE']._serialized_start=50
  _globals['_SAYRESPONSE']._serialized_end=80
  _globals['_SAY']._serialized_start=82
  _globals['_SAY']._serialized_end=134
# @@protoc_insertion_point(module_scope)
