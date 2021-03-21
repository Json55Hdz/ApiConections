using System;
using UnityEngine;

namespace SnowKore.Logger
{
    [Serializable]
    public struct LogCategoryParams
    {
        public LogCategory category;
        public bool isEnabled;
        public Color color;
    }
}
