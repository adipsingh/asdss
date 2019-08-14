using FRSS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FRSS.DataAccessLayer
{
    public class compmasterdatalayer
    {

        public List<compmastermodel> GetAllCompMasterData()
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            DataSet ds = null;
            List<compmastermodel> compmasterlist = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["frsscon"].ToString());

                SqlCommand cmd = new SqlCommand("spl_getcompmasterlist", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_custid", "");

                cmd.Parameters.Add("@p_errorcode", SqlDbType.BigInt);
                cmd.Parameters["@p_errorcode"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@p_errormessage", SqlDbType.VarChar, 100);
                cmd.Parameters["@p_errormessage"].Direction = ParameterDirection.Output;

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                compmasterlist = new List<compmastermodel>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    compmastermodel cobj = new compmastermodel();

                    cobj.compid = Convert.ToString(dt.Rows[i]["compid"]);
                    cobj.compcode = Convert.ToString(dt.Rows[i]["compcode"]);
                    cobj.compname = Convert.ToString(dt.Rows[i]["compname"]);
                    cobj.compcity = Convert.ToString(dt.Rows[i]["compcity"]);
                    cobj.compstate = Convert.ToString(dt.Rows[i]["compstate"]);
                    cobj.compmobile1 = Convert.ToInt64(dt.Rows[i]["compmobile1"]);
                    cobj.compemail = Convert.ToString(dt.Rows[i]["compemail"]);
                    cobj.compweb = Convert.ToString(dt.Rows[i]["compweb"]);

                    compmasterlist.Add(cobj);
                }

                return compmasterlist;
            }
            catch (Exception ex)
            {
                return compmasterlist;
            }
            finally
            {
                con.Close();
            }
        }
    }
}