using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using EntityWeb.SignalR;
using System.Net.NetworkInformation;
using System.Data.SqlClient;

namespace EntityWeb.StatusClasses
{
    public class GetStatus
    {
        private ServerStatus ServerStatus = ServerStatus.Instance;
        private Thread LiveStatus;
        private Ping pinger;
        public GetStatus()
        {
            LiveStatus = new Thread(CheckStatus);
            pinger = new Ping();
        }

        public void Start()
        {
            LiveStatus.Start();
        }

        public void Stop()
        {
            LiveStatus.Abort();
        }

        public void CheckStatus()
        {
            while (true)
            {
                try
                {
                    PingReply reply = pinger.Send("10.0.0.205");
                    if (reply.Status == IPStatus.Success)
                    {
                        ServerStatus.UpdateDesktop(true);
                    }
                    else
                    {
                        ServerStatus.UpdateDesktop(false);
                    }
                }
                catch (PingException)
                {
                    ServerStatus.UpdateDesktop(false);
                }

                using (SqlConnection conn = new SqlConnection("Server=ryandesktop;Database=PittEvents;User ID=dbaccess;pwd=testing"))
                {
                    try
                    {
                        conn.Open();
                        ServerStatus.UpdateSQL(true);
                    }
                    catch (SqlException)
                    {
                        ServerStatus.UpdateSQL(false);
                    }
                }
                Thread.Sleep(5000);
            }
        }
    }
}