using System;
using System.Collections;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace RangeControl_example {
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }
    }
    public class DateTimeViewModel {
        public int Count { get; set; }
        public double Start { get; set; }
        IEnumerable itemsSource;
        public IEnumerable ItemsSource { get { return itemsSource ?? (itemsSource = CreateItemsSource(Count)); } }
        protected double GenerateStartValue(Random random) {
            return Start + random.NextDouble() * 100;
        }
        protected double GenerateAddition(Random random) {
            double factor = random.NextDouble();
            if (factor == 1)
                factor = 50;
            else if (factor == 0)
                factor = -50;
            return (factor - 0.5) * 50;
        }
        readonly Random random = new Random();
        DateTime start = new DateTime(2000, 1, 1);
        public TimeSpan Step { get; set; }

        protected IEnumerable CreateItemsSource(int count) {
            var points = new List<DateTimeDataPoint>();

            double value = GenerateStartValue(random);
            points.Add(new DateTimeDataPoint() { Value = start, DisplayValue = value });
            for (int i = 1; i < count; i++) {
                value += GenerateAddition(random);
                start = start + Step;
                points.Add(new DateTimeDataPoint() { Value = start, DisplayValue = value });
            }
            return points;
        }
    }
    public class NumericDataPoint {
        public int Value { get; set; }
        public double DisplayValue { get; set; }
    }
    public class DateTimeDataPoint {
        public DateTime Value { get; set; }
        public double DisplayValue { get; set; }
    }
}
