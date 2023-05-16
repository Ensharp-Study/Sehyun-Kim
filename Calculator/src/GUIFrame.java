import javax.swing.JFrame;
import javax.swing.JButton;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.Dimension;
import java.awt.Color;
import java.awt.Font;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.*;
import java.awt.GridLayout;
import java.util.ArrayList;
import java.awt.*;
import java.awt.event.*;
import javax.swing.event.*;
import javax.swing.*;
import javax.swing.JFrame;
public class GUIFrame extends JFrame {
    private JTextArea logArea;
    private JTextField inputSpace;
    private JTextField displaySpace;
    private String num = "";
    private ArrayList<String> equation = new ArrayList<String>();

    public void createJFrame() {
        setSize(324, 534);
        setMinimumSize(new Dimension(324, 534));
        setLocationRelativeTo(null);
        setTitle("계산기");
        setVisible(true);
        setResizable(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        createTextField();
        createExpressionTextField();
    }

    public void createTextField() { //숫자가 들어가는 TEXTFIELD
        setLayout(null);

        inputSpace = new JTextField();
        inputSpace.setBorder(javax.swing.BorderFactory.createEmptyBorder());
        inputSpace.setEditable(true);
        inputSpace.setHorizontalAlignment(JTextField.RIGHT);
        inputSpace.setFont(new Font("Arial", Font.BOLD, 50));
        inputSpace.setBounds(8, 80, 290, 60);

        add(inputSpace);
    }
    public void createExpressionTextField() { //식이 들어가는 TEXTFIELD
        setLayout(null);

        displaySpace = new JTextField();
        displaySpace.setBorder(javax.swing.BorderFactory.createEmptyBorder());
        displaySpace.setEditable(true);
        displaySpace.setHorizontalAlignment(JTextField.RIGHT);
        displaySpace.setFont(new Font("Noto Sans CJK", Font.PLAIN, 18));
        displaySpace.setBounds(8, 50, 290, 30);
        displaySpace.setForeground(Color.GRAY);
        add(displaySpace);
    }

    public void createPannel(){ //패널
        setLayout(null);
        JPanel buttonPanel = new JPanel();
        //GridLayout(4, 4, 10, 10) -> 가로 칸수, 세로 칸수, 좌우 간격, 상하 간격
        buttonPanel.setLayout(new GridLayout(6, 5, 10, 10));
        buttonPanel.setBounds(8, 145, 290, 420);

        String button_names[] = { "C", "CE", "⌫", "÷", "7", "8", "9", "×", "4", "5", "6", "-", "1", "2", "3", "+","±","0",".","=" };
        JButton buttons[] = new JButton[button_names.length];
        Color color = new Color(0, 153, 153);
        for (int i = 0; i < button_names.length; i++) {
            buttons[i] = new JButton(button_names[i]);
            buttons[i].setFont(new Font("Noto Sans CJK", Font.PLAIN, 15));
            if (i==19){
                buttons[i].setBackground(color);
                buttons[i].setForeground(Color.WHITE);
            }
            else {
                buttons[i].setBackground(Color.WHITE);
                buttons[i].setForeground(Color.BLACK);
            }
            buttons[i].setBorderPainted(false);
            buttons[i].addActionListener(new PadActionListener());
            buttonPanel.add(buttons[i]);
        }
        JButton logButton = new JButton("LOG");
        logButton.setBounds(220, 10, 80, 30);
        logButton.setFont(new Font("Noto Sans CJK", Font.PLAIN,15));
        logButton.setBorderPainted(false);
        logButton.setForeground(Color.BLACK);
        logButton.setBackground(Color.WHITE);
        add(logButton);
        logButton.addActionListener(new PadActionListener());

        add(inputSpace);
        add(buttonPanel);
    }

    class PadActionListener implements ActionListener{

        public void actionPerformed(ActionEvent e) {
            String operation = e.getActionCommand();

            if (operation.equals("C")) {
                inputSpace.setText("");
            }
            else if (operation.equals("CE")) {
                inputSpace.setText("");
            }
            else if (operation.equals("=")) {
                String expression = inputSpace.getText();
                String result = Double.toString(calculate(inputSpace.getText()));
                displaySpace.setText(""+expression+"=");
                inputSpace.setText("" + result);
                num = "";
            }
            else if  (operation.equals("+")||operation.equals("-")||operation.equals("×")||operation.equals("÷")){
                String expression = inputSpace.getText();
                displaySpace.setText(expression+operation);

            }
            else if (operation.equals("Log")) {
//로그 버튼 -> 로그 패널 하나 더 만들기
            }
            else {
                inputSpace.setText(inputSpace.getText() + e.getActionCommand());
            }
        }
    }

    public void seperateText(String inputText) {
        equation.clear();

        for (int i = 0; i < inputText.length(); i++) {
            char text = inputText.charAt(i);
            if (text == '-' || text == '+' || text == '×' || text == '÷') {
                equation.add(num);
                num = "";
                equation.add(text + "");
            } else {
                num = num + text;
            }
        }
        equation.add(num);
    }

    public double calculate(String inputText) {
        seperateText(inputText); //이 메소드를 통해 입력된 식은 equation 리스트에 담김
        double expression = 0;
        double number = 0;
        String mode = "";

        //리스트에 있는 요소를 하나씩 꺼내기
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
            } else { //연산자가 아니라면(숫자인 경우)
                number = Double.parseDouble(text);
                //숫자로 변환한 뒤 number 변수에 저장
                if (mode.equals("add")) { //더하기
                    expression += number;
                } else if (mode.equals("sub")) { //빼기
                    expression -= number;
                } else if (mode.equals("mul")) { //곱하기
                    expression *= number;
                } else if (mode.equals("div")) { //나누기
                    expression /= number;
                } else { //숫자면
                    expression = number;
                }
                expression = Math.round(expression * 100000) / 100000.0;
                mode = "";

                // 현재 검사 중인 요소가 연산자이고, 다음 요소도 연산자인 경우
                if (i < equation.size() - 1 && (equation.get(i + 1).equals("+") || equation.get(i + 1).equals("-") || equation.get(i + 1).equals("×") || equation.get(i + 1).equals("÷"))) {
                    // i번째 요소 제거
                    equation.remove(i);
                    // i+1번째 요소를 현재 요소로 설정
                    equation.set(i, equation.get(i));
                    // i를 감소시켜 다음 요소를 검사하도록 함
                    i--;
                }
            }
        }

        return expression;
    }

    public void displayLog(){
        JPanel logPanel = new JPanel();
        logArea = new JTextArea(10, 20);
        JScrollPane scrollPane = new JScrollPane(logArea);
        logArea.setEditable(false);
        logPanel.add(scrollPane);

        JPanel logButtonPanel = new JPanel();
        JButton showLogButton = new JButton("Show Log");
        JButton hideLogButton = new JButton("Hide Log");
        showLogButton.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                logPanel.setVisible(true);
                showLogButton.setVisible(false);
                hideLogButton.setVisible(true);
            }
        });
        hideLogButton.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                logPanel.setVisible(false);
                showLogButton.setVisible(true);
                hideLogButton.setVisible(false);
            }
        });
        hideLogButton.setVisible(false);
        logButtonPanel.add(showLogButton);
        logButtonPanel.add(hideLogButton);

        // 로그 패널과 로그 버튼 패널을 프레임의 EAST에 추가합니다.
        JPanel rightPanel = new JPanel(new BorderLayout());
        rightPanel.add(logButtonPanel, BorderLayout.NORTH);
        rightPanel.add(logPanel, BorderLayout.CENTER);
        //frame.add(rightPanel, BorderLayout.EAST);
    }
}

