using System;
using System.Threading.Tasks;
using Benergy.Core.Exceptions;
using Benergy.Core.Models.API;

namespace Benergy.Core.Helpers
{
    /// <summary>
    /// Helpers methods used to generate standard object, APIModel
    /// </summary>
    public static class APIHelper
    {
        public static APIResponseModel<T> Get<T>(Func<string, T> action, string message = "")
            where T : class
        {
            APIResponseModel<T> api;

            try
            {
                T model = action(null);
                api = new APIResponseModel<T>() { Result = APIResult.Success, Model = model, Message = message };
            }
            catch (System.Exception exp)
            {
                api = new APIResponseModel<T>() { Result = APIResult.Exception, Model = null, Message = exp.GetBaseException().Message };
            }

            return api;
        }

        public static APIResponseModel<T> Save<T>(Action<string> action, string message)
            where T : class
        {
            APIResponseModel<T> api;

            try
            {
                action(null);
                api = new APIResponseModel<T>() { Result = APIResult.Success, Model = null, Message = message };
            }
            catch (System.Exception exp)
            {
                api = new APIResponseModel<T>() { Result = APIResult.Exception, Model = null, Message = exp.GetBaseException().Message };
            }

            return api;
        }

         public static APIResponseModel<T> SaveGet<T>(Func<string, T> action, string message)
            where T : class
        {
            return Get(action, message);
        }

        public static APIResponseModel<T> BlankModel<T>()
            where T : class
        {
            return new APIResponseModel<T>() { Result = APIResult.Success, Model = null, Message = string.Empty };
        }

        public static async Task<APIResponseModel<T>> GetAsync<T>(Func<string, Task<T>> action, string message = "")
            where T : class
        {
            APIResponseModel<T> api;

            try
            {
                T model = await action(null);
                api = new APIResponseModel<T>() { Result = APIResult.Success, Model = model, Message = message };
            }
            catch (System.Exception exp)
            {
                api = new APIResponseModel<T>() { Result = APIResult.Exception, Model = null, Message = exp.GetBaseException().Message };
            }

            return api;
        }

        public static async Task<APIResponseModel<NTModel>> SaveAsync(Func<string, Task> action, string message)
        {
            APIResponseModel<NTModel> api;

            try
            {
                await action(null);
                api = new APIResponseModel<NTModel>() { Result = APIResult.Success, Model = null, Message = message };
            }
            catch (NTException exp)
            {
                api = new APIResponseModel<NTModel>() { Result = APIResult.ValidationException, Model = new NTModel() { Data = exp.Errors }, Message = exp.Message };
            }
            catch (System.Exception exp)
            {
                api = new APIResponseModel<NTModel>() { Result = APIResult.Exception, Model = null, Message = exp.GetBaseException().Message };
            }

            return api;
        }

        public static async Task<APIResponseModel<T>> SaveGetAsync<T>(Func<string, Task<T>> action, string message)
            where T : class
        {
            return await GetAsync(action, message);
        }
    }
}