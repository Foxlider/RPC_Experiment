use clap::Parser;

#[derive(Debug, Parser)]
#[clap(author, version, about, long_about = None)]
#[clap(propagate_version = true)]
#[clap(
    subcommand_required = true,
    arg_required_else_help = true
)]
pub struct App {
    #[clap(subcommand)]
    command: Option<Commands>,
}

#[derive(Debug, Parser)]
pub enum Commands {
    /// Manage the remote users
    #[clap(subcommand)]
    Users(UsersCommand),
}

#[derive(Debug, Parser)]
pub enum UsersCommand {
    /// List the remote users
    List
}