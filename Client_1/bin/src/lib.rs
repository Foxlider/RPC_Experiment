pub mod cli;

pub mod user {
    mod proto {
        tonic::include_proto!("users");
    }

    #[derive(Debug)]
    pub struct UserClient {
        client: proto::users_client::UsersClient<tonic::transport::Channel>,
    }

    impl UserClient {
        pub async fn new(host: impl AsRef<str>) -> eyre::Result<Self> {
            Ok(Self {
                client: proto::users_client::UsersClient::connect(host.as_ref().to_string()).await?
            })
        }

        pub async fn create_user(&mut self, id: i32, name: impl AsRef<str>) -> eyre::Result<()> {
            let request = tonic::Request::new(proto::User {
                id,
                name: name.as_ref().to_string()
            });
            let response = self.client.create(request).await?;

            dbg!(response);

            Ok(())
        }
    }

}

pub mod hello {
    mod proto {
        tonic::include_proto!("hello");
    }

    #[derive(Debug)]
    pub struct HelloClient {
        client: proto::say_client::SayClient<tonic::transport::Channel>,
    }

    impl HelloClient {
        pub async fn new(host: impl AsRef<str>) -> eyre::Result<Self> {
            Ok(Self {
                client: proto::say_client::SayClient::connect(host.as_ref().to_string()).await?
            })
        }

        pub async fn say(&mut self, content: impl AsRef<str>) -> eyre::Result<()> {
            let request = tonic::Request::new(proto::SayRequest {
                name: content.as_ref().to_string()
            });
            let response = self.client.send(request).await?;

            dbg!(response);

            Ok(())
        }
    }

}