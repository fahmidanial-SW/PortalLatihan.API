namespace PortalLatihan.Application.ViewModel
{
    public class ZoneDropdownResponse : BaseDropdownGuidValue
    {
        public required List<RegionDropdownResponse> Regions { get;set; }
    }
}
