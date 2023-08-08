using ApplicationBLL.Database;
using ApplicationBLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class jQueryController : Controller
    {
        private readonly ILogger<jQueryController> logger;
        private jQueryDatabase Database = new jQueryDatabase();

        public jQueryController(ILogger<jQueryController> logger) => this.logger = logger;

        public IActionResult Index()
        {
            logger.LogInformation($"jQuery page start at {DateTime.Now}");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadDatatable()
        {
            try
            {
                var response = await Database.GetAll();
                IEnumerable<jQueryModel>? list = response.ResponseObject as IEnumerable<jQueryModel>;

                if (response.ErrorCode == ProjectCore.EnErrorCode.OK)
                {
                    logger.LogInformation("LoadDatatable is successful");
                    return Json(new { data = list, errorCode = (int)response.ErrorCode, });
                }
                else if (response.ErrorCode == ProjectCore.EnErrorCode.NotExist)
                {
                    logger.LogError($"LoadDatable is failed / Response =>  ErrorCode: {(int)response.ErrorCode}, ErrorMessage: {response.ErrorCode}");
                    return Json(new { data = list, errorCode = (int)response.ErrorCode, result = $"ErrorCode: {(int)response.ErrorCode}", });
                }
                else if (response.ErrorCode == ProjectCore.EnErrorCode.IternalError)
                {
                    logger.LogError($"LoadDatable is failed / Response =>  ErrorCode: {(int)response.ErrorCode}, ErrorMessage: {response.ErrorCode}");
                    return Json(new { data = list, errorCode = (int)response.ErrorCode, result = $"ErrorCode: {(int)response.ErrorCode}" });
                }

                return Json(new { errorCode = (int)ProjectCore.EnErrorCode.IternalError, result = "ErrorCode: 2" });
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception form LoadDatatable => {ex.Message}");
                return Json(new { errorCode = (int)ProjectCore.EnErrorCode.IternalError, result = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTable(int? id)
        {
            if (id != null)
            {
                var response = await Database.GetOne(id.Value);

                if (response.ErrorCode == ProjectCore.EnErrorCode.OK)
                {
                    jQueryModel? model = response.ResponseObject as jQueryModel;

                    logger.LogInformation("UpdateTable[GET] is successful");
                    return PartialView(model);
                }
                else if (response.ErrorCode == ProjectCore.EnErrorCode.NotExist)
                {
                    logger.LogError($"UpdateTable[GET] is failed / Response =>  ErrorCode: {(int)response.ErrorCode}, ErrorMessage: {response.ErrorCode}");
                    return Json(new { errorCode = (int)response.ErrorCode, result = $"ErrorCode: {(int)response.ErrorCode}" });
                }

                logger.LogError($"UpdateTable[GET] is failed / Response =>  ErrorCode: {(int)response.ErrorCode}, ErrorMessage: {response.ErrorCode}");
                return Json(new { errorCode = (int)response.ErrorCode, result = $"ErrorCode: {(int)response.ErrorCode}" });
            }

            return PartialView(new jQueryModel());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTable([FromBody] jQueryModel data)
        {
            try
            {
                var exist = await Database.GetOne(data.ID);

                if (exist.ResponseObject != null)
                {
                    var edit_response = await Database.Edit(data);

                    logger.LogInformation("UpdateTable[POST] - edit is successful");
                    return Json(new { errorCode = (int)edit_response.ErrorCode, result = edit_response.ErrorMessage });
                }

                var create_response = await Database.Create(data);

                logger.LogInformation("UpdateTable[POST] - create is successful");
                return Json(new { errorCode = (int)create_response.ErrorCode, result = create_response.ErrorMessage });
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception form UpdateTable => {ex.Message}");
                return Json(new { result = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteObject(int id)
        {
            try
            {
                var response = await Database.Delete(id);

                logger.LogInformation("DeleteObject is successful");
                return Json(new { errorCode = (int)response.ErrorCode, result =  response.ErrorMessage });
            }
            catch(Exception ex)
            {
                logger.LogError($"Exception form DeleteObject => {ex.Message}");
                return Json(new { result = ex.Message });
            }
        }
    }
}
