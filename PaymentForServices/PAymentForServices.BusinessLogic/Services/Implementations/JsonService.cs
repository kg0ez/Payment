using System;
using System.Text.Json;
using PAymentForServices.Common.Enums;
using PAymentForServices.Common.Server;

namespace PAymentForServices.BusinessLogic.Services
{
    public class JsonService:IJsonService
    {
        public string SerializeServerQuery(ServerQuery query)
        {
            string json = JsonSerializer.Serialize(query);
            return json;
        }

        public string SerializeString(string obj)
        {
            string json = JsonSerializer.Serialize(obj);
            return json;
        }
    }
}

