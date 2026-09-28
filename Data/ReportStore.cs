using EvolveDataBank.Models;

namespace EvolveDataBank.Data;

/// <summary>In-memory data taken from evolvedatabank.com. Registered as a singleton in Program.cs.</summary>
public class ReportStore
{
    public const string ColdChainSlug = "cold-chain-market-analysis";
    public const int TableUnlockPrice = 99;

    public IReadOnlyList<IndustryGroup> Industries { get; }
    public IReadOnlyList<ReportSummary> Reports { get; }
    public IReadOnlyList<PriceOption> Prices { get; }
    public ReportDetail ColdChain { get; }

    public int TotalCategories => Industries.Sum(i => i.Categories.Count);

    private static Category C(string name, int id) => new(name, id);

    public ReportStore()
    {
        Industries = new[]
        {
            new IndustryGroup("Automotive and Transportation", "automotive", new[] {
                C("Technology", 1), C("Automotive Components & Materials", 31), C("Automotive Systems & Accessories", 42),
                C("Vehicle Safety and Security", 43), C("On-Highway and Off-Highway Vehicles", 44), C("Transportation", 45) }),
            new IndustryGroup("Chemical and Materials", "chemicals", new[] {
                C("Bulk Chemicals", 47), C("Specialty Chemicals", 48), C("Coatings & Adhesives", 49), C("Ceramics & Glass", 50),
                C("Textile", 51), C("Advanced Materials", 52), C("Composites", 53) }),
            new IndustryGroup("Aerospace and Defence", "aerospace", new[] {
                C("Marine", 3), C("Security", 13), C("Aviation", 36), C("Defence Platforms and Systems", 37),
                C("Unmanned Systems", 38), C("Space Technology", 39) }),
            new IndustryGroup("Construction And Manufacturing", "construction", new[] {
                C("Industrial Equipment", 29), C("Construction Equipment", 32), C("Manufacturing Technology", 35),
                C("Building & Construction Materials", 54), C("Construction Technology and Sustainability", 55),
                C("Analytical and Scientific Instrumentation", 56), C("Packaging", 57), C("Mining", 84) }),
            new IndustryGroup("Electronics and Semiconductor", "electronics", new[] {
                C("Display Technology", 17), C("Sensor and Control", 21), C("Semiconductor Materials and Components", 58),
                C("Electronics Systems and Components", 59), C("Optoelectronics", 60), C("Security and Surveillance", 61),
                C("Communication and Connectivity Technology", 62), C("Battery and Wireless Charging", 63) }),
            new IndustryGroup("Life Science", "life-science", new[] {
                C("Medical Devices", 22), C("Pharmaceuticals", 25), C("Biotechnology", 64), C("Healthcare IT", 65), C("Therapeutics", 66) }),
            new IndustryGroup("Consumer Goods & Retail", "consumer", new[] {
                C("Electronic & Electrical", 23), C("Beauty & Personal Care", 67), C("Clothing & Accessories", 68),
                C("Homecare & Decor", 69), C("Household Appliances", 70), C("Travel & Tourism", 85) }),
            new IndustryGroup("BFSI", "bfsi", new[] {
                C("Insurance", 26), C("Banking", 40), C("Financial Services", 41) }),
            new IndustryGroup("Food & Beverages", "food", new[] {
                C("Food", 27), C("Food Services & Hospitality", 71), C("Additives & Supplements", 72),
                C("Agriculture & Agri Products", 73), C("Beverages", 74) }),
            new IndustryGroup("Information & Communication Technology", "ict", new[] {
                C("Software and Services", 28), C("Analytics", 30), C("AI & IoT", 34), C("Data Center & Cloud Computing", 75),
                C("Telecom", 76), C("Information Security", 77) }),
            new IndustryGroup("Energy & Power", "energy", new[] {
                C("Well Intervention", 33), C("Non-Renewable / Conventional Energy", 78), C("Clean & Renewable Energy", 79),
                C("Transmission and Distribution (T&D)", 80), C("Pumps, Motors, and Control Devices", 81),
                C("Drilling Equipment & Services", 82), C("Offshore Oil & Gas", 83) }),
        };

        Reports = new[]
        {
            new ReportSummary("Testing, Inspection, and Certification (TIC)", "testing-inspection-certification-market-analysis"),
            new ReportSummary("Cold Chain", ColdChainSlug),
            new ReportSummary("Automotive Cyber Security", "automotive-cyber-security-market-analysis"),
            new ReportSummary("Agriculture Tires", "agriculture-tires-market-analysis"),
            new ReportSummary("Decentralized Energy Resources", "decentralized-energy-resources-market-analysis"),
            new ReportSummary("Vertical Farming", "vertical-farming-market-analysis"),
            new ReportSummary("Energy Transition", "energy-transition-market-analysis"),
            new ReportSummary("Smart Grid", "smart-grid-market-analysis"),
            new ReportSummary("Autonomous Drilling System", "autonomous-drilling-system-market-analysis"),
            new ReportSummary("Advanced Materials in Aerospace and Defence", "advance-materials-in-aerospace-and-defence-market-analysis"),
        };

        // Prices are from the cold chain report page. CONFIRM licence wording with the client.
        Prices = new[]
        {
            new PriceOption("Single Use", 3470, "Single", "Full report for one purchaser."),
            new PriceOption("Enterprise License", 5520, "Enterprise", "Full report licensed for organisation-wide use."),
            new PriceOption("Data Pack Excel", 1390, "DataPack", "The report's market data in Excel format."),
        };

        var geography = new[]
        {
            new GeoRegion("North America", new[] { "US", "Canada", "Mexico" }),
            new GeoRegion("Europe", new[] { "UK", "Germany", "France", "Italy", "Spain", "BeNeLux", "Russia", "Nordic", "Rest of Europe" }),
            new GeoRegion("Asia Pacific", new[] { "China", "India", "Japan", "South Korea", "Thailand", "Australia", "Philippines", "Rest of Asia Pacific" }),
            new GeoRegion("South America", new[] { "Brazil", "Argentina", "Rest of South America" }),
            new GeoRegion("Middle East & Africa", new[] { "Saudi Arabia", "UAE", "Israel", "South Africa", "Rest of Middle East & Africa" }),
        };

        var coverage = new List<CoverageRow> { new("Global", true, true) };
        foreach (var g in geography)
        {
            coverage.Add(new CoverageRow(g.Region, true, true));
            coverage.AddRange(g.Countries.Select(c => new CoverageRow(c, false, false)));
        }

        ColdChain = new ReportDetail
        {
            Title = "Global Cold Chain Market: Trends & Forecast to 2036",
            Slug = ColdChainSlug,
            Code = "EBI2000231",
            Published = "June 2026",
            BreadcrumbTrail = new[] { "Automotive & Transportation", "Transportation" },
            ScopeLine = "Segmented by technology, type, temperature and application, and by geography. Opportunities, trends and forecast from 2024 to 2036.",
            Size2025 = 365.29,
            Size2036 = 2030.82,
            Cagr = 16.15,
            KeyFacts = new[]
            {
                new LabelValue("Largest type (2025)", "Cold chain storage & infrastructure"),
                new LabelValue("Leading application", "Food & beverage, projected CAGR above 16%. Pharmaceutical is growing at about 15%."),
                new LabelValue("Largest temperature segment", "Chilled"),
                new LabelValue("Largest technology", "Vapor compression, projected CAGR around 17%. Blast freezing is also expanding quickly."),
                new LabelValue("Largest and fastest-growing region", "Asia Pacific"),
                new LabelValue("Fastest-growing major country", "India. China was valued at about USD 27.00 billion in 2025."),
            },
            DriverParagraphs = new[]
            {
                "Demand comes mainly from food and pharmaceutical supply chains, where products must stay within a temperature range from storage through last-mile delivery. Growth in fresh and frozen food, biologics, vaccines and specialty medicines all raise the need for validated cold storage and monitored transport.",
                "Four trends stand out: real-time visibility through IoT sensors and GPS tracking, automation in cold storage (for example, Noatum Logistics opened a robotically assisted facility in Lisbon in May 2025), investment in energy-efficient and lower-emission refrigeration, and closer integration between producers, retailers, logistics providers and technology firms. In 2025, Cold Chain Technologies acquired Global Cold Chain Solutions to strengthen its Asia Pacific presence.",
            },
            Companies = new[]
            {
                "Americold Realty Trust", "Lineage", "DHL Supply Chain", "Maersk", "Kuehne+Nagel", "UPS", "FedEx",
                "Carrier Global", "Daikin Industries", "Thermo King", "Cold Chain Technologies",
            },
            Takeaway = "The market is entering a high-growth phase. Operators that pair reliable temperature-controlled capacity with monitoring technology, sustainability and integrated logistics are best placed through 2036.",
            ScopeRows = new[]
            {
                new LabelList("Technology", new[] { "Blast Freezing", "Vapor Compression", "Evaporative Cooling", "Cryogenic Cooling Systems", "Other Technologies" }),
                new LabelList("Type", new[] { "Cold Chain Storage & Infrastructure", "Refrigerated Transportation Services", "Other Services" }),
                new LabelList("Temperature", new[] { "Chilled", "Frozen", "Deep Frozen" }),
                new LabelList("Application", new[] { "Food & Beverage", "Pharmaceutical", "Other Applications" }),
            },
            Geography = geography,
            Coverage = coverage,
            Related = new[]
            {
                new RelatedReport("Global Third-Party Logistics Market", $"{Site.LiveBase}/ProductMaster/ProductDataDisplay/third-party-logistics-market-analysis", "Trends & Forecast to 2034"),
                new RelatedReport("Global Omnichannel Logistics Market", $"{Site.LiveBase}/ProductMaster/ProductDataDisplay/omnichannel-logistics-market-analysis", "Trends & Forecast to 2034"),
            },
        };
    }
}
