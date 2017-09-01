using System;

namespace Nintaco
{
    public static class ApiSource
    {

        public static RemoteAPI API;

        public static void initRemoteAPI(String host, int port)
        {
            API = new RemoteAPI(host, port);
        }
    }
}
