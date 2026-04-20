using LKM1.Data;
using Npgsql;
using LKM1.Models;
using System;

namespace LKM1.Context
{
    public class PembeliContext
    {
        private string __constr;
        private string __ErrorMsg;

        public PembeliContext(string pConstr)
        {
            __constr = pConstr;
        }
        public List<Pembeli> ListPembeli()
        {
            List<Pembeli> list1 = new List<Pembeli>();
            string query = string.Format(@"Select id, nama, no_telp, alamat
                    from pembeli;");
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list1.Add(new Pembeli()
                    {
                        id = int.Parse(reader["id"].ToString()),
                        nama = reader["nama"].ToString(),
                        no_telp = reader["no_telp"].ToString(),
                        alamat = reader["alamat"].ToString()
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

        public void AddPembeli(Pembeli pembeli)
        {
            string query = string.Format(@"INSERT INTO pembeli (id, nama, no_telp, alamat) 
VALUES ('{0}', '{1}', '{2}', '{3}')", pembeli.id, pembeli.nama, pembeli.no_telp, pembeli.alamat);
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


        public void UpdatePembeli(int id, Pembeli pembeli)
        {
            string query = @"UPDATE pembeli 
                 SET nama = @nama, no_telp = @no_telp, alamat = @alamat
                 WHERE id = @id";

            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                cmd.Parameters.AddWithValue(@"id", id);
                cmd.Parameters.AddWithValue("@nama", pembeli.nama);
                cmd.Parameters.AddWithValue(@"no_telp", pembeli.no_telp);
                cmd.Parameters.AddWithValue(@"alamat", pembeli.alamat);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }

        public void DeletePembeli(int id)
        {
            string query = string.Format(@"DELETE FROM pembeli WHERE id={0};", id);
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
