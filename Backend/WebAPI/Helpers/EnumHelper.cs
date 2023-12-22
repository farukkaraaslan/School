namespace WebAPI.Helpers;

public class EnumHelper
{
    public enum Status
    {
        Working = 0,
        Onleave=1,
        Hospital=2,
        NewComer=3
    }

    public enum LogStatus
    {
        Archive= 0,
        Active= 1,
        Delete= 2,
        Dayly= 3,
        Weekly=5,
        Monthly=6,
        Yearly=7
    }
}
