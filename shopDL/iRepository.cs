using shopModel;

namespace shopDL
{
    public interface iRepository<T>
    {
        // Create, read, update, delete

        /// <summary>
        /// This will create a resource to the database
        /// </summary>
        /// <param name="p_resource">This resourse being saved to the database</param>
        void Add ( T p_resource);

        /// <summary>
        /// This will get all the specific resourse from database
        /// </summary>
        /// <returns>T is the resource being given</returns>

        List<T> GetAll();

        Task<List<T>> GetAllAsync();

        /// <summary>
        /// This will update an exiting resource
        /// </summary>
        /// <param name="p_resource"> This is the resourse it is updating</param>

        void Update(T p_resource);
    }
}