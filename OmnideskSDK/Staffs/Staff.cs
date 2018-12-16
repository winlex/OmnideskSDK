using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnideskSDK.Staffs {
    public class Staff {
        public int staff_id { get; set; }
        public string staff_email { get; set; }
        public string staff_full_name { get; set; }
        public string staff_signature { get; set; }
        public string thumbnail { get; set; }
        public bool active { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public override bool Equals(object obj) {
            var staff = obj as Staff;
            return staff != null &&
                   staff_email == staff.staff_email;
        }
    }
}
