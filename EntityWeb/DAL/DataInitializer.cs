using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EntityWeb.Models;

namespace EntityWeb.DAL
{
    public class DataInitializer : System.Data.Entity.CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var Agents = new List<Agent>
            {
                new Agent{Hostname="ryanlaptop",IP="10.0.0.57"}
            };
            Agents.ForEach(s => context.Agents.Add(s));
            context.SaveChanges();
        }
    }
}