using System;
using System.Data.SQLite;

namespace MyForm
{
    class Sqlite
    {
        //数据库连接
        private SQLiteConnection m_dbConnection;     

        public Sqlite()
        {
            connectToDatabase();
        }


        //创建一个连接到指定数据库
        void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;");
            m_dbConnection.Open();
        }

        SQLiteConnection connection()
        {
            return m_dbConnection;
        }

        //创建一个空的数据库
        void createNewDatabase(string dataPath)
        {
            SQLiteConnection.CreateFile(dataPath);
        }


        //在指定数据库中创建一个table
        void createTable()
        {
            string sql = "create table if not exists highscores (name varchar(20), score int)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //插入一些数据
        void fillTable()
        {
            string sql = "insert into highscores (name, score) values ('He', 5000)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('And I', 9001)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //使用sql查询语句，并显示结果
        void printHighscores()
        {
            string sql = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            Console.ReadLine();
        }        
    }

}

namespace MyForm
{
    class MySql
    {
        public MySql()
        {
            Console.WriteLine("MySql construct!");
        }
    }
}