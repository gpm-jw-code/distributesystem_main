using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cls_PostgreSQL_Tool
{
    public class SQL_controller
    {
        /// <summary>
        /// pgsql 內建會有的 schema name 
        /// </summary>
        private List<string> default_schema_list = new List<string>() {
            "pg_catalog",
            "pg_toast",
            "information_schema"
        };

        // 預設連線設定 
        public string _server = "localhost";

        public string Server
        {
            get { return _server; }
            set
            {
                _server = value;
                Reset_Connection();
            }
        }

        public string _username = "admin";
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                Reset_Connection();
            }
        }

        public string _password = "admin";
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                Reset_Connection();
            }
        }

        public string _database = "Database";
        public string Database
        {
            get { return _database; }
            set
            {
                _database = value;
                Reset_Connection();
            }
        }

        public string _port = "5432";
        public string Port
        {
            get { return _port; }
            set
            {
                _port = value;
                Reset_Connection();
            }
        }

        public string _timeZone = "Asia/Taipei";
        public string TimeZone
        {
            get { return _timeZone; }
            set
            {
                _timeZone = value;
                Reset_Connection();
            }
        }

        /// <summary>
        /// 用來存取 Schema_Table_Structure 用的
        /// </summary>
        protected Class_JSON.JSON_File_Operator Json_Op_Schema_Table_Structure = new Class_JSON.JSON_File_Operator("./DBStructure.json");

        /// <summary>
        /// 紀錄database裡面的 Schema 與 Table 架構 
        /// key Schema, 第二層 為 Table 列表 
        /// </summary>
        public Dictionary<string, List<string>> _Schema_Table_Structure = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> Schema_Table_Structure
        {
            get { return _Schema_Table_Structure; }
            set { _Schema_Table_Structure = value; }
        }

        /// <summary>
        /// 主要連線設定組件 
        /// </summary>
        private NpgsqlConnection conn;

        /// <summary>
        /// 自訂連線位址("Server", "Username", "Password", "Database", "Port")
        /// </summary>
        public SQL_controller(
            string Server = "localhost",
            string Username = "admin",
            string Password = "admin",
            string Database = "Database",
            string Port = "5432",
            string TimeZone = "Asia/Taipei")
        {
            this.Server = Server;
            this.Username = Username;
            this.Password = Password;
            this.Port = Port;
            this.TimeZone = TimeZone;

            this.Database = "postgres";
            Create_Database(Database);
            this.Database = Database;
            Reset_Connection();

            Schema_Table_Structure
                = (Dictionary<string, List<string>>)Json_Op_Schema_Table_Structure
                .Deserialize_JSON_from_a_file(Schema_Table_Structure);
        }

        /// <summary>
        /// 連線SQL。
        /// Note: 必須先手動在pgadmin上 Create Database, 才能conn.open()到該Database 
        /// </summary>
        public void Open()
        {
            Open(conn);
        }


        public void Open(NpgsqlConnection sql_connect)
        {
            try
            {
                if (sql_connect.State == ConnectionState.Closed)
                    sql_connect.Open();
                Console.Out.WriteLine($"Opening Connection (Server={ Server })");
            }
            catch (Exception exp)
            {
                Console.Out.WriteLine($"[EXCEPTION] in [Open()]: { exp.Message }");
                throw exp;
            }
        }

        /// <summary>
        /// 斷線
        /// </summary>
        public void Close()
        {
            Close(conn);
        }

        public void Close(NpgsqlConnection sql_connect)
        {
            try
            {
                if (sql_connect.State == ConnectionState.Open)
                    sql_connect.Close();
                Console.Out.WriteLine($"Connection Closed. (Server={ Server })");
            }
            catch (Exception exp)
            {
                Console.Out.WriteLine($"[EXCEPTION] in [Close()]: { exp.Message }");
                throw exp;
            }
        }

        /// <summary>
        /// 將連線設定更新到 NpgsqlConnection conn; 
        /// </summary>
        public void Reset_Connection()
        {
            string connString = $"Host={Server};Username={Username};Password={Password};Database={Database};Port={Port};SSLMode=Prefer";
            conn = new NpgsqlConnection(connString);
        }


        /// <summary>
        /// 將編輯好的SQL程式灌入PostgreSQL DB 中執行
        /// SQLstring: SQL語法 
        /// sql_connect: NpgsqlConnection 連線物件 
        /// </summary>
        public void Command_Execute(string SQLstring, NpgsqlConnection sql_connect)
        {
            if (sql_connect.State == ConnectionState.Closed)
                sql_connect.Open();
            using (var command = new NpgsqlCommand(SQLstring, sql_connect))
            {
                command.ExecuteNonQuery();
            }
            sql_connect.Close();
        }


        /// <summary>
        /// 將編輯好的SQL程式灌入PostgreSQL DB 中執行
        /// SQLstring: SQL語法 
        /// 使用Conn
        /// </summary>
        public void Command_Execute(string SQLstring)
        {
            Command_Execute(SQLstring, conn);
        }


        /// <summary>
        /// 將編輯好的SQL程式灌入PostgreSQL DB 中執行, 並回傳內容, (通常用再 Query 功能中
        /// SQLstring: SQL語法 
        /// </summary>
        public NpgsqlDataReader Command_Execute_and_Return(string SQLstring, NpgsqlConnection sql_connect)
        {
            if (sql_connect.State == ConnectionState.Closed)
                sql_connect.Open();
            using (var Command_Execute = new NpgsqlCommand(SQLstring, sql_connect))
            {
                NpgsqlDataReader dr = Command_Execute.ExecuteReader();
                sql_connect.Close();
                return dr;
            }
        }

        /// <summary>
        /// 將編輯好的SQL程式灌入PostgreSQL DB 中執行, 並回傳NpgsqlDataAdapter, (通常用再 Query 功能中
        /// SQLstring: SQL語法 
        /// </summary>
        public DataTable Command_Execute_and_Return_DataTable(string SQLstring, NpgsqlConnection sql_connect)
        {
            if (sql_connect.State == ConnectionState.Closed)
                sql_connect.Open();
            try
            {
                using (var Command_Execute = new NpgsqlCommand(SQLstring, sql_connect))
                {
                    NpgsqlDataAdapter DataAdapte = new NpgsqlDataAdapter(Command_Execute);

                    DataTable _datatable = new DataTable();
                    DataAdapte.Fill(_datatable);

                    sql_connect.Close();
                    return _datatable;
                }
            }
            catch (Exception exp)
            {
                return new DataTable();
            }

        }

        /// <summary>
        /// 將編輯好的SQL程式灌入PostgreSQL DB 中執行, 並回傳內容, (通常用再 Query 功能中
        /// SQLstring: SQL語法 
        /// </summary>
        public NpgsqlDataReader Command_Execute_and_Return(string SQLstring)
        {
            return Command_Execute_and_Return(SQLstring, conn);
        }

        /// <summary>
        /// 將編輯好的SQL程式灌入PostgreSQL DB 中執行, 並回傳NpgsqlDataAdapter, (通常用再 Query 功能中
        /// SQLstring: SQL語法
        /// </summary>
        public DataTable Command_Execute_and_Return_DataAdapte(string SQLstring)
        {
            return Command_Execute_and_Return_DataTable(SQLstring, conn);
        }

        /// <summary>
        /// 設定時區
        /// area格式 = Aaia/Taipei
        /// </summary>
        public void Timezone_set(string area)
        {
            string SQLstring_set_timezone = $"ALTER database {Database} SET timezone = '{area}'";
            Command_Execute(SQLstring_set_timezone);

            Console.Out.WriteLine($"Set TIMEZONE: {area}");
        }


        /// <summary>
        /// 新增database
        /// 重複名稱則不再新增, 並且會噴例外錯誤
        /// Note: 必須先手動在pgadmin上 Create Database, conn.open()到該Database後, 才能另外再Create新的Database
        /// </summary>
        public bool Create_Database(string database_name)
        {
            try
            {
                string create_database = $"CREATE DATABASE {database_name}"; // create database不能使用 "IF NOT EXISTS" 
                Command_Execute(create_database);

                Console.Out.WriteLine($"Finished creating NEW DATABASE: { database_name }");
            }
            catch (Exception exp)
            {
                Console.Out.WriteLine($"[EXCEPTION] in [Create_Database]: { exp.Message }");

                if (!exp.Message.Contains("42P04")) // 代碼 42P04 代表 database 已存在, 若代碼不是 42P04 直接噴例外, 
                    throw exp;
                else
                    return false;
            }
            return true;
        }


        /// <summary>
        /// 建立Schema, ("schema名稱")。
        /// Schema名稱開頭要是英文字。
        /// 若已存在, 則不會再建立
        /// </summary>
        public void Create_Schema(string schema_name)
        {
            string create_schema = $"CREATE SCHEMA IF NOT EXISTS {schema_name}";
            Command_Execute(create_schema);
            Console.Out.WriteLine($"SCHEMA: {schema_name} Created.");


            if (Schema_Table_Structure.ContainsKey(schema_name)) //因為是新建立schema, 需把現有的table刷掉
                Schema_Table_Structure[schema_name] = new List<string>();
            else
                Schema_Table_Structure.Add(schema_name, new List<string>());
            Json_Op_Schema_Table_Structure.Serialize_JSON_to_a_file(Schema_Table_Structure);
        }


        /// <summary>
        /// 創建 table 連同 columan 
        /// 完整輸入 column name 跟 type 
        /// </summary>
        public void Create_Table(string schema_name, string table_name, Dictionary<string, string> ColName_Type)
        {
            string sql_command = $"CREATE TABLE IF NOT EXISTS {schema_name}.{table_name} ( ";
            foreach (var col_type in ColName_Type)
            {
                sql_command += $"{col_type.Key} {col_type.Value},";
            }
            sql_command = sql_command.TrimEnd(',');
            sql_command += $" );";

            Command_Execute(sql_command);
            Console.Out.WriteLine($"TABLE: {schema_name}.{table_name} Created.");
        }



        /// <summary>
        /// 建立Table, ("schema名稱", "table名稱", "column名稱", "column資料型態")。
        /// 一定要先給一個column。
        /// 若 第一個column要建立成Datetime, 則 Datetime資料型態→timestamp(3)。
        /// </summary>
        public void Create_Table(string schema_name, string table_name, string column_name, string type)
        {
            string create_table = $"CREATE TABLE IF NOT EXISTS {schema_name}.{table_name}({column_name} {type})";
            Command_Execute(create_table, conn);

            Console.Out.WriteLine($"TABLE: {schema_name}.{table_name} Created.");
            Console.Out.WriteLine($"- COLUMN: {column_name} type: {type} Created.");

            Schema_Table_Structure[schema_name].Add(table_name);
            Json_Op_Schema_Table_Structure.Serialize_JSON_to_a_file(Schema_Table_Structure);
        }



        /// <summary>
        /// 新增Column, ("選擇schema", "選擇table", "新增column名稱", "column資料型態")
        /// </summary>
        public void Create_Column(string schema_name, string table_name, string column_name, string type)
        {
            string sql_command = $"ALTER TABLE {schema_name}.{table_name} ADD IF NOT EXISTS {column_name} {type}";
            Command_Execute(sql_command, conn);
        }



        /// <summary>
        /// 列出所有 database
        /// </summary>
        /// <returns></returns>
        public List<string> List_Database()
        {
            string sql_command =
                $"SELECT datname FROM pg_database WHERE datistemplate = false;";

            DataTable query_data = Command_Execute_and_Return_DataTable(sql_command, conn);

            List<string> list_database = new List<string>();

            foreach (DataRow datarow in query_data.Rows)
            {
                string extract_row = datarow["datname"].ToString();
                list_database.Add(extract_row);
            }

            Close();
            return list_database;
        }



        /// <summary>
        /// 列出所有 Schema
        /// </summary>
        public List<string> List_Schema()
        {
            string sql_command =
                $"select schema_name " +
                $"from information_schema.schemata;";
            DataTable query_data = Command_Execute_and_Return_DataTable(sql_command, conn);


            List<string> list_schema = new List<string>();

            foreach (DataRow datarow in query_data.Rows)
            {
                string extract_row = datarow["schema_name"].ToString();
                if (!default_schema_list.Any(a => a == extract_row))
                    list_schema.Add(extract_row);
            }

            Close();
            return list_schema;
        }

        /// <summary>
        /// 列出 schema 下的 table 
        /// </summary>
        public List<string> List_Table(string schema_name)
        {
            string sql_command =
                $"select *from information_schema.tables " +
                $"where table_schema = '{schema_name}'";

            DataTable query_data = Command_Execute_and_Return_DataTable(sql_command, conn);

            List<string> list_table = new List<string>();
            foreach (DataRow datarow in query_data.Rows)
            {
                string extract_row = datarow["table_name"].ToString();
                list_table.Add(extract_row);
            }

            Close();
            return list_table;
        }

        /// <summary>
        /// 列出 column 
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public List<string> List_Column(string table_name)
        {
            string sql_command =
                $"select *from information_schema.columns " +
                $"where table_name = '{table_name}'";

            DataTable query_data = Command_Execute_and_Return_DataTable(sql_command, conn);

            List<string> list_column = new List<string>();
            foreach (DataRow datarow in query_data.Rows)
            {
                string extract_row = datarow["column_name"].ToString();
                list_column.Add(extract_row);
            }

            Close();
            return list_column;
        }


        /// <summary>
        /// 刪除Table, ("schema名稱", "table名稱")
        /// </summary>
        public void Drop_Table(string Schema_name, string Table_name)
        {
            try
            {
                string sql_command = $"drop table {Schema_name}.{Table_name}";
                Command_Execute(sql_command, conn);
                Console.Out.WriteLine("Finished drop Table.");
            }
            catch (Exception exp)
            {
                Console.Out.WriteLine($"[Drop_Table ERROR] {exp.Message}");
                Close();
                throw exp;
            }
        }


        /// <summary>
        /// 刪除Schema, ("schema名稱")
        /// 此方法僅能刪除「空的」Schema
        /// 當此Schems中還有Table時, 則需先將Table全數刪除
        /// </summary>
        /// <param name="schema_name"></param>
        public void Drop_Schema(string Schema_name)
        {
            try
            {
                string sql_command = $"drop schema {Schema_name}";
                Command_Execute(sql_command, conn);
                Console.Out.WriteLine("Finished drop Schema.");
            }
            catch (Exception exp)
            {
                Console.Out.WriteLine($"[Drop_Schema ERROR] {exp.Message}");
                Close();
                throw exp;
            }
        }


        /// <summary>
        /// 刪除Database
        /// 無人連線至此Database時才可刪除, 刪除database的前置作業太多, 建議還是手動比較快 
        /// </summary>
        public void Drop_Database(string database_name)
        {
            if (database_name == Database)
                throw new Exception("[Drop_Database][ERROR] Can Not Drop Current database. change ur connect database first.");

            try
            {
                string sql_command = $"DROP DATABASE IF EXISTS {database_name}";
                Command_Execute(sql_command, conn);
                Console.Out.WriteLine("Finished drop Database.");
            }
            catch (Exception exp)
            {
                Console.Out.WriteLine($"[Drop_Database ERROR] {exp.Message}");
                Close();
                throw exp;
            }
        }

        //=== CRUD 系列 ===//

        // Create //

        /// <summary>
        /// 插入資料行
        /// </summary>
        public void insert_row<T>(string schema_name, string table_name, List<string> column_names, List<T> data)
        {
            if (column_names.Count != data.Count)
                throw new Exception("[Insert row ERROR] Length of col and length of data do not match");

            string sql_command = $"INSERT INTO {schema_name}.{table_name} " +
                sql_string_combine_colname_and_data_for_insert_row(column_names, data) +
                $";";

            Command_Execute(sql_command, conn);
        }


        /// <summary>
        /// 插入多row
        /// data格式: list of row 
        /// </summary>
        public void insert_mulitrow<T>(string schema_name, string table_name, List<string> column_names, List<List<T>> data)
        {

            if (column_names.Count != data[0].Count)
                throw new Exception("[Insert row ERROR] Length of col and length of data do not match");

            string sql_command = $"INSERT INTO {schema_name}.{table_name} " +
                sql_string_combine_colname_and_data_for_insert_rows(column_names, data) +
                $";";

            Command_Execute(sql_command, conn);
        }


        /// <summary>
        /// 插入多個column 
        /// data格式: list of column
        /// </summary>
        public void insert_mulit_col<T>(string schema_name, string table_name, List<string> column_names, List<List<T>> data)
        {
            if (column_names.Count != data.Count)
                throw new Exception("[Insert row ERROR] Length of col and length of data do not match");

            string sql_command = $"INSERT INTO {schema_name}.{table_name} " +
                sql_string_combine_colname_and_data_for_insert_cols(column_names, data) +
                $";";

            Command_Execute(sql_command, conn);
        }



        /// <summary>
        /// (for insert cols)組合 column name跟 data, 變成以下格式: 
        /// (col1 , col2 , col3 , ... ) VALUES( data1, data2, data23 , ... )
        /// </summary>
        private string sql_string_combine_colname_and_data_for_insert_cols<T>(List<string> column_names, List<List<T>> data)
        {
            string colname_and_data = "";
            colname_and_data += SQLString_data_format_Brackets_and_commas_separated(column_names, false);
            colname_and_data += $"VALUES";
            for (int i = 0; i < data[0].Count; i++)
            {
                List<object> a_row = new List<object>();
                for (int j = 0; j < data.Count; j++)
                {
                    a_row.Add(data[j][i]);
                }
                colname_and_data += SQLString_data_format_Brackets_and_commas_separated(a_row, true) + ",";
            }

            colname_and_data = colname_and_data.TrimEnd(',');
            return colname_and_data;
        }


        /// <summary>
        /// (for insert rows)組合 column name跟 data, 變成以下格式: 
        /// (col1 , col2 , col3 , ... ) VALUES( data1, data2, data23 , ... )
        /// </summary>
        private string sql_string_combine_colname_and_data_for_insert_rows<T>(List<string> column_names, List<List<T>> data)
        {
            string colname_and_data = "";
            colname_and_data += SQLString_data_format_Brackets_and_commas_separated(column_names, false);
            colname_and_data += $"VALUES";

            for (int i = 0; i < data.Count; i++)
            {
                colname_and_data += SQLString_data_format_Brackets_and_commas_separated(data[i], true) + ",";
            }
            colname_and_data = colname_and_data.TrimEnd(',');
            return colname_and_data;
        }

        /// <summary>
        /// (for insert row)組合 column name跟 data, 變成以下格式: 
        /// (col1 , col2 , col3 , ... ) VALUES( data1, data2, data23 , ... )
        /// </summary>
        private string sql_string_combine_colname_and_data_for_insert_row<T>(List<string> column_names, List<T> data)
        {
            string colname_and_data = "";
            colname_and_data += SQLString_data_format_Brackets_and_commas_separated(column_names, false);
            colname_and_data += $"VALUES";
            colname_and_data += SQLString_data_format_Brackets_and_commas_separated(data, true);
            return colname_and_data;
        }


        /// <summary>
        /// list 資料做括號與逗號分隔處理 
        /// (data1 , data2 , data3, ...)
        /// </summary>
        private string SQLString_data_format_Brackets_and_commas_separated<T>(List<T> data, bool with_single_quotation_marks = false)
        {


            string sqlstring = $"(";



            if (with_single_quotation_marks)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    //1.1 Array or list 
                    if (is_this_array(data[i]))
                    {
                        sqlstring += "'{";
                        IEnumerable enumerable_data = data[i] as IEnumerable;
                        foreach (var element in enumerable_data)
                        {
                            sqlstring += $"{element},";
                        }
                        sqlstring = sqlstring.TrimEnd(',');
                        sqlstring += "}',";
                    }
                    else //1.2 with single quotation marks
                    {
                        sqlstring += $"'{data[i]}',";
                    }
                }
            }
            else
            {
                //2. NO single quotation marks
                for (int i = 0; i < data.Count; i++)
                    sqlstring += $"{data[i]},";
            }


            sqlstring = sqlstring.TrimEnd(',');
            sqlstring += $") ";
            return sqlstring;
        }


        /// <summary>
        /// 檢查是否為array 或list 
        /// </summary>
        private bool is_this_array(object data_sample)
        {
            Type type_check = data_sample.GetType();
            if (type_check.IsArray)
                return true;
            if (data_sample is IList)
                return true;
            return false;
        }

        // Read //

        /// <summary>
        /// 查詢 完整table 回傳 DataTable 
        /// </summary>
        public DataTable Select_All_to_Datatable(string schema_name, string table_name)
        {
            string sql_command = $"SELECT * FROM {schema_name}.{table_name}";
            DataTable query_data = Command_Execute_and_Return_DataAdapte(sql_command);
            return query_data;
        }

        public List<List<string>> Select_All_To_ListList(string schema_name, string table_name)
        {
            string sql_command = $"SELECT * FROM {schema_name}.{table_name}";
            DataTable query_data = Command_Execute_and_Return_DataAdapte(sql_command);
            var OutputData = new List<List<string>>();
            foreach (DataRow item in query_data.Rows)
            {
                List<string> List_NewSensorData = new List<string>();
                foreach (var Datacell in item.ItemArray)
                {
                    List_NewSensorData.Add(Datacell.ToString());
                }
                OutputData.Add(List_NewSensorData);
            }
            return OutputData;
        }


        /// <summary>
        /// 查詢 完整table 回傳 DataTable 
        /// 加上可設定條件, 須以SQL語法輸入 條件字串 
        /// 例如 "datetime > '2021-01-01' AND  datetime < '2021-04-01' "
        /// Note: 查詢日期, 可以只輸入到日期, 字串要記得加單引號: ' 
        /// </summary>
        public DataTable Select_to_Datatable(string schema_name, string table_name, string Condition)
        {
            string sql_command = $"SELECT * FROM {schema_name}.{table_name} WHERE {Condition} ";
            DataTable query_data = Command_Execute_and_Return_DataAdapte(sql_command);
            return query_data;
        }

        public List<List<string>> Select_to_List_List(string schema_name, string table_name, string Condition)
        {
            string Sql_Command = $"SELECT * FROM {schema_name}.{table_name} WHERE {Condition} ";
            DataTable query_data = Command_Execute_and_Return_DataAdapte(Sql_Command);
            var OutputData = new List<List<string>>();
            foreach (DataRow item in query_data.Rows)
            {
                List<string> List_NewSensorData = new List<string>();
                foreach (var Datacell in item.ItemArray)
                {
                    List_NewSensorData.Add(Datacell.ToString());
                }
                OutputData.Add(List_NewSensorData);
            }
            return OutputData;
        }



        // Update //




        // Delete //

        /// <summary>
        /// 清掉符合條件的數據
        /// </summary>
        public void Delete_Data(string schema_name, string table_name, string Condition)
        {
            string sql_command = $"DELETE FROM {schema_name}.{table_name} WHERE {Condition}";
            Command_Execute(sql_command, conn);
        }

        /// <summary>
        /// 清掉table內全部數據
        /// 使用TRUNCATE刪除 
        /// 會保留資料表結構及其欄位、條件約束、索引等。
        /// </summary>
        public void Delete_All_Data(string schema_name, string table_name)
        {
            string sql_command = $"TRUNCATE {schema_name}.{table_name} ";
            //如果是 使用 DELETE 不加 WHERE條件, 也是跟 TRUNCATE 有一樣效果, 但是會消耗大量資源 

            Command_Execute(sql_command, conn);
        }

        public bool CheckTableExist(string Schema_Name, string Table_Name)
        {
            string SqlCommand = $"Select From pg_tables where schemaname = '{Schema_Name}' and tablename='{Table_Name}'";
            DataTable Data = Command_Execute_and_Return_DataTable(SqlCommand, conn);
            return Data.Rows.Count > 0;
        }



        //============//重購分隔線//============//


        /// <summary>
        /// 更新Data, ("選擇schema", "選擇table", "選擇column", "輸入更新Data", "選擇欲更新的ID number")
        /// </summary>
        /// <param name="schema_name"></param>
        /// <param name="table_name"></param>
        /// <param name="column_name"></param>
        /// <param name="data"></param>
        /// <param name="row_name"></param>
        /// <param name="row_inf"></param>
        public void Update_Data(string schema_name, string table_name, string column_name, string data, string row_name, string row_inf)
        {
            string update_data = $"UPDATE {schema_name}.{table_name} SET {column_name} = {data} WHERE {row_name} = {row_inf}";
            Command_Execute(update_data, conn);
        }


        /// <summary>
        /// 無檔案存取權限(無法從本地電腦直接給檔案匯入)
        /// 需要有絕對系統路徑才行
        /// </summary>
        /// <param name="schema_name"></param>
        /// <param name="table_name"></param>
        /// <param name="file_road"></param>
        /// <param name="type"></param>
        public void Copy_Data(string schema_name, string table_name, string file_road, string type)
        {
            string copy_data = $"copy {schema_name}.{table_name} from '{file_road}' delimiter ',' {type} header";
            Command_Execute(copy_data, conn);
        }


        public void Select_Connect(string schema_name, string table_name)
        {
            string select_connect = $"SELECT pg_terminate_backend(pg_stat_activity.procpid) FROM pg_stat_get_activity(NULL::integer)WHERE datid = (SELECT oid from pg_database where datname = 'your_database'); ";
            Command_Execute(select_connect, conn);
        }


    }
}
