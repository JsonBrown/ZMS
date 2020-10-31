using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZMS.Data.Equipment;
using ZMS.Domain.Equipment;

namespace ZMS.Areas.Equipment.Pages
{
    public class EquipmentModel : PageModel
    {
        private readonly IGearData gearData;
        public IEnumerable<Gear> GearSearch;
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }
        public IEnumerable<Gear> AllEquipment { get; set; }
        public int NeedsAttention => AllEquipment.Count(g => g.Status == GearStatus.NeedsAttention);
        public IEnumerable<Gear> Harnesses => AllEquipment.Where(g => g.Status == GearStatus.Good && g.GearType == GearType.Harness);
        public EquipmentModel(IGearData gearData)
        {
            this.gearData = gearData;
        }
        public void OnGet()
        {
            AllEquipment = gearData.GetAllEquipment();
            GearSearch = GetGearByLabel(Search);
        }
        public IEnumerable<Gear> GetGearByLabel(string label = null)
        {
            return from g in AllEquipment
                   where g.LabelNumber == int.Parse(label)
                   orderby g.GearType
                   select g;
        }
    }
    }

