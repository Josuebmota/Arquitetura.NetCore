using System;

namespace App.Src.Config.Environments
{
    public static class Env
    {
        public static readonly Func<string, string> Get = (env) => Environment.GetEnvironmentVariable(env);
       
    }
}
