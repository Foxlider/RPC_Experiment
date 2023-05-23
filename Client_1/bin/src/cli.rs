use clap::Parser;

#[derive(Debug, Parser)]
#[clap(author, version, about, long_about = None)]
#[clap(propagate_version = true)]
#[clap(
    subcommand_required = true,
    arg_required_else_help = true
)]
pub struct App {
    #[arg(long)]
    #[clap(env = "GRPC_USER_HOST", default_value = "http://0.0.0.0:50051")]
    pub users_host: String,
    #[arg(long)]
    #[clap(env = "GRPC_HELLO_HOST", default_value = "http://0.0.0.0:50051")]
    pub hello_host: String,

    #[clap(subcommand)]
    pub command: Commands,
}

#[derive(Debug, Parser)]
pub enum Commands {
    /// Say something
    Say {
        #[arg(short = 'c', long)]
        content: String,
    },
    /// Manage the remote users
    #[clap(subcommand)]
    Users(UsersCommand),
}

#[derive(Debug, Parser)]
pub enum UsersCommand {
    /// Get a remote users
    Get,
    /// Create a users
    Create,
    /// List the remote users
    List
}