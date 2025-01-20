package model;

import java.util.ArrayList;

public class EquationParser {
    public static ArrayList<String> separateText(String inputText) {
        ArrayList<String> equation = new ArrayList<>();
        StringBuilder num = new StringBuilder();

        for (char text : inputText.toCharArray()) {
            if ("+-×÷".indexOf(text) != -1) {
                equation.add(num.toString());
                num.setLength(0);
                equation.add(String.valueOf(text));
            } else {
                num.append(text);
            }
        }
        equation.add(num.toString());
        return equation;
    }
}
