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

        public static int QueryGetId(T login)
        {
            var json = Serialize(login, QueryUserType.GetId);

            string answer = NetworkHandler.Client(json);

            var id = JsonSerializer.Deserialize<int>(answer);

            return id;
        }

        public static UserDto QueryGetUser(T id)
        {
            var json = Serialize(id, QueryUserType.GetUser);

            var answer = NetworkHandler.Client(json);

            var user = JsonSerializer.Deserialize<UserDto>(answer);

            return user;
        }
    }
}

