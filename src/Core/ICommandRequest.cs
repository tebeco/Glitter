﻿namespace Freya.Core
{
    internal interface ICommandRequest
    {
        public string Key { get; set; }
        public IEnumerable<object> Parameters { get; set; }
    }
}