using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnideskSDK {
    public class User {
        public int user_id { get; set; }
        public string user_full_name { get; set; }
        public string company_name { get; set; }
        public string company_position { get; set; }
        public string thumbnail { get; set; }
        public bool confirmed { get; set; }
        public bool active { get; set; }
        public bool deleted { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string type { get; set; }
        public string user_email { get; set; }
        public int language_id { get; set; }
        public Custom_Fields_User custom_fields { get; set; }
    }

    public class Custom_Fields_User {
        public string cf_20 { get; set; }
        public bool cf_23 { get; set; }
    }

}
