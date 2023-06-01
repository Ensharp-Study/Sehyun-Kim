import java.util.Scanner;

public class CMDPlayer {
    private String currentDrive; //현재 드라이브의 정보를 담을 변수
    private String currentDirectory; //현재 디렉터리의 정보를 담을 변수

    public CMDPlayer(String currentDrive, String currentDirectory){
        this.currentDrive = currentDrive;
        this.currentDirectory = currentDirectory;
    }
    private void printMessage(){
        System.out.println("Microsoft Windows [Version 10.0.22621.1555]");
        System.out.println("(c) Microsoft Corporation. All rights reserved.");
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
        CdPlayer mode = new CdPlayer(currentDrive, currentDirectory);
        if (command.startsWith("cd")) {
            currentDirectory=mode.enterCdMode(command, currentDrive, currentDirectory);
        }
        else if (command.startsWith("dir")) {
        }
        else if (command.startsWith("cls")) {
        }
        else if (command.startsWith("help")) {
        }
        else if (command.startsWith("copy")) {
        }
        else if (command.startsWith("move")) {
        }
        else {
            System.out.print("'" + command + "'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\n");
            System.out.print("배치 파일이 아닙니다.\n\n");
        }
    }
}