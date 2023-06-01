import java.util.Scanner;

public class CMD {
    private String currentDrive; //현재 드라이브의 정보를 담을 변수
    private String currentDirectory; //현재 디렉터리의 정보를 담을 변수

    private void printMessage(){
        System.out.println("Microsoft Windows [Version 10.0.22621.1555]");
        System.out.println("(c) Microsoft Corporation. All rights reserved.");
        currentDrive="C:\\";
        currentDirectory="Users\\user";
    }

    //실행 메소드
    public void run() {
        Scanner scanner = new Scanner(System.in);
        String command;
        printMessage();
        //exit이 입력되기 전까지 반복
        do {
            System.out.print(currentDrive + currentDirectory+">");
            command = scanner.nextLine();
            enterMode(command);
        } while (!command.equals("exit"));

        scanner.close();
    }

    //모드로 진입하는 메소드
    private void enterMode(String command) {
        Mode mode = new Mode();
        if (command.startsWith("cd")) {
            mode.enterCdMode(command, currentDrive, currentDirectory);
        }
        else if (command.equals("dir")) {
            // Handle dir command
        }
        else if (command.equals("cls")) {
            // Handle cls command
        }
        else if (command.equals("help")) {
            // Handle help command
        }
        else if (command.equals("copy")) {
            // Handle copy command
        }
        else if (command.equals("move")) {
            // Handle move command
        }
        else {
            System.out.print("'" + command + "'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\n");
            System.out.print("배치 파일이 아닙니다.\n\n");
        }
    }
}