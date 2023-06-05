package CMDPlayer;

import ModePlayer.*;

import java.util.Scanner;

public class CMDPlayer {
    private String currentDrive; //현재 드라이브의 정보를 담을 변수
    private String currentDirectory; //현재 디렉터리의 정보를 담을 변수

    public CMDPlayer(String currentDrive, String currentDirectory){
        this.currentDrive = currentDrive;
        this.currentDirectory = currentDirectory;
    }
    private void printMessage(){
        String osVersion = System.getProperty("os.version");
        System.out.println("Microsoft Windows [Version " + osVersion + "]");
        System.out.println("(c) Microsoft Corporation. All rights reserved.");
    }

    //실행 메소드
    public void run() {
        Scanner scanner = new Scanner(System.in);
        String command;
        printMessage();
        // exit이 입력되기 전까지 반복
        System.out.println(currentDrive + currentDirectory + ">");
        command = scanner.nextLine();
        enterMode(command);

        while (!command.equals("exit")) {
            System.out.print(currentDrive + currentDirectory + ">");
            command = scanner.nextLine();
            enterMode(command);
        }

        scanner.close();
    }

    //모드로 진입하는 메소드
    private void enterMode(String command) {
        CdPlayer cdPlayer = new CdPlayer(currentDrive, currentDirectory);
        ClsPlayer clsPlayer = new ClsPlayer();
        HelpPlayer helpPlayer = new HelpPlayer();
        CopyPlayer copyPlayer = new CopyPlayer(currentDrive, currentDirectory);
        DirPlayer dirPlayer = new DirPlayer(currentDrive, currentDirectory);
        MovePlayer movePlayer = new MovePlayer(currentDrive, currentDirectory);

        if (command.startsWith("cd")) {
            currentDirectory=cdPlayer.enterCdMode(command, currentDrive, currentDirectory);
        }
        else if (command.startsWith("dir")) {
            dirPlayer.displayDirectory();
        }
        else if (command.startsWith("cls")) {
            clsPlayer.clearScreen();
        }
        else if (command.startsWith("help")) {
            helpPlayer.informHelp();
        }
        else if (command.startsWith("copy")) {
            copyPlayer.isFileOrDirectory(command);
        }
        else if (command.startsWith("move")) {
            movePlayer.move(command);
        }
        else {
            System.out.print("'" + command + "'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\n");
            System.out.print("배치 파일이 아닙니다.\n\n");
        }
    }
}