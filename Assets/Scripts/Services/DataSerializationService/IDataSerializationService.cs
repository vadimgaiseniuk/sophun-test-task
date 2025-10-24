using System.Threading.Tasks;

namespace Services.DataSerializationService
{
    public interface IDataSerializationService
    {
        Task<T> DeserializeAsync<T>(string data);
    }
}