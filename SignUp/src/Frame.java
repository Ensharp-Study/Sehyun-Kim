import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

public class Frame extends JFrame {
    //이미지 변수를 전역적으로 사용할 수 있도록 클래스의 멤버 변수로 선언
    private BufferedImage mainFrameBackground; //메인 화면(프레임) 배경 이미지
    private BufferedImage logInImage; //로그인 패널 이미지

    public void run(){

    }

    //메인 프레임 이미지를 불러오는 메소드
    private void bringMainFrameImage( ){
        //BufferedImage 변수 mainFrameBackground 선언, 초기화
        BufferedImage mainFrameBackground = null;

        //mainFrameBackground 로드하기
        try {
            mainFrameBackground =ImageIO.read(new File("images/엔샵크래프트.png"));
        }
        //로드 과정에서 예외 발생 시 스택 트레이스 출력
        catch (IOException e) {
            e.printStackTrace();
        }
    }

    //프레임 생성하는 메소드
    private void createFrame() {
        setTitle("엔샵크래프트");
        setResizable(false);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        JPanel panel = new JPanel() {
            @Override
            //배경 이미지 그리기
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(mainFrameBackground, 0, 0, getWidth(), getHeight(), null);
            }
        };
        panel.setPreferredSize(new Dimension(1000, 600));

        add(panel);
        pack();
        setVisible(true);
    }

    //로그인 패널 이미지를 불러오는 메소드
    private void bringLogInImage(){
        //BufferedImage 변수 logInImage 선언, 초기화
        BufferedImage logInImage = null;

        //logInImage 로드하기
        try {
            logInImage = ImageIO.read(new File("images/마크 로그인.png"));
        }
        //로드 과정에서 예외 발생 시 스택 트레이스 출력
        catch (IOException e) {
            e.printStackTrace();
        }
    }

    //로그인 패널을 추가하는 메소드
    private void addLogInPanel(){

        //패널 추가
        JPanel LogInPanel = new JPanel(){
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(logInImage, 0, 0, null);
            }
        }

    }

    private void addSignUpPanel(){

    }

    private void addIdSearcherPanel(){

    }

    private void addPwSearcherPanel(){

    }
}