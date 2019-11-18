using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Benergy.Core.Context
{
    public static class NTContext
    {
        public static NTContextModel Context
        {
            get
            {
                return CallContext<NTContextModel>.GetData("BenergyContext");
            }

            set
            {
                NTContextModel model = value;
                if (model == null)
                {
                    model = new NTContextModel();
                }

                NTContextModel contextModel = Context;

                if (contextModel == null)
                {
                    CallContext<NTContextModel>.SetData("BenergyContext", model);
                }
                else
                {
                    contextModel = Mapper.Map<NTContextModel, NTContextModel>(model, contextModel);
                }
            }
        }

        public static HttpContext HttpContext
        {
            get
            {
                return CallContext<HttpContext>.GetData("HttpContext");
            }

            set
            {
                CallContext<HttpContext>.SetData("HttpContext", value);
            }
        }
    }
}