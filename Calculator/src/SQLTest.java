import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class SQLTest {
    public static void testSQL() throws SQLException {
        String url = "jdbc:mysql://localhost:3306/jdbc";
        String userName = "root";
        String password = "0000";

        Connection connection = DriverManager.getConnection(url, userName, password);
        Statement statement = connection.createStatement();
        ResultSet resultSet = statement.executeQuery("select * from users");

        resultSet.next();
        String name = resultSet.getString("name");
        System.out.println(name);


        resultSet.close();
        statement.close();
        connection.close();

        System.out.println("룰루");
    }
}
