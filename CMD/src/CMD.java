import java.util.Scanner;

public class CMD {
    public static void main(String[] args) {
        CMD cmd = new CMD();
        cmd.start();
    }

    public void printMessage(){
        System.out.println("Microsoft Windows [Version 10.0.22621.1555]");
        System.out.println("(c) Microsoft Corporation. All rights reserved.");
    }

    public void start() {
        Scanner scanner = new Scanner(System.in);
        String command;
        printMessage();
        do {
            System.out.print("C:\\Users\\user>>");
            command = scanner.nextLine();
            executeCommand(command);
        } while (!command.equals("exit"));

        scanner.close();
    }

    private void executeCommand(String command) {
        if (command.equals("hello")) {
            System.out.println(" ");
        }
    }
}