using LKM1.Data;
using LKM1.Models;
using Npgsql;
using System;
using System.Collections.Generic;

namespace LKM1.Context
{
    public class PesananContext
    {
        private string __constr;
        private string __ErrorMsg;

        public PesananContext(string pConstr)
        {
            __constr = pConstr;
        }

        public List<Pesanan> ListPesanan()
        {
            List<Pesanan> list = new List<Pesanan>();
            string query = @"SELECT o.id, o.pembeli_id, o.menu_id, o.quantity, o.status, 
                                    p.nama AS nama, m.nama_menu AS nama_menu
                             FROM pesanan o
                             JOIN pembeli p ON o.pembeli_id = p.id
                             JOIN menu m ON o.menu_id = m.id;";

            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Pesanan()
                    {
                        id = int.Parse(reader["id"].ToString()),
                        pembeli_id = int.Parse(reader["pembeli_id"].ToString()),
                        menu_id = int.Parse(reader["menu_id"].ToString()),
                        quantity = int.Parse(reader["quantity"].ToString()),
                        status = reader["status"].ToString(),

                        //pembeli = new Pembeli { nama = reader["pembeli_nama"].ToString() },
                        //menu = new Menu { nama_menu = reader["menu_nama"].ToString() }
                    });
                }
                cmd.Dispose();
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }

            return list;
        }

        public void AddPesanan(Pesanan pesanan)
        {
            string query = @"INSERT INTO pesanan (pembeli_id, menu_id, quantity, status) 
                             VALUES (@pembeli_id, @menu_id, @quantity, @status);";

            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                cmd.Parameters.AddWithValue("@pembeli_id", pesanan.pembeli_id);
                cmd.Parameters.AddWithValue("@menu_id", pesanan.menu_id);
                cmd.Parameters.AddWithValue("@quantity", pesanan.quantity);
                cmd.Parameters.AddWithValue("@status", pesanan.status);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }

        public void UpdatePesanan(int id, Pesanan pesanan)
        {
            string query = @"UPDATE pesanan 
                             SET pembeli_id = @pembeli_id, menu_id = @menu_id, quantity = @quantity, status = @status
                             WHERE id = @id;";

            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@pembeli_id", pesanan.pembeli_id);
                cmd.Parameters.AddWithValue("@menu_id", pesanan.menu_id);
                cmd.Parameters.AddWithValue("@quantity", pesanan.quantity);
                cmd.Parameters.AddWithValue("@status", pesanan.status);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }

        public void DeletePesanan(int id)
        {
            string query = @"DELETE FROM pesanan WHERE id = @id;";

            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                cmd.Parameters.AddWithValue("@id", id);

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
