using System.Collections.Generic;
using Behlog.Core.Models.System;

namespace Behlog.Web.ViewModels.System {

    /// <summary>
    /// Represents a <see cref="City"/> that 
    /// contains a City data and is a child of a <see cref="ProvinceViewModel"/>.
    /// </summary>
    public class CityViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public string ParentTitle { get; set; }
    }

    /// <summary>
    /// Represents a <see cref="City"/> that contains a Province data.
    /// a Province is a <see cref="City"/> when It's <see cref="City.ParentId"/> is null.
    /// </summary>
    public class ProvinceViewModel {

        public ProvinceViewModel() {
            Cities = new List<CityViewModel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public IEnumerable<CityViewModel> Cities { get; set; }
    }

}
