namespace MVCKurs.Services
{
    public interface IDateTimeService
    {
        DateTime CurrentDateTime { get; set; }  
        public string GetDateTime();
    }
}
