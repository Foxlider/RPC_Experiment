use clap::Parser;
use cli::{Commands, UsersCommand};
use client_1::{hello::HelloClient, user::UserClient};

mod cli;

#[tokio::main]
async fn main() -> eyre::Result<()> {
    color_eyre::install()?;
    let app = cli::App::parse();

    match app.command {
        Commands::Users(command) => match command {
            UsersCommand::Create { id, name } => {
                let mut user_client = UserClient::new(&app.users_host).await?;
                user_client.create_user(id, name).await?;
            }
            #[allow(clippy::unimplemented)]
            _ => unimplemented!(),
        },
        Commands::Say { content } => {
            let mut hello_client: HelloClient = HelloClient::new(&app.hello_host).await?;
            hello_client.say(content).await?;
        }
    }

    Ok(())
}
