using Newtonsoft.Json;

namespace MovieStoreMVCApp.Helpers
{
    public static class SessionHelper
    {
        //ErweiterungsMethode -> HttpContext.Session.SetObjectAsJson()
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            List<string> str = new List<string>();
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
