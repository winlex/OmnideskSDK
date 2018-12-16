using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OmnideskSDK;
using System.IO;

namespace Test {
    class Program {
        private const string Host = "";
        private const string Username = "";
        private const string ApiKey = "";

        static void Main(string[] args) {
            string[] str;
            str = JsonConvert.DeserializeObject<string[]>(File.ReadAllText("../../env.json"));

            Omnidesk omnidesk = new Omnidesk(args[0], args[1], args[2]);

            UserParameters parameters = new UserParameters() {
                user_email = str[3]
            };
            List<User> staffs = omnidesk.GetStaff(parameters);

            CaseParameters parameters2 = new CaseParameters();
            parameters2.StaffId = new int[] {
                staffs[0].user_id
            };
            List<Case> cases = omnidesk.GetCase(parameters2);

            Console.WriteLine();
        }
    }
}
