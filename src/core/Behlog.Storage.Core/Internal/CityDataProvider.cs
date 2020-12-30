using System;
using System.Collections.Generic;
using System.Linq;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;

namespace Behlog.Storage.Core.Internal {
    internal static class CityDataProvider {

        internal static IEnumerable<City> GetIranCities() {
            var provinces = new List<City>();
            var cities = new List<City>();
            int _id = 1;
            foreach (var province in DNTPersianUtils.Core.IranCities.Iran.Provinces) {
                var myprovince = new City {
                    Id = _id,
                    Kind = CityType.Province,
                    Status = EntityStatus.Enabled,
                    Title = province.ProvinceName
                };
                provinces.Add(myprovince);
                _id++;
                foreach (var county in province.Counties) {
                    foreach (var district in county.Districts) {
                        foreach (var city in district.Cities) {
                            cities.Add(new City {
                                Id = _id,
                                Kind = CityType.City,
                                ParentId = myprovince.Id,
                                Status = EntityStatus.Enabled,
                                Title = city.CityName
                            });
                            _id++;
                        }
                    }
                }
            }

            //Combine provinces and cities together and sort them by id
            provinces.AddRange(cities);

            return provinces.OrderBy(_ => _.Id);
        }
    }
}
