using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Services.FileHandlingService
{
    public class FileHandlingService : IFileHandlingService
    {
        public async Task<string> ReadFileAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Debug.LogError($"File by path {filePath} does not exist");
                return string.Empty;
            }

            try
            {
                string fileContent = await File.ReadAllTextAsync(filePath);
                
                return fileContent;
            }
            catch (Exception e)
            {
                Debug.LogError($"File reading by path {filePath} failed with exception: {e.Message}");
                return string.Empty;
            }
        }

        public async Task<string> ReadFileFromResourcesAsync(string fileName)
        {
            TextAsset file = Resources.Load<TextAsset>(fileName);

            if (file == null)
            {
                Debug.LogError($"Resource file not found at path: {fileName}");
                return string.Empty;
            }

            try
            {
                await Task.Yield();
                return file.text;
            }
            catch (Exception e)
            {
                Debug.LogError($"File reading by path {fileName} failed with exception: {e.Message}");
                return string.Empty;
            }
        }
    }
}