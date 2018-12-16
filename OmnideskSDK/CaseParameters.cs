using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnideskSDK {
    public class CaseParameters {
        /// <summary>
        /// Хранит информацию о переменных, которые используются
        /// </summary>
        public Dictionary<string, bool> variables = new Dictionary<string, bool>() {
            {"page", false },
            {"limit", false },
            {"user_id", false },
            {"user_email", false },
            {"user_phone", false },
            {"subject", false },
            {"staff_id", false },
            {"group_id", false },
            {"channel", false },
            {"priority", false },
            {"filter", false },
            {"status", false },
            {"custom_fields", false },
            {"labels", false },
            {"show_merged_cases", false },
            {"show_active_chats", false },
            {"sort", false },
            {"from_time", false },
            {"to_time", false }
        };

        private int page { get; set; }
        private int limit { get; set; }
        private int[] user_id { get; set; }
        private string[] user_email { get; set; }
        private string[] user_phone { get; set; }
        private string subject { get; set; }
        private int[] staff_id { get; set; }
        private int[] group_id { get; set; }
        private string[] channel { get; set; }
        private string[] priority { get; set; }
        private string filter { get; set; }
        private string[] status { get; set; }
        //private string[] custom_fields { get; set; }
        private int[] labels { get; set; }
        private bool show_merged_cases { get; set; }
        private bool show_active_chats { get; set; }
        private string sort { get; set; }
        private int from_time { get; set; }
        private int to_time { get; set; }

        /// <summary>
        /// Номер страницы (положительное целое число)
        /// </summary>
        public int Page {
            get { return page; }
            set {
                variables["page"] = true;
                if (value > 0 && value % 1 == 0)
                    page = value;
            }
        }
        /// <summary>
        /// Лимит обращений на странице (целое число от 1 до 100). 
        /// 
        /// Если нужно вернуть все обращения с запроса, то данный параметр не указываем.
        /// </summary>
        public int Limit {
            get { return limit; }
            set {
                variables["limit"] = true;
                if (value >= 1 && value <= 100 && value % 1 == 0)
                    limit = value;
                else throw new OmnideskException("limit: Параметр должен быть целым цислом от 1 до 100");
            }
        }
        /// <summary>
        /// ID пользователя (выборка всех обращений конкретного пользователя)
        /// </summary>
        public int[] UserId {
            get { return user_id; }
            set {
                variables["user_id"] = true;
                user_id = value;
            }
        }
        /// <summary>
        /// Поиск обращений по email-адресу пользователя (не менее 4-х символов)
        /// </summary>
        public string[] UserEmail {
            get { return user_email; }
            set {
                for (int i = 0; i < value.Length; i++)
                    if (value[i].Length < 4)
                        throw new OmnideskException("user_email: Один из email'ов имеется меньше 4 символов.");
                variables["user_email"] = true;
                user_email = value;
            }
        }
        /// <summary>
        /// Поиск обращений по номеру телефона пользователя (не менее 4-х символов)
        /// </summary>
        public string[] UserPhone {
            get { return user_phone; }
            set {
                for (int i = 0; i < value.Length; i++)
                    if (value[i].Length < 4)
                        throw new OmnideskException("user_phone: Один из номеров имеет меньше 4 символов.");
                variables["user_phone"] = true;
                user_phone = value;
            }
        }
        /// <summary>
        /// Поиск обращений по определённой теме (не менее 4-х символов)
        /// </summary>
        public string Subject {
            get { return subject; }
            set {
                if (value.Length < 4)
                    throw new OmnideskException("subject: Тема имеет меньше 4 символов.");
                variables["subject"] = true;
                subject = value;
            }
        }
        /// <summary>
        /// ID сотрудника (выборка всех обращений, в которых указанный сотрудник является ответственным).
        ///
        /// Выставите значение 0, если хотите получить список обращений без ответственного.
        /// </summary>
        public int[] StaffId {
            get { return staff_id; }
            set {
                variables["staff_id"] = true;
                staff_id = value;
            }
        }
        /// <summary>
        /// ID группы (выборка всех обращений, в которых выбрана данная группа)
        /// </summary>
        public int[] GroupId {
            get { return group_id; }
            set {
                variables["group_id"] = true;
                group_id = value;
            }
        }
        /// <summary>
        /// Канал обращения (возможные варианты: email, chat, twitter, facebook, idea,cch123)
        /// </summary>
        public string[] Channel {
            get { return channel; }
            set {
                for (int i = 0; i < value.Length; i++)
                    if (value[i] != "email" && value[i] != "chat" && value[i] != "twitter" &&
                        value[i] != "facebook" && value[i] != "idea" && value[i] != "cch123")
                        throw new OmnideskException("channel: " + value[i] + " - Канал введен не корректно.");
                variables["channel"] = true;
                channel = value;
            }
        }
        /// <summary>
        /// Приоритет обращения (возможные варианты: low, normal, high, critical)
        /// </summary>
        public string[] Priority {
            get { return priority; }
            set {
                for (int i = 0; i < value.Length; i++)
                    if (value[i] != "low" && value[i] != "normal" && value[i] != "high" && value[i] != "critical")
                        throw new OmnideskException("priority: " + value[i] + " - Приоритет введен не корректно.");
                variables["priority"] = true;
                priority = value;
            }
        }
        /// <summary>
        /// ID фильтра (выборка всех обращений, которые попадают под данный фильтр)
        /// </summary>
        public string Filter {
            get { return filter; }
            set {
                variables["filter"] = true;
                filter = value;
            }
        }
        /// <summary>
        /// Статус обращения (возможные варианты: open, waiting, closed)
        /// </summary>
        public string[] Status {
            get { return status; }
            set {
                for (int i = 0; i < value.Length; i++)
                    if (value[i] != "open" && value[i] != "waiting" && value[i] != "closed")
                        throw new OmnideskException("status: " + value[i] + " - Статус введен не корректно.");
                variables["status"] = true;
                status = value;
            }
        }
        /// <summary>
        /// Дополнительные поля данных.
        ///
        /// Фильтровать можно как по полям обращения, так и по полям пользователя.Достаточно лишь указать ID поля.
        ///
        /// В зависимости от типа поля, по которому выполняется фильтрация обращений, поиск осуществляется по-разному:
        /// - «текстовое поле» или «текстовая область» — производится поиск включения передаваемой строки;
        /// - «чекбокс» — производится поиск по наличию/отсутствию флага в зависимости от передаваемого значения;
        /// - «список» — производится поиск по ключу поиск, равному передаваемому значению.
        /// </summary>
        //public string[] CustomFields {
        //    get { return custom_fields; }
        //    set { custom_fields = value; }
        //}
        /// <summary>
        /// Метки обращений для фильтрации
        /// </summary>
        public int[] Labels {
            get { return labels; }
            set {
                variables["labels"] = true;
                labels = value;
            }
        }
        /// <summary>
        /// Отображение поглощённых обращений. По умолчанию используется значение false. Пропишите параметр со значением true, чтобы в результатах были поглощённые обращения.
        /// </summary>
        public bool ShowMergedCases {
            get { return show_merged_cases; }
            set {
                variables["show_merged_cases"] = true;
                show_merged_cases = value;
            }
        }
        /// <summary>
        /// Отображение активных чатов. По умолчанию используется значение false. Пропишите параметр со значением true, чтобы в результатах были активные чаты.
        /// </summary>
        public bool ShowActiveChats {
            get { return show_active_chats; }
            set {
                variables["show_active_chats"] = true;
                show_active_chats = value;
            }
        }
        /// <summary>
        /// - updated_at_desc — по времени последнего изменения (от новых к старым);
        /// - updated_at_asc — по времени последнего изменения(от старых к новым);
        /// - created_at_desc — по времени создания обращения(от новых к старым);
        /// - created_at_asc — по времени создания обращения(от старых к новым);
        /// - response_asc — по времени последнего ответа обращения(от старых к новым);
        /// - response_desc — по времени последнего ответа обращения(от новых к старым);
        /// - priority_desc — по приоритету обращения(критические в начале);
        /// - priority_asc — по приоритету обращения(низкие в начале);
        /// - status_asc — по статусу обращения(открытые в начале);
        /// - status_desc — по статусу обращения(закрытые в начале).
        /// </summary>
        public string Sort {
            get { return sort; }
            set {
                if (value == "update_at_desc" ||
                    value == "updated_at_asc" ||
                    value == "created_at_desc" ||
                    value == "created_at_asc" ||
                    value == "response_asc" ||
                    value == "response_desc" ||
                    value == "priority_desc" ||
                    value == "priority_asc" ||
                    value == "status_asc" ||
                    value == "status_desc"
                    ) {
                    variables["sort"] = true;
                    sort = value;
                }
                else throw new OmnideskException("sort: " + value + " - Режим сортировки введен не корректно.");
            }
        }
        /// <summary>
        /// Начало периода для фильтра по дате добавления обращения (строковое значение или timestamp)
        /// </summary>
        public int FromTime {
            get { return from_time; }
            set {
                variables["from_time"] = true;
                from_time = value;
            }
        }
        /// <summary>
        /// Конец периода для фильтра по дате добавления обращения (строковое значение или timestamp)
        /// </summary>
        public int ToTime {
            get { return to_time; }
            set {
                variables["to_time"] = true;
                to_time = value;
            }
        }
    }
}
