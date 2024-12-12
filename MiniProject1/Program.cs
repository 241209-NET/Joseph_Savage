using System;
using System.Collections.Generic;

class Program {
    static List<Square> board = new List<Square>();
    static List<Player> player = new List<Player>();
    public static double goal = 5000.00;
    static Random random = new Random();
    public static void help() {
        
        Console.WriteLine($"earn ${goal} in order to win");
        Console.WriteLine("commands:");
        Console.WriteLine("'roll': moves forward and ends your turn");
        Console.WriteLine("'buy': purchases property before rolling");
        Console.WriteLine("'steal': steal money from the bank. The more money you try to steal increases chance of being caught. For example, stealing $250 gives you a 50% chance of being caught. You will go to jail if caught!");
        Console.WriteLine("'help': explains rules");
        Console.WriteLine("'quit': ends the game");
        Console.WriteLine("");

    }
    public static void Main() {

        player.Add(new Player("Player 1", 0, 1500, 0));
        //player.Add(new Player("Player 2", 0, 1500, 0));
        player.Add(new Ai("Inky", 0, 1500, 0, 2));
        //player.Add(new Ai("Blinky", 0, 1500, 0, 4));
        //player.Add(new Ai("Pinky", 0, 1500, 0, 6));
        //player.Add(new Ai("Clyde", 0, 1500, 0, 20));
        
        //add squares to the board
        board.Add(new Square("Go"));
        board.Add(new Property("Mediterranean Avenue", 60.0, -1));
        board.Add(new Square("Chance Square"));
        board.Add(new Property("Baltic Avenue", 60.0, -1));
        board.Add(new Square("Tax Office"));
        board.Add(new Property("Oriental Avenue", 100.0, -1));
        board.Add(new Property("Reading Railroad", 200.0, -1));
        board.Add(new Property("Vermont Avenue", 100.0, -1));
        board.Add(new Square("Chance Square"));
        board.Add(new Property("Connecticut Avenue", 120.0, -1));
        //Keep Track of this Element number
        board.Add(new Square("Jail"));
        //Must update goToJail method in Player class if more Squares or properties are enough
        board.Add(new Property("St. Charles Place", 140.0, -1));
        board.Add(new Property("States Avenue", 140.0, -1));
        board.Add(new Property("Virginia Avenue", 160.0, -1));
        board.Add(new Property("St. James Place", 180.0, -1));
        board.Add(new Property("Pennysylvania Railroad", 300.0, -1));
        board.Add(new Square("Chance Square"));
        board.Add(new Property("Tennessee Avenue", 180.0, -1));
        board.Add(new Property("New York Avenue", 200.0, -1));
        board.Add(new Square("FREE PARKING"));
        board.Add(new Property("Kentucky Avenue", 220.0, -1));
        board.Add(new Square("Chance Square"));
        board.Add(new Property("Indiana Avenue", 220.0, -1));
        board.Add(new Property("Illinois Avenue", 240.0, -1));
        board.Add(new Property("Atlantic Avenue", 260.0, -1));
        board.Add(new Property("B&O Railroad", 200.0, -1));
        board.Add(new Property("Ventnor Avenue", 260.0, -1));
        board.Add(new Property("Marvin Gardens", 280.0, -1));
        board.Add(new Square("GO TO JAIL"));
        board.Add(new Property("Pacific Avenue", 300.0, -1));
        board.Add(new Property("North Carolina Avenue", 300.0, -1));
        board.Add(new Square("Chance Square"));
        board.Add(new Property("Pennsylvania Avenue", 320.0, -1));
        board.Add(new Property("Shortline Railroad", 200.0, -1));
        board.Add(new Square("Chance Square"));
        board.Add(new Property("Park Place", 350.0, -1));
        board.Add(new Square("Tax Office"));
        board.Add(new Property("Boardwalk", 400.0, -1));

        string input = "";

        help();

        Console.ReadKey(true);

        bool gameover = false;

        int turnCount = 1;

        while (!gameover) {

            for (int i = 0; i < player.Count; i++) {

                if (player[i].cash <= 0.0) {
                        i++;
                }
                else if (player[i].cash >= goal) {

                    Console.WriteLine($"{player[i].name} earned ${player[i].cash}");
                    Console.WriteLine($"{player[i].name} won!");
                    gameover = true;
                    i = player.Count;

                }

                if (player[i] is not Ai) {

                    bool turn = true;

                    while (turn) {
                        
                        Console.WriteLine($"{player[i].name} Turn: {turnCount} Cash: ${player[i].cash}");
                        Console.WriteLine($"current position: {board[player[i].position].name}");
                        Console.WriteLine("commands: 'roll', 'buy', 'steal', 'help', 'quit'");

                        input = Console.ReadLine();

                        switch (input) {

                            case "roll": {

                                    Console.Clear();

                                    int diceRoll = random.Next(1, 13);

                                    Console.WriteLine($"you rolled a {diceRoll}");

                                    player[i].position += diceRoll;

                                    if (player[i].position >= board.Count) {

                                        player[i].position -= board.Count;

                                        player[i] = Player.passGo(player[i]);

                                    }

                                    if (board[player[i].position] is not Property) {
                                        
                                        Square space = board[player[i].position];

                                        Console.WriteLine($"You landed on {space.name}");

                                        switch (space.name) {

                                            case "GO TO JAIL": {

                                                player[i] = Player.goToJail(player[i]);

                                                break;

                                            }
                                            case "Chance Square": {

                                                player[i] = Player.chanceCard(player[i]);

                                                break;

                                            }
                                            case "Tax Office": {

                                                player[i] = Player.tax(player[i]);

                                                break;

                                            }                                    
                                            default: {

                                                break;

                                            }
                                            

                                        }

                                    }
                                    //player landed on property
                                    else {

                                        Property space = (Property) board[player[i].position];
                                        
                                        //player landed on owned property
                                        if (space.owner != -1) {

                                                
                                            Console.WriteLine($"You landed on {space.name}, which can be bought for ${space.price * 5}");


                                        }
                                        //player landed on unowned property
                                        else {

                                            Console.WriteLine($"You landed on {space.name}, which costs ${space.price}");

                                        }

                                    }

                                turn = false;

                                break;
                                
                            }

                            case "buy": {

                                Console.Clear();

                                //Space is a property
                                if (board[player[i].position] is Property) {

                                    Property space = (Property) board[player[i].position];

                                    //property has not been purchased yet
                                    if  (space.owner == -1 && space.price < player[i].cash) {

                                        Console.WriteLine($"You purchased {space.name}");

                                        player[i].cash -= space.price;

                                        space.owner = i;

                                    }
                                    //Space can be bought out by another player for 5 times their worth
                                    else if (space.owner != i && player[i].cash >= space.price * 5) {

                                        Console.WriteLine($"You bought out {space.name} for 5 times its worth from {player[i].name}!");

                                        player[i].cash -= (space.price * 5);

                                        player[space.owner].cash = (space.price * 5);

                                        space.owner = i;

                                    }
                                    //Player cannot afford property
                                    else {

                                        Console.WriteLine("You can't purchase this property!");

                                    }

                                    board[player[i].position] = space;

                                }
                                //Space is a Square
                                else {

                                    Console.WriteLine("You can't purchase this square!");

                                }

                                break;

                            }

                            case "quit": {

                                Console.Clear();

                                gameover = true;

                                turn = false;

                                i = player.Count;

                                break;

                            }
                            case "help": {

                                Console.Clear();

                                help();

                                break;

                            }
                            case "steal": {

                                player[i] = Player.steal(player[i]);

                                break;

                            }

                            default: {

                                turn = true;

                                Console.WriteLine("INVALID COMMAND");

                                break;

                            }

                        }

                        }

                }
                //player is ai
                else {

                    Console.WriteLine("computers turn:");

                    Ai computer = (Ai) player[i];

                    Console.WriteLine($"{computer.name} Turn: {turnCount} Cash: {computer.cash}");

                    Console.ReadKey(true);

                    string aiAction = computer.autoAction();

                    //player is standing on square
                    if (!(board[computer.position] is not Property)) {

                        Property space = (Property) board[computer.position];
                                
                        //computer is standing on unowned property
                        if (space.owner == -1 && computer.cash >= space.price && (computer.autoAction().Equals("buy") || computer.autoAction().Equals("buy and steal"))) {

                            Console.WriteLine($"{computer.name} bought {space.name}");
                            Console.ReadKey(true);
                            computer.cash -= space.price;
                            space.owner = i;
                        
                        }
                        //computer is not owner
                        else if (space.owner != i) {

                            if (computer.cash >= space.price * 5 && space.owner != -1 && computer.autoAction().Equals("buy and steal")) {

                                Console.WriteLine($"{computer.name} bought out {space.name} from {player[space.owner].name} for {space.price * 5}");

                                Console.ReadKey(true);

                                computer.cash -= (space.price * 5);

                                player[space.owner].cash = (space.price * 5);

                                space.owner = i;

                            }

                        }

                        board[computer.position] = space;

                        if (aiAction.Equals("steal") || aiAction.Equals("buy and steal")) {

                            double amount = (double) random.Next(computer.intensity * 20, 501);

                            //Console.WriteLine($"{computer.name} tried stealing ${amount} from the bank!");
                            //Console.ReadKey(true);

                            double bank = (double) random.Next(1, 501);

                            //Console.WriteLine($"The banker will notice if ${bank} is gone");

                            Console.ReadKey(true);

                                if (amount < bank) {

                                    Console.WriteLine($"{computer.name} stole ${amount} from the bank!");

                                    Console.ReadKey(true);

                                    computer.cash += amount;

                                }
                                else {

                                    Console.WriteLine($"The banker caught {computer.name} stealing ${amount}!");

                                    Console.ReadKey(true);

                                    computer = (Ai) Player.goToJail(computer);

                                }

                        }

                    }

                    int diceRoll = random.Next(1, 13);

                    Console.WriteLine($"{computer.name} rolled a {diceRoll}");

                    Console.ReadKey(true);

                    computer.position += diceRoll;

                    if (computer.position >= board.Count) {

                        computer.position -= board.Count;

                        computer = (Ai) Player.passGo(computer);

                    }

                    Console.WriteLine($"{computer.name} landed on {board[computer.position].name}");

                    Console.ReadKey(true);
                            
                    if (board[computer.position] is not Property) {

                        Square space = board[computer.position];

                        switch (space.name) {

                            case "GO TO JAIL": {

                                computer = (Ai) Player.goToJail(computer);

                                break;

                            }
                            case "Chance Square": {

                                computer = (Ai) Player.chanceCard(computer);

                                break;

                            }
                            case "Tax Office": {

                                computer = (Ai) Player.tax(computer);

                                break;

                            }                                    
                            default: {

                                break;

                            }

                        }

                    }

                    Console.ReadKey(true);
                    
                    player[i] = computer;

                }

                Console.WriteLine();


            }

            turnCount++;

            //gameover if player 1 wins or loses
            if (player[0].cash <= 0.0) {

                Console.WriteLine($"{player[0].name} went bankrupt!");
                Console.WriteLine("Game Over!");

                gameover = true;

            } 
            else if (player[0].cash >= goal){

                Console.WriteLine($"{player[0].name} earned ${player[0].cash}");
                Console.WriteLine($"{player[0].name} won!");

                gameover = true;

            }
        }
    }
}