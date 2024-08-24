using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Domain;
using PortalLatihan.Domain.Entities;

namespace PortalLatihan.Application.Services
{
    public class InitialDataService(IUnitOfWork unitOfWork) : IInitialDataService
    {
        public async Task InitializeZoneRegionData()
        {
            var zoneData = await unitOfWork.RefZone_List();
            var regionData = await unitOfWork.RefRegion_List();

            if (zoneData.Count != 0 || regionData.Count != 0)
            {
                return;
            }

            var zoneLK = new RefZone
            {
                Code = "LK",
                Name = "Lembah Klang"
            };

            var zoneUT = new RefZone
            {
                Code = "UT",
                Name = "Utara"
            };


            var zoneSL = new RefZone
            {
                Code = "SL",
                Name = "Selatan"
            };


            var zonePT = new RefZone
            {
                Code = "PT",
                Name = "Pantai Timur"
            };


            var zoneSB = new RefZone
            {
                Code = "SB",
                Name = "Sabah"
            };

            var zoneSW = new RefZone
            {
                Code = "SW",
                Name = "Sarawak"
            };

            var regionLK1 = new RefRegion
            {
                ZoneID = zoneLK.ID,
                Code = "",
                Name = "HQ"
            };

            var regionLK2 = new RefRegion
            {
                ZoneID = zoneLK.ID,
                Code = "",
                Name = "Wisma Sawit"
            };

            var regionLK3 = new RefRegion
            {
                ZoneID = zoneLK.ID,
                Code = "",
                Name = "Wisma Dura"
            };

            var regionLK4 = new RefRegion
            {
                ZoneID = zoneLK.ID,
                Code = "",
                Name = "Wisma Oleifeira"
            };

            var regionUT1 = new RefRegion
            {
                ZoneID = zoneUT.ID,
                Code = "",
                Name = "Bagan Datuk"
            };

            var regionUT2 = new RefRegion
            {
                ZoneID = zoneUT.ID,
                Code = "",
                Name = "Pulau Pinang"
            };

            var regionSL1 = new RefRegion
            {
                ZoneID = zoneSL.ID,
                Code = "",
                Name = "Kluang"
            };

            var regionSL2 = new RefRegion
            {
                ZoneID = zoneSL.ID,
                Code = "",
                Name = "Johor Bahru"
            };

            var regionPT1 = new RefRegion
            {
                ZoneID = zonePT.ID,
                Code = "",
                Name = "Paka"
            };

            var regionPT2 = new RefRegion
            {
                ZoneID = zonePT.ID,
                Code = "",
                Name = "Penor"
            };

            var regionPT3 = new RefRegion
            {
                ZoneID = zonePT.ID,
                Code = "",
                Name = "Keratong"
            };

            var regionPT4 = new RefRegion
            {
                ZoneID = zonePT.ID,
                Code = "",
                Name = "Jerantut"
            };

            var regionPT5 = new RefRegion
            {
                ZoneID = zonePT.ID,
                Code = "",
                Name = "Kuantan"
            };

            var regionSB1 = new RefRegion
            {
                ZoneID = zoneSB.ID,
                Code = "",
                Name = "Kota Kinabalu"
            };

            var regionSB2 = new RefRegion
            {
                ZoneID = zoneSB.ID,
                Code = "",
                Name = "Lahad Datu"
            };

            var regionSW1 = new RefRegion
            {
                ZoneID = zoneSW.ID,
                Code = "",
                Name = "Kuching"
            };

            var regionSW2 = new RefRegion
            {
                ZoneID = zoneSW.ID,
                Code = "",
                Name = "Sessang"
            };

            await unitOfWork.RefZone_Add(zoneLK,"Auto");
            await unitOfWork.RefZone_Add(zoneUT,"Auto");
            await unitOfWork.RefZone_Add(zoneSL,"Auto");
            await unitOfWork.RefZone_Add(zonePT,"Auto");
            await unitOfWork.RefZone_Add(zoneSB,"Auto");
            await unitOfWork.RefZone_Add(zoneSW,"Auto");

            await unitOfWork.RefRegion_Add(regionLK1,"user");
            await unitOfWork.RefRegion_Add(regionLK2,"user");
            await unitOfWork.RefRegion_Add(regionLK3,"user");
            await unitOfWork.RefRegion_Add(regionLK4,"user");
            await unitOfWork.RefRegion_Add(regionUT1,"user");
            await unitOfWork.RefRegion_Add(regionUT2,"user");
            await unitOfWork.RefRegion_Add(regionSL1,"user");
            await unitOfWork.RefRegion_Add(regionSL2,"user");
            await unitOfWork.RefRegion_Add(regionPT1,"user");
            await unitOfWork.RefRegion_Add(regionPT2,"user");
            await unitOfWork.RefRegion_Add(regionPT3,"user");
            await unitOfWork.RefRegion_Add(regionPT4,"user");
            await unitOfWork.RefRegion_Add(regionPT5,"user");
            await unitOfWork.RefRegion_Add(regionSB1,"user");
            await unitOfWork.RefRegion_Add(regionSB2,"user");
            await unitOfWork.RefRegion_Add(regionSW1,"user");
            await unitOfWork.RefRegion_Add(regionSW2,"user");
        }

    }
}
