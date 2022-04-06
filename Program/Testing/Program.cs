using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ShopAppTry3.Logic
{


	public class StockList
	{
		//private static string[] List
		//public void List()
		//{
		//Things I need always: Product Name, Manufactorer Name, quantity at each store, price
		//static string[,,] dataStore = new string[1, 1, 1];
		//}


		//SqlDataReader rdr = null;
	public static void Main()
        {
			string _connectionString = "Server=tcp:firsttryserver.database.windows.net,1433;Initial Catalog=FirstTryResourceGroupDatabase;Persist Security Info=False;User ID=Mechsrule1;Password=ed3MxmE23EKEsed;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
		    string[] infoGot = new string[1];
			infoGot[0] = "Error";
			SqlConnection connection = new SqlConnection(_connectionString);
			connection.Open();
			string[] storeNames = new string[4];
			string[] productNames = new string[20];
			string[] manufactorer = new string[20];
			string[] price = new string[20];
			string[] store1Quantities = new string[20];
			string[] store2Quantities = new string[20];
			string[] store3Quantities = new string[20];
			string[] store4Quantities = new string[20];
			string[] DCQuantities = new string[20];
				for (int i = 0; i < 4; i++)
				{
					using SqlCommand cmd = new SqlCommand(
					"SELECT Name FROM Names.Stores " +
					"WHERE Store_ID = " + i, connection);
					using SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						storeNames[i] = reader.GetString(0);
					}
				}
				for (int j = 0; j < 20; j++)
				{
                    int i = j + 1;
					using SqlCommand cmd = new SqlCommand(
						"SELECT ProductName FROM Names.Product " +
						"WHERE ProductNum = " + i, connection);
					using SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						productNames[j] = reader.GetString(0);
					}
				}
				for (int j = 0; j < 20; j++)
				{
                    int i = j + 1;
					using SqlCommand cmd = new SqlCommand(
						"SELECT ProductMaker FROM Names.Product " +
						"WHERE ProductNum = " + i, connection);
					using SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						manufactorer[j] = reader.GetString(0);
					}
				}
				for (int j = 0; j < 20; j++) //reset to 20
				{
                    int i = j + 1;
                    //Console.WriteLine("test " + j);
                    string test = ("Inventory.Item" + i.ToString());
					using SqlCommand cmd = new SqlCommand(
						"SELECT Price FROM " + test + " " +
						"WHERE Store_ID = " + "1", connection);
					using SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						price[j] = (reader.GetSqlMoney(0).ToString());
                        //Console.WriteLine(price[j]);
                        // var x = reader.GetColumnSchema();
                        // foreach(var y in x){
                        // Console.WriteLine(y);
                        // }
					}
				}
				for (int j = 0; j < 20; j++)
				{
                    int i = j + 1;
                    string test = ("Inventory.Item" + i.ToString());
					using SqlCommand cmd = new SqlCommand(
						"SELECT Quantity FROM " + test + " " +
						"WHERE Store_ID = " + "0", connection);
					using SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						DCQuantities[j] = reader.GetString(0);
					}
				}
				for (int j = 0; j < 20; j++)
				{
                    int i = j + 1;
					string test = ("Inventory.Item" + i.ToString());
					using SqlCommand cmd = new SqlCommand(
						"SELECT Quantity FROM " + test + " " +
						"WHERE Store_ID = " + "1", connection);
					using SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						store1Quantities[j] = (reader.GetInt32(0).ToString());
					}
				}
				for (int j = 0; j < 20; j++)
				{
                    int i = j + 1;
					string test = ("Inventory.Item" + i.ToString());
					using SqlCommand cmd = new SqlCommand(
						"SELECT Quantity FROM " + test + " " +
						"WHERE Store_ID = " + "2", connection);
					using SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						store2Quantities[j] = (reader.GetInt32(0).ToString());
					}
				}
				for (int j = 0; j < 20; j++)
				{
                    int i = j + 1;
					string test = ("Inventory.Item" + i.ToString());
					using SqlCommand cmd = new SqlCommand(
						"SELECT Quantity FROM " + test + " " +
						"WHERE Store_ID = " + "3", connection);
					using SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						store3Quantities[j] = (reader.GetInt32(0).ToString());
					}
				}
				for (int j = 0; j < 20; j++)
				{
                    int i = j + 1;
					string test = ("Inventory.Item" + i.ToString());
					using SqlCommand cmd = new SqlCommand(
						"SELECT Quantity FROM " + test + " " +
						"WHERE Store_ID = " + "4", connection);
					using SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						store4Quantities[j] = (reader.GetInt32(0).ToString());
					}
				}
			foreach (string item in storeNames)
			{
				Console.WriteLine(item);
			}
            

			connection.Close();
        }

        }
}

