using LKM1.Data;
using Npgsql;
using LKM1.Models;
using System;

namespace LKM1.Context
{
        public class MenuContext
        {
            private string __constr;
            private string __ErrorMsg;

            public MenuContext(string pConstr)
            {
                __constr = pConstr;
            }
            public List<Menu> ListMenu()
            {
                List<Menu> list1 = new List<Menu>();
                string query = string.Format(@"Select id, nama_menu, harga
                    from menu;");
                SqlDBHelper db = new SqlDBHelper(this.__constr);
                try
                {
                    NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list1.Add(new Menu()
                        {
                            id = int.Parse(reader["id"].ToString()),
                            nama_menu = reader["nama_menu"].ToString(),
                            harga = reader["harga"].ToString(),
                        });
                    }

                    cmd.Dispose();
                    db.CloseConnection();
                }

                catch (Exception ex)
                {
                    __ErrorMsg = ex.Message;
                }

                return list1;
            }

            public void AddMenu(Menu menu)
            {
                string query = string.Format(@"INSERT INTO menu (id, nama_menu, harga) 
VALUES ('{0}', '{1}', '{2}')", menu.id, menu.nama_menu, menu.harga);
                SqlDBHelper db = new SqlDBHelper(this.__constr);
                try
                {
                    NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();
                }
                catch (Exception ex)
                {
                    __ErrorMsg = ex.Message;
                }
            }


            public void UpdateMenu(int id, Menu menu)
            {
                string query = @"UPDATE menu 
                 SET nama_menu = @nama_menu, harga = @harga
                 WHERE id = @id";

                SqlDBHelper db = new SqlDBHelper(this.__constr);
                try
                {
                    NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                    cmd.Parameters.AddWithValue(@"id", id);
                    cmd.Parameters.AddWithValue("@nama_menu", menu.nama_menu);
                    cmd.Parameters.AddWithValue(@"harga", menu.harga);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();
                }
                catch (Exception ex)
                {
                    __ErrorMsg = ex.Message;
                }
            }

            public void DeleteMenu(int id)
            {
                string query = string.Format(@"DELETE FROM menu WHERE id={0};", id);
                SqlDBHelper db = new SqlDBHelper(this.__constr);
                try
                {
                    NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();
                }
                catch (Exception ex)
                {
                    __ErrorMsg = ex.Message;
                }
            }
        }
}
