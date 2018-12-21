using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnideskSDK.Labels {
    public class LabelParameters {
        /// <summary>
        /// Хранит информацию о переменных, которые используются
        /// </summary>
        public Dictionary<string, bool> variables = new Dictionary<string, bool>() {
            {"page", false },
            {"limit", false }
        };

        private int _page;
        private int _limit;
        
        /// <summary>
        /// Номер страницы (положительное целое число)
        /// </summary>
        public int page {
            get { return _page; }
            set {
                variables["page"] = true;
                if (value > 0 && value % 1 == 0)
                    _page = value;
            }
        }
        /// <summary>
        /// Лимит сотрудников на странице (целое число от 1 до 100)
        /// </summary>
        public int limit {
            get { return _limit; }
            set {
                variables["limit"] = true;
                if (value >= 1 && value <= 100 && value % 1 == 0)
                    _limit = value;
                else throw new OmnideskException("limit: Параметр должен быть целым цислом от 1 до 100");
            }
        }
    }
}
