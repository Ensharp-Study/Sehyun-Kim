import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

public class MainFrame extends JFrame {
    private BufferedImage mainFrameBackground;
    private BufferedImage logInButtonImage;
    private BufferedImage signUpImage;
    private BufferedImage idSearcherImage;
    private BufferedImage pwSearcherImage;
    private JButton logInButton;
    private JButton signUpButton;
    private JButton idSearcherButton;
    private JButton pwSearcherButton;
    private JPanel mainPanel;
    private JFrame mainFrame;
    private JButton popUppedLogIn;
    private JPanel wallPanel;
    private JPanel panel;
    private JPanel backPanel;
    private JButton popUppedLogInButton;
    public MainFrame() {
        //bringImage 메소드를 통해 전달받은 상대경로 매개변수로 이미지를 가져오기
        this.mainFrameBackground = bringImage("images/엔샵크래프트.png");
        this.logInButtonImage = bringImage("images/마크 로그인.png");
        this.signUpImage = bringImage("images/마크 회원가입.png");
        this.idSearcherImage = bringImage("images/마크 ID찾기.png");
        this.pwSearcherImage = bringImage("images/마크 PW찾기.png");


        this.logInButton = new JButton();
        this.signUpButton = new JButton();
        this.idSearcherButton = new JButton();
        this.pwSearcherButton = new JButton();
        this.mainPanel = new JPanel();
        this.mainFrame=new JFrame();
        this.popUppedLogIn = new JButton();
        this.panel= new JPanel();
        this.backPanel=new JPanel();
        this.popUppedLogInButton= new JButton();
    }

    //프로그램 실행 메소드
        public void run() {
        MainFunction mainFunction = new MainFunction();
        //프레임 생성
        createFrame(mainFrameBackground);

        addButton(logInButtonImage, 330, 310, 340, 80, logInButton);
        addButton(signUpImage, 330, 400, 340, 80, signUpButton);
        addButton(idSearcherImage, 330, 490, 160, 80, idSearcherButton);
        addButton(pwSearcherImage, 510, 490, 160, 80, pwSearcherButton);

        //로그인 버튼이 눌렸을경우
        addFunctionToButton(logInButton, () -> {
            Component[] components = mainPanel.getComponents();
            for (Component component : components) {
                component.setVisible(false);
            } // mainPanel 구성요소 모두 안 보이게
            // backPanel에 패널 추가
            BufferedImage logInImage = bringImage("images/로그인.png");
            backPanel = addPanel(logInImage, 300, 310, 400, 230);

            backPanel.setLayout(null); // 레이아웃 매니저를 null로 설정

            JTextField idTextField = new JTextField();
            backPanel.add(idTextField);
            idTextField.setBounds(15, 25, 372, 58);

            JTextField pwTextField = new JTextField();
            backPanel.add(pwTextField);
            pwTextField.setBounds(15, 100, 372, 58);
            // 로그인 버튼 이미지 가져오고 버튼 추가
            BufferedImage logInButtonImage = bringImage("images/로그인 버튼.png");
            JButton logInButton = new JButton(new ImageIcon(logInButtonImage));
            logInButton.setBounds(10, 160, 380, 60);
            logInButton.setContentAreaFilled(false);
            logInButton.addActionListener(e -> {
                String userId = idTextField.getText();
                String userPw = pwTextField.getText();
                SqlConnector sqlConnector = new SqlConnector();
                sqlConnector.connectToSql(userId,userPw);
                Component[] element = backPanel.getComponents();
                for (Component component : element) {
                    component.setVisible(false);
                } // mainPanel 구성요소 모두 안 보이게
                Component[] elements = mainPanel.getComponents();
                for (Component component : elements) {
                    component.setVisible(true);
                } // mainPanel 구성요소 모두 안 보이게
            });
            backPanel.add(logInButton);

            JLayeredPane layeredPane = new JLayeredPane();
            wallPanel.removeAll(); // 기존 구성 요소 제거
            wallPanel.setLayout(new BorderLayout());
            wallPanel.add(layeredPane, BorderLayout.CENTER);

            // backPanel을 JLayeredPane에 추가
            layeredPane.add(backPanel, JLayeredPane.PALETTE_LAYER);
            mainFrame.revalidate(); // 변경 사항을 적용
        });
        addFunctionToButton(signUpButton, () -> {
            Component[] components = mainPanel.getComponents();
            for (Component component : components) {
                component.setVisible(false);
            } // mainPanel 구성요소 모두 안 보이게
            // backPanel에 패널 추가
            BufferedImage logInImage = bringImage("images/로그인.png");
            backPanel = addPanel(logInImage, 300, 310, 400, 230);

            backPanel.setLayout(null); // 레이아웃 매니저를 null로 설정
        });
        addFunctionToButton(idSearcherButton, () -> {
            System.out.println("버튼 클릭");
        });
        addFunctionToButton(pwSearcherButton, () -> {
            System.out.println("버튼 클릭");
        });
    }

