using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EShop.Api.Exceptions
{
    public class CustomBadRequest
    {
        private StringBuilder errorString = new StringBuilder();
        public CustomBadRequest(ActionContext context)
        {
            ConstructErrorMessages(context);
            throw new BadHttpRequestException(errorString.ToString());
        }

        private void ConstructErrorMessages(ActionContext context)
        {

            foreach (var item in context.ModelState.Values)
            {
                errorString.Append(string.Join("", item.Errors.Select(p => p.ErrorMessage + "-")));
            }

            errorString.Remove(errorString.Length - 1, 1);
        }
    }
}
