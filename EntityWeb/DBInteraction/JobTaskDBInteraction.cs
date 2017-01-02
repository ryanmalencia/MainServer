using System.Linq;
using DataTypes;
using EntityWeb.DAL;

namespace EntityWeb.DBInteraction
{
    public class JobTaskDBInteraction
    {
        private DataContext DB;
        public JobTaskDBInteraction()
        {
            DB = new DataContext();
        }

        public JobTaskCollection GetByGroup(int group)
        {
            var Tasks = DB.JobTasks.Where(a => a.Group == group);
            JobTaskCollection GroupTasks = new JobTaskCollection();
            foreach(JobTask Task in Tasks)
            { 
                GroupTasks.AddJobTask(Task);
            }
            return GroupTasks;
        }
    }
}