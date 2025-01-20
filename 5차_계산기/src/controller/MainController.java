package controller;

import view.CalculatorFrame;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class MainController implements ActionListener {
    private final CalculatorFrame view;
    private final BasicOperationsController basicController;
    private final UtilityController utilityController;
    private final NumberController numberController;

    private boolean isResultDisplayed = false;  // 계산 결과 표시 상태
    private boolean isOperatorEntered = false; // 연산자 입력 상태
    private String currentInput = "";          // 현재 입력된 숫자

    public MainController(CalculatorFrame view) {
        this.view = view;
        this.basicController = new BasicOperationsController();
        this.utilityController = new UtilityController();
        this.numberController = new NumberController();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        String command = e.getActionCommand();
        JTextField inputSpace = view.getInputSpace();
        JTextField displaySpace = view.getDisplaySpace();

        try {
            switch (command) {
                case "C", "CE", "⌫" -> utilityController.handleUtility(command, inputSpace, displaySpace);
                case "+", "-", "×", "÷" -> handleOperator(command, inputSpace, displaySpace);
                case "=" -> {
                    basicController.handleOperation(command, inputSpace, displaySpace);
                    isResultDisplayed = true;  // 결과 표시 상태로 전환
                    isOperatorEntered = false; // 연산자 상태 초기화
                }
                default -> handleNumber(command, inputSpace); // 숫자 입력 처리
            }
        } catch (Exception ex) {
            utilityController.showError(inputSpace, displaySpace, "Error");
        }
    }

    private void handleOperator(String operator, JTextField inputSpace, JTextField displaySpace) {
        if (!currentInput.isEmpty()) {
            displaySpace.setText(displaySpace.getText() + currentInput + operator);
            isOperatorEntered = true; // 연산자 입력 상태로 전환
        }
    }

    private void handleNumber(String number, JTextField inputSpace) {
        // 연산자 입력 후 첫 숫자 입력 시 초기화
        if (isOperatorEntered) {
            inputSpace.setText("");   // 입력창 초기화
            isOperatorEntered = false; // 연산자 상태 해제
        }

        // 계산 결과 표시 후 숫자 입력 시 초기화
        if (isResultDisplayed) {
            inputSpace.setText("");
            currentInput = "";
            isResultDisplayed = false; // 결과 상태 초기화
        }

        // 숫자 입력 연결
        currentInput = inputSpace.getText() + number;
        inputSpace.setText(currentInput);
    }
}
