using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using OmnideskSDK.Staffs;
using OmnideskSDK;

namespace Test {
    class Program {
        private const string Host = "";
        private const string Username = "";
        private const string ApiKey = "";

        static void Main(string[] args) {
            string[] str;
            str = JsonConvert.DeserializeObject<string[]>(File.ReadAllText("../../env.json"));

            Omnidesk omnidesk = new Omnidesk(args[0], args[1], args[2]);

            UserParameters userParameters = new UserParameters() {
                user_email = str[3]
            };
            List<User> users = omnidesk.getUsers(userParameters);

            StaffParameters staffParameters = new StaffParameters();
            List<Staff> staffs = omnidesk.getStaffs(staffParameters);
            int count = 0;
            foreach (Staff t in staffs)
                if (t.active)
                    count++;

            CaseParameters caseParameters = new CaseParameters();
            caseParameters.staff_id = new int[] {
                staffs[staffs.IndexOf(new Staff() { staff_email = str[3] } )].staff_id
            };
            List<Case> cases = omnidesk.getCases(caseParameters);

            Console.WriteLine();
        }
    }
}
