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

    public String enterCdMode(String command, String currentDrive, String currentDirectory) {
        String commandTokens = command.substring(2); //cd 지우고 나머지 문자열 저장
        String cleanedCommand = commandTokens.replace(" ",""); //나머지 문자열의 공백을 모두 제거
        File file = new File(currentDrive + currentDirectory, cleanedCommand); // 드라이브 정보를 포함한 전체 경로로 설정

        if (cleanedCommand.equals("..")){ //cd .. 입력된 경우
            currentDirectory = moveToParentDirectory(currentDrive, currentDirectory);
        }
        else if (command.equals("cd")){ //cd만 입력된 경우
            System.out.println(currentDrive + currentDirectory);
        }
        else if (Paths.get(cleanedCommand).isAbsolute()) { // 절대 경로가 입력된 경우
            String drive = cleanedCommand.substring(0, 3);
            currentDrive = drive;
            currentDirectory = cleanedCommand.substring(3);
        }
        else if (file.exists() && file.isDirectory()) {
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

    private String moveToParticularDirectory(String directoryPath) {
        //1. 가고 싶은 디렉터리의 전체 경로 입력되었을 경우
        //2. cd + 원하는 디렉터리 --> 해당 디렉터리로 이동
        File directory = new File(directoryPath);
        if (directory.isDirectory()) {
            currentDirectory = directoryPath;
        } else {
            System.out.println("지정된 경로를 찾을 수 없습니다.");
        }
        return currentDirectory;
    }
    private String moveToParentDirectory(String currentDrive, String currentDirectory) {
        //cd..이라고 입력하면 상위 디렉터리로 이동
        String[] currentPathTokens = currentDirectory.split("\\\\");
        if (currentPathTokens.length > 0) {
            StringBuilder parentDirectory = new StringBuilder();
            for (int i = 0; i < currentPathTokens.length - 1; i++) {
                parentDirectory.append(currentPathTokens[i]);
            }
            currentDirectory = parentDirectory.toString();
        }
        return currentDirectory;
    }

}
