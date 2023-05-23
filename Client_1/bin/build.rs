fn main() {
    tonic_build::compile_protos("../../protos/hello.proto").unwrap();
}
