import java.util.Scanner;

public class CMD {
    public static void main(String[] args) {
        CMD cmd = new CMD();
        cmd.run();
    }

    private void printMessage(){
        System.out.println("Microsoft Windows [Version 10.0.22621.1555]");
        System.out.println("(c) Microsoft Corporation. All rights reserved.");
    }

    private void run() {
        Scanner scanner = new Scanner(System.in);
        String command;
        printMessage();
        do {
            System.out.print("C:\\Users\\user>>");
            command = scanner.nextLine();
            enterMode(command);
        } while (!command.equals("exit"));

        scanner.close();
    }

    private void enterMode(String command) {
        Mode mode = new Mode();
        String[] token = command.split("\\s"); //command를 공백 기준으로 자르기
        String[] arguments = new String[token.length - 1]; //
        System.arraycopy(token, 1, arguments, 0, arguments.length);

        if (token[0].equals("cd")){
            mode.enterCdMode(arguments);
        }
        else if (token[0].equals("dir")){

        }
        else if (token[0].equals("cls")){

        }
        else if (token[0].equals("help")){

        }
        else if (token[0].equals("copy")){

        }
        else if (token[0].equals("move")){

        }
        else {
            System.out.print("'"+command+"'"+"은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\n");
            System.out.print("배치 파일이 아닙니다.\n\n");
        }
    }
}