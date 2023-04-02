using System.Globalization;

namespace JetSetGo.Application.Converters;

public class DateConverter
{
    public DateOnly? Convert(string date)
    {
        if (DateOnly.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateOnly dateConverted))
        {
            return dateConverted;
        }

        return null;
    }
}