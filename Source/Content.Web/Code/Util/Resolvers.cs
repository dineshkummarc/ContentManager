using System.Web;
//
using AutoMapper;
//
using ContentNamespace.Web.Code.Service.Interfaces;
//
using Ninject.Core;

namespace ContentNamespace.Web.Code.Util
{
    public class Resolvers
    {
        #region Methods...

        public class HtmlContent : ValueResolver<string, string>
        {
            protected override string ResolveCore(string rawContentData)
            {
                string processedContentData = string.Empty;
                var kernel = HttpContext.Current.Application["ContentManagerStandardKernel"] as IKernel;

                if (kernel != null)
                {
                    var setting = ((ISettingService)kernel.Get(typeof(ISettingService))).Get();

                    processedContentData = (rawContentData.Length > setting.ContentExtractLength ?
                                            rawContentData.Substring(0, setting.ContentExtractLength) + "..." :
                                            rawContentData);
                }

                return processedContentData;
            }
        }

        #endregion
    }
}
