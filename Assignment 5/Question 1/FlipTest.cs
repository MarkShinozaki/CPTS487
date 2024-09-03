public class CommandPatternDemo {
    public static void main(String[] args) {
        // Receiver
        Light lamp = new Light();

        // ConcreteCommand
        Command switchUp = new FlipUpCommand(lamp);
        Command switchDown = new FlipDownCommand(lamp);

        // Invoker
        Switch mySwitch = new Switch();

        // Execute the commands
        mySwitch.storeAndExecute(switchUp);
        mySwitch.storeAndExecute(switchDown);
    }
}