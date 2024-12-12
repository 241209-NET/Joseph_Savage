using System;
using System.Collections.Generic;

public class Square {

    public string name;

    public Square(string name) {
        this.name = name;
    }
}
public class Property : Square {
    public double price;
    public int owner = -1;

    public Property(string name, double price, int owner) : base(name) {
        this.name = name;
        this.price = price;
        this.owner = owner;
    }
}

public class Player {
    public string name = "Player"; 
    public int position = 0;
    public double cash = 1500.00;
    public int getOutOfJailFreeCards = 0;
    public Player(string name, int position, double cash, int getOutOfJailFreeCards) {

        this.name = name;
        this.position = position;
        this.cash = cash;
        this.getOutOfJailFreeCards = getOutOfJailFreeCards;

    }

}

public class Ai : Player {
    public int intensity;
    public Ai(string name, int position, double cash, int getOutOfJailFreeCards, int intensity) : base(name, position, cash, getOutOfJailFreeCards) {
        this.intensity = intensity;
    }
    //what kind of actions will ai perform (other than roll)
    public string autoAction() {

        Random random = new Random();

        string perform = "nothing";

        if (intensity < 0 || intensity > 20) {

            intensity = 0;

        }

        int commandType = random.Next(intensity, 21);

        if (commandType < 4) {

            return perform;

        }
        else if (commandType > 4 && commandType < 9) {

            perform  = "buy";

        }
        else if (commandType > 9 && commandType < 14) {

            perform = "steal";

        }
        else {

            perform = "buy and steal";

        }

        return perform;

    }

}
class Program {
    static List<Square> board = new List<Square>();
    static List<Player> player = new List<Player>();

    public static double goal = 5000.00;
    static Random random = new Random();

    public static Player passGo(Player player) {

        double goPayment = 1000.0;

        player.cash += goPayment;

        Console.WriteLine($"{player.name} passed Go and earned ${goPayment}");

        return player;

    }

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

    public static Player goToJail(Player player) {

        if (player.getOutOfJailFreeCards > 0) {

            player.getOutOfJailFreeCards--;

            Console.WriteLine($"{player.name} used Get Out of Jail Free Card");

            Console.ReadKey(true);

        }
        else {

            double fine = 50.0;

            Console.WriteLine($"{player.name} has been sent to jail!");
            Console.ReadKey(true);
            Console.WriteLine($"{player.name} payed a ${fine}");
            Console.ReadKey(true);

            player.cash -= fine;

            //current position is 10 but keep track if more Squares are added to board!
            player.position = 10;

        }

        return player;

    }

    public static Player steal(Player player) {

        Console.WriteLine("How much will you steal?");

        double amount = 0.0;

        try {
            
            amount = Convert.ToDouble(Console.ReadLine());

            double bank = (double) random.Next(1, 501);

            Console.WriteLine($"The banker will notice if ${bank} is gone");

            if (!amount.Equals(null)) {

                if (amount < bank) {

                    Console.WriteLine($"You stole ${amount} from the bank!");

                    player.cash += amount;

                    return player;

                }
                else {

                    Console.WriteLine($"The banker caught you stealing ${amount}!");

                    return goToJail(player);

                }

            }

        }
        catch (Exception e) {

            Console.WriteLine(e.Message);

            Console.WriteLine("You decided stealing is wrong!");

            return player;

        }

        return player;

    }

    public static Player tax(Player player) {

        double taxMoney = player.cash * 0.10;

        Console.WriteLine($"{player.name} payed 10% of cash (${taxMoney}) to the bank.");
        Console.ReadKey(true);

        player.cash -= taxMoney;

        return player;

    }
    
