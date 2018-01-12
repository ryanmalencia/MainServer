using EntityWeb.DBInteraction;
using DataTypes;

namespace EntityWeb.Logic
{
    public class JobLogic
    {
        private JobDBInteraction JobDB = new JobDBInteraction();
        /// <summary>
        /// Get All Jobs in DB
        /// </summary>
        /// <returns>JobCollection containing all jobs</returns>
        public JobCollection GetAllJobs()
        {
            return JobDB.GetAllJobs();
        }
        /// <summary>
        /// Get the next set of jobs to run 
        /// </summary>
        /// <returns>JobCollection containing jobs to run</returns>
        public JobCollection GetJobsToRun()
        {
            return JobDB.GetJobsToRun();
        }
        /// <summary>
        /// Get Job by its ID
        /// </summary>
        /// <param name="Id">ID of desired job</param>
        /// <returns>Job object or null if it does not exist</returns>
        public Job GetJobById(int Id)
        {
            return JobDB.GetJobById(Id);
        }
        /// <summary>
        /// Set Job to Distributed State
        /// </summary>
        /// <param name="job">Job to set</param>
        /// <returns>Updated job object</returns>
        public Job PutDist(Job job)
        {
            return JobDB.PutDist(job);
        }
        /// <summary>
        /// Set Job to Started State
        /// </summary>
        /// <param name="job">Job to set</param>
        /// <returns>Updated job object</returns>
        public Job PutStarted(Job job)
        {
            return JobDB.PutStarted(job);
        }
        /// <summary>
        /// Set Job to Finished State
        /// </summary>
        /// <param name="job">Job to set</param>
        /// <returns>Updated job object</returns>
        public Job PutFinished(Job job)
        {
            return JobDB.PutFinished(job);
        }
        /// <summary>
        /// Reset Job State
        /// </summary>
        /// <param name="job">Job to set</param>
        /// <returns>Updated job object</returns>
        public Job PutReset(Job job)
        {
            return JobDB.PutReset(job);
        }
    }
}