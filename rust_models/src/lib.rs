pub struct User {
    id: u32,
    name: String
}

pub struct Card {
    id: u32,
    name: String,
    life_points: u32,
    attack: u32,
    defense: u32
}

enum TransactionType {
    Sell,
    Buy
}

pub struct Transaction {
    id: u32,
    transaction_type: TransactionType,
    user_id: u32,
    card_id: u32
}

pub struct Game {
    id: u32,
    user1_id: u32,
    user2_id: u32,
    card1_id: u32,
    card2_id: u32,
}