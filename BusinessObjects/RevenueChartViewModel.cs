using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;

namespace BusinessObjects
{
    public class RevenueChartViewModel
    {
        public RevenueChartViewModel(DateTimeFilterType filterType)
        {
            using var context = new MentorClassManagementContext();

            var dateRange = GetDateRange(filterType);

            var revenueData = context.Payments
                .Where(p => p.PaymentDate >= dateRange.Item1 && p.PaymentDate <= dateRange.Item2)
                .AsEnumerable()
                .GroupBy(p => filterType == DateTimeFilterType.ThisWeek
                    ? p.PaymentDate.Date
                    : filterType == DateTimeFilterType.ThisYear
                        ? new DateTime(p.PaymentDate.Year, p.PaymentDate.Month, 1)
                        : p.PaymentDate.Date)
                .Select(g => new
                {
                    Label = filterType == DateTimeFilterType.ThisWeek
                                ? g.Key.ToString("ddd dd/MM")
                                : filterType == DateTimeFilterType.ThisYear
                                    ? g.Key.ToString("MM/yyyy")
                                    : g.Key.ToString("dd/MM/yyyy"),
                    Total = g.Sum(p => p.Amount)
                })
                .OrderBy(x => x.Label)
                .ToList();

            RevenueSeries = new ISeries[]
            {
            new ColumnSeries<decimal>
            {
                Values = revenueData.Select(x => x.Total).ToArray(),
                Name = "Revenue",
                Fill = new SolidColorPaint(SKColors.SteelBlue)
            }
            };

            RevenueXAxes = new Axis[]
            {
            new Axis { Labels = revenueData.Select(x => x.Label).ToArray() }
            };

            RevenueYAxes = new Axis[]
            {
            new Axis { Name = "VND" }
            };
        }

        private Tuple<DateTime, DateTime> GetDateRange(DateTimeFilterType filter)
        {
            var now = DateTime.Now;
            return filter switch
            {
                DateTimeFilterType.AllTime => new Tuple<DateTime, DateTime>(
                    new DateTime(1753, 1, 1),
                    DateTime.MaxValue),

                DateTimeFilterType.ThisYear => new Tuple<DateTime, DateTime>(
                    new DateTime(now.Year, 1, 1),
                    new DateTime(now.Year, 12, 31)),

                DateTimeFilterType.ThisMonth => new Tuple<DateTime, DateTime>(
                    new DateTime(now.Year, now.Month, 1),
                    new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month))),

                DateTimeFilterType.ThisWeek => new Tuple<DateTime, DateTime>(
                    now.AddDays(-(int)now.DayOfWeek + (int)DayOfWeek.Monday),
                    now.AddDays(7 - (int)now.DayOfWeek)),

                _ => new Tuple<DateTime, DateTime>(
                    new DateTime(1753, 1, 1),
                    DateTime.MaxValue)
            };
        }

        public IEnumerable<ISeries> RevenueSeries { get; set; }
        public IEnumerable<Axis> RevenueXAxes { get; set; }
        public IEnumerable<Axis> RevenueYAxes { get; set; }
    }
}
