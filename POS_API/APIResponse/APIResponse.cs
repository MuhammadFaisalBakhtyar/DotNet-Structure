using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_API.APIResponse
{
    public class APIResponse<T> where T : class
    {
        public List<T> Data;
        public IEnumerable<T> DataEnum;
        public bool IsSuccess;
        public string ErrorMessage;
    }
}