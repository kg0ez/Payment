using System;
using PAymentForServices.Common.Enums;

namespace PAymentForServices.Common.Server
{
    [Serializable]
    public class ServerQuery
    {
        public QueryType Type { get; set; }

        public string TypeAction { get; set; }

        public string Object { get; set; }
    }
}

