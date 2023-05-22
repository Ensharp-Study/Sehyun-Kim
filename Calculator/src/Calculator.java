import javax.swing.JFrame;
import javax.swing.JTextField;
import javax.swing.JPanel;
import java.awt.*;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;

public class Calculator extends JFrame {
    private JPanel calculatePanel;
    private JPanel logPanel;
    private JTextField inputSpace;
    private JTextField displaySpace;

    public void run() {
        createFrame();
        createPanels();
        addComponentListener();
        showFrame();
        createTextField();
        createExpressionTextField();
    }

    // 프레임 생성 메소드
    private void createFrame() {
        setSize(324, 534);
        setMinimumSize(new Dimension(324, 534));
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        getContentPane().setLayout(new BorderLayout());
    }

    // 패널 생성 메소드
    private void createPanels() {
        // 왼쪽 상단 패널 - 계산식 올라가는 패널
        calculatePanel = new JPanel();
        calculatePanel.setPreferredSize(new Dimension(324, 534));
        calculatePanel.setLayout(null); // calculatePanel에 null 레이아웃 설정
        add(calculatePanel);

        // 왼쪽 하단 패널 - 버튼 들어가는 패널
        InputButtonPanel inputButtonPanel = new InputButtonPanel(this);
        inputButtonPanel.setBounds(8, 145, 290, 420);
        calculatePanel.add(inputButtonPanel); // calculatePanel에 inputButtonPanel 추가

        // 오른쪽 패널 - 로그 출력
        logPanel = new JPanel();
        logPanel.setPreferredSize(new Dimension(324, 534));
        logPanel.setBackground(Color.BLUE);
        add(logPanel);
    }

    public void createTextField() {
        inputSpace = new JTextField();
        inputSpace.setBorder(javax.swing.BorderFactory.createEmptyBorder());
        inputSpace.setEditable(true);
        inputSpace.setHorizontalAlignment(JTextField.RIGHT);
        inputSpace.setFont(new Font("Arial", Font.BOLD, 50));
        inputSpace.setBounds(8, 80, 290, 60);

        calculatePanel.add(inputSpace); // calculatePanel에 inputSpace 추가
    }

    public void createExpressionTextField() {
        displaySpace = new JTextField();
        displaySpace.setBorder(javax.swing.BorderFactory.createEmptyBorder());
        displaySpace.setEditable(true);
        displaySpace.setHorizontalAlignment(JTextField.RIGHT);
        displaySpace.setFont(new Font("Noto Sans CJK", Font.PLAIN, 18));
        displaySpace.setBounds(8, 50, 290, 30);
        displaySpace.setForeground(Color.GRAY);

        calculatePanel.add(displaySpace); // calculatePanel에 displaySpace 추가
    }

    //드래그에 따라 창 크기 변경 + logPanel 보이게 하는 메소드
    private void addComponentListener() {
        addComponentListener(new ComponentAdapter() {
            @Override
            public void componentResized(ComponentEvent e) {
                Dimension size = getSize();
                calculatePanel.setPreferredSize(new Dimension(size.width, size.height));

                if (size.width >= 800) { // 계산 패널의 가로 너비가 800 이상이라면, 로그 패널 추가
                    if (logPanel.getParent() == null) {
                        getContentPane().add(logPanel, BorderLayout.EAST);
                        logPanel.setVisible(true);
                    }
                } else { // 아니라면 로그 패널 삭제
                    if (logPanel.getParent() != null) {
                        getContentPane().remove(logPanel);
                        logPanel.setVisible(false);
                    }
                }
                getContentPane().add(calculatePanel, BorderLayout.WEST);
                revalidate();
                repaint();
            }
        });
    }

    private void showFrame() {
        setSize(324, 534);
        setVisible(true);
    }

    public JTextField getInputSpace() {
        return inputSpace;
    }

    public JTextField getDisplaySpace() {
        return displaySpace;
    }
}