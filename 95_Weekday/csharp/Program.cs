using System.Globalization;
using Weekday;

Console.WriteLine("WEEKDAY".PadLeft(32));
Console.WriteLine("CREATIVE COMPUTING  MORRISTOWN, NEW JERSEY".PadLeft(15));

Console.Write(@"


WEEKDAY IS A COMPUTER DEMONSTRATION THAT
GIVES FACTS ABOUT A DATE OF INTEREST TO YOU.


");


var today = InputDate("ENTER TODAY'S DATE IN THE FORM: 3,24,1979  ");

var doi = InputDate("ENTER DAY OF BIRTH (OR OTHER DAY OF INTEREST)");


// Test for date before current calendar


// Print the day of the week the date of interest falls on
var tense = Tense(today, doi);

var dayOfWeek = doi.Day == 13 && doi.DayOfWeek == DayOfWeek.Friday
       ? "FRIDAY THE THIRTEENTH---BEWARE!"
       : $"{doi.DayOfWeek}.";

Console.WriteLine($"{doi.ToShortDateString()} {tense} a {dayOfWeek}");

if (doi >= today) 
{
    // We're done
    return;
}


// Figure out the years/months/days since the date of interest
// The original program ignores leap years and that not all months have 30/31 days

var years = today.Year - doi.Year;
var months = today.Month - doi.Month;
var days = today.Day - doi.Day;

if (days < 0) 
{
    // Drop a month and add it (as 30 days) to the days
    months -= 1;
    days += 30;
}

if (months < 0) 
{
    // Drop a year and add it (as 12 months) to the months
    years -= 1;
    months += 12;
}

if (years < 0) 
{
    return;
}

Print(" ", " ", "Years", "Months", "Days");
Print(" ", " ", "-----", "-----", "-----");
Print("YOUR AGE (IF BIRTHDATE) ", years, months, days);


// Simulate BASIC console output with 15-character zones
static void Print(params object [] args) 
{
    var output = "";
    int toNextZone = 0;

    foreach(var arg in args) 
    {
        output += new string(' ', toNextZone);
        output += arg;
        toNextZone = 15 - ((arg.ToString() ?? "").Length % 15);
    }

    Console.WriteLine(output);
}


static DateTime InputDate(string prompt)
{
    DateTime result;
    string dateInput;
    bool inputValid = true;
    do
    {
        if (!inputValid) 
        {
            Console.WriteLine("Invalid input.");
        }

        Console.WriteLine(prompt);
        dateInput = Console.ReadLine() ?? "";

        inputValid = DateTime.TryParseExact(dateInput, "M,d,yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
    }
    while (!inputValid);

    return result;
}

static string Tense(DateTime today, DateTime dayOfInterest) 
{
    if (dayOfInterest == today) 
    {
        return "is";
    }

    if (dayOfInterest > today)
    {
           return "will be";
    }

    return "was";
}