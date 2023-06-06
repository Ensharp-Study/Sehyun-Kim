package ModePlayer;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;

public class MovePlayer {
    private int fileCount;
    private String currentDrive; // 현재 드라이브의 정보를 담을 변수
    private String currentDirectory; // 현재 디렉터리의 정보를 담을 변수

    private CdPlayer cdPlayer;
    public MovePlayer(String currentDrive, String currentDirectory) {
        this.currentDrive = currentDrive;
        this.currentDirectory = currentDirectory;
        this.cdPlayer = new CdPlayer(currentDirectory, currentDrive);
    }

    public void isFileOrDirectory(String command) {

        cdPlayer.sliceCommandWithSpace(command, 5);

        if (source.exists() && source.isFile()) {
            moveFile(source, destination);
        }
        else if (source.exists() && source.isDirectory()) {
            moveDirectory(source, destination);
        }
    }

    public void move(String command) {
        String commandTokens = command.substring(5); // move+" " 제외 나머지 문자열
        int spaceIndex = commandTokens.indexOf(" "); // 공백이 몇 번째 인덱스에서 나오는지 찾기
        fileCount =0 ;

        String sourcePath = commandTokens.substring(0, spaceIndex); // 공백 이전 문자열 저장 (이동 대상)
        String destinationPath = commandTokens.substring(spaceIndex + 1); // 공백 이후 문자열 저장

        File source = new File(currentDrive + currentDirectory + File.separator + sourcePath);
        File destination = new File(currentDrive + currentDirectory + File.separator + destinationPath);

        if (source.exists()) {
            if (source.isFile()) {
                moveFile(source, destination);
            } else if (source.isDirectory()) {
                moveDirectory(source, destination);
            }
        } else {
            System.out.println("지정된 파일 또는 폴더를 찾을 수 없습니다.");
        }
    }

    private void moveFile(File sourceFile, File destinationFile) {
        try {
            Files.move(sourceFile.toPath(), destinationFile.toPath(), StandardCopyOption.REPLACE_EXISTING);
            System.out.println("파일이 성공적으로 이동되었습니다.");
            fileCount++;
        }
        catch (IOException e) {
            System.out.println("파일 이동 중 오류가 발생했습니다: " + e.getMessage());
        }
    }

    private void moveDirectory(File sourceFolder, File destinationFolder) {
        if (!destinationFolder.exists()) {
            destinationFolder.mkdirs(); // 대상 폴더가 없으면 생성
        }

        File[] files = sourceFolder.listFiles(); // 폴더 내 파일들을 가져옴
        if (files != null) {
            for (File file : files) {
                File destinationFile = new File(destinationFolder, file.getName());
                if (file.isFile()) {
                    moveFile(file, destinationFile);
                } else if (file.isDirectory()) {
                    moveDirectory(file, destinationFile);
                }
            }
        }

        // 원본 폴더 삭제
        boolean deleted = sourceFolder.delete();
        if (deleted) {
            System.out.println(fileCount + "개 파일이 성공적으로 이동되었습니다.");
        } else {
            System.out.println("원본 폴더를 삭제하는데 실패했습니다.");
        }
    }


}