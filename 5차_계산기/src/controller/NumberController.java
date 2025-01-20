
package controller;

import javax.swing.*;

public class NumberController {
    public void handleNumber(String number, JTextField inputSpace) {
        String currentText = inputSpace.getText();

        // 길이 제한: 숫자 입력은 최대 16자리까지
        if (currentText.length() >= 16) {
            return;
        }
        if (inputSpace.getText().equals("Error")) {
            inputSpace.setText("");
        }
        // 초기 상태에서 입력 처리
        if (currentText.equals("0")) {
            inputSpace.setText(number);
        } else {
            inputSpace.setText(currentText + number); // 숫자 연결
        }
    }
}
