package model;

import java.util.ArrayList;

public class CalculatorModel {
    public double calculate(String expression) {
        ArrayList<String> tokens = tokenize(expression);
        return evaluate(tokens);
    }

    private ArrayList<String> tokenize(String expression) {
        ArrayList<String> tokens = new ArrayList<>();
        StringBuilder number = new StringBuilder();

        for (char c : expression.toCharArray()) {
            if ("+-×÷".indexOf(c) >= 0) {
                tokens.add(number.toString());
                number.setLength(0);
                tokens.add(String.valueOf(c));
            } else {
                number.append(c);
            }
        }
        tokens.add(number.toString());
        return tokens;
    }

    private double evaluate(ArrayList<String> tokens) {
        double result = Double.parseDouble(tokens.get(0));
        for (int i = 1; i < tokens.size(); i += 2) {
            String operator = tokens.get(i);
            double operand = Double.parseDouble(tokens.get(i + 1));
            result = applyOperation(result, operator, operand);
        }
        return result;
    }

    private double applyOperation(double a, String operator, double b) {
        return switch (operator) {
            case "+" -> a + b;
            case "-" -> a - b;
            case "×" -> a * b;
            case "÷" -> a / b;
            default -> throw new IllegalArgumentException("Unknown operator: " + operator);
        };
    }
}
