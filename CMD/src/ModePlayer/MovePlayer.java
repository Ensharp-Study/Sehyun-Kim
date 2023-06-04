package ModePlayer;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;

public class MovePlayer {
    private String currentDrive; // 현재 드라이브의 정보를 담을 변수
    private String currentDirectory; // 현재 디렉터리의 정보를 담을 변수

    public MovePlayer(String currentDrive, String currentDirectory) {
        this.currentDrive = currentDrive;
        this.currentDirectory = currentDirectory;
    }

    public void move(String command) {
        File source = new File(currentDrive + currentDirectory);
        File destination = new File(currentDrive + currentDirectory);

        String commandTokens = command.substring(5); // copy+" " 제외 나머지 문자열
        int spaceIndex = commandTokens.indexOf(" "); // 공백이 몇 번째 인덱스에서 나오는지 찾기
        String sourcePath = commandTokens.substring(0, spaceIndex); // 공백 이전 문자열 저장
        String destinationPath = commandTokens.substring(spaceIndex + 1); // 공백 이후 문자열 저장

        if (!source.exists()) {
            System.out.println("소스 파일 또는 디렉터리를 찾을 수 없습니다.");
            return;
        }

        try {
            if (source.isFile() && destination.isDirectory()) {
                moveFileToDirectory(source, destination);
            } else if (source.isDirectory() && destination.isDirectory()) {
                moveDirectoryToDirectory(source, destination);
            } else if (isAbsolutePath(destinationPath)) {
                moveFileToAbsolutePath(source, destination);
            } else if (source.isFile() && destination.isFile()) {
                moveFileToFile(source, destination);
            } else {
                System.out.println("이동할 수 없는 조합입니다.");
            }
        } catch (Exception e) {
            System.out.println("파일 또는 디렉터리 이동에 실패했습니다.");
        }
    }

    //파일을 폴더로 이동
    private void moveFileToDirectory(File source, File destinationDir) throws Exception {
        if (!destinationDir.exists() || !destinationDir.isDirectory()) {
            System.out.println("대상 폴더를 찾을 수 없습니다.");
            return;
        }

        File destination = new File(destinationDir, source.getName());
        Files.move(source.toPath(), destination.toPath(), StandardCopyOption.REPLACE_EXISTING);

        System.out.println("파일을 성공적으로 이동했습니다.");
    }

    //폴더를 폴더로 이동
    private void moveDirectoryToDirectory(File source, File destinationDir) throws Exception {
        if (!destinationDir.exists() || !destinationDir.isDirectory()) {
            System.out.println("대상 폴더를 찾을 수 없습니다.");
            return;
        }

        File destination = new File(destinationDir, source.getName());
        Files.move(source.toPath(), destination.toPath(), StandardCopyOption.REPLACE_EXISTING);

        System.out.println("폴더를 성공적으로 이동했습니다.");
    }

    //파일을 파일로 덮어쓰기
    private void moveFileToFile(File source, File destinationFile) throws Exception {
        if (!destinationFile.exists() || !destinationFile.isFile()) {
            System.out.println("대상 파일을 찾을 수 없습니다.");
            return;
        }

        Files.move(source.toPath(), destinationFile.toPath(), StandardCopyOption.REPLACE_EXISTING);

        System.out.println("파일을 성공적으로 이동했습니다.");
    }

    //파일을 절대 경로로 이동
    private void moveFileToAbsolutePath(File source, File destination) throws Exception {
        if (!destination.isAbsolute()) {
            System.out.println("절대 경로를 입력해야 합니다.");
            return;
        }

        Files.move(source.toPath(), destination.toPath(), StandardCopyOption.REPLACE_EXISTING);

        System.out.println("파일을 성공적으로 이동했습니다.");
    }

    private boolean isAbsolutePath(String path) {
        return new File(path).isAbsolute();
    }
}