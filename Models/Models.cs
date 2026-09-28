using System.Globalization;

namespace EvolveDataBank.Models;

public static class Site
{
    public const string LiveBase = "https://evolvedatabank.com";
    // Copy the logo into wwwroot/images and point this at "~/images/..." before deploying.
    public const string LogoUrl = LiveBase + "/images/evolve%20business%20intelligence%20logo.jpeg";
}

public record Category(string Name, int Id);

public record IndustryGroup(string Name, string Anchor, IReadOnlyList<Category> Categories);

public record ReportSummary(string Market, string Slug)
{
    public string Title => $"Global {Market} Market";
}

public record PriceOption(string Name, int Price, string RateType, string Description);

public record LabelValue(string Label, string Value);

public record LabelList(string Label, IReadOnlyList<string> Items);

public record GeoRegion(string Region, IReadOnlyList<string> Countries);

public record CoverageRow(string Name, bool IsRegion, bool HasRegionOrCountryCut);

public record RelatedReport(string Title, string Url, string Meta);

public class ReportDetail
{
    public string Title { get; init; } = "";
    public string Slug { get; init; } = "";
    public string Code { get; init; } = "";
    public string Published { get; init; } = "";
    public IReadOnlyList<string> BreadcrumbTrail { get; init; } = Array.Empty<string>();
    public string ScopeLine { get; init; } = "";

    public double Size2025 { get; init; }
    public double Size2036 { get; init; }
    public double Cagr { get; init; }

    public IReadOnlyList<LabelValue> KeyFacts { get; init; } = Array.Empty<LabelValue>();
    public IReadOnlyList<string> DriverParagraphs { get; init; } = Array.Empty<string>();
    public IReadOnlyList<string> Companies { get; init; } = Array.Empty<string>();
    public string Takeaway { get; init; } = "";

    public IReadOnlyList<LabelList> ScopeRows { get; init; } = Array.Empty<LabelList>();
    public IReadOnlyList<GeoRegion> Geography { get; init; } = Array.Empty<GeoRegion>();
    public IReadOnlyList<CoverageRow> Coverage { get; init; } = Array.Empty<CoverageRow>();
    public IReadOnlyList<RelatedReport> Related { get; init; } = Array.Empty<RelatedReport>();

    // Each region row has 5 tables (country/region cut + 4 splits); each country row has 4.
    public int TableCount => Coverage.Sum(r => r.HasRegionOrCountryCut ? 5 : 4);

    public string Size2025Text => Size2025.ToString("N2", CultureInfo.InvariantCulture);
    public string Size2036Text => Size2036.ToString("N2", CultureInfo.InvariantCulture);
    public string CagrText => Cagr.ToString("0.##", CultureInfo.InvariantCulture);
    public string BarNowPercent => (Size2025 / Size2036 * 100).ToString("0.00", CultureInfo.InvariantCulture);
    public string GrowthMultiple => (Size2036 / Size2025).ToString("0.0", CultureInfo.InvariantCulture);
}
