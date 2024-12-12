//Ai is a computer player not controlled by the user
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