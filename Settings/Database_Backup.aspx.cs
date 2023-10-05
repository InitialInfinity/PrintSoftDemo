using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_panel_Settings_Database_Backup : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd, cmd2, cmd3;
    SqlDataAdapter adapt, adapt2, adapt3;
    DataTable dt, dt2, dt3;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_backup_Click(object sender, EventArgs e)
    {
        string backupDestination = "C:\\";
        // check if backup folder exist, otherwise create it.
        if (!System.IO.Directory.Exists(backupDestination))
        {
            System.IO.Directory.CreateDirectory("D:\\SQLBackUpFolder");
        }

        try
        {
            conn.Open();
            cmd = new SqlCommand("backup database TutorialsPanel to disk='" + backupDestination + "\\" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak'",conn);
            cmd.ExecuteNonQuery();
            //Close connection
            conn.Close();
            Response.Write("Backup database successfully");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}