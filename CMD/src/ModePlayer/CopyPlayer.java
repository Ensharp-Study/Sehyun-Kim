package ModePlayer;
import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardCopyOption;

public class CopyPlayer {
    private String currentDrive; //현재 드라이브의 정보를 담을 변수
    private String currentDirectory; //현재 디렉터리의 정보를 담을 변수
    public CopyPlayer(String currentDrive, String currentDirectory) {
        this.currentDrive = currentDrive;
        this.currentDirectory = currentDirectory;
    }
    public void enterCopyMode(String command, String currentDrive, String currentDirectory){
        String commandTokens = command.substring(5); //copy+" " 제외 나머지 문자열
        int spaceIndex = commandTokens.indexOf(" ");
        String sourcePath = commandTokens.substring(0, spaceIndex-1 );
        String destinationPath = commandTokens.substring(spaceIndex);

        File sourceFile = new File(currentDirectory, sourcePath);
        File destinationDir = new File(currentDirectory, destinationPath);

        if (sourceFile.exists() && destinationDir.exists()&&destinationDir.isDirectory()){
            Path source = sourceFile.toPath();
            Path destination = new File(destinationDir, sourceFile.getName()).toPath();
            //Files.copy(source, destination, StandardCopyOption.COPY_ATTRIBUTES);
            System.out.println("!");
        }
        else{
            System.out.println("지정된 파일을 찾을 수 없습니다.");
        }

    }
}
