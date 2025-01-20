package CMDPlayer;

import ModePlayer.*;

import java.util.Scanner;

public class CMDPlayer {
    private String currentDrive; //현재 드라이브의 정보를 담을 변수
    private String currentDirectory; //현재 디렉터리의 정보를 담을 변수

    private CdPlayer cdPlayer;
    private ClsPlayer clsPlayer;
    private HelpPlayer helpPlayer;
    private CopyPlayer copyPlayer;
    private DirPlayer dirPlayer;
    private MovePlayer movePlayer;

    public CMDPlayer(String currentDrive, String currentDirectory){
        this.currentDrive = currentDrive;
        this.currentDirectory = currentDirectory;
        cdPlayer = new CdPlayer(currentDrive, currentDirectory);
        clsPlayer = new ClsPlayer();
        helpPlayer = new HelpPlayer();
        copyPlayer = new CopyPlayer(currentDrive, currentDirectory);
        dirPlayer = new DirPlayer(currentDrive, currentDirectory);
        movePlayer = new MovePlayer(currentDrive, currentDirectory);
    }
    private void printMessage() {
        String osName = System.getProperty("os.name");
        String osVersion = System.getProperty("os.version");

        if (osName.toLowerCase().contains("windows")) {
            System.out.println("Microsoft Windows [Version " + osVersion + "]");
            System.out.println("(c) Microsoft Corporation. All rights reserved.");
        } else if (osName.toLowerCase().contains("mac")) {
            System.out.println("macOS " + osVersion);
            System.out.println("(c) Apple Inc. All rights reserved.");
        } else if (osName.toLowerCase().contains("linux")) {
            System.out.println("Linux " + osVersion);
            System.out.println("(c) Open Source Community. All rights reserved.");
        } else {
            System.out.println("Unknown operating system: " + osName);
        }
    }

    //실행 메소드
    public void run(){
        Scanner scanner = new Scanner(System.in);
        String command;
        printMessage();
        // exit이 입력되기 전까지 반복
        System.out.println(currentDrive + currentDirectory + ">");
        command = scanner.nextLine();
        currentDirectory=enterMode(command);

        while (!command.equals("exit")) {
            System.out.print(currentDrive + currentDirectory + ">");
            command = scanner.nextLine();
            enterMode(command);
        }

        scanner.close();
    }

    //모드로 진입하는 메소드
    private String enterMode(String command) {
        switch (command.split(" ")[0]) {
            case "cd":
                currentDirectory = cdPlayer.enterCdMode(command, currentDrive, currentDirectory);
                break;
            case "dir":
                dirPlayer.displayDirectory();
                break;
            case "cls":
                clsPlayer.clearScreen();
                break;
            case "help":
                helpPlayer.informHelp();
                break;
            case "copy":
                copyPlayer.isFileOrDirectory(command);
                break;
            case "move":
                movePlayer.move(command);
                break;
            default:
                System.out.print("'" + command + "'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\n");
                System.out.print("배치 파일이 아닙니다.\n\n");
                break;
        }

        return currentDirectory;
    }
}