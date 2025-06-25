using System.ComponentModel.DataAnnotations;


namespace ISP.Models
{
    public class PassengerCard : BaseCard
    {


        public PassengerCard() : base(cardType: "КНП")
        {
            //CardName = $"{CreationDate.ToShortDateString()}_{CardType}_{ShortName}";
        }


        //Наименование подрядной организации:
        [Required(ErrorMessage = "Укажите название организации")]
        public string NameOfOrganization { get; set; } = "";

        //Номер транспортного средства
        private string numberOfAuto = "";

        [Required(ErrorMessage = "Укажите гос. номер автомобиля")]
        [RegularExpression(@"[A-Za-zА-Яа-я]{1}" + " " + @"[0-9]{3}" + " " + @"[A-Za-zА-Яа-я]{2}" + " " + @"[0-9]{2,3}", ErrorMessage = "Гос. номер должен иметь формат: A 111 AA 111")]
        public string NumberOfAuto { get => numberOfAuto.ToUpper(); set => numberOfAuto = value.ToUpper(); }

        //Тип авто в таблице просто чек боксы
        public string TypeOfAuto { get; set; } = "0";


        #region Осмотр ТС
        //Наличие в ТС аварийного комплекта
        public bool EmergencyKit { get; set; } = true;

        //Наличие в БСМТС
        public bool MonitoringSystem { get; set; } = true;

        //Наличие посторонних предметов в зоне обзора водителя
        public bool ForeignObjects { get; set; } = true;

        //Наличие плана поездки
        public bool RoutePassport { get; set; } = true;

        //Наличие паспорта автобусного маршрута
        public bool BusPassport { get; set; } = true;

        //Водитель и пассажир пристёгнуты ремнями
        public bool SeatBeltsFastened { get; set; } = true;

        //Груз зафиксирован
        public bool CargoFixed { get; set; } = true;
        #endregion


        //Безопасное перестроение из ряда в ряд
        public bool SafeLaneChange { get; set; } = true;

        //Соблюдает безопасную дистанцию
        public bool KeepingDistance { get; set; } = true;

        //Не превышает установленную скорость
        public bool SpeedLimit { get; set; } = true;

        //Демонстрирует безопасное поведение
        public bool SafeBehavior { get; set; } = true;

        //Не пользуется мобильным телефоном
        public bool NoCell { get; set; } = true;

        //Контролирует ТС на дороге и в плотном транспортном потоке
        public bool ControlOfAuto { get; set; } = true;

        //Не принимает пищу за рулем
        public bool NotEat { get; set; } = true;

        //Учитывает дорожные условия
        public bool UnderstandsRoadConditions { get; set; } = true;

        //Выполняет требования дорожных знаков разметки и светофоров
        public bool RoadSignRequirements { get; set; } = true;

        //Своевременно включает световые приборы и сигналы поворота
        public bool TimelyTurnOffTheLights { get; set; } = true;

        //Внимательно относится к пешеходам
        public bool AttentionToPedestrians { get; set; } = true;

        //Уступает движущемся транспортным средствам
        public bool GiveWay { get; set; } = true;

        //Безопасно управляет Т/C задним ходом
        public bool AutoSafelyInReverse { get; set; } = true;

        //При остановке использует ручной тормоз
        public bool HandbrakeUsing { get; set; } = true;

        //Соблюдает режим труда и отдыха
        public bool RestRegime { get; set; } = true;



        //Темное время суток
        public bool Night { get; set; }

        //ясно
        public bool Clear { get; set; }

        //солнечно
        public bool Sun { get; set; }

        //облачно
        public bool Cloud { get; set; }

        //дождь
        public bool Rain { get; set; }

        //дождь/град
        public bool RainHail { get; set; }

        //снег
        public bool Snow { get; set; }



        //асфальт
        public bool Asphalt { get; set; }

        //гололед
        public bool Ice { get; set; }

        //гравийное
        public bool Gravel { get; set; }

        //бездорожье
        public bool OffRoad { get; set; }

        //грунтовое
        public bool Ground { get; set; }

        //грязь
        public bool Dirt { get; set; }



        //Было выявлено нарушение?
        public bool ViolationDetected { get; set; }
        //Работа остановлена?
        public bool WorkStopped { get; set; }


        //Комментарий пассажира
        //[MinLength(2, ErrorMessage = "Заполните комментарий пассажира")]
        public string PassengerComment { get; set; } = string.Empty;


        //Незамедлительные действия
        [MinLength(2, ErrorMessage = "Заполните незамедлительные мероприятия")]
        public string Actions { get; set; } = "";

        //Заключительные мероприятия
        [MinLength(2, ErrorMessage = "Заполните заключительные мероприятия")]
        public string? FinalActions { get; set; } = "";

        //Ответственный
        [MinLength(2, ErrorMessage = "Укажите ответственного")]
        public string Responsible { get; set; } = "";

        //Срок исполнения

        public DateTime? Deadline { get; set; }
    }
}
