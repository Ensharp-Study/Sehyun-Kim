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
import javax.swing.JFrame;
public class GUIFrame extends JFrame {
    private JTextArea logArea;
    private JTextField inputSpace;
    //계산식의 숫자를 담을 변수 num
    private String num = "";
    //계산 기능을 구현하기 위해 ArrayList에 숫자와 연산 기호를 하나씩 구분해 담음3
    private ArrayList<String> equation = new ArrayList<String>();
    public void createJFrame() { //프레임
        // JFrame 생성 및 초기화 -> JFrame : 밑바탕이 되는 프레임
        JFrame frame = new JFrame("Calculator");
        frame.setPreferredSize(new Dimension(324, 534));
        frame.setMinimumSize(new Dimension(324, 534));
        frame.setLocationRelativeTo(null); //setDefaultCloseOperation 짝꿍
        setResizable(false);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); //esc 눌러도 남아있는 JVM을 다 지워주는 기능
    }
    public void createTextField(){ //텍스트필드
        //JTextField 생성
        setLayout(null); //컨테이너의 레이아웃 매니저를 NULL로 설정한다.

        // -> 하위 컴포넌트들은 레이아웃 매니저에 의해 배치되는 것이 아니라 setBounds()메소드로 위치,크기 지정된다.
        inputSpace = new JTextField();
        inputSpace.setEditable(false);
        inputSpace.setBackground(Color.WHITE);
        inputSpace.setHorizontalAlignment(JTextField.RIGHT);
        inputSpace.setFont(new Font("Arial", Font.BOLD, 50));
        inputSpace.setBounds(8, 50, 290, 70);
        add(inputSpace);

        setTitle("계산기");
        setVisible(true);
        setMinimumSize(new Dimension(324, 534));
        setSize(324,534);
        setResizable(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
    }

    public void createPannel(){ //패널
        setLayout(null);
        JPanel buttonPanel = new JPanel();
        //GridLayout(4, 4, 10, 10) -> 가로 칸수, 세로 칸수, 좌우 간격, 상하 간격
        buttonPanel.setLayout(new GridLayout(6, 5, 10, 10));
        buttonPanel.setBounds(8, 130, 290, 420);

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
                String result = Double.toString(calculate(inputSpace.getText()));
                //inputspace 에 입력된 문자열을 calculate 메소드의 매개변수로 넣어서 string 형식으로 바꿔서 result에 저장
                inputSpace.setText("" + result);

                num = "";
            }
            else { //숫자면
                inputSpace.setText(inputSpace.getText() + e.getActionCommand());
            }
        }
    }

    public void separateText(String inputText) {
        equation.clear(); //equation 초기화

        for (int i = 1; i < inputText.length(); i++) {
            char text = inputText.charAt(i);
            char prevText=inputText.charAt(i-1);

            if (isOperator(prevText)&&isOperator(text)){
                // 이전 문자와 현재 문자가 모두 연산자인 경우
                equation.remove(equation.size() - 1); // 이전 연산자 제거
                equation.add(text + ""); // 현재 연산자 추가
            }
            else if (!isOperator(prevText)&&isOperator(text)){
                // 이전 문자는 숫자이고, 현재 문자가 연산자인 경우
                equation.add(num); // 지금까지 더해놨던 num을 equation에 추가하기
                num = ""; // num 초기화
                equation.add(text + ""); // equation에 text를 추가
            }
            else if (isOperator(prevText)&&!isOperator(text)){
                // 이전 문자가 연산자이고, 현재 문자는 숫자인 경우
                equation.add(text + ""); // equation에 text를 추가
            }
            else if (!isOperator(prevText)&&!isOperator(text)) {
                // 이전 문자와 현재 문자가 모두 숫자인 경우
                num = num + text;
            }
        }
        equation.add(num);
    }

    public boolean isOperator (char text){
        return text == '+' || text == '-' || text == '*' || text == '/';
    } //text가 연산기호면 true 반환, 아니면 false 반환하는 메소드 isOperator

    public double calculate(String inputText) {
        separateText(inputText);

        double firstExpression = 0;
        double secondExpression = 0;
        String mode = "";

        for (String s : equation) {
            if (s.equals("+")) {
                mode = "add";
            } else if (s.equals("-")) {
                mode = "sub";
            } else if (s.equals("×")) {
                mode = "mul";
            } else if (s.equals("÷")) {
                mode = "div";
            } else {
                secondExpression = Double.parseDouble(s);

                if (mode.equals("add")) {
                    firstExpression += secondExpression;
                } else if (mode.equals("sub")) {
                    firstExpression -= secondExpression;
                } else if (mode.equals("mul")) {
                    firstExpression *= secondExpression;
                } else if (mode.equals("div")) {
                    firstExpression /= secondExpression;
                } else { //숫자면
                    firstExpression = secondExpression;
                }
                firstExpression = Math.round(firstExpression * 100000) / 100000.0;
                mode = "";
            }
        }

        return firstExpression;
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

