using EntityWeb.DAL;
using DataTypes;
using System.Linq;
using System;

namespace EntityWeb.DBInteraction
{
    public class JobDBInteraction
    {
        private DataContext DB;
        public JobDBInteraction()
        {
            DB = new DataContext();
        }

        public JobCollection GetAllJobs()
        {
            JobCollection AllJobs = new JobCollection();
            foreach(Job job in DB.Jobs)
            {
                AllJobs.AddJob(job);
            }
            return AllJobs;
        }

        public JobCollection GetJobsToRun()
        {
            JobCollection Jobs = new JobCollection();
            foreach (Job job in DB.Jobs.Where(a => a.Distributed == 0 && a.Started == 0))
            {
                if(job.Finished == 0)
                {
                    Jobs.AddJob(job);
                }
                else if(job.Repeat == 1)
                {
                    Jobs.AddJob(job);
                }
            }
            return Jobs;
        }

        public Job GetJobById(int Id)
        {
            return DB.Jobs.FirstOrDefault(a => a.JobID == Id);
        }

        public void PutDist(Job job)
        {
            var Job = DB.Jobs.FirstOrDefault(a => a.JobID == job.JobID);
            if(Job != null)
            {
                Job.Distributed = 1;
                Job.Finished = 0;
                Job.Last_Distributed = DateTime.Now;
                DB.SaveChanges();
            }
        }

        public void PutStarted(Job job)
        {
            var Job = DB.Jobs.FirstOrDefault(a => a.JobID == job.JobID);
            if(Job != null)
            {
                Job.Started = 1;
                DB.SaveChanges();
            }
        }

        public void PutFinished(Job job)
        {
            var Job = DB.Jobs.FirstOrDefault(a => a.JobID == job.JobID);
            if(Job != null)
            {
                if(Job.Repeat == 0)
                {
                    Job.Distributed = 1;
                    Job.Last_Finished = DateTime.Now;
                }
                else
                {
                    Job.Distributed = 0;
                    Job.Last_Finished = DateTime.Now;
                }
                Job.Finished = 1;
                DB.SaveChanges();
            }
        }

        public void PutReset(Job job)
        {
            var Job = DB.Jobs.FirstOrDefault(a => a.JobID == job.JobID);
            if(Job != null)
            {
                Job.Distributed = 0;
                Job.Started = 0;
                DB.SaveChanges();
            }
        }
    }
}