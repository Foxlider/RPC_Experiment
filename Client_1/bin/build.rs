use clap::CommandFactory;

#[path = "src/cli.rs"]
mod cli;

fn main() {
    tonic_build::compile_protos("../../protos/hello.proto").unwrap();
    tonic_build::compile_protos("../../protos/user.proto").unwrap();

    let out_dir = std::path::PathBuf::from(std::env::var_os("OUT_DIR").ok_or(std::io::ErrorKind::NotFound).unwrap());
    let target_dir = out_dir.parent().unwrap().parent().unwrap().parent().unwrap();
    let man = clap_mangen::Man::new(cli::App::command());
    let mut buffer: Vec<u8> = Default::default();
    man.render(&mut buffer).unwrap();

    std::fs::write(target_dir.join("client_1.1"), buffer).unwrap();
}
