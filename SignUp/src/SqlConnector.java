import javax.swing.*;
import java.awt.*;
import java.sql.*;

public class SqlConnector {
    public void connectToSql(String userId,String password){
        String url = "jdbc:mysql://localhost:3306/calculator";


        String query = "SELECT * FROM userdata WHERE id=? AND pw=?";

        try (Connection connection = DriverManager.getConnection(url, "root", "0000");
             PreparedStatement statement = connection.prepareStatement(query)) {

            // Set parameter values
            statement.setString(1, userId);
            statement.setString(2, password);

            // Execute the query
            ResultSet resultSet = statement.executeQuery();

            if (resultSet.next()) {
                // Login successful
                JOptionPane.showMessageDialog(null, "Login successful", "Login", JOptionPane.INFORMATION_MESSAGE);

            } else {
                // Login failed
                JOptionPane.showMessageDialog(null, "Login failed", "Login", JOptionPane.ERROR_MESSAGE);
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
