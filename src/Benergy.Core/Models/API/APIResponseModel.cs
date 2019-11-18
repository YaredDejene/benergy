namespace Benergy.Core.Models.API
{
        public class APIResponseModel<T>
    {
        public APIResult Result { get; set; }

        public string Message { get; set; }

        public T Model { get; set; }
    }
}