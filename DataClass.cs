using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace SalesGenerator
{
    class DataClass
    {
        private static string server = "sql4.freesqldatabase.com";
        private static string user = "sql4415325";
        private static string password = "kG5qWmg8qi";
        private static string port = "3306";
        private static string cs;
        private static string sql = "";
        private static string dbName = "sql4415325";

        private static MySqlConnection conn = null;
        private static MySqlCommand cmd;
        private static MySqlDataReader rdr = null;


        public static List<Check_info> checkInfoList;
        public static List<Check_info> removedInfoList;


        public static void startConnection()
        {
            cs = "server=" + server + ";user=" + user + ";port=" + port + ";password=" + password + ";";

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static bool stopConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }


        public static StringBuilder selectProductManage(string id, int quantity)
        {
            StringBuilder selectData = new StringBuilder();
            Check_info chk = new Check_info();
            int c = 0;
            bool match = false;
            int stck = 0;

            try
            {
                sql = "SELECT NAME, BRAND, PRICE, STOCK FROM " + dbName + ".PRODUCTS WHERE PRODUCT_ID=@product_id";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@product_id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    chk.Name = rdr["NAME"].ToString();
                    chk.Brand = rdr["BRAND"].ToString();
                    chk.Id = Int32.Parse(id);

                    foreach (Check_info item in DataClass.checkInfoList)//finds product on first line
                    {
                        if (item.Id.ToString().Equals(id))
                        {
                            c = DataClass.checkInfoList.FindIndex(el => el.Id == item.Id);
                            match = true;
                            break;
                        }
                    }


                    if (match == true)
                    {
                        stck = Int32.Parse(rdr["STOCK"].ToString()) - quantity;
                        if (stck < 0)
                        {
                            quantity = stck + quantity;
                            DataClass.checkInfoList[c].Amount = quantity;
                            DataClass.checkInfoList[c].Market_stock = 0;
                            double price = float.Parse(rdr["PRICE"].ToString()) * quantity;
                            DataClass.checkInfoList[c].Price = (float)Math.Round(price, 2);
                        }
                        else
                        {
                            DataClass.checkInfoList[c].Amount = quantity;
                            DataClass.checkInfoList[c].Market_stock = stck;
                            double price = float.Parse(rdr["PRICE"].ToString()) * quantity;
                            DataClass.checkInfoList[c].Price = (float)Math.Round(price, 2);
                        }
                    }
                    else
                    {
                        stck = Int32.Parse(rdr["STOCK"].ToString()) - quantity;
                        if (stck <= 0)
                        {
                            rdr.Close();
                            break;
                        }
                        else
                        {
                            chk.Amount = 1;
                            double price = double.Parse(rdr["PRICE"].ToString());
                            chk.Price = (float)Math.Round(price, 2);

                            DataClass.checkInfoList.Add(chk);
                        }
                    }

                    selectData.AppendFormat("{0,-20} | {1,-20} | {2,-10} | {3,-5}\r\n", rdr["NAME"], rdr["BRAND"], (float.Parse(rdr["PRICE"].ToString()) * quantity).ToString("c2"), "X" + quantity);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                return selectData;
            }
            return selectData;
        }


        public static bool insertSale()
        {
            StringBuilder selectData = new StringBuilder();

            MySqlCommand cmd = new MySqlCommand();
            DateTime _date = DateTime.Now;
            float totalprice = 0;

            try
            {
                sql = "INSERT INTO " + dbName + ".SALES (`PRICE`, `GENERATION_DATE`) VALUES (@price, @generation_date)";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@generation_date", _date);

                foreach (Check_info item in DataClass.checkInfoList)
                {
                    item.Date = DateTime.Now;
                    totalprice += item.Price;
                }
                cmd.Parameters.AddWithValue("@price", totalprice);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static int getLastSale()
        {
            int sale_id = 0;
            try
            {
                sql = "SELECT MAX(SALE_ID) FROM " + dbName + ".`SALES`";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                sale_id = Int32.Parse(rdr["MAX(SALE_ID)"].ToString());
                rdr.Close();
            }
            catch (Exception ex)
            {
                return sale_id;
            }
            return sale_id;
        }

        public static void sequentialInserSales_detail(int sale_id)
        {
            try
            {
                foreach (Check_info item in DataClass.checkInfoList)
                {
                    sql = "INSERT INTO " + dbName + ".SALES_DETAIL (`SALE_ID`, `PRODUCT_ID`, `AMOUNT`, `PRICE`) VALUES (@sale_id, @product_id, @amount, @price)";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@product_id", item.Id);

                    cmd.Parameters.AddWithValue("@sale_id", sale_id);

                    cmd.Parameters.AddWithValue("@amount", item.Amount);
                    cmd.Parameters.AddWithValue("@price", item.Price);
                    cmd.ExecuteNonQuery();

                    updateProductStock();

                }
            }
            catch (Exception ex)
            {

            }
        }

        private static void updateProductStock()
        {
            try
            {
                foreach (Check_info item in DataClass.checkInfoList)
                {
                    sql = "UPDATE " + dbName + ".PRODUCTS SET STOCK = @market_stock WHERE PRODUCT_ID = @product_id";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@product_id", item.Id);
                    cmd.Parameters.AddWithValue("@market_stock", item.Market_stock);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }

        }


        public static StringBuilder selectProductManageRemover(string criteriaData, int count)
        {
            StringBuilder selectData = new StringBuilder();
            string sql = "";
            MySqlCommand cmd = new MySqlCommand();
            Check_info chk = new Check_info();
            int c = 0;
            int i = 0;
            bool match = false;
            int stck = 0;

            try
            {
                sql = "SELECT NAME, BRAND, PRICE, STOCK FROM " + dbName + ".PRODUCTS WHERE PRODUCT_ID=@product_id";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@product_id", criteriaData);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    chk.Name = rdr["NAME"].ToString();
                    chk.Brand = rdr["BRAND"].ToString();
                    chk.Id = Int32.Parse(criteriaData);

                    foreach (Check_info item in removedInfoList)
                    {
                        if (item.Id.ToString().Equals(criteriaData))
                        {
                            c = removedInfoList.FindIndex(el => el.Id == item.Id);
                            match = true;
                            break;
                        }
                    }

                    foreach (Check_info item in DataClass.checkInfoList)
                    {
                        if (item.Id.ToString().Equals(criteriaData))
                        {
                            i = DataClass.checkInfoList.FindIndex(el => el.Id == item.Id);
                            break;
                        }
                    }


                    if (match == true)
                    {
                        stck = DataClass.checkInfoList[i].Amount;
                        if (stck < count)
                        {
                            count = stck;
                            removedInfoList[c].Amount = count;
                            removedInfoList[c].Market_stock = stck;
                            double price = double.Parse(rdr["PRICE"].ToString()) * count;
                            removedInfoList[c].Price = (float)Math.Round(price, 2);

                        }
                        else
                        {
                            removedInfoList[c].Amount = count;
                            removedInfoList[c].Market_stock = count;
                            double price = double.Parse(rdr["PRICE"].ToString()) * count;
                            removedInfoList[c].Price = (float)Math.Round(price, 2);
                        }
                    }
                    else
                    {
                        chk.Amount = 1;
                        double price = double.Parse(rdr["PRICE"].ToString());
                        chk.Price = (float)Math.Round(price, 2);
                        chk.Market_stock = 1;
                        removedInfoList.Add(chk);
                    }

                    selectData.AppendFormat("{0,-20} | {1,-20} | {2,-10} | {3,-5}\r\n", rdr["NAME"], rdr["BRAND"], (float.Parse(rdr["PRICE"].ToString()) * count).ToString("c2"), "X" + count);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                return selectData;
            }
            return selectData;
        }

    }


}
