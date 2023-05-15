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
public class GUIFrame extends JFrame {
    private JTextField inputSpace;
    //계산식의 숫자를 담을 변수 num
    private String num = "";
    //계산 기능을 구현하기 위해 ArrayList에 숫자와 연산 기호를 하나씩 구분해 담음
    private ArrayList<String> equation = new ArrayList<String>();
    public void createJFrame() {
        // JFrame 생성 및 초기화 -> JFrame : 밑바탕이 되는 프레임
        JFrame frame = new JFrame("Calculator");
        frame.setPreferredSize(new Dimension(324, 534)); //기본 사이즈 지정
        frame.setMinimumSize(new Dimension(324, 534)); //최소 사이즈 지정
        frame.setLocationRelativeTo(null); //setDefaultCloseOperation 짝꿍
        setResizable(false); //크기 지정 가능
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); //esc 눌러도 남아있는 JVM을 다 지워주는 기능
    }
    public void createTextField(){
        //JTextField 생성
        setLayout(null); //컨테이너의 레이아웃 매니저를 NULL로 설정한다. -> 하위 컴포넌트들은 레이아웃 매니저에 의해 배치되는 것이 아니라 setBounds()메소드로 위치,크기 지정된다.
        inputSpace = new JTextField(); //JTextField 클래스 객체 생성하여 inputSpace 변수에 할당한다.
        inputSpace.setEditable(false); // 편집 불가능 -> 버튼만 사용
        inputSpace.setBackground(Color.WHITE); // 배경색 설정
        inputSpace.setHorizontalAlignment(JTextField.RIGHT); // 정렬위치 설정
        inputSpace.setFont(new Font("Arial", Font.BOLD, 50)); // 글씨체 설정
        // 위치와 크기(x:8,y:10의 위치에 270x70의 크기)
        inputSpace.setBounds(8, 10, 290, 70);
        add(inputSpace);

        setTitle("계산기");
        setVisible(true);
        setMinimumSize(new Dimension(324, 534));
        setSize(324,534);
        setResizable(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        // 화면의 가운데에 띄움
        setLocationRelativeTo(null);
    }

    public void createPannel(){
        setLayout(null);
        JPanel buttonPanel = new JPanel();
        //GridLayout(4, 4, 10, 10) -> 가로 칸수, 세로 칸수, 좌우 간격, 상하 간격
        buttonPanel.setLayout(new GridLayout(6, 5, 10, 10));
        buttonPanel.setBounds(8, 90, 290, 235);

        String button_names[] = { "CE", "C", "◀", "÷", "7", "8", "9", "x", "4", "5", "6", "-", "1", "2", "3", "+","±","0",".","=" };
        JButton buttons[] = new JButton[button_names.length]; //배열 생성

        for (int i = 0; i < button_names.length; i++) {
            buttons[i] = new JButton(button_names[i]);
            buttons[i].setFont(new Font("Arial", Font.BOLD, 15));
            if ((i >= 4 && i <= 6) || (i >= 8 && i <= 10) || (i >= 12 && i <= 14) || (i == 17)) buttons[i].setBackground(Color.WHITE);
            else buttons[i].setBackground(Color.GRAY);
            buttons[i].setForeground(Color.BLACK);
            //테두리 없애기
            buttons[i].setBorderPainted(false);
            //액션리스너를 버튼에 추가
            //buttons[i].addActionListener(new PadActionListener());
            buttonPanel.add(buttons[i]);
        }
        add(inputSpace);
        add(buttonPanel);
    }

}