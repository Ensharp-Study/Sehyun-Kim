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
    public void enterCopyMode(String command, String currentDrive, String currentDirectory) {
        String commandTokens = command.substring(5); // copy+" " 제외 나머지 문자열
        int spaceIndex = commandTokens.indexOf(" "); // 공백이 몇 번째 인덱스에서 나오는지 찾기
        String sourcePath = commandTokens.substring(0, spaceIndex); // 공백 이전 문자열 저장
        String destinationPath = commandTokens.substring(spaceIndex + 1); // 공백 이후 문자열 저장

        File sourceFile = new File(currentDrive+currentDirectory, sourcePath); // sourcePath에 해당하는 파일 찾기
        File destinationDir = new File(currentDrive+currentDirectory, destinationPath); // destinationPath에 해당하는 폴더 찾기

        if (sourceFile.exists() && destinationDir.exists() && destinationDir.isDirectory()) {
            // 파일이 존재하는지, destinationDir이 디렉터리 경로인지 확인
            Path source = sourceFile.toPath();
            Path destination = new File(destinationDir, sourceFile.getName()).toPath();

            // Files.copy는 IOException을 발생시키므로 try-with-resources 사용하여 예외 처리
            try {
                Files.copy(source, destination, StandardCopyOption.COPY_ATTRIBUTES);
                System.out.println("1개 파일이 복사되었습니다.");
            } catch (Exception e) {
                System.out.println("지정된 경로를 찾을 수 없습니다.");
            }
        }
        System.out.println("1개 파일이 복사되었습니다.");
    }
}
