using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Entities.Results
{
    public class Result
    {
        public ErrorModel Error { get; set; } = new ErrorModel();
        public bool HasError => Error.ErrorCode != null || Error.ErrorMessage != null;
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ErrorModel
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<string>? ErrorDataList { get; set; }
    }
}
