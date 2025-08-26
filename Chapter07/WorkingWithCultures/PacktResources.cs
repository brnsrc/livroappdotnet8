using Microsoft.Extensions.Localization; // To use IStringLocalize and so on

namespace WorkingWithCultures
{
    public class PacktResources
    {
        private readonly IStringLocalizer<PacktResources> localizer = null!;
        public PacktResources(StringLocalizer<PacktResources> localizer)
        {
            this.localizer = localizer;
        }

        public string? GetEnterYourNamePrompt()
        {
            string resourceStringName = "EnterYourName";

            // 1. Get the LocalizedString object.
            LocalizedString localizedString = localizer[resourceStringName];

            // 2. Check if the reource string was found.
            if (localizedString.ResourceNotFound)
            {
                ConsoleColor previousColor = ForegroundColor;
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"Error: reource string \"{resourceStringName}\"not found."
                + Environment.NewLine + $"Search path: {localizedString.SearchedLocation}");
                ForegroundColor = previousColor;
                return $"{localizedString}: ";
            }

            // 3. Return the found reource string.
            return localizedString;
        }

        public string? GetEnterYourDobPrompt()
        {
            //LocalizedString has an implicit cast to string
            // that fall back to the key if the resource
            //string is not found
            return localizer["localizedString"];
        }

        public string? GetEnterYourSalaryPrompt()
        {
            return localizer["EnterYorSalary"];
        }

        public string? GetPersonDetails(string name, DateTime dob, int minutes, decimal salary)
        {
            return localizer["PersonDetails", name, dob, minutes, salary];
        }
    }
}