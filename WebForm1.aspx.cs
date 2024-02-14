using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Esercizio_L3_S3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static string connString = ConfigurationManager.ConnectionStrings["Esercizio_L3_S3_BackEnd"].ToString();
        SqlConnection conn = new SqlConnection(connString);
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            TxtNome.Text = "";
            TxtCognome.Text = "";
            LstSala.SelectedIndex = 0;
            ChkRidotto.Checked = false;

            conn.Open();

            SqlCommand commandCountNord = new SqlCommand("SELECT COUNT(*) FROM Biglietti WHERE Sala='nord'", conn);
            string countNord = commandCountNord.ExecuteScalar().ToString();
            SqlCommand commandCountNordReduced = new SqlCommand("SELECT COUNT(*) FROM Biglietti WHERE Sala='nord' AND Ridotto=1", conn);
            string countNordReduced = commandCountNordReduced.ExecuteScalar().ToString();
            LblNord.Text = $"Totali: {countNord}, ridotti: {countNordReduced}";

            SqlCommand commandCountSud = new SqlCommand("SELECT COUNT(*) FROM Biglietti WHERE Sala='sud'", conn);
            string countSud = commandCountSud.ExecuteScalar().ToString();
            SqlCommand commandCountSudReduced = new SqlCommand("SELECT COUNT(*) FROM Biglietti WHERE Sala='sud' AND Ridotto=1", conn);
            string countSudReduced = commandCountSudReduced.ExecuteScalar().ToString();
            LblSud.Text = $"Totali: {countSud}, ridotti: {countSudReduced}";

            SqlCommand commandCountEst = new SqlCommand("SELECT COUNT(*) FROM Biglietti WHERE Sala='est'", conn);
            string countEst = commandCountEst.ExecuteScalar().ToString();
            SqlCommand commandCountEstReduced = new SqlCommand("SELECT COUNT(*) FROM Biglietti WHERE Sala='est' AND Ridotto=1", conn);
            string countEstReduced = commandCountEstReduced.ExecuteScalar().ToString();
            LblEst.Text = $"Totali: {countEst}, ridotti: {countEstReduced}";

            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand saveTicket = new SqlCommand("" +
                    $"INSERT INTO Biglietti (Nome, Cognome, Sala, Ridotto) VALUES " +
                    $"('{TxtNome.Text}', '{TxtCognome.Text}', '{LstSala.SelectedItem.Value}', {Convert.ToInt32(ChkRidotto.Checked)})" +
                    "", conn);

                int affectedRows = saveTicket.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    Response.Write("Dati non inseriti");
                }
            }
            catch
            {
                Response.Write("qualcosa non va");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}