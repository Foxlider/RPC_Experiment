use tonic::{transport::Server, Request, Response, Status};
use hello::say_server::{Say, SayServer};
use hello::{SayResponse, SayRequest};

pub mod hello {
    tonic::include_proto!("hello");
}

#[derive(Debug, Default)]
pub struct HelloService {}

#[tonic::async_trait]
impl Say for HelloService {
    async fn send(&self,request:Request<SayRequest>) -> Result<Response<SayResponse>,Status> {
        Ok(Response::new(SayResponse{
            message:format!("hello {}", request.get_ref().name),
        }))
    }
}

#[tokio::main]
async fn main() -> Result<(), Box<dyn std::error::Error>> {
    println!("Launching gRPC server...");

    let address = "[::1]:8081".parse().unwrap();
    let hello_service = HelloService::default();

    Server::builder()
        .add_service(SayServer::new(hello_service))
        .serve(address)
        .await?;

    Ok(())
}