using System.Text.RegularExpressions;

namespace JetSetGo.Application.Email;

public class EmailObject
{
    public string ToEmail { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string PlainTextContent { get; set; } = null!;
    public string HtmlContent { get; set; } = null!;
    public bool IsEmailAddressValid()
    {
        var patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"

                            + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"

                            + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"

                            + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"

                            + @"[a-zA-Z]{2,}))$";

        var regexStrict = new Regex(patternStrict);

        return regexStrict.IsMatch(ToEmail);
    }
    private string GetHtmlContent()
    {
        var content =
            "<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n    <meta charset=\"UTF-8\">\n    <title>Jet Set Go - Booking Deleted</title>\n    <style>\n        /* Email styling */\n        body {\n            font-family: Arial, Helvetica, sans-serif;\n            font-size: 16px;\n            line-height: 1.5;\n            color: #333;\n            background-color: #f4f4f4;\n            padding: 20px;\n        }\n        .container {\n            max-width: 600px;\n            margin: 0 auto;\n            background-color: #fff;\n            border: 1px solid #ddd;\n            border-radius: 10px;\n            overflow: hidden;\n        }\n        .header {\n            background-color: #005073;\n            color: #fff;\n            text-align: center;\n            padding: 20px;\n        }\n        .header h1 {\n            margin: 0;\n            font-size: 28px;\n            font-weight: bold;\n            text-transform: uppercase;\n            letter-spacing: 1px;\n        }\n        .content {\n            padding: 20px;\n        }\n        .message {\n            margin-bottom: 20px;\n            text-align: center;\n        }\n        .message h2 {\n            margin: 0;\n            font-size: 24px;\n            font-weight: bold;\n            text-transform: uppercase;\n            letter-spacing: 1px;\n            color: #333;\n        }\n        .message p {\n            margin: 0;\n            font-size: 18px;\n            color: #777;\n        }\n        .cta {\n            text-align: center;\n            margin-top: 20px;\n        }\n        .cta a {\n            display: inline-block;\n            padding: 10px 20px;\n            background-color: #005073;\n            color: #fff;\n            text-decoration: none;\n            border-radius: 5px;\n            transition: background-color 0.2s ease;\n        }\n        .cta a:hover {\n            background-color: #002b44;\n        }\n        /* Image styling */\n        .image {\n            text-align: center;\n        }\n        .image img {\n            max-width: 100%;\n            height: auto;\n        }\n    </style>\n</head>\n<body>\n    <div class=\"container\">\n        <div class=\"header\">\n            <h1>Jet Set Go</h1>\n        </div>\n        <div class=\"content\">\n            <div class=\"message\">\n                <h2>Booking Deleted</h2>\n                <p>We regret to inform you that your booking has been deleted.</p>\n            </div>\n            <div class=\"image\">\n                <img src=\"https://yourwebsite.com/images/deleted_booking.jpg\" alt=\"Booking Deleted\">\n            </div>\n            <div class=\"cta\">\n                <a href=\"https://yourwebsite.com/bookings\">View Other Bookings</a>\n            </div>\n        </div>\n    </div>\n</body>\n</html>";
        return content;
    }
}