using System;
using PAymentForServices.Common.Enums;
using PAymentForServices.Common.Server;
using System.Text.Json;
using PAymentForServices.Common.ModelsDto;
using PAymentForServices.Web.Models;

namespace PAymentForServices.Web.Handler
{
    public static class QueryHandler<T>
    {
        public static string Serialize(T obj,QueryType type, string someTypeAction)
        {
            ServerQuery query = new ServerQuery
            {
                Type = type,
                TypeAction = someTypeAction,
                Object = JsonSerializer.Serialize<T>(obj)
            };
            var json = JsonSerializer.Serialize<ServerQuery>(query);
            return json;
        }

        public static string QueryTypeSerialize(T someType)
        {
            return JsonSerializer.Serialize<T>(someType);
        }

        public static int QueryGetId(T login)
        {
            var typeAction = JsonSerializer.Serialize<QueryUserType>(QueryUserType.GetId);

            var json = Serialize(login, QueryType.User, typeAction);

            string answer = NetworkHandler.ConnectionWithServ(json);

            var id = JsonSerializer.Deserialize<int>(answer);

            return id;
        }

        public static UserDto QueryGetUser(T id)
        {
            var typeAction = JsonSerializer.Serialize<QueryUserType>(QueryUserType.GetUser);

            var json = Serialize(id, QueryType.User, typeAction);

            var answer = NetworkHandler.ConnectionWithServ(json);

            var user = JsonSerializer.Deserialize<UserDto>(answer)!;

            return user;
        }
    }
}

