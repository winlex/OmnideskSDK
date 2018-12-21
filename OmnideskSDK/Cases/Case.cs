using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnideskSDK.Cases {
    public class Case {
        public int case_id { get; set; }
        public string case_number { get; set; }
        public string subject { get; set; }
        public int user_id { get; set; }
        public int staff_id { get; set; }
        public int group_id { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string channel { get; set; }
        public string recipient { get; set; }
        public string recipient_cc { get; set; }
        public string recipient_bcc { get; set; }
        public string[] recipient_arr { get; set; }
        public string[] recipient_cc_arr { get; set; }
        public object[] recipient_bcc_arr { get; set; }
        public bool deleted { get; set; }
        public bool spam { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string last_response_at { get; set; }
        public int parent_case_id { get; set; }
        public string closing_speed { get; set; }
        public int language_id { get; set; }
        public Custom_Fields custom_fields { get; set; }
        public object[] labels { get; set; }
    }

    public class Custom_Fields {
        public string cf_2240 { get; set; }
        public string cf_2650 { get; set; }
        public string cf_2481 { get; set; }
        public string cf_2480 { get; set; }
        public string cf_2479 { get; set; }
        public string cf_2478 { get; set; }
        public string cf_2477 { get; set; }
        public bool cf_2476 { get; set; }
        public string cf_2292 { get; set; }
        public string cf_2291 { get; set; }
        public bool cf_2290 { get; set; }
        public string cf_2263 { get; set; }
        public string cf_2262 { get; set; }
        public string cf_2261 { get; set; }
        public bool cf_2260 { get; set; }
        public string cf_2385 { get; set; }
        public string cf_2247 { get; set; }
        public string cf_2246 { get; set; }
        public string cf_2169 { get; set; }
        public string cf_2302 { get; set; }
        public string cf_1754 { get; set; }
    }
}
