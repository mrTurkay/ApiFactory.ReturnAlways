using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiFactory.ReturnAlways
{
    public class ResultModel : ActionResult
    {
        public ResultModel()
        {
            Success = true;
            StatusCode = StatusCodes.Status200OK;
        }

        public ResultModel(object returnValue, int count)
        {
            Success = true;
            StatusCode = StatusCodes.Status200OK;
            ResponseData = returnValue;
            Count = count;
            Type = "list";
        }

        public ResultModel(object returnValue, PagerModel pager)
        {
            Success = true;
            StatusCode = StatusCodes.Status200OK;
            ResponseData = returnValue;
            Count = pager.CurrentRowCount;
            Type = "list";
            Pager = pager;
        }

        public ResultModel(object returnValue)
        {
            Success = true;
            StatusCode = StatusCodes.Status200OK;
            ResponseData = returnValue;
            Type = "object";
            Count = 1;
        }
        public ResultModel(object returnValue, bool isbool)
        {
            Success = true;
            StatusCode = StatusCodes.Status200OK;
            ResponseData = returnValue;
            Type = "boolean";
            Count = 1;
        }
        public ResultModel(int statusCode, string message)
        {
            Success = false;
            StatusCode = statusCode;
            Message = message;
        }
        public ResultModel(int statusCode, object errorMessages, bool error)
        {
            Success = false;
            StatusCode = statusCode;
            Message = errorMessages;
        }

        public ResultModel(int statusCode, object returnValue)
        {
            Success = true;
            StatusCode = statusCode;
            ResponseData = returnValue;
        }

        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public object Message { get; set; }
        public List<string> Fields { get; set; }
        public string Type { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }

        private int? _count;
        public int? Count
        {
            get => _count;
            set { if (value == 0) _count = null; _count = value; }
        }

        public PagerModel Pager { get; set; }
        public object ResponseData { get; set; }

        [JsonIgnore]
        public ObjectResult AsReturn => new ObjectResult(this) { StatusCode = this.StatusCode };


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }


    }
}