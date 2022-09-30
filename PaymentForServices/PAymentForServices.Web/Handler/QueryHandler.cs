using System;
using PAymentForServices.Common.Enums;
using PAymentForServices.Common.Server;
using System.Text.Json;

namespace PAymentForServices.Web.Handler
{
    public static class QueryHandler<T>
    {
        public static string Serialize(T obj, QueryUserType type)
        {
            ServerQuery query = new ServerQuery
            {
                Type = type,
                Object = JsonSerializer.Serialize<T>(obj)
            };
            var json = JsonSerializer.Serialize<ServerQuery>(query);
            return json;
        }
    }
}

