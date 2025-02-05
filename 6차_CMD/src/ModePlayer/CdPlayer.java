package ModePlayer;

import java.io.File;
import java.nio.file.Path;
import java.nio.file.Paths;

public class CdPlayer {
    private String currentDrive; //현재 드라이브의 정보를 담을 변수
    private String currentDirectory; //현재 디렉터리의 정보를 담을 변수
    public CdPlayer(String currentDrive, String currentDirectory) {
        this.currentDrive = currentDrive;
        this.currentDirectory = currentDirectory;
    }

    public Object[] sliceCommand(String command, int number) {
        String commandTokens = command.substring(number);
        String cleanedCommand = command.substring(number + 1);
        File file = new File(currentDrive + currentDirectory, cleanedCommand);
        return new Object[]{cleanedCommand, commandTokens, file};
    }

    public Object[] sliceCommandWithSpace(String command, int number){
        String commandTokens  =command.substring(number);
        int spaceIndex=commandTokens.indexOf(" ");

        String sourcePath = commandTokens.substring(0, spaceIndex);
        String destinationPath = commandTokens.substring(spaceIndex+1);

        File source = new File(currentDrive + currentDirectory + File.separator + sourcePath);
        File destination = new File(currentDrive + currentDirectory + File.separator + destinationPath);

        return new Object[] {sourcePath, destinationPath, source, destination};
    }

    public String enterCdMode(String command, String currentDrive, String currentDirectory) {
        Object[] result = sliceCommand(command, 3);
        String cleanedCommand = (String) result[0];
        String commandTokens = (String) result[1];
        File file = (File) result[2];

        if (commandTokens.equals("..") || commandTokens.equals(" ..")){ //cd .. 입력된 경우
            currentDirectory = moveToParentDirectory(currentDrive, currentDirectory);
        }
        else if (command.equals("cd")){ //cd만 입력된 경우
            System.out.println(currentDrive + currentDirectory);
        }
        else if (cleanedCommand.equals("\\")){
            currentDirectory="";
            return currentDirectory;
        }
        else if (Paths.get(cleanedCommand).isAbsolute()) { // 절대 경로가 입력된 경우
            String drive = cleanedCommand.substring(0, 3);
            currentDrive = drive;
            currentDirectory = cleanedCommand.substring(3);
        }
        else if (file.exists()) {
            if (currentDirectory.isEmpty()) {
                currentDirectory = cleanedCommand;
            } else {
                currentDirectory += "\\" + cleanedCommand; // 상대 경로를 추가하여 이동
            }
        }
        else{
            System.out.println("'"+command+"은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\n");
            System.out.println("배치 파일이 아닙니다.\n");
        }

        return currentDirectory;
    }

    private String moveToParentDirectory(String currentDrive, String currentDirectory) {
        // cd..이라고 입력하면 상위 디렉터리로 이동
        String[] currentPathTokens = currentDirectory.split("\\\\");
        if (currentPathTokens.length > 0) {
            StringBuilder parentDirectory = new StringBuilder();
            for (int i = 0; i < currentPathTokens.length - 1; i++) {
                parentDirectory.append(currentPathTokens[i]).append("\\");
            }
            currentDirectory = parentDirectory.toString();
        }
        return currentDirectory;
    }

}
