using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for SMTP
/// </summary>
public class SMTP
{
    public SMTP()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string fetch_SmtpServer()
    {
        string server = "";

        DbHelper d = new DbHelper();
        string sqlQuery = "select Value from tbl_Config where item='SmtpServer'";
        DataSet ds = d.ExecuteDataSet(sqlQuery, ConnectionState.CloseOnExit);
        DataTable dtStore = ds.Tables[0];
        return server = dtStore.Rows[0]["Value"].ToString();


    }

    public string fetch_port()
    {
        string port = "";
        DbHelper d = new DbHelper();

        string sqlQuery = "select Value from tbl_Config where item='Port'";

        DataSet ds = d.ExecuteDataSet(sqlQuery, ConnectionState.CloseOnExit);
        DataTable dtStore = ds.Tables[0];

        return port = dtStore.Rows[0]["Value"].ToString();


    }

    public string fetch_UserName()
    {
        string username = "";
        DbHelper d = new DbHelper();
        string sqlQuery = "select Value from tbl_Config where item='UserName'";
        DataSet ds = d.ExecuteDataSet(sqlQuery, ConnectionState.CloseOnExit);
        DataTable dtStore = ds.Tables[0];

        return username = dtStore.Rows[0]["Value"].ToString();

    }

    public string fetch_Password()
    {
        string password = "";
        DbHelper d = new DbHelper();
        string sqlQuery = "select Value from tbl_Config where item='Password'";
        DataSet ds = d.ExecuteDataSet(sqlQuery, ConnectionState.CloseOnExit);
        DataTable dtStore = ds.Tables[0];


        return password = dtStore.Rows[0]["Value"].ToString();

    }

    public bool fetch_EnableSSL()
    {
        bool ssl = false;
        DbHelper d = new DbHelper();


        string sqlQuery = "select Value from tbl_Config where item='EnableSSL'";

        DataSet ds = d.ExecuteDataSet(sqlQuery, ConnectionState.CloseOnExit);
        DataTable dtStore = ds.Tables[0];


        return ssl = Convert.ToBoolean(dtStore.Rows[0]["Value"].ToString());


    }

    public bool fetch_UseAuthentication()
    {
        bool userAuth = false;
        DbHelper d = new DbHelper();


        string sqlQuery = "select Value from tbl_Config where item='UseAuthentication'";

        DataSet ds = d.ExecuteDataSet(sqlQuery, ConnectionState.CloseOnExit);
        DataTable dtStore = ds.Tables[0];


        return userAuth = Convert.ToBoolean(dtStore.Rows[0]["Value"].ToString());


    }

    public string fetch_EmailFrom()
    {
        string Emailfrom = "";
        DbHelper d = new DbHelper();


        string sqlQuery = "select Value from tbl_Config where item='EmailFrom'";

        DataSet ds = d.ExecuteDataSet(sqlQuery, ConnectionState.CloseOnExit);
        DataTable dtStore = ds.Tables[0];


        return Emailfrom = dtStore.Rows[0]["Value"].ToString();


    }

    public string fetch_Emailto()
    {
        string emailTo = "";
        DbHelper d = new DbHelper();


        string sqlQuery = "select Value from tbl_Config where item='TO Email address'";

        DataSet ds = d.ExecuteDataSet(sqlQuery, ConnectionState.CloseOnExit);
        DataTable dtStore = ds.Tables[0];


        return emailTo = dtStore.Rows[0]["Value"].ToString();


    }

    public string fetch_BCCTo()
    {
        string BCCTo = "";
        DbHelper d = new DbHelper();


        string sqlQuery = "select Value from tbl_Config where item='BCCTo'";

        DataSet ds = d.ExecuteDataSet(sqlQuery, ConnectionState.CloseOnExit);
        DataTable dtStore = ds.Tables[0];


        return BCCTo = dtStore.Rows[0]["Value"].ToString();


    }




}