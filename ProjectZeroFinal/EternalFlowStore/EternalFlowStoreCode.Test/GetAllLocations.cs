using EternalFlowStore.Logic;

namespace EternalFlowStoreCode.Test
{
    internal class GetAllLocations : StoreLocation
    {
        public GetAllLocations(int Location_ID, string Location, string Country, string Address, string StateProvinceArea, string PhoneNumber, string Email) : base(Location_ID, Location, Country, Address, StateProvinceArea, PhoneNumber, Email)
        {
        }
    }
}