using System.Collections.Generic;
using UnityEngine;

namespace SnowKore.Logger
{
    [CreateAssetMenu(fileName = "LoggerConfig", menuName = "BGD/Config/Logger")]
    public class LoggerConfig : ScriptableObject
    {
        [SerializeField]
        private List<LogCategoryParams> categoriesParams = new List<LogCategoryParams>();
        [SerializeField]
        private List<LogTypeColor> typesColor = new List<LogTypeColor>();

        public Color GetCategoryColor (LogCategory category)
        {
            if (!categoriesParams.Exists(c => c.category == category))
                return Color.white;

            return categoriesParams.Find(c => c.category == category).color;
        }

        public Color GetTypeColor(LogType type)
        {
            if (!typesColor.Exists(t => t.type == type))
                return Color.white;

            return typesColor.Find(t => t.type == type).color;
        }

        public bool IsEnabled(LogCategory category)
        {
            if (!categoriesParams.Exists(c => c.category == category))
            {
                Debug.LogWarning("Log category " + category + " not found. Please create parameters for that category.");
                return true;
            }

            return categoriesParams.Find(c => c.category == category).isEnabled;
        }
    }
}
