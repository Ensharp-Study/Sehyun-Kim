import javax.swing.JPanel;
import javax.swing.JButton;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.text.DecimalFormat;
import java.util.ArrayList;

public class InputButtonPanel extends JPanel {
    private Calculator frame;

    public InputButtonPanel(Calculator frame) {
        this.frame = frame;
        setLayout(new GridLayout(6, 5, 10, 10));

        String button_names[] = {"C", "CE", "⌫", "÷", "7", "8", "9", "×", "4", "5", "6", "-", "1", "2", "3", "+", "±", "0", ".", "="};
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


    class PadActionListener implements ActionListener {
        private String formatResult(double result) {
            if (result == (long) result) {
                return String.format("%d", (long) result); // Format as integer if the result is a whole number
            } else {
                return String.format("%s", result); // Format as decimal number if the result has decimal places
            }
        }
        public void actionPerformed(ActionEvent e) {
            String operation = e.getActionCommand();
            int index = 0;
            Boolean check =true;
            index = frame.getDisplaySpace().getText().length() - 1;

            if (operation.equals("C")) { //C 입력 시
                frame.getInputSpace().setText("");
                frame.getDisplaySpace().setText("");
            }
            else if (operation.equals("CE")) {  //ce
                frame.getInputSpace().setText("");
            }
            else if (operation.equals("⌫")) {
                index = frame.getInputSpace().getText().length() - 1;
                char lastText = frame.getInputSpace().getText().charAt(index);
                if (lastText != '+' && lastText != '-' && lastText != '×' && lastText != '÷') {
                    String result =  frame.getInputSpace().getText();
                    result=result.substring(0, result.length() - 1);
                    frame.getInputSpace().setText(formatNumber(Double.parseDouble(result)));
                    frame.getDisplaySpace().setText(formatNumber(Double.parseDouble(result)));
                }
            }
            else if (operation.equals("=")) {
                String value = frame.getInputSpace().getText();
                String expression = frame.getDisplaySpace().getText();
                frame.getDisplaySpace().setText(expression + value);
                expression = frame.getDisplaySpace().getText();
                double result = calculate(expression); //계산 -> = 빼고 다 들어가있음
                String formattedResult = formatResult(result); //형변환
                frame.getDisplaySpace().setText(expression + "="); // = 더해서 DISPLAYSPACE에 추가
                frame.getInputSpace().setText(formattedResult); //형변환해서 INPUTSPACE에 추가
            }
            else if (operation.equals("+") || operation.equals("-") || operation.equals("×") || operation.equals("÷")) {
                //연산기호면 displacespace에 올리기
                frame.getDisplaySpace().setText(frame.getInputSpace().getText() + operation);
            }
            //index = frame.getDisplaySpace().getText().length() - 1;

            else if (Character.isDigit(operation.charAt(0)) ) { //입력된 게 숫자면
                //if(frame.getInputSpace().getText().length() != 0) {
                    //index = frame.getInputSpace().getText().length() - 1;
                    //char lastText = frame.getDisplaySpace().getText().charAt(index);
                    //String expression = frame.getInputSpace().getText();
                    //int inputIndex = frame.getInputSpace().getText().length() - 1;
                    //char text = frame.getInputSpace().getText().charAt(index);
                    //if ((lastText == '+' || lastText == '-' || lastText == '×' || lastText == '÷') && Character.isDigit(text)) {
                    //    frame.getDisplaySpace().setText(expression + operation);
                    //} //else if (!Character.isDigit(text)) {
                    //    frame.getDisplaySpace().setText("" + operation);
                    //}
                //}
                //else{
                if(frame.getDisplaySpace().getText().endsWith("+") || frame.getDisplaySpace().getText().endsWith("-") || frame.getDisplaySpace().getText().endsWith("×") || frame.getDisplaySpace().getText().endsWith("÷")) {
                    frame.getInputSpace().setText(String.valueOf(operation.charAt(0)));
                }
                else if(frame.getDisplaySpace().getText().endsWith("=")) {
                    frame.getDisplaySpace().setText("");
                    frame.getInputSpace().setText(String.valueOf(operation.charAt(0)));
                }
                    else {
                    if (frame.getInputSpace().getText().length() < 16) {
                        frame.getInputSpace().setText(frame.getInputSpace().getText() + operation.charAt(0));
                    }
                }
                //}
            }
            else if (operation.equals(".")){ //점이 입력될 떄
                String expression = frame.getInputSpace().getText();
                frame.getInputSpace().setText(expression+operation);
            }
            else if (Character.isDigit(operation.charAt(0))) { //숫자 처음으로 입력될 떄
                if (frame.getInputSpace().getText().equals("0")) {
                    frame.getInputSpace().setText("");
                    frame.getDisplaySpace().setText("");
                }
                frame.getInputSpace().setText(formatNumber(Double.parseDouble(operation)));
            }
            else if (operation.equals("Log")) {
                // Handle Log operation
            }

        }

        private String formatNumber(double number) {
            DecimalFormat decimalFormat = new DecimalFormat("#,###.###");
            return decimalFormat.format(number);
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
}