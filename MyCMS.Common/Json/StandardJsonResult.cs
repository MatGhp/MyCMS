using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace MyCMS.Common.Json
{
    public class StandardJsonResult : JsonResult
    {
        public IList<string> ErrorMessages { get; private set; }
        public StandardJsonResult()
        {
            Settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Error };
            ErrorMessages = new List<string>();
        }

        public JsonSerializerSettings Settings { get; set; }
        public void AddError(string errorMessage)
        {
            ErrorMessages.Add(errorMessage);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            if (this.Data == null)
                return;

            var response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;

            if (this.ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;


            SerializeData(response);
            //var serializer = JsonSerializer.Create(this.Settings);
            //using (var writer = new JsonTextWriter(response.Output))
            //{
            //    serializer.Serialize(writer, Data);
            //    writer.Flush();
            //}
        }

        protected virtual void SerializeData(HttpResponseBase response)
        {
            if (ErrorMessages.Any())
            {
                var originalData = Data;
                Data = new
                {
                    Success = false,
                    OriginalData = originalData,
                    ErrorMessage = string.Join("\n", ErrorMessages),
                    ErrorMessages = ErrorMessages.ToArray()
                };

                response.StatusCode = 400;
            }

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[]
                {
                    new StringEnumConverter(),
                },
            };

            response.Write(JsonConvert.SerializeObject(Data, settings));

            //----------------------
            //var serializer = JsonSerializer.Create(settings);
            //using (var writer = new JsonTextWriter(response.Output))
            //{
            //    serializer.Serialize(writer, Data);
            //    writer.Flush();
            //}
        }
    }
    public class StandardJsonResult<T> : StandardJsonResult
    {
        public new T Data
        {
            get { return (T)base.Data; }
            set { base.Data = value; }
        }
    }
}
