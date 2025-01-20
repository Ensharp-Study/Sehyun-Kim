package view;

import javax.swing.*;
import java.awt.*;

public class DisplayPanel extends JPanel {
    private JTextField inputSpace;
    private JTextField displaySpace;

    public DisplayPanel() {
        setLayout(new GridLayout(2, 1));

        displaySpace = new JTextField();
        displaySpace.setEditable(false);
        displaySpace.setFont(new Font("Noto Sans CJK", Font.PLAIN, 18));
        displaySpace.setForeground(Color.GRAY);
        add(displaySpace);

        inputSpace = new JTextField();
        inputSpace.setEditable(false);
        inputSpace.setFont(new Font("Arial", Font.BOLD, 50));
        add(inputSpace);
    }

    public JTextField getInputSpace() {
        return inputSpace;
    }

    public JTextField getDisplaySpace() {
        return displaySpace;
    }
}
