using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KlickbookEcommerceService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private IBackgroundTaskQueue queue;
        private readonly ILogger<ApiController> logger;


        public ApiController(IBackgroundTaskQueue queue, ILogger<ApiController> logger)
            => (this.queue, this.logger) = (queue, logger);

        [HttpPost]
        [Route("forgot-password/{user?}")]
        public async Task<IActionResult> ForgotPassword(string user)
        {
            // and more...
            // Queue processing
            await queue.QueueBackgroundWorkItemAsync(async (token) =>
            {
                //await _mailService.SendAsync(mailData, token);
            });

            return Ok();
        }

        [HttpGet]
        public IActionResult StartProcessing()
        {
            queue.QueueBackgroundWorkItem(async token =>
            {
                // put processing code here
                object response = DoSomethind();
                logger.LogInformation("my service runs fine, ... " + response);
                token.ThrowIfCancellationRequested();
            });
    
        return Ok();
        }

        private string DoSomethind()
        {
            try
            {
                return Guid.NewGuid().ToString();
            }
            catch (Exception ex)
            {
                return "There was an error while processing,... " + ex.Message;
                //throw ex;
            }
        }
    }
}
