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

        if (cleanedCommand.equals("..")){
            currentDirectory = moveToParentDirectory(currentDrive, currentDirectory);
        }

        return currentDirectory;

    }

    private String moveToParentDirectory(String currentDrive, String currentDirectory) {
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

    private String moveTo
}
