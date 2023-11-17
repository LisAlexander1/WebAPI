namespace RandomDateLib;

public class RandomDate
{
    public static DateTime GetRandomDay(int startYear = 1)
    {
        Random gen = new Random();
        DateTime start = new DateTime(startYear, 1, 1);
        int range = (DateTime.Today - start).Days;           
        return start.AddDays(gen.Next(range));
    }
}