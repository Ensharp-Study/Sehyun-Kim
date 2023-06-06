package ModePlayer;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardCopyOption;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardCopyOption;
import java.util.Scanner;

public class CopyPlayer {
    private String currentDrive; //현재 드라이브의 정보를 담을 변수
    private String currentDirectory; //현재 디렉터리의 정보를 담을 변수

    public CopyPlayer(String currentDrive, String currentDirectory) {
        this.currentDrive = currentDrive;
        this.currentDirectory = currentDirectory;
    }

    public void isFileOrDirectory(String command) {
        String commandTokens = command.substring(5); // copy+" " 제외 나머지 문자열
        int spaceIndex = commandTokens.indexOf(" "); // 공백이 몇 번째 인덱스에서 나오는지 찾기

        String sourcePath = commandTokens.substring(0, spaceIndex); // 공백 이전 문자열 저장 (복사 대상)
        String destinationPath = commandTokens.substring(spaceIndex + 1); // 공백 이후 문자열 저장

        File source = new File(currentDrive + currentDirectory + File.separator + sourcePath);
        File destination = new File(currentDrive + currentDirectory + File.separator + destinationPath);

        if (source.exists() && source.isFile()) {
            copyFile(source, destination);
        }
        else if (source.exists() && source.isDirectory()) {
            copyDirectory(source, destination);
        }
    }

    private void copyFile(File sourceFile, File destinationFile) {
        String sourcePath = sourceFile.getAbsolutePath();
        String destinationPath = destinationFile.getAbsolutePath();

        if (destinationPath.equals(sourcePath)) {
            System.out.println("같은 파일로 복사할 수 없습니다: " + sourceFile.getName());
            System.out.println("     0개 파일이 복사되었습니다.");
        }

        else {
            try {
                Files.copy(sourceFile.toPath(), destinationFile.toPath(), StandardCopyOption.COPY_ATTRIBUTES);
                System.out.println("     1개 파일이 복사되었습니다.");
            } catch (IOException e) {
                System.out.println("지정된 파일을 찾을 수 없습니다.");
            }
        }
    }

    private void createDestination(File sourceFolder, File destinationFolder){
        destinationFolder.mkdirs(); // 대상 폴더가 없으면 생성
        int fileCount = 0; // 복사된 파일의 수를 세는 변수

        File[] files = sourceFolder.listFiles(); // 폴더 내 파일들을 가져옴
        if (files != null) {
            for (File file : files) {
                File destinationFile = new File(destinationFolder, file.getName());
                try {
                    System.out.println(sourceFolder.getName()+ File.separator +file.getName());
                    Files.copy(file.toPath(), destinationFile.toPath(), StandardCopyOption.COPY_ATTRIBUTES);
                    fileCount++;
                } catch (IOException e) {
                    System.out.println("파일 복사 중 오류가 발생했습니다: " + e.getMessage());
                }
            }
        }

        System.out.println("\t\t\t\t"+fileCount + "개 파일이 성공적으로 복사되었습니다.");
    }

    private void OverwriteDestination(File sourceFolder, File destinationFolder) {
        int fileCount = 0;
        File[] files = sourceFolder.listFiles();
        Scanner scanner = new Scanner(System.in);

        if (files != null) {
            for (File file : files) {
                File destinationFile = new File(destinationFolder, file.getName());
                System.out.print(file.getName() + "을(를) 덮어쓰시겠습니까? (yes/no/all): ");

                if (!scanner.hasNextLine()) {
                    continue;
                }

                String input = scanner.nextLine().toLowerCase();

                if (destinationFile.exists()) {
                    if (destinationFile.getName().equals(file.getName())) {
                        System.out.println("같은 이름의 파일로 복사할 수 없습니다: " + file.getName());
                        continue;
                    }

                    if (!input.equals("all")) {
                        System.out.println("파일이 이미 존재합니다: " + file.getName());
                        continue;
                    }
                }

                if (input.equals("no")) {
                    continue;
                }

                try {
                    System.out.println(sourceFolder.getName() + File.separator + file.getName());
                    Files.copy(file.toPath(), destinationFile.toPath(), StandardCopyOption.COPY_ATTRIBUTES);
                    fileCount++;
                } catch (IOException e) {
                    System.out.println("파일 복사 중 오류가 발생했습니다: " + e.getMessage());
                }
            }
        }

        System.out.println(fileCount + "개 파일이 성공적으로 복사되었습니다.");
    }
    private void copyDirectory(File sourceFolder, File destinationFolder) {
        if (!destinationFolder.exists()) {
            createDestination(sourceFolder,destinationFolder);
        }

        else if (destinationFolder.exists()){
            OverwriteDestination(sourceFolder,destinationFolder);
        }


    }
}