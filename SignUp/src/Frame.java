import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;
import java.awt.*;

public class Frame extends JFrame {

    public void createFrame() {
        Image background;

        setTitle("마인크래프트");
        setResizable(false);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        background = new ImageIcon("엔샵크래프트.png").getImage();
        JPanel panel = new JPanel() {
            @Override
            //배경 이미지 그리기
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(background, 0, 0, getWidth(), getHeight(), null);
            }
        };
        panel.setPreferredSize(new Dimension(1000, 600));

        add(panel);
        pack();
        setVisible(true);
    }
}