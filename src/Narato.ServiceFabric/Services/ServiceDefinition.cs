﻿using System;

namespace Narato.ServiceFabric.Services
{
    public abstract class ServiceDefinition
    {
        public abstract string ServiceTypeName { get; }

        public string InstanceKey { get; protected set; }

        public virtual Uri ApplicationUri => new Uri(Environment.GetEnvironmentVariable("Fabric_ApplicationName") ?? "");
        public virtual Uri ServiceUri => string.IsNullOrEmpty(InstanceKey) ?
            new Uri(ApplicationUri.AbsoluteUri + $"/{ServiceTypeName}") :
            new Uri(ApplicationUri.AbsoluteUri + $"/{ServiceTypeName}/{InstanceKey.ToLower()}");
    }
}