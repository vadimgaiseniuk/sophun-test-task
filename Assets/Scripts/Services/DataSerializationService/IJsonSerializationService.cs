using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace Services.DataSerializationService
{
    public class JsonDataSerializationService : IDataSerializationService
    {
        public async Task<T> DeserializeAsync<T>(string data)
        {
            try
            {
                T deserializedObject = await Task.Run( () => JsonConvert.DeserializeObject<T>(data));
                
                return deserializedObject;
            }
            catch (Exception e)
            {
                Debug.LogError($"Deserialization of data failed with exception: {e.Message}");
                return default;
            }
        }
    }
}