using System;
using System.Collections.Generic;
using System.Linq;

public class HumanTimeFormat{
  public static string formatDuration(int secs)
  {
        List<string> list = new List<string>();

        TimeSpan t = TimeSpan.FromSeconds(secs);

        int years = t.Days / 365;
        int days = t.Days % 365;
        int hours = t.Hours;
        int minutes = t.Minutes;
        int seconds = t.Seconds;

        string sYears = years > 1 ? " years" : " year";
        string sDays = days > 1 ? " days" : " day";
        string sHours = hours > 1 ? " hours" : " hour";
        string sMinutes = minutes > 1 ? " minutes" : " minute";
        string sSeconds = seconds > 1 ? " seconds" : " second";

        string sYearsVal = years > 0 ? " " + years.ToString() + sYears: "";
        list.Add(sYearsVal);
        string sDaysVal = days > 0 ? " " + days.ToString() + sDays: "";
        list.Add(sDaysVal);
        string sHoursVal = hours > 0 ? " " + hours.ToString() + sHours: "";
        list.Add(sHoursVal);
        string sMinutesVal = minutes > 0 ? " " + minutes.ToString() + sMinutes : "";
        list.Add(sMinutesVal);
        string sSecondsVal = seconds > 0 ? " " + seconds.ToString() + sSeconds : "";
        list.Add(sSecondsVal);

        list = list.Where(s => s.Length > 0).ToList();

        if (list.Count == 0) { return "now";}
        
        if (list.Count == 1) { return list.First(s => s.Length > 0).Trim();}

        return string.Join(",", list.Take(list.Count - 1)).Trim() + " and" + list.Last();
  }
}
