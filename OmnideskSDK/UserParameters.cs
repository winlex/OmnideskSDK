using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnideskSDK {
    public class UserParameters {
        /// <summary>
        /// Хранит информацию о переменных, которые используются
        /// </summary>
        public Dictionary<string, bool> variables = new Dictionary<string, bool>() {
            {"page", false },
            {"limit", false },
            {"user_email", false },
            {"user_phone", false },
            {"language_id", false },
            {"custom_fiels", false },
            {"amount_of_cases", false },
        };

        private int _page;
        private int _limit;
        private string _user_email;
        private string _user_phone;
        private int _language_id;
        private string _custom_fields;
        private bool _amount_of_cases;

        /// <summary>
        /// Номер страницы (положительное целое число)
        /// </summary>
        public int page {
            get { return _page; }
            set {
                variables["page"] = true;
                _page = value;
            }
        }
        /// <summary>
        /// Лимит пользователей на странице (целое число от 1 до 100)
        /// </summary>
        public int limit {
            get { return _limit; }
            set {
                variables["limit"] = true;
                _limit = value;
            }
        }
        /// <summary>
        /// Поиск пользователей по email-адресу (не менее 3-х символов)
        /// </summary>
        public string user_email {
            get { return _user_email; }
            set {
                variables["user_email"] = true;
                _user_email = value;
            }
        }
        /// <summary>
        /// Поиск пользователей по телефону (не менее 3-х символов)
        /// </summary>
        public string user_phone {
            get { return _user_phone; }
            set {
                variables["user_phone"] = true;
                _user_phone = value;
            }
        }
        /// <summary>
        /// язык пользователя
        /// </summary>
        public int language_id {
            get { return _language_id; }
            set {
                variables["language_id"] = true;
                _language_id = value;
            }
        }
        /// <summary>
        /// Дополнительные поля данных.
        /// 
        /// В зависимости от типа поля, по которому выполняется фильтрация обращений, поиск осуществляется по-разному:
        /// 
        /// - «текстовое поле» или «текстовая область» — производится поиск включения передаваемой строки;
        /// - «чекбокс» — производится поиск по наличию/отсутствию флага в зависимости от передаваемого значения;
        /// - «список» — производится поиск по ключу поиск, равному передаваемому значению.
        /// </summary>
        public string custom_fields {
            get { return _custom_fields; }
            set {
                variables["custom_fields"] = true;
                _custom_fields = value;
            }
        }
        /// <summary>
        /// Количество обращений пользователя. Параметр может быть true или false (по умолчанию)
        /// </summary>
        public bool amount_of_cases {
            get { return _amount_of_cases; }
            set {
                variables["amount_of_cases"] = true;
                _amount_of_cases = value;
            }
        }
    }
}