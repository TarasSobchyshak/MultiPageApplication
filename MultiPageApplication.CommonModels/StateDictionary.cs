using System.Collections.Generic;

namespace MultiPageApplication.CommonModels
{
    public static class StateDictionary
    {
        static StateDictionary()
        {
            Dic = new Dictionary<int, Dictionary<string, object>>();
        }
        public static Dictionary<int, Dictionary<string, object>> Dic { get; set; }
    }
}
