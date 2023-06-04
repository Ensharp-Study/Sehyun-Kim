package ModePlayer;

import java.io.File;

public class DirPlayer {
    private String currentDrive; //현재 드라이브의 정보를 담을 변수
    private String currentDirectory; //현재 디렉터리의 정보를 담을 변수
    public DirPlayer(String currentDrive, String currentDirectory) {
        this.currentDrive = currentDrive;
        this.currentDirectory = currentDirectory;
    }

    public void displayDirectory(){
        File directory = new File(currentDrive + currentDirectory);
        File[] files = directory.listFiles();

        if (files != null) {
            for (File file : files) {
                String name = file.getName();
                String type = file.isDirectory() ? "<DIR>" : "<FILE>";
                long size = file.length();

                System.out.printf("%-20s%-10s%10d bytes%n", name, type, size);
            }
        } else {
            System.out.println("");
        }
    }
}
