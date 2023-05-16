import javax.swing.JFrame;
import javax.swing.JTextField;
import javax.swing.JPanel;
import java.awt.Dimension;
import java.awt.Color;
import java.awt.Font;

public class CalculatorFrame extends JFrame {
    private JTextField inputSpace;
    private JTextField displaySpace;

    public void createJFrame() {
        setSize(324, 534);
        setMinimumSize(new Dimension(324, 534));
        setLocationRelativeTo(null);
        setTitle("계산기");
        setVisible(true);
        setResizable(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        createTextField();
        createExpressionTextField();
        createPanel();
    }

    public void createTextField() {
        setLayout(null);

        inputSpace = new JTextField();
        inputSpace.setBorder(javax.swing.BorderFactory.createEmptyBorder());
        inputSpace.setEditable(true);
        inputSpace.setHorizontalAlignment(JTextField.RIGHT);
        inputSpace.setFont(new Font("Arial", Font.BOLD, 50));
        inputSpace.setBounds(8, 80, 290, 60);

        add(inputSpace);
    }

    public void createExpressionTextField() {
        setLayout(null);

        displaySpace = new JTextField();
        displaySpace.setBorder(javax.swing.BorderFactory.createEmptyBorder());
        displaySpace.setEditable(true);
        displaySpace.setHorizontalAlignment(JTextField.RIGHT);
        displaySpace.setFont(new Font("Noto Sans CJK", Font.PLAIN, 18));
        displaySpace.setBounds(8, 50, 290, 30);
        displaySpace.setForeground(Color.GRAY);
        add(displaySpace);
    }

    public void createPanel() {
        ButtonPanel buttonPanel = new ButtonPanel(this);
        buttonPanel.setBounds(8, 145, 290, 420);
        add(buttonPanel);
    }

    public JTextField getInputSpace() {
        return inputSpace;
    }

    public JTextField getDisplaySpace() {
        return displaySpace;
    }
}