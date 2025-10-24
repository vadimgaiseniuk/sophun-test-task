//© 2023 Sophun Games LTD. All rights reserved.
//This code and associated documentation are proprietary to Sophun Games LTD.
//Any use, reproduction, distribution, or release of this code or documentation without the express permission
//of Sophun Games LTD is strictly prohibited and could be subject to legal action.

using System.Collections.Generic;
using System.Threading.Tasks;
using Services.AssetManagingService;
using UnityEngine;

namespace Services.SimplePopupService
{
    /// <summary>
    ///     Manages popups, providing functionality for opening, closing, and loading popups.
    /// </summary>
    public class PopupManagingService : IPopupManagingService
    {
        private readonly IAssetManagingService m_AssetManagingService;
        private readonly Dictionary<string, GameObject> m_Popups = new();

        private PopupManagingService(IAssetManagingService assetManagingService)
        {
            m_AssetManagingService = assetManagingService;
        }

        /// <summary>
        ///     Opens a popup by its name and initializes it with the given parameters.
        ///     If the popup is already loaded, it will log an error and return.
        /// </summary>
        /// <param name="name">The name of the popup to open.</param>
        /// <param name="param">The parameters to initialize the popup with.</param>
        /// <param name="model">The model to handle the popup</param>
        /// <param name="parent">The parent to instantiate the popup in</param>
        public async void OpenPopup<TData, TModel>(string name, TData param, TModel model, Transform parent)
        {
            if (m_Popups.ContainsKey(name))
            {
                Debug.LogError($"Popup with name {name} is already shown");
                return;
            }

            await LoadPopup<TData, TModel>(name, param, model, parent);
        }

        /// <summary>
        ///     Closes a popup by its name.
        ///     If the popup is loaded, it will release its instance and remove it from the dictionary.
        /// </summary>
        /// <param name="name">The name of the popup to close.</param>
        public void ClosePopup(string name)
        {
            if (!m_Popups.ContainsKey(name))
                return;

            GameObject popup = m_Popups[name];
            m_AssetManagingService.ReleaseAssetInstance(popup);
            m_Popups.Remove(name);
        }

        /// <summary>
        ///     Loads and instantiates a popup from Unity's addressable system using the provided name.
        ///     Then initializes the popup with the provided parameters.
        ///     If the popup doesn't have any IPopupInitialization components, it will log an error and release its instance.
        /// </summary>
        /// <param name="name">The name of the popup to load.</param>
        /// <param name="param">The parameters to initialize the popup with.</param>
        /// <param name="model">The model to handle the popup</param>
        /// <param name="parent">The parent to instantiate the popup in</param>
        private async Task LoadPopup<TData, TModel>(string name, TData param, TModel model, Transform parent)
        {
            GameObject popupObject = await m_AssetManagingService.InstantiateAssetAsync(name, parent);

            if (popupObject == null)
                return;
            
            popupObject.SetActive(true);
            
            IPopupInitialization<TData, TModel>[] popupInitComponents = popupObject.GetComponents<IPopupInitialization<TData, TModel>>();

            foreach (IPopupInitialization<TData, TModel> component in popupInitComponents)
            {
                await component.Initialize(param, model, m_AssetManagingService);
            }

            m_Popups.Add(name, popupObject);
        }
    }
}