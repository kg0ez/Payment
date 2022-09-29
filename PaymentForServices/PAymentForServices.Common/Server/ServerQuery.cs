using System;
using PAymentForServices.Common.Enums;

namespace PAymentForServices.Common.Server
{
    public class ServerQuery<T>
    {
        public QueryUserType Type { get; set; }

        public T Object { get; set; }
    }
}

