using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZMS.Domain.Equipment;

namespace ZMS.Data.Equipment
{
    public class InMemoryGearData : IGearData
    {
        // constructor at the bottom (lots of info) 
        readonly List<Gear> equipment;
        readonly List<GearInspection> gearInspections;
        public Gear AddGear(Gear newGear)
        {
            equipment.Add(newGear);
            newGear.Id = equipment.Max(g => g.Id) + 1;
            return newGear;
        }

        public GearInspection AddInspection(GearInspection newInspection)
        {
            gearInspections.Add(newInspection);
            newInspection.Id = gearInspections.Max(i => i.Id) + 1;
            return newInspection;
        }

        public int Commit()
        {
            return 0;
        }

        public Gear DeleteGear(int id)
        {
            var gear = equipment.FirstOrDefault(g => g.Id == id);
            if (gear != null)
            {
                equipment.Remove(gear);
            }
            return gear;
        }

        public GearInspection DeleteInspection(int id)
        {
            var inspection = gearInspections.FirstOrDefault(i => i.Id == id);
            if (inspection != null)
            {
                gearInspections.Remove(inspection);
            }
            return inspection;
        }

        public IEnumerable<Gear> GetAllEquipment()
        {
            return from g in equipment
                   orderby g.GearType
                   select g;
        }

        /*public IEnumerable<Gear> GetByGearType(string type = null)
        {
            Enum.TryParse(type, out GearType e);
            return from g in equipment
                   where string.IsNullOrEmpty(type) || g.GearType == e && g.Status == GearStatus.Good
                   orderby g.Location
                   select g;
        }*/

        public Gear GetGearById(int id)
        {
            return equipment.SingleOrDefault(g => g.Id == id);
        }

