import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Scanner {
    private BufferedReader reader;

    public Scanner() {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }
    public void run(){
        while (true) {
            scanInput();
        }
    }
    public String scanInput(){
        System.out.print("> ");
        String command=null;
        command = reader.readLine();
        if (command.equals("exit")){
            System.out.println("프로그램을 종료합니다.");
            System.exit(0);
        }
        else {
            return command;
        }
        return null;
    }
}
