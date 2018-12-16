using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnideskSDK {
    public class Omnidesk {
        private RestClient Connection;

        /// <summary>
        /// Конструктор для создания соединения
        /// </summary>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="apiKey"></param>
        public Omnidesk(string host, string username, string apiKey) {
            var url = new Uri(new Uri("https://" + host + ".omnidesk.ru/"), "api/").ToString();
            Connection = new RestClient(url);
            Connection.Authenticator = new HttpBasicAuthenticator(username, apiKey);
        }
        /// <summary>
        /// Возвращает список обращений
        /// </summary>
        /// <param name="parameters">Набор параметров</param>
        /// <returns>Список обращений</returns>
        public List<Case> GetCase(CaseParameters parameters) {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));

            List<Case> cases = new List<Case>();
            bool f = !parameters.variables["limit"]; //Флаг, которые отвечает за получениех всех или не всех обращений с запроса
            int limit = 0, page = 0;

            do {
                RestRequest request = new RestRequest("cases.json", Method.GET);
                request.AddHeader("Content-Type", "application/json");

                if (!f) {
                    if (parameters.variables["page"]) request.AddParameter("page", parameters.Page);
                    if (parameters.variables["limit"]) request.AddParameter("limit", parameters.Limit);
                } else request.AddParameter("page", page); 
                if (parameters.variables["user_id"]) foreach (int t in parameters.UserId) request.AddParameter("user_id[]", t);
                if (parameters.variables["user_email"]) foreach (string t in parameters.UserEmail) request.AddParameter("user_email[]", t);
                if (parameters.variables["user_phone"]) foreach (string t in parameters.UserPhone) request.AddParameter("user_phone[]", t);
                if (parameters.variables["subject"]) request.AddParameter("subject", parameters.Subject);
                if (parameters.variables["staff_id"]) foreach (int t in parameters.StaffId) request.AddParameter("staff_id[]", t);
                if (parameters.variables["group_id"]) foreach (int t in parameters.GroupId) request.AddParameter("group_id[]", t);
                if (parameters.variables["channel"]) foreach (string t in parameters.Channel) request.AddParameter("channel[]", t);
                if (parameters.variables["priority"]) foreach (string t in parameters.Priority) request.AddParameter("priority[]", t);
                if (parameters.variables["filter"]) request.AddParameter("filter", parameters.Filter);
                if (parameters.variables["status"]) foreach (string t in parameters.Status) request.AddParameter("status[]", t);
                if (parameters.variables["labels"]) foreach (int t in parameters.Labels) request.AddParameter("labels[]", t);
                if (parameters.variables["show_merged_cases"]) request.AddParameter("show_merged_cases", parameters.ShowMergedCases);
                if (parameters.variables["show_active_chats"]) request.AddParameter("show_active_chats", parameters.ShowActiveChats);
                if (parameters.variables["sort"]) request.AddParameter("sort", parameters.Sort);
                if (parameters.variables["from_time"]) request.AddParameter("from_time", parameters.FromTime);
                if (parameters.variables["to_time"]) request.AddParameter("to_time", parameters.ToTime);

                var response = Connection.Execute(request);
                var content = response.Content;

                JObject obj = JObject.Parse(content);
                if (!obj.GetValue("case").HasValues) break;
                if (f) int.TryParse(obj.GetValue("total_count").ToString(), out limit);
                foreach (JProperty t in obj.Properties()) {
                    if (t.Name == "total_count") continue;
                    var c = JsonConvert.DeserializeObject<Case>(t.Value["case"].ToString());
                    cases.Add(c);
                }
                page++;
            } while (page != limit / 100);

            return cases;
        }

        public List<User> GetStaff(UserParameters parameters) {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));

            List<User> cases = new List<User>();
            bool f = !parameters.variables["limit"]; //Флаг, которые отвечает за получениех всех или не всех обращений с запроса
            int limit = 0, page = 0;

            do {
                RestRequest request = new RestRequest("users.json", Method.GET);
                request.AddHeader("Content-Type", "application/json");

                if (!f) {
                    if (parameters.variables["page"]) request.AddParameter("page", parameters.page);
                    if (parameters.variables["limit"]) request.AddParameter("limit", parameters.limit);
                } else request.AddParameter("page", page);
                if (parameters.variables["user_email"]) request.AddParameter("user_email", parameters.user_email);
                if (parameters.variables["user_phone"]) request.AddParameter("user_phone", parameters.user_phone);
                if (parameters.variables["language_id"]) request.AddParameter("language_id", parameters.language_id);
                if (parameters.variables["amount_of_cases"]) request.AddParameter("amount_of_cases", parameters.amount_of_cases);
                if (parameters.variables["amount_of_cases"]) request.AddParameter("amount_of_cases", parameters.amount_of_cases);

                var response = Connection.Execute(request);
                var content = response.Content;
                
                JObject obj = JObject.Parse(content);
                if (f) int.TryParse(obj.GetValue("total_count").ToString(), out limit);
                foreach (JProperty t in obj.Properties()) {
                    if (t.Name == "total_count") continue;
                    var c = JsonConvert.DeserializeObject<User>(t.Value["user"].ToString());
                    cases.Add(c);
                }
                page++;
            } while (page < limit / 100);

            return cases;
        }
    }
}
