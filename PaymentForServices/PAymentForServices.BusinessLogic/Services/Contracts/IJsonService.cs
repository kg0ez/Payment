using System;
using PAymentForServices.Common.Server;

namespace PAymentForServices.BusinessLogic.Services
{
    public interface IJsonService
    {
        string SerializeServerQuery(ServerQuery query);

    }
}

