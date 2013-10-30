
namespace AshAnil.FinPlanner.DBInfrastructure
{
    /// <summary>
    /// Class to manage the ids to be used for newly created business objects
    /// </summary>
    public static class IdFetcher
    {
        static uint nextId = 0;

        /// <summary>
        /// Set the nextId when a file is read from database
        /// </summary>
        /// <param name="newId"></param>
        public static void SetNextId(uint newId)
        {
            nextId = newId;
        }

        /// <summary>
        /// Returns the next id to be used
        /// </summary>
        /// <returns></returns>
        public static uint GetNextId()
        {
            return nextId++;
        }
    }
}
