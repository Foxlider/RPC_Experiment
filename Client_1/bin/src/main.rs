use hello::{say_client::SayClient, SayRequest};
use std::env::var;

pub mod hello {
    tonic::include_proto!("hello");
}

#[tokio::main]
async fn main() -> eyre::Result<()> {
    color_eyre::install()?;

    let mut client =
        SayClient::connect(var("GRPC_HOST").unwrap_or_else(|_| "http://0.0.0.0:50051".to_string())).await?;

    let request = tonic::Request::new(SayRequest {
        name: "PiNg".to_string()
    });

    let response = client.send(request).await?;

    println!("RESPONSE={:?}", response);

    Ok(())
}
