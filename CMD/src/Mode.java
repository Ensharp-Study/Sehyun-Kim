import java.util.HashMap;
import java.util.Map;

public class Mode {
    public void enterCdMode(String command, String currentDrive, String currentDirectory) {
        String commandTokens = command.substring(2); //cd 지우고 나머지 문자열 저장
        String cleanedCommand = commandTokens.replace(" ",""); //나머지 문자열의 공백을 모두 제거

        if (cleanedCommand.equals("..")){
            currentDirectory = moveToParentDirectory(currentDrive, currentDirectory);
            System.out.println(currentDrive + currentDirectory);
        }
        /*
        if (arguments.length>0) {
            String argumentString = arguments[0].substring(3); // Extract the remaining argument after removing "cd"
            String cleanedArgument = argumentString.replaceAll("\\s", ""); // Remove whitespace

            if (cleanedArgument.equals("..")) {
                currentDirectory = moveToParentDirectory(currentDrive, currentDirectory);
                System.out.println(currentDrive + currentDirectory);
            }
        else if (tokens[0].equals("\\")){ // Handle moving to the root directory

        }

        else if (tokens[0].equals("")){

        }

            Map<String, String> result = new HashMap<>();
            result.put("currentDrive", currentDrive);
            result.put("currentDirectory", currentDirectory);

            return result;
        }
        */
    }

    private String moveToParentDirectory(String currentDrive, String currentDirectory) {
        String[] currentPathTokens = currentDirectory.split("\\\\"); // Split by "\\"
        if (currentPathTokens.length > 1) {
            StringBuilder parentDirectory = new StringBuilder();
            for (int i = 0; i < currentPathTokens.length - 1; i++) {
                parentDirectory.append(currentPathTokens[i]).append("\\");
            }
            currentDirectory = parentDirectory.toString();
        }
        return currentDirectory;
    }
}
