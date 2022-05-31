namespace MVCKurs.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTimeService()
        {
            CurrentDateTime = DateTime.Now;
        }

        //Parameterübergabe? 
        public DateTimeService(Action<DateTime> dateTimeOptions)
        {
            dateTimeOptions = new Action<DateTime>(SetDateTimeOptions);


        }

        public void SetDateTimeOptions(DateTime time)
            => CurrentDateTime = time;

        public DateTime CurrentDateTime { get; set; }

        public string GetDateTime()
        {
            return CurrentDateTime.ToString();
        }
    }
}
