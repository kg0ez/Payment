using System;
using PAymentForServices.Common.Enums;

namespace PAymentForServices.Common.Server
{
    [Serializable]
    public class ServerQuery
    {
        public QueryUserType Type { get; set; }

        public string Object { get; set; }
    }
}

