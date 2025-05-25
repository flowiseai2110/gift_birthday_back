using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DA
{
    public class SupabaseSettings
    {
        public string Url { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string BucketName { get; set; } = string.Empty;
        public string StorageUrl { get; set; } = string.Empty;
        public string AuthUrl { get; set; } = string.Empty;
        public string ProjectRef { get; set; } = string.Empty;
    }
}
