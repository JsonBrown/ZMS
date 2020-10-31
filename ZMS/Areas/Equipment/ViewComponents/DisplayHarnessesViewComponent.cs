using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZMS.Data.Equipment;
using ZMS.Domain.Equipment;

namespace ZMS.Areas.Equipment.ViewComponents
{
    public class DisplayHarnessesViewComponent : ViewComponent
    {
        private readonly IGearData gearData;

        public DisplayHarnessesViewComponent(IGearData gearData)
        {
            this.gearData = gearData;
        }
        public IViewComponentResult Invoke()
        {
            var harnesses = gearData.GetByGearType(GearType.Harness).ToList();
            return View(harnesses);
        }
    }
}
