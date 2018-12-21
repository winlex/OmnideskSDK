using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnideskSDK.Labels {
    public class Label {
        public int label_id { get; set; }
        public string label_title { get; set; }

        public override bool Equals(object obj) {
            var label = obj as Label;
            return label != null &&
                   label_title == label.label_title;
        }

        public override string ToString() {
            return "id: " + label_id + "\ntitle: " + label_title;
        }
    }
}
