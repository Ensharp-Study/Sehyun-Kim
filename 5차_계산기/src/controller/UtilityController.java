package controller;

import constants.Colors;

import javax.swing.*;

public class UtilityController {
    public void handleUtility(String command, JTextField inputSpace, JTextField displaySpace) {
        switch (command) {
            case "C" -> clearAll(inputSpace, displaySpace);  // 모든 입력 초기화
            case "CE" -> clearEntry(inputSpace);             // 현재 입력만 초기화
            case "⌫" -> backspace(inputSpace);               // 마지막 문자 삭제
        }
    }

    public void showError(JTextField inputSpace, JTextField displaySpace, String message) {
        inputSpace.setText(message);
        displaySpace.setText("");
        inputSpace.setForeground(Colors.ERROR_TEXT);  // 에러 메시지 색상 설정
    }

    private void clearAll(JTextField inputSpace, JTextField displaySpace) {
        inputSpace.setText("0");
        displaySpace.setText("");
        resetTextColor(inputSpace); // 텍스트 색상 초기화
    }

    private void clearEntry(JTextField inputSpace) {
        inputSpace.setText("0");
        resetTextColor(inputSpace); // 텍스트 색상 초기화
    }

    private void backspace(JTextField inputSpace) {
        String input = inputSpace.getText();
        if (input.length() > 1) {
            inputSpace.setText(input.substring(0, input.length() - 1));
        } else {
            inputSpace.setText("0");
        }
    }

    private void resetTextColor(JTextField inputSpace) {
        inputSpace.setForeground(Colors.BUTTON_TEXT_DEFAULT); // 기본 색상으로 복원
    }
}
