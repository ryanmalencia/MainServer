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
        public void PutDist(Job job)
        {
            JobDB.PutDist(job);
        }
        /// <summary>
        /// Set Job to Started State
        /// </summary>
        /// <param name="job">Job to set</param>
        public void PutStarted(Job job)
        {
            JobDB.PutStarted(job);
        }
        /// <summary>
        /// Set Job to Finished State
        /// </summary>
        /// <param name="job">Job to set</param>
        public void PutFinished(Job job)
        {
            JobDB.PutFinished(job);
        }
        /// <summary>
        /// Reset Job state
        /// </summary>
        /// <param name="job">Job to reset</param>
        public void PutReset(Job job)
        {
            JobDB.PutReset(job);
        }
    }
}