//© 2023 Sophun Games LTD. All rights reserved.
//This code and associated documentation are proprietary to Sophun Games LTD.
//Any use, reproduction, distribution, or release of this code or documentation without the express permission
//of Sophun Games LTD is strictly prohibited and could be subject to legal action.

using System.Threading.Tasks;
using Services.AssetManagingService;

namespace SimplePopupService
{
    /// <summary>
    ///     An interface for initializing popups.
    /// </summary>
    public interface IPopupInitialization<in TData, in TModel>
    {
        /// <summary>
        ///     Initializes the popup with the given parameters.
        /// </summary>
        /// <param name="data">The initialization parameters.</param>
        /// <param name="model">The model to handle the initialization</param>
        /// <param name="assetManagingService">The asset managing service</param>
        Task Initialize(TData data, TModel model, IAssetManagingService assetManagingService);
    }
}