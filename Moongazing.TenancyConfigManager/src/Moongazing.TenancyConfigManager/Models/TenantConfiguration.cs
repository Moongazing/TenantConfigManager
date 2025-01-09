namespace Moongazing.TenancyConfigManager.Models
{
    public class TenantConfiguration
    {
        public int Id { get; set; }
        public string TenantId { get; set; } = default!;
        public string Key { get; set; } = default!;
        public string Value { get; set; } = default!;
    }
}