

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


        public static Player passGo(Player player) {

        double goPayment = 1000.0;

        player.cash += goPayment;

        Console.WriteLine($"{player.name} passed Go and earned ${goPayment}");

        return player;

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
            Console.WriteLine($"{player.name} payed a ${fine} fine");
            Console.ReadKey(true);

            player.cash -= fine;

            //current position is 10 but keep track if more Squares are added to board!
            player.position = 10;

        }

        return player;

    }

    public static Player steal(Player player) {

        Console.WriteLine("How much will you steal?");

        Random random = new Random();

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
    
    public static Player chanceCard(Player player) {

        Random random = new Random();

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

                    player = Player.passGo(player);

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

}