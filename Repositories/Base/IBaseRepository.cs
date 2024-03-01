using TestUkrposhta.DTOs;

namespace TestUkrposhta.Repositories
{
    public interface IBaseRepository<T> where T : BaseDTO
    {
        /// <summary> Returns all instances from db </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary> Returns sorted instances from db </summary>
        Task<IEnumerable<T>> GetOrderedItemsAsync(string orderStatement = "ID", int? take = null, int? skip = null);

        /// <summary> Returns item from db by ID column </summary>
        Task<T?> GetItemAsync(int id);

        /// <summary> Removes item from db </summary>
        /// <returns> True, if any row is affected </returns>
        Task<bool> Delete(int id);
    }
}
