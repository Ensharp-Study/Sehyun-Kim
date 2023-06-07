import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

public class Frame extends JFrame {

    //프로그램 실행 메소드
    public void run() {
        //bringImage 메소드를 통해 전달받은 상대경로 매개변수로 이미지를 가져오기
        BufferedImage mainFrameBackground = bringImage("images/엔샵크래프트.png");
        BufferedImage logInImage = bringImage("images/마크 로그인.png");
        BufferedImage signUpImage = bringImage("images/마크 회원가입.png");
        BufferedImage idSearcherImage = bringImage("images/마크 ID찾기.png");
        BufferedImage pwSearcherImage = bringImage("images/마크 PW찾기.png");

        //프레임 생성
        createFrame(mainFrameBackground);

        //패널+버튼 추가
        addButton(logInImage, 330, 310, 340, 80);
        addButton(signUpImage, 330, 400, 340, 80);
        addButton(idSearcherImage, 330, 490, 160, 80);
        addButton(pwSearcherImage, 510, 490, 160, 80);
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
        setTitle("엔샵크래프트");
        setResizable(false);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        JPanel mainPanel = new JPanel(new BorderLayout()) {
            @Override
            //배경 이미지 그리기
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(frameBackground, 0, 0, getWidth(), getHeight(), null);
            }
        };
        mainPanel.setPreferredSize(new Dimension(1000, 600));
        add(mainPanel);
        pack();
        setVisible(true);
    }

    //패널+버튼을 추가하는 메소드
    //매개변수는 이미지 객체
    private void addButton(BufferedImage logInImage, int xCoordinate, int yCoordinate, int width, int height) {
        //패널 생성
        JPanel panel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(logInImage, 0, 0, getWidth(), getHeight(), null);
            }
        };
        panel.setOpaque(false); // 패널 배경을 투명하게 설정
        panel.setBounds(xCoordinate, yCoordinate, width, height);

        //버튼 생성
        JButton button = new JButton();
        button.setPreferredSize(new Dimension(width, height));
        button.setContentAreaFilled(false); // 버튼 배경을 투명하게 설정
        button.setBorderPainted(false); // 버튼 외곽선 제거

        panel.add(button);

        //메인 패널에 추가하기
        JPanel mainPanel = (JPanel) getContentPane().getComponent(0);
        mainPanel.setLayout(null); // 레이아웃 매니저를 null로 설정하여 컴포넌트의 위치를 직접 지정
        mainPanel.add(panel); // 로그인 패널을 메인 패널에 추가

        revalidate();
    }
}