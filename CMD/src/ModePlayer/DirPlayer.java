package ModePlayer;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;

public class DirPlayer {
    private String currentDrive; //현재 드라이브의 정보를 담을 변수
    private String currentDirectory; //현재 디렉터리의 정보를 담을 변수
    public DirPlayer(String currentDrive, String currentDirectory) {
        this.currentDrive = currentDrive;
        this.currentDirectory = currentDirectory;
    }

    public void displayDirectory() {
        File directory = new File(currentDrive + currentDirectory);
        File[] files = directory.listFiles();

        if (files != null) {
            SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd hh:mm a");

            for (File file : files) {
                String name = file.getName();
                String type = file.isDirectory() ? "<DIR>" : " ";
                long size = file.length();
                long lastModified = file.lastModified();
                String lastModifiedDateString = dateFormat.format(new Date(lastModified));

                System.out.printf("%s\t%s\t%-10s\t%,12d bytes%n", lastModifiedDateString.substring(0, 10), lastModifiedDateString.substring(11), type, size);
            }
            System.out.printf("%d개 파일\t\t\t\t\t\t\t%,15d 바이트%n", files.length, directory.getTotalSpace());
            System.out.printf("%d개 디렉터리\t\t\t\t\t\t\t%,15d 바이트 남음%n", directory.listFiles(File::isDirectory).length, directory.getFreeSpace());
        } else {
            System.out.println("");
        }
    }

}
