package controller;

import model.CalculatorModel;

import javax.swing.*;

public class BasicOperationsController {
    private final CalculatorModel model;

    public BasicOperationsController() {
        this.model = new CalculatorModel();
    }

    public void handleOperation(String command, JTextField inputSpace, JTextField displaySpace) {
        if (command.equals("=")) {
            calculateResult(inputSpace, displaySpace);
        } else {
            appendOperator(command, inputSpace, displaySpace);
        }
    }

    private void calculateResult(JTextField inputSpace, JTextField displaySpace) {
        String expression = displaySpace.getText() + inputSpace.getText();
        double result = model.calculate(expression);
        inputSpace.setText(String.valueOf(result));
        displaySpace.setText(expression + " =");
    }

    private void appendOperator(String operator, JTextField inputSpace, JTextField displaySpace) {
        String input = inputSpace.getText();
        if (!input.isEmpty() && !input.endsWith(".")) {
            displaySpace.setText(displaySpace.getText() + input + operator);
            inputSpace.setText("");
        }
    }
}
