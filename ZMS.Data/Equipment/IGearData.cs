using System;
using System.Collections.Generic;
using System.Text;
using ZMS.Domain.Equipment;

namespace ZMS.Data.Equipment
{
    public interface IGearData
    {
        IEnumerable<Gear> GetAllEquipment();
        // IEnumerable<Gear> GetByGearType(string type);
        Gear GetGearById(int id);
        Gear AddGear(Gear newGear);
        Gear UpdateGear(Gear updatedGear);
        Gear DeleteGear(int id);
       // Gear RetireGear(); - might not need this one...
        int Commit();
        IEnumerable<GearInspection> GetInspections(int id);
        GearInspection GetInspectionById(int id);
        GearInspection AddInspection(GearInspection newInspection);
        GearInspection UpdateInspection(GearInspection updatedInspection);
        GearInspection DeleteInspection(int id);



    }
}