    //패널 추가하는 메소드
    public JPanel addPanel(BufferedImage logInImage, int xCoordinate, int yCoordinate, int width, int height){
        panel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(logInImage, 0, 0, getWidth(), getHeight(), null);
            }
        };
        panel.setOpaque(false); // 패널 배경을 투명하게 설정
        panel.setBounds(xCoordinate, yCoordinate, width, height);

        return panel;
    }

    public JButton addButtonBack(BufferedImage logInImage, int xCoordinate, int yCoordinate, int width, int height, JButton button) {
        // 패널 생성
        JPanel panel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(logInImage, 0, 0, getWidth(), getHeight(), null);
            }
        };
        panel.setOpaque(false); // 패널 배경을 투명하게 설정
        panel.setBounds(xCoordinate, yCoordinate, width, height);

        button.setPreferredSize(new Dimension(width, height));
        button.setContentAreaFilled(false); // 버튼 배경을 투명하게 설정
        panel.add(button);

        backPanel.setLayout(null); // 레이아웃 매니저를 null로 설정하여 컴포넌트의 위치를 직접 지정
        backPanel.add(panel); // 로그인 패널을 메인 패널에 추가

        revalidate();

        return button;
    }
    //패널+버튼을 추가하는 메소드
    //매개변수는 이미지 객체, x/y좌표, 너비/높이
    public void addButton(BufferedImage logInImage, int xCoordinate, int yCoordinate, int width, int height, JButton button) {
        // 패널 생성
        JPanel panel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(logInImage, 0, 0, getWidth(), getHeight(), null);
            }
        };
        panel.setOpaque(false); // 패널 배경을 투명하게 설정
        panel.setBounds(xCoordinate, yCoordinate, width, height);

        button.setPreferredSize(new Dimension(width, height));
        button.setContentAreaFilled(false); // 버튼 배경을 투명하게 설정
        panel.add(button);

        // 메인 패널 가져오기
        mainPanel = (JPanel) getContentPane().getComponent(0); // getContentPane()를 사용하여 메인 패널 가져오기

        mainPanel.setLayout(null); // 레이아웃 매니저를 null로 설정하여 컴포넌트의 위치를 직접 지정
        mainPanel.add(panel); // 로그인 패널을 메인 패널에 추가

        revalidate();
    }

    //이미지를 가져오는 메소드
    public BufferedImage bringImage(String route){
        BufferedImage imageObject = null;
        try {
            imageObject = ImageIO.read(new File(route));
        } catch (IOException e) {
            e.printStackTrace();
        }
        return imageObject;
    }

    //프레임 생성하는 메소드
    //매개변수는 이미지 객체
    private void createFrame(BufferedImage frameBackground) {
        mainFrame = new JFrame();
        mainFrame.setTitle("엔샵크래프트");
        mainFrame.setResizable(false);
        mainFrame.setLocationRelativeTo(null);
        mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        //메인패널에 이미지 넣기
        wallPanel = new JPanel(new BorderLayout()) {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(frameBackground, 0, 0, getWidth(), getHeight(), null);
            }
        };
        //크기조정
        wallPanel.setPreferredSize(new Dimension(1000, 600));
        getContentPane().add(wallPanel);
        pack();
        setVisible(true);
    }



    private void addFunctionToButton(JButton button, Runnable action) {
        button.addActionListener(e -> {
            action.run(); // 버튼 클릭 시 전달받은 내용 실행
        });
    }
}