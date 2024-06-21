using System.Net;
using System.Text.Json;

namespace Web.RentalCar.Utility
{
    public class CookieHelper
    {
        public class CookieItem
        {
            public string ItemKey { get; set; }
            public string ItemValue { get; set; }
        }

        public class NewCookie
        {
            public NewCookie(string cookieId)
            {
                _cookieId = cookieId;
            }
            private string _cookieId = string.Empty;
            private Content _content = new Content();

            public Content Values
            {
                get
                {
                    return _content;
                }
            }
            public string CookieID
            {
                get
                {
                    return _cookieId;
                }
                private set { _cookieId = value; }
            }

            public void Add(string key, object content)
            {
                _content.Add(key, content);
            }

            public static NewCookie GetNewCookieByString(string? cookieValue, string cookieId)
            {
                List<CookieItem> result = JsonSerializer.Deserialize<List<CookieItem>>(cookieValue);

                NewCookie cookieSource = new NewCookie(cookieId);
                foreach (var item in result)
                {
                    cookieSource.Add(item.ItemKey, item.ItemValue);
                }

                return cookieSource;
            }

            public static string GetJsonByNewCookie(NewCookie cookie)
            {
                List<CookieItem> items = new List<CookieItem>();
                foreach (var key in cookie.Keys)
                {
                    items.Add(new CookieItem()
                    {
                        ItemKey = key,
                        ItemValue = cookie.Values[key]?.ToString()
                    });
                }
                var jsonString01 = JsonSerializer.Serialize(items);
                return jsonString01;
            }
            public int Count
            {
                get
                {
                    return _content.Count;
                }
            }
            public IEnumerable<string> Keys
            {
                get
                {
                    return _content.Keys;
                }
            }
        }

        public class Content
        {
            private Dictionary<string, object> _cookieValue = new Dictionary<string, object>();
            public Dictionary<string, object> CookieValue
            {
                get
                {
                    return _cookieValue;
                }
            }

            public object this[string key]
            {
                get
                {
                    return _cookieValue[key];
                }
                set { _cookieValue[key] = value; }
            }

            public void Add(string key, object obj)
            {
                _cookieValue.Add(key, obj);
            }
            public int Count
            {
                get
                {
                    return _cookieValue.Count;
                }
            }
            public IEnumerable<string> Keys
            {
                get
                {
                    return _cookieValue.Keys.AsEnumerable();
                }
            }
        }
    }
}
