package view;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;

public class InputButtonPanel extends JPanel {
    public InputButtonPanel(ActionListener actionListener) {
        setLayout(new GridLayout(5, 4, 10, 10)); // 5행 4열, 버튼 간격 조정
        setBackground(new Color(240, 248, 255)); // 패널 배경색 설정 (연한 블루)

        String[] buttonNames = {"C", "CE", "⌫", "÷", "7", "8", "9", "×", "4", "5", "6", "-", "1", "2", "3", "+", "±", "0", ".", "="};

        for (String buttonName : buttonNames) {
            JButton button = createStyledButton(buttonName);
            button.addActionListener(actionListener); // MainController 연결
            add(button);
        }
    }

    private JButton createStyledButton(String text) {
        JButton button = new JButton(text);

        // 버튼 모양 설정
        button.setFont(new Font("Arial", Font.BOLD, 20));
        button.setFocusPainted(false);
        button.setContentAreaFilled(false);
        button.setOpaque(true);
        button.setBackground(new Color(255, 255, 255)); // 버튼 기본 배경색
        button.setForeground(Color.BLACK); // 텍스트 색상
        button.setBorder(BorderFactory.createLineBorder(new Color(200, 200, 200), 2, true)); // 둥근 테두리

        // "=" 버튼 색상 강조
        if (text.equals("=")) {
            button.setBackground(new Color(0, 150, 136)); // 청록색
            button.setForeground(Color.WHITE); // 흰색 텍스트
        }

        // Hover 효과 추가
        button.addMouseListener(new java.awt.event.MouseAdapter() {
            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                button.setBackground(new Color(220, 220, 220)); // Hover 시 밝은 회색
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt) {
                if (text.equals("=")) {
                    button.setBackground(new Color(0, 150, 136)); // "=" 버튼 색상 유지
                } else {
                    button.setBackground(new Color(255, 255, 255)); // 기본 배경색으로 복원
                }
            }
        });

        return button;
    }
}
