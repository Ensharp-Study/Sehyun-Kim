package view;

import controller.MainController;

import javax.swing.*;
import java.awt.*;

public class CalculatorFrame extends JFrame {
    private JTextField inputSpace;
    private JTextField displaySpace;

    public CalculatorFrame() {
        setTitle("Calculator");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setSize(324, 534);
        setLayout(new BorderLayout());

        // Display Panel
        DisplayPanel displayPanel = new DisplayPanel();
        inputSpace = displayPanel.getInputSpace();
        displaySpace = displayPanel.getDisplaySpace();
        add(displayPanel, BorderLayout.NORTH);

        // Button Panel
        MainController controller = new MainController(this);
        InputButtonPanel inputButtonPanel = new InputButtonPanel(controller);
        add(inputButtonPanel, BorderLayout.CENTER);

        setVisible(true);
    }

    public JTextField getInputSpace() {
        return inputSpace;
    }

    public JTextField getDisplaySpace() {
        return displaySpace;
    }
}