        public GearInspection GetInspectionById(int id)
        {
            return gearInspections.SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<GearInspection> GetInspections(int id)
        {
            return from i in gearInspections
                   where i.LabelNumber == id
                   orderby i.Date
                   select i;
        }

        public Gear UpdateGear(Gear updatedGear)
        {
            var gear = equipment.SingleOrDefault(gear => gear.Id == updatedGear.Id);
            if (gear != null)
            {
                gear.DateOfFirstUse = updatedGear.DateOfFirstUse;
                gear.GearModel = updatedGear.GearModel;
                gear.GearType = updatedGear.GearType;
                gear.GuideAssigned = updatedGear.GuideAssigned;
                gear.GuideEquipment = updatedGear.GuideEquipment;
                gear.Inspections = updatedGear.Inspections;
                gear.LabelNumber = updatedGear.LabelNumber;
                gear.Location = updatedGear.Location;
                gear.Manufacturer = updatedGear.Manufacturer;
                gear.Notes = updatedGear.Notes;
                gear.RescueGear = updatedGear.RescueGear;
                gear.SerialNumber = updatedGear.SerialNumber;
                gear.Size = updatedGear.Size;
                gear.Status = updatedGear.Status;
            }
            return gear;
        }

        public GearInspection UpdateInspection(GearInspection updatedInspection)
        {
            var inspection = gearInspections.SingleOrDefault(c => c.Id == updatedInspection.Id);
            {
                inspection.Date = updatedInspection.Date;
                inspection.Gear = updatedInspection.Gear;
                inspection.GearType = updatedInspection.GearType;
                inspection.Inspector = updatedInspection.Inspector;
                inspection.LabelNumber = updatedInspection.LabelNumber;
                inspection.Summary = updatedInspection.Summary;
            }
            return inspection;
        }
        public InMemoryGearData()
        {
            gearInspections = new List<GearInspection>
            {
                new GearInspection {Id = 1, GearType = GearType.Harness, Date = DateTime.Parse("06/24/2020"), Summary="Good", Inspector = "Mitchell", LabelNumber = 1},
                new GearInspection {Id = 2, GearType = GearType.Helmet, Date = DateTime.Parse("06/24/2020"), Summary="ok", Inspector = "Mitchell", LabelNumber = 7},
                new GearInspection {Id = 3, GearType = GearType.Trolley, Date = DateTime.Parse("06/24/2020"), Summary="small knicks but it's good", Inspector = "Mitchell", LabelNumber = 14},
                new GearInspection {Id = 4, GearType = GearType.Harness, Date = DateTime.Parse("06/24/2020"), Summary="yea i wouldn't use that but whatever it's good", Inspector = "Mitchell", LabelNumber = 1},
                new GearInspection {Id = 5, GearType = GearType.Lanyard, Date = DateTime.Parse("06/24/2020"), Summary="borderline not safe", Inspector = "Mitchell", LabelNumber = 19},
                new GearInspection {Id = 6, GearType = GearType.Carabiner, Date = DateTime.Parse("06/24/2020"), Summary="I won't be using it so it's good", Inspector = "Mitchell", LabelNumber = 27},
                new GearInspection {Id = 7, GearType = GearType.Radio, Date = DateTime.Parse("06/24/2020"), Summary="looks brand new", Inspector = "Mitchell", LabelNumber = 43}
            };
            equipment = new List<Gear>
            {
                //Harnesses
            new Gear { Id = 1, LabelNumber = 1, SerialNumber = "Abcdefg1234", GearType = GearType.Harness, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "French Creek", GearModel = "H-4043", Size = "Regular", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = ""},
            new Gear { Id = 2, LabelNumber = 2, SerialNumber = "Hijklmno5678", GearType = GearType.Harness, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "French Creek", GearModel = "H-4043", Size = "Regular", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Guide_Cubby, GuideEquipment = true, GuideAssigned = "Mitchell" },
            new Gear { Id = 3, LabelNumber = 3, SerialNumber = "Abcdeg1234", GearType = GearType.Harness, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "French Creek", GearModel = "H-4043", Size = "Regular", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 4, LabelNumber = 4, SerialNumber = "Hiklmno5678", GearType = GearType.Harness, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "French Creek", GearModel = "H-4042", Size = "Small", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 5, LabelNumber = 5, SerialNumber = "Abcdefg234", GearType = GearType.Harness, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "French Creek", GearModel = "H-4044", Size = "Large", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 6, LabelNumber = 6, SerialNumber = "Hijklno5678", GearType = GearType.Harness, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "French Creek", GearModel = "H-4044", Size = "Large", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = "" },
            // Helmets
            new Gear { Id = 7, LabelNumber = 1, SerialNumber = "Abcdefg1234", GearType = GearType.Helmet, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Petzl", GearModel = "Panga", Size = "", Notes = "", RescueGear = false, Status = GearStatus.NeedsAttention, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = ""},
            new Gear { Id = 8, LabelNumber = 2, SerialNumber = "Hijklmno5678", GearType = GearType.Helmet, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Petzl", GearModel = "Panga", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 9, LabelNumber = 3, SerialNumber = "Abcdeg1234", GearType = GearType.Helmet, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Petzl", GearModel = "Panga", Size = "", Notes = "Headband was replaced", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 10, LabelNumber = 4, SerialNumber = "Hiklmno5678", GearType = GearType.Helmet, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Petzl", GearModel = "Panga", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 11, LabelNumber = 5, SerialNumber = "Abcdefg234", GearType = GearType.Helmet, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Petzl", GearModel = "Vertex", Size = "Regular", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Guide_Cubby, GuideEquipment = true, GuideAssigned = "Mitchell" },
            new Gear { Id = 12, LabelNumber = 6, SerialNumber = "Hijklno5678", GearType = GearType.Helmet, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Petzl", GearModel = "Vertex", Size = "Large", Notes = "", RescueGear = false, Status = GearStatus.Retired, Location = GearLocation.StorageChalet, GuideEquipment = true, GuideAssigned = "" },
            //Trolleys
            new Gear { Id = 13, LabelNumber = 1, SerialNumber = "Abcdefg1234", GearType = GearType.Trolley, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Petzl", GearModel = "Tandem Speed", Size = "", Notes = "Used for Rope Tow on platform 2", RescueGear = true, Status = GearStatus.Good, Location = GearLocation.P2, GuideEquipment = false, GuideAssigned = ""},
            new Gear { Id = 14, LabelNumber = 2, SerialNumber = "Hijklmno5678", GearType = GearType.Trolley, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Petzl", GearModel = "Trac Plus", Size = "", Notes = "", RescueGear = true, Status = GearStatus.Good, Location = GearLocation.T2, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 15, LabelNumber = 3, SerialNumber = "Abcdeg1234", GearType = GearType.Trolley, DateOfFirstUse = DateTime.Parse("06/01/2017"), Manufacturer = "Petzl", GearModel = "Trac Plus", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Guide_Cubby, GuideEquipment = true, GuideAssigned = "Mitchell" },
            new Gear { Id = 16, LabelNumber = 4, SerialNumber = "Hiklmno5678", GearType = GearType.Trolley, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Petzl", GearModel = "Trac Plus", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 17, LabelNumber = 5, SerialNumber = "Abcdefg234", GearType = GearType.Trolley, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Petzl", GearModel = "Trac Plus", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Guide_Cubby, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 18, LabelNumber = 6, SerialNumber = "Hijklno5678", GearType = GearType.Trolley, DateOfFirstUse = DateTime.Parse("07/04/2019"), Manufacturer = "Petzl", GearModel = "Trac Plus", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Retired, Location = GearLocation.StorageChalet, GuideEquipment = true, GuideAssigned = "" },
            //Lanyards
            new Gear { Id = 19, LabelNumber = 1, SerialNumber = "Abcdefg1234", GearType = GearType.Lanyard, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Petzl", GearModel = "Unadjustable", Size = "", Notes = "", RescueGear = false, Status = GearStatus.NeedsAttention, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = ""},
            new Gear { Id = 20, LabelNumber = 2, SerialNumber = "Hijklmno5678", GearType = GearType.Lanyard, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Misty Mountain", GearModel = "Unadjustable", Size = "", Notes = "Carabiner is rusted through", RescueGear = false, Status = GearStatus.Retired, Location = GearLocation.StorageUnit, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 21, LabelNumber = 3, SerialNumber = "Abcdeg1234", GearType = GearType.Lanyard, DateOfFirstUse = DateTime.Parse("06/01/2018"), Manufacturer = "Misty Mountain", GearModel = "Adjustable", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Guide_Cubby, GuideEquipment = true, GuideAssigned = "Mitchell" },
            new Gear { Id = 22, LabelNumber = 4, SerialNumber = "Hiklmno5678", GearType = GearType.Lanyard, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Misty Mountain", GearModel = "Unadjustable", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 23, LabelNumber = 5, SerialNumber = "Abcdefg234", GearType = GearType.Lanyard, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Misty Mountain", GearModel = "Unadjustable", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Guide_Cubby, GuideEquipment = true, GuideAssigned = "" },
            new Gear { Id = 24, LabelNumber = 6, SerialNumber = "Hijklno5678", GearType = GearType.Lanyard, DateOfFirstUse = DateTime.Parse("07/04/2016"), Manufacturer = "Misty Mountain", GearModel = "Adjustable", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.StorageChalet, GuideEquipment = true, GuideAssigned = "" },
            //Carabiners
            new Gear { Id = 25, LabelNumber = 1, SerialNumber = "", GearType = GearType.Carabiner, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Omega", GearModel = "Jake", Size = "Aluminum", Notes = "", RescueGear = false, Status = GearStatus.NeedsAttention, Location = GearLocation.Guide_Cubby, GuideEquipment = true, GuideAssigned = ""},
            new Gear { Id = 26, LabelNumber = 2, SerialNumber = "", GearType = GearType.Lanyard, DateOfFirstUse = DateTime.Parse("06/01/2016"), Manufacturer = "Omega", GearModel = "Jake", Size = "Aluminum", Notes = "Carabiner is rusted through", RescueGear = false, Status = GearStatus.Retired, Location = GearLocation.StorageUnit, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 27, LabelNumber = 3, SerialNumber = "", GearType = GearType.Carabiner, DateOfFirstUse = DateTime.Parse("05/01/2018"), Manufacturer = "Omega", GearModel = "Jake", Size = "Aluminum", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 28, LabelNumber = 4, SerialNumber = "", GearType = GearType.Carabiner, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Kong", GearModel = "Steel D", Size = "Steel", Notes = "", RescueGear = true, Status = GearStatus.Good, Location = GearLocation.T5, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 29, LabelNumber = 5, SerialNumber = "", GearType = GearType.Carabiner, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "CSI", GearModel = "Triple Locker with Pin", Size = "Aluminum", Notes = "This is the carabiner on the powerfan", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.T6, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 30, LabelNumber = 6, SerialNumber = "", GearType = GearType.Carabiner, DateOfFirstUse = DateTime.Parse("07/04/2016"), Manufacturer = "Liberty Mountain", GearModel = "Oval", Size = "Aluminum", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.StorageChalet, GuideEquipment = true, GuideAssigned = "" },
            //Zip Tethers
            new Gear { Id = 31, LabelNumber = 1, SerialNumber = "", GearType = GearType.Zip_Tether, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Misty Mountain", GearModel = "", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Guide_Cubby, GuideEquipment = true, GuideAssigned = "Mitchell"},
            new Gear { Id = 32, LabelNumber = 2, SerialNumber = "", GearType = GearType.Zip_Tether, DateOfFirstUse = DateTime.Parse("06/01/2016"), Manufacturer = "Misty Mountain", GearModel = "", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Retired, Location = GearLocation.StorageUnit, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 33, LabelNumber = 3, SerialNumber = "", GearType = GearType.Zip_Tether, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Misty Mountain", GearModel = "", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 34, LabelNumber = 4, SerialNumber = "", GearType = GearType.Zip_Tether, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Misty Mountain", GearModel = "", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Gear_Cube, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 35, LabelNumber = 5, SerialNumber = "", GearType = GearType.Zip_Tether, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Misty Mountain", GearModel = "", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.T6, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 36, LabelNumber = 6, SerialNumber = "", GearType = GearType.Zip_Tether, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Misty Mountain", GearModel = "", Size = "", Notes = "", RescueGear = false, Status = GearStatus.NeedsAttention, Location = GearLocation.StorageChalet, GuideEquipment = false, GuideAssigned = "" },
            //Gloves
            new Gear { Id = 37, LabelNumber = 1, SerialNumber = "", GearType = GearType.Zip_Tether, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Rocks Edge", GearModel = "Client Gloves", Size = "XS", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.StorageChalet, GuideEquipment = true, GuideAssigned = ""},
            new Gear { Id = 38, LabelNumber = 2, SerialNumber = "", GearType = GearType.Zip_Tether, DateOfFirstUse = DateTime.Parse("06/01/2016"), Manufacturer = "Rocks Edge", GearModel = "Client Gloves", Size = "S", Notes = "", RescueGear = false, Status = GearStatus.Retired, Location = GearLocation.StorageUnit, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 39, LabelNumber = 3, SerialNumber = "", GearType = GearType.Zip_Tether, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Rocks Edge", GearModel = "Client Gloves", Size = "M", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.StorageChalet, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 40, LabelNumber = 4, SerialNumber = "", GearType = GearType.Zip_Tether, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Rocks Edge", GearModel = "Client Gloves", Size = "L", Notes = "", RescueGear = true, Status = GearStatus.Good, Location = GearLocation.T5, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 41, LabelNumber = 5, SerialNumber = "", GearType = GearType.Zip_Tether, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Rocks Edge", GearModel = "Full Finger Guide Gloves", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Guide_Cubby, GuideEquipment = true, GuideAssigned = "Mitchell" },
            new Gear { Id = 42, LabelNumber = 6, SerialNumber = "", GearType = GearType.Zip_Tether, DateOfFirstUse = DateTime.Parse("05/01/2016"), Manufacturer = "Rocks Edge", GearModel = "Adventure Park Gloves (red)", Size = "", Notes = "", RescueGear = false, Status = GearStatus.NeedsAttention, Location = GearLocation.Office, GuideEquipment = true, GuideAssigned = "" },
            //Radios
            new Gear { Id = 43, LabelNumber = 1, SerialNumber = "Abcdefg1234", GearType = GearType.Radio, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "ChineseCompany", GearModel = "Garbage", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.StorageChalet, GuideEquipment = true, GuideAssigned = "" },
            new Gear { Id = 44, LabelNumber = 2, SerialNumber = "Bcdefg12345", GearType = GearType.Radio, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "ChineseCompany", GearModel = "Garbage", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.StorageChalet, GuideEquipment = true, GuideAssigned = "" },
            new Gear { Id = 45, LabelNumber = 3, SerialNumber = "Cdefg1234ab", GearType = GearType.Radio, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "ChineseCompany", GearModel = "Garbage", Size = "", Notes = "Clip broke off, needs replacing", RescueGear = false, Status = GearStatus.NeedsAttention, Location = GearLocation.Office, GuideEquipment = true, GuideAssigned = "Ground Support" },
            //Radio Harnesses
            new Gear { Id = 46, LabelNumber = 1, SerialNumber = "Abcdefg1234", GearType = GearType.Radio_Harness, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "RadioUSA", GearModel = "HolsterForYourShoulster", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.StorageChalet, GuideEquipment = true, GuideAssigned = "Mitchell" },
            new Gear { Id = 47, LabelNumber = 2, SerialNumber = "Bcdefg12345", GearType = GearType.Radio_Harness, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "RadioUSA", GearModel = "HolsterForYourShoulster", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.StorageChalet, GuideEquipment = true, GuideAssigned = "" },
            new Gear { Id = 48, LabelNumber = 3, SerialNumber = "Cdefg1234ab", GearType = GearType.Radio_Harness, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "RadioUSA", GearModel = "HolsterForYourShoulster", Size = "", Notes = "strap broke off, needs replacing", RescueGear = false, Status = GearStatus.NeedsAttention, Location = GearLocation.Office, GuideEquipment = true, GuideAssigned = "" },
            //Cameras
            new Gear { Id = 49, LabelNumber = 1, SerialNumber = "Abcdefg1234", GearType = GearType.Camera, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "GoPro", GearModel = "Hero 4", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Office, GuideEquipment = true, GuideAssigned = "Mitchell" },
            new Gear { Id = 50, LabelNumber = 2, SerialNumber = "Bcdefg12345", GearType = GearType.Camera, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "GoPro", GearModel = "Hero 4 Black", Size = "", Notes = "No Screen on the back", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.Office, GuideEquipment = true, GuideAssigned = "" },
            new Gear { Id = 51, LabelNumber = 3, SerialNumber = "Cdefg1234ab", GearType = GearType.Radio_Harness, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "Canon", GearModel = "Powershot", Size = "", Notes = "strap broke off, needs replacing", RescueGear = false, Status = GearStatus.NeedsAttention, Location = GearLocation.Office, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 52, LabelNumber = 1, SerialNumber = "Abcdefg1234", GearType = GearType.Camera, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "GoPro", GearModel = "Hero 4", Size = "", Notes = "", RescueGear = false, Status = GearStatus.Retired, Location = GearLocation.StorageUnit, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 53, LabelNumber = 2, SerialNumber = "Bcdefg12345", GearType = GearType.Camera, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "Canon", GearModel = "Powershot", Size = "", Notes = "Button not working?", RescueGear = false, Status = GearStatus.NeedsAttention, Location = GearLocation.Office, GuideEquipment = false, GuideAssigned = "" },
            //Rope
            new Gear { Id = 54, LabelNumber = 1, SerialNumber = "", GearType = GearType.Rope, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "New England Ropes", GearModel = "Kernmantle 4", Size = "21 feet", Notes = "", RescueGear = true, Status = GearStatus.Good, Location = GearLocation.T3, GuideEquipment = true, GuideAssigned = "Mitchell" },
            new Gear { Id = 55, LabelNumber = 2, SerialNumber = "", GearType = GearType.Rope, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "New England Ropes", GearModel = "Kernmantle 4", Size = "68 feet", Notes = "No Screen on the back", RescueGear = true, Status = GearStatus.Good, Location = GearLocation.T5, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 56, LabelNumber = 3, SerialNumber = "", GearType = GearType.Rope, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "Powerfan", GearModel = "Drope", Size = "standard - 6 feet", Notes = "Installed 7/18/20", RescueGear = false, Status = GearStatus.NeedsAttention, Location = GearLocation.T6, GuideEquipment = false, GuideAssigned = "" },
             //Prussik Rope
            new Gear { Id = 57, LabelNumber = 1, SerialNumber = "", GearType = GearType.Prussik_Rope, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "New England Ropes", GearModel = "Kernmantle 1", Size = "Regular", Notes = "", RescueGear = true, Status = GearStatus.Good, Location = GearLocation.T3, GuideEquipment = false, GuideAssigned = "" },
            new Gear { Id = 58, LabelNumber = 2, SerialNumber = "", GearType = GearType.Prussik_Rope, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "New England Ropes", GearModel = "Kernmantle 1", Size = "Regular", Notes = "needs retying", RescueGear = true, Status = GearStatus.NeedsAttention, Location = GearLocation.Office, GuideEquipment = true, GuideAssigned = "Mitchell" },
            new Gear { Id = 59, LabelNumber = 3, SerialNumber = "", GearType = GearType.Prussik_Rope, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "Misty Mountain", GearModel = "Standard", Size = "Regular", Notes = "", RescueGear = true, Status = GearStatus.Good, Location = GearLocation.T6, GuideEquipment = false, GuideAssigned = "" },
            //Misc
            new Gear { Id = 60, LabelNumber = 1, SerialNumber = "asdf1234", GearType = GearType.Misc, DateOfFirstUse = DateTime.Parse("05/01/2020"), Manufacturer = "Petzl", GearModel = "ASC (Ascender)", Size = "", Notes = "Got this for free from petzl, might be good to trim trees with", RescueGear = false, Status = GearStatus.Good, Location = GearLocation.StorageChalet, GuideEquipment = false, GuideAssigned = "" },
            };
        }

    }
}
