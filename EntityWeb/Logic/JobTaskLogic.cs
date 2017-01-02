using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataTypes;
using EntityWeb.DBInteraction;

namespace EntityWeb.Logic
{
    public class JobTaskLogic
    {
        public JobTaskDBInteraction JobTaskDB = new JobTaskDBInteraction();
        public JobTaskCollection GetByGroup(int group)
        {
            return JobTaskDB.GetByGroup(group);
        }
    }
}