    public static Player ChanceCard(Player player) {

        int cardType = random.Next(0, 5);

        double payment = 0.0;

        switch(cardType) {

            //player pays bank
            case 0: {

                payment = (double) random.Next(0, 301);

                Console.WriteLine($"{player.name} paid the bank ${payment}");
                Console.ReadKey(true);

                player.cash -= payment;

                break;

            }
            //player earns cash
            case 1: {

                payment = (double) random.Next(0, 501);

                Console.WriteLine($"{player.name} earned ${payment}!");
                Console.ReadKey(true);

                player.cash += payment;

                break;

            }
            //player zooms
            case 2: {

                int zoomed = random.Next(0, 23);

                if (zoomed < player.position) {

                    player = passGo(player);

                }

                player.position = zoomed;

                break;

            }
            case 3: {

                player = goToJail(player);

                break;

            }
            case 4: {

                Console.WriteLine($"{player.name} got a Get Out of Jail Free Card!");

                Console.ReadKey(true);

                player.getOutOfJailFreeCards++;

                break;

            }

        }

        return player;

    }
    public static void Main() {

        player.Add(new Player("Player 1", 0, 1500, 0));
        player.Add(new Player("Player 2", 0, 1500, 0));
        player.Add(new Ai("Inky", 0, 1500, 0, 2));
        player.Add(new Ai("Blinky", 0, 1500, 0, 4));
        player.Add(new Ai("Pinky", 0, 1500, 0, 6));
        player.Add(new Ai("Clyde", 0, 1500, 0, 20));
        

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
        board.Add(new Square("Jail"));
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

                        bool rolled = false;
                        
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

                                        player[i] = passGo(player[i]);

                                    }

                                    if (board[player[i].position] is not Property) {

                                        turn = false;

                                        Square space = board[player[i].position];

                                        Console.WriteLine($"You landed on {space.name}");

                                        switch (space.name) {

                                            case "GO TO JAIL": {

                                                player[i] = goToJail(player[i]);

                                                break;

                                            }
                                            case "Chance Square": {

                                                player[i] = ChanceCard(player[i]);

                                                break;

                                            }
                                            case "Tax Office": {

                                                player[i] = tax(player[i]);

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

                                                
                                            Console.WriteLine($"You landed on {space.name}");


                                        }
                                        //player landed on unowned property
                                        else {

                                            Console.WriteLine($"You landed on {space.name}, which costs ${space.price}");

                                        }

                                    }

                                rolled = true;

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

                                player[i] = steal(player[i]);

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

                    Console.WriteLine($"{computer.name} Cash: {computer.cash}");

                    Console.ReadKey(true);

                    string aiAction = computer.autoAction();

                    if (board[computer.position] is not Property) {

                        //effect already happened nothing!

                    }
                    //player is standing on property
                    else {

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

                                Console.WriteLine($"{computer.name} bought out {space.name} from {player[space.owner].name}");

                                Console.ReadKey(true);

                                computer.cash -= (space.price * 5);

                                player[space.owner].cash = (space.price * 5);

                                space.owner = i;

                            }

                        }

                        board[computer.position] = space;

                        if (aiAction.Equals("steal") || aiAction.Equals("buy and steal")) {

                            double amount = (double) random.Next(computer.intensity * 20, 501);

                            Console.WriteLine($"{computer.name} tried stealing ${amount} from the bank!");

                            Console.ReadKey(true);

                            double bank = (double) random.Next(1, 501);

                            Console.WriteLine($"The banker will notice if ${bank} is gone");

                            Console.ReadKey(true);

                                if (amount < bank) {

                                    Console.WriteLine($"{computer.name} stole ${amount} from the bank!");

                                    Console.ReadKey(true);

                                    computer.cash += amount;

                                }
                                else {

                                    Console.WriteLine($"The banker caught {computer.name} stealing ${amount}!");

                                    Console.ReadKey(true);

                                    computer = (Ai) goToJail(computer);

                                }

                        }

                    }
                    

                    int diceRoll = random.Next(1, 13);

                    Console.WriteLine($"{computer.name} rolled a {diceRoll}");

                    Console.ReadKey(true);

                    computer.position += diceRoll;

                    if (computer.position >= board.Count) {

                        computer.position -= board.Count;

                        computer = (Ai) passGo(computer);

                    }

                    Console.WriteLine($"{computer.name} landed on {board[computer.position].name}");

                    Console.ReadKey(true);
                            
                    if (board[computer.position] is not Property) {

                        Square space = board[computer.position];

                        switch (space.name) {

                            case "GO TO JAIL": {

                                computer = (Ai) goToJail(computer);

                                break;

                            }
                            case "Chance Square": {

                                computer = (Ai) ChanceCard(computer);

                                break;

                            }
                            case "Tax Office": {

                                computer = (Ai) tax(computer);

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