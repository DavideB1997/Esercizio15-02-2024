using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsercizioW3D4
{
    public partial class Home : System.Web.UI.Page
    {
        static string connectionStringModello = ConfigurationManager.ConnectionStrings["preventiviAuto"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionStringModello);

        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ModelloAuto, NomeOptional FROM Modello CROSS JOIN Optional", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string modello = reader["ModelloAuto"].ToString();
                string optional = reader["NomeOptional"].ToString();

                if (!DropDownList1.Items.Contains(new ListItem(modello)))
                {
                    DropDownList1.Items.Add(modello);
                }
                if (!CheckBoxList1.Items.Contains(new ListItem(optional)))
                {
                    CheckBoxList1.Items.Add(optional);
                }
            }

            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            decimal totale = 0;
            string modelloSelezionate = DropDownList1.SelectedValue;

            conn.Open();

            foreach (ListItem item in CheckBoxList1.Items) 
            {
                if (item.Selected)
                {
                    SqlCommand cmd = new SqlCommand("SELECT PrezzoOptional FROM Optional WHERE NomeOptional = @nome", conn);
                    cmd.Parameters.AddWithValue("@nome", item.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        totale += Convert.ToDecimal(reader["PrezzoOptional"]);
                    }
                    reader.Close();
                }
            }

            conn.Close() ;

            conn.Open();


            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    SqlCommand cmdModello = new SqlCommand("SELECT Prezzo, ImgModello FROM Modello WHERE ModelloAuto = @modello", conn);
                    cmdModello.Parameters.AddWithValue("@modello", item.Text);
                    SqlDataReader readerModello = cmdModello.ExecuteReader();
                    if (readerModello.Read())
                    {
                        totale += Convert.ToDecimal(readerModello["PrezzoAuto"]);

                        Image1.ImageUrl = readerModello["ImgModello"].ToString();
                    }
                    readerModello.Close();
                }
            }

            conn.Close();


            int anniGaranzia = Convert.ToInt32(DropDownListAnniGaranzia.SelectedValue);
            totale += anniGaranzia * 120;


            Label2.Text = "Totale : " + totale.ToString();

        }
    }
}