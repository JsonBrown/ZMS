using System;
using System.Collections.Generic;
using System.Text;
using ZMS.Domain.Equipment;

namespace ZMS.Data.Equipment
{
    public interface IGearData
    {
        IEnumerable<Gear> GetAll();
        IEnumerable<Gear> GetByGearType();
        Gear GetGearById(int Id);
        Gear AddGear(Gear newGear);
        Gear UpdateGear(Gear updatedGear);
        Gear DeleteGear();
       // Gear RetireGear(); - might not need this one...
        int Commit();
        IEnumerable<GearInspection> GetInspections(int id);
        GearInspection GetInspectionById(int id);
        GearInspection AddInspection(GearInspection newInspection);
        GearInspection UpdateInspection(GearInspection updatedInspection);
        GearInspection DeleteInspection();



    }
}
