using Business.DependencyInjection;
using Business.Dto.Page;

namespace WebApi.Models
{
    public class PageModel : IModel
    {
        public UserMessage UserMessage { get; set; }

        public static PageModel GetModel(
            string title,
            IBusinessDependencies dependencies,
            string message = null,
            bool displayAsRaw = false,
            MessageType messageType = MessageType.Info)
        {
            return new PageModel()
            {
                UserMessage = new UserMessage
                {
                    Message = message,
                    MessageType = messageType,
                    DisplayAsRaw = displayAsRaw
                }
            };
        }

        protected static PageMetadataDto GetPageMetadata(string title, IBusinessDependencies dependencies)
        {
            return new PageMetadataDto()
            {
                Title = title,
                CompanyName = dependencies.SiteContextService.SiteName
            };
        }
    }
}