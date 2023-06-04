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

    //command가 파일인지 폴더인지 판단하는 메소드
    public void isFileOrDirectory(String command, String currentDrive, String currentDirectory){
        String commandTokens = command.substring(5); // copy+" " 제외 나머지 문자열
        int spaceIndex = commandTokens.indexOf(" "); // 공백이 몇 번째 인덱스에서 나오는지 찾기
        String sourcePath = commandTokens.substring(0, spaceIndex); // 공백 이전 문자열 저장 (복사 대상)
        String destinationPath = commandTokens.substring(spaceIndex + 1); // 공백 이후 문자열 저장

        File sourceFile = new File(currentDrive + currentDirectory + File.separator + sourcePath);
        File destinationFile = new File(currentDrive + currentDirectory + File.separator + destinationPath);

        if (sourceFile.isFile() && destinationFile.isDirectory()){
            //파일을 폴더로 복사
            copyFileToDirectory(sourcePath,destinationPath,currentDrive,currentDirectory);
        }
        else if  (sourceFile.isDirectory() && destinationFile.isDirectory()){
            //폴더를 폴더로 복사
            copyDirectoryToDirectory(sourcePath,destinationPath,currentDrive,currentDirectory);
        }
        else if  (sourceFile.isFile() && destinationFile.isFile()){
            //파일을 파일로 덮어쓰기
            copyFileToFile(sourcePath,destinationPath,currentDrive,currentDirectory);
        }

    }

    //파일을 폴더로 복사
    public void copyFileToDirectory(String sourcePath, String destinationPath, String currentDrive, String currentDirectory) {
        File sourceFile = new File(currentDrive + currentDirectory+"\\"+ sourcePath); // sourcePath에 해당하는 파일 찾기
        File destinationDir = new File(currentDrive + currentDirectory+"\\"+destinationPath); // destinationPath에 해당하는 폴더 찾기
        System.out.println(sourceFile);
        System.out.println(destinationDir);
        if (sourceFile.exists() &&  destinationDir.isDirectory()) {
            // 파일이 존재하는지, destinationDir이 디렉터리 경로인지 확인
            Path source = sourceFile.toPath();;
            Path destination = new File(currentDrive + currentDirectory+"\\"+destinationPath, sourceFile.getName()).toPath();
            System.out.println(source);
            System.out.println(destination);

            // Files.copy는 IOException을 발생시키므로 try-with-resources 사용하여 예외 처리
            try {
                Files.copy(source, destination, StandardCopyOption.COPY_ATTRIBUTES);
                System.out.println("1개 파일이 복사되었습니다.");
            } catch (Exception e) {
                System.out.println("지정된 경로를 찾을 수 없습니다.11"+ e.getMessage());
            }
        }
        else{
            System.out.println("지정된 경로를 찾을 수 없습니다.");
        }
    }

    // 파일을 파일로 덮어쓰기
    public void copyFileToFile(String sourcePath, String destinationPath, String currentDrive, String currentDirectory) {
        File sourceFile = new File(currentDrive + currentDirectory+"\\"+ sourcePath); // sourcePath에 해당하는 파일 찾기
        File destinationFile = new File(currentDrive + currentDirectory+"\\"+destinationPath); // destinationPath에 해당하는 파일 찾기
        System.out.println("아");
        if (sourceFile.exists() && destinationFile.isFile()) {
            // 파일이 존재하는지, destinationFile이 파일 경로인지 확인
            Path source = sourceFile.toPath();
            Path destination = destinationFile.toPath();

            // Files.copy는 IOException을 발생시키므로 try-with-resources 사용하여 예외 처리
            try {
                Files.copy(source, destination, StandardCopyOption.COPY_ATTRIBUTES);
                System.out.println("파일이 덮어쓰기 복사되었습니다.");
            } catch (Exception e) {
                System.out.println("지정된 경로를 찾을 수 없습니다. 오류 메시지: " + e.getMessage());
            }
        } else {
            System.out.println("지정된 경로를 찾을 수 없습니다.");
        }
    }

    // 폴더를 폴더로 복사
    public void copyDirectoryToDirectory(String sourcePath, String destinationPath, String currentDrive, String currentDirectory) {
        File sourceDir = new File(currentDrive + currentDirectory+"\\"+ sourcePath); // sourcePath에 해당하는 폴더 찾기
        File destinationDir = new File(currentDrive + currentDirectory+"\\"+ destinationPath); // destinationPath에 해당하는 폴더 찾기
        System.out.println("ㄹ아");
        System.out.println( sourceDir );
        System.out.println( destinationDir );
        if (sourceDir.isDirectory() && destinationDir.isDirectory()) {
            // sourceDir, destinationDir 모두 디렉터리인지 확인
            File[] files = sourceDir.listFiles();

            if (files != null) {
                // 폴더 내의 파일들을 하나씩 복사
                for (File file : files) {
                    Path source = file.toPath();
                    Path destination = new File(destinationDir, file.getName()).toPath();

                    try {
                        Files.copy(source, destination, StandardCopyOption.COPY_ATTRIBUTES);
                    } catch (Exception e) {
                        System.out.println("파일 복사 중 오류가 발생했습니다: " + e.getMessage());
                    }
                }
                System.out.println(files.length + "개 파일이 복사되었습니다.");
            } else {
                System.out.println("폴더가 비어 있습니다.");
            }
        } else {
            System.out.println("지정된 경로를 찾을 수 없습니다.");
        }
    }


}
