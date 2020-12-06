using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using DNTPersianUtils.Core;

namespace Behlog.Web.Admin.ViewModels.Components {

    public class PersianDateViewModel {

        private PersianCalendar _calendar = new PersianCalendar();
        private DateTime _now = DateTime.Now;

        public PersianDateViewModel() {
            Value = DateTime.Now;
        }

        public PersianDateViewModel(DateTime dateValue) {
            Value = dateValue;
        }

        #region Properties

        private DateTime? _value;
        public DateTime? Value {
            get {
                if (Day == 0 || Month == 0 || Year == 0)
                    return null;

                try {
                    _value = _calendar.ToDateTime(Year, Month, Day, 0, 0, 0,0,0);
                    return _value;
                }
                catch {
                    return null;
                }
            }
            set {
                _value = value;
                if (_value.HasValue) 
                    setPersianDate();
            }
        }

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public int CurrentDay => _now.GetPersianDayOfMonth();
        public int CurrentMonth => _now.GetPersianMonth();
        public int CurrentYear => _now.GetPersianYear();

        #endregion


        public IList<SelectListItem> Months =>
            new List<SelectListItem> {
                new SelectListItem("فروردین", "1", selected: isCurrentMonth(1)),
                new SelectListItem("اردیبهشت", "2", selected: isCurrentMonth(2)),
                new SelectListItem("خرداد", "3", selected: isCurrentMonth(3)),
                new SelectListItem("تیر", "4", selected: isCurrentMonth(4)),
                new SelectListItem("مرداد", "5", selected: isCurrentMonth(5)),
                new SelectListItem("شهریور", "6", selected: isCurrentMonth(6)),
                new SelectListItem("مهر", "7", selected: isCurrentMonth(7)),
                new SelectListItem("آبان", "8", selected: isCurrentMonth(8)),
                new SelectListItem("آذر", "9", selected: isCurrentMonth(9)),
                new SelectListItem("دی", "10", selected: isCurrentMonth(10)),
                new SelectListItem("بهمن", "11", selected: isCurrentMonth(11)),
                new SelectListItem("اسفند", "12", selected: isCurrentMonth(12))
            };

        public IList<SelectListItem> Days {
            get {
                var result = new List<SelectListItem>();
                for (int i = 1; i <= 31; i++)
                    result.Add(new SelectListItem(i.ToString(), 
                        i.ToString(), 
                        selected: isCurrentDay(i)
                    ));

                return result;
            }
        }

        public IList<SelectListItem> Years {
            get {
                var result = new List<SelectListItem>();
                for(int i = CurrentYear-30; i < CurrentYear+30; i++)
                    result.Add(new SelectListItem(i.ToString(),
                        i.ToString(),
                        selected: isCurrentYear(i)
                    ));

                return result;
            }
        }

        private void setPersianDate() {
            Day = _calendar.GetDayOfMonth(Value.Value);
            Month = _calendar.GetMonth(Value.Value);
            Year = _calendar.GetYear(Value.Value);
        }

        private bool isCurrentMonth(int month) => CurrentMonth == month;

        private bool isCurrentDay(int day) => CurrentDay == day;

        private bool isCurrentYear(int year) => CurrentYear == year;
    }
}
