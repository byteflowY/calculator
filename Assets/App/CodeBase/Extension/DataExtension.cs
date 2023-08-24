using UnityEngine;

namespace App.CodeBase.Extension
{
    public static class DataExtension
    {
        public static T ToDeserialized<T>(this string json)
        {
            return JsonUtility.FromJson<T>(json);
        }

        public static string ToJson(this object obj)
        {
            return JsonUtility.ToJson(obj);
        }
    }
}
