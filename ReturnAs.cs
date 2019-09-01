using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFactory.ReturnAlways
{
    public static class ReturnAs
    {
        public static IActionResult Ok()
        {
            return new ResultModel().AsReturn;
        }

        public static IActionResult Ok(object returnData)
        {
            return new ResultModel(returnData).AsReturn;
        }

        public static IActionResult OkList(object returnData = null, int count = 0)
        {
            return new ResultModel(returnData, count).AsReturn;
        }

        public static IActionResult OkList(object returnData, PagerModel pagerModel)
        {
            return new ResultModel(returnData, pagerModel).AsReturn;
        }

        public static IActionResult OkBoolean(object returnData = null)
        {
            return new ResultModel(returnData, true).AsReturn;
        }

        public static IActionResult Created(object returnData)
        {
            return new ResultModel(StatusCodes.Status201Created, returnData).AsReturn;
        }

        public static IActionResult File(object returnData, string fileName, string fileType = "excel")
        {
            var result = new ResultModel(returnData) { Type = "file", FileType = fileType, FileName = fileName };
            return result.AsReturn;
        }
        public static IActionResult NotFound(int id = -1)
        {
            var idString = id > 0 ? id.ToString() : "";
            return new ResultModel(StatusCodes.Status404NotFound, "Record not found " + idString).AsReturn;
        }
        public static IActionResult NotFound<TId>(TId id)
        {
            var idstr = id.ToString();
            return new ResultModel(StatusCodes.Status404NotFound, "Record not found " + idstr).AsReturn;
        }
        public static IActionResult BadRequest(string message = "Check Request")
        {
            return new ResultModel(StatusCodes.Status400BadRequest, message).AsReturn;
        }

        public static IActionResult BadRequest(object messages)
        {
            return new ResultModel(StatusCodes.Status400BadRequest, messages, true).AsReturn;
        }

        public static IActionResult Unauthorized(string message = "Unauthorized")
        {
            return new ResultModel(StatusCodes.Status401Unauthorized, message).AsReturn;
        }
        public static IActionResult Forbidden(string message = "No Access Rights")
        {
            return new ResultModel(StatusCodes.Status403Forbidden, message).AsReturn;
        }
        public static IActionResult InternalServerError(string message = "Check Request")
        {
            return new ResultModel(StatusCodes.Status500InternalServerError, message).AsReturn;
        }

    }
}