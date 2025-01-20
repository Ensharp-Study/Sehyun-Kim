import view.CalculatorFrame;
import controller.MainController;

public class Main {
    public static void main(String[] args) {
        CalculatorFrame frame = new CalculatorFrame(); // 프레임 생성
        MainController controller = new MainController(frame); // MainController 초기화
    }
}
