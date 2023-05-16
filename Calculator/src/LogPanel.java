import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class LogPanel {
    public void displayLog(){
        JPanel logPanel = new JPanel();
        JTextArea logArea = new JTextArea(10, 20);
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

        // 로그 패널과 로그 버튼 패널을 프레임의 EAST에 추가
        JPanel rightPanel = new JPanel(new BorderLayout());
        rightPanel.add(logButtonPanel, BorderLayout.NORTH);
        rightPanel.add(logPanel, BorderLayout.CENTER);
        //frame.add(rightPanel, BorderLayout.EAST);
    }
}
