import javax.swing.JPanel;
import javax.swing.JButton;
import java.awt.Color;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

public class ButtonPanel extends JPanel {
    private CalculatorFrame frame;
    public ButtonPanel(CalculatorFrame frame) {
        this.frame = frame;
        setLayout(new GridLayout(6, 5, 10, 10));

        String button_names[] = { "C", "CE", "⌫", "÷", "7", "8", "9", "×", "4", "5", "6", "-", "1", "2", "3", "+", "±", "0", ".", "=" };
        JButton buttons[] = new JButton[button_names.length];
        Color color = new Color(0, 153, 153);

        for (int i = 0; i < button_names.length; i++) {
            buttons[i] = new JButton(button_names[i]);
            buttons[i].setFont(new Font("Noto Sans CJK", Font.PLAIN, 15));
            if (i == 19) {
                buttons[i].setBackground(color);
                buttons[i].setForeground(Color.WHITE);
            } else {
                buttons[i].setBackground(Color.WHITE);
                buttons[i].setForeground(Color.BLACK);
            }
            buttons[i].setBorderPainted(false);
            buttons[i].addActionListener(new PadActionListener());
            add(buttons[i]);
        }
    }

    private void addButtonsToPanel(JButton[] buttons) {
        for (JButton button : buttons) {
            add(button);
        }
    }

    class PadActionListener implements ActionListener {
        public void actionPerformed(ActionEvent e) {
            String operation = e.getActionCommand();
            int index = 0;
            index = frame.getDisplaySpace().getText().length() - 1;

            if (operation.equals("C")) { //C 입력 시
                frame.getInputSpace().setText("");
                frame.getDisplaySpace().setText("");
            }
            else if (operation.equals("CE")) {  //c와 ce 차이 있는거 반영하기
                frame.getInputSpace().setText("");
                frame.getDisplaySpace().setText("");
            }
            else if (operation.equals("=")) {  //= 입력 시
                String expression = frame.getDisplaySpace().getText();
                String result = Double.toString(calculate(expression));
                frame.getDisplaySpace().setText(expression);
                frame.getInputSpace().setText(result);
            }
            else if (operation.equals("+") || operation.equals("-") || operation.equals("×") || operation.equals("÷")) {
                //연산기호 입력 시
                frame.getDisplaySpace().setText(frame.getDisplaySpace().getText() + operation);
            }
            else if (Character.isDigit(operation.charAt(0)) && index >= 0) {
                //else 숫자 입력 시
                index = frame.getDisplaySpace().getText().length() - 1;
                char lastText = frame.getDisplaySpace().getText().charAt(index);
                frame.getDisplaySpace().setText(frame.getDisplaySpace().getText() + operation);

                if (Character.isDigit(lastText)) { //그 전 입력도 숫자면
                    frame.getInputSpace().setText(frame.getInputSpace().getText() + operation);
                } else { //그 전 입력이 숫자가 아니면
                    frame.getInputSpace().setText("" + operation);
                }
            }
            else if (Character.isDigit(operation.charAt(0))) {
                //처음에 숫자면
                frame.getDisplaySpace().setText(operation);
                frame.getInputSpace().setText(operation);
            }
            else if (operation.equals("Log")) {
                // Handle Log operation
            }
        }
    }

    private double calculate(String inputText) {
        ArrayList<String> equation = separateText(inputText);
        double expression = 0;
        double number = 0;
        String mode = "";

        for (int i = 0; i < equation.size(); i++) {
            String text = equation.get(i);
            if (text.equals("+")) {
                mode = "add";
            } else if (text.equals("-")) {
                mode = "sub";
            } else if (text.equals("×")) {
                mode = "mul";
            } else if (text.equals("÷")) {
                mode = "div";
            } else {
                number = Double.parseDouble(text);
                if (mode.equals("add")) {
                    expression += number;
                } else if (mode.equals("sub")) {
                    expression -= number;
                } else if (mode.equals("mul")) {
                    expression *= number;
                } else if (mode.equals("div")) {
                    expression /= number;
                } else {
                    expression = number;
                }
                expression = Math.round(expression * 100000) / 100000.0;
                mode = "";

                if (i < equation.size() - 1 && (equation.get(i + 1).equals("+") || equation.get(i + 1).equals("-")
                        || equation.get(i + 1).equals("×") || equation.get(i + 1).equals("÷"))) {
                    equation.remove(i);
                    equation.set(i, equation.get(i));
                    i--;
                }
            }
        }
        return expression;
    }

    private ArrayList<String> separateText(String inputText) {
        //분리한 숫자는 num에 들어가고,
        //equation에는 num + 연산기호 + num 의 형태로 식이 들어간다.
        ArrayList<String> equation = new ArrayList<String>();
        String num = "";

        for (int i = 0; i < inputText.length(); i++) { //입력된 문자열을 분석한다.
            char text = inputText.charAt(i);
            if (text == '-' || text == '+' || text == '×' || text == '÷') {
                equation.add(num); //지금까지 이어 붙였던 num을 equation에 add
                num = ""; //num 초기화
                equation.add(text + ""); //text 변수의 값을 문자열로 바꾼 뒤에 equation에 이어 붙인다.
            } else {  //연산기호가 아닐 경우 (숫자일 경우에는)
                num = num + text;
            }
        }
        equation.add(num);  //남아있을 수 있는 num을 equation에 add

        return equation;
    }

}