using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Gear
{
    public class Vehicle : Equipment
    {
        public int Handling { get; set; }
        public int? OffRoadHandling { get; set; }
        public int Speed { get; set; }
        public int? StallSpeed { get; set; }
        public int Acceleration { get; set; }
        public int Body { get; set; }
        public int Armor { get; set; }
        public int Signature { get; set; }
        public int SignatureSonar { get; set; }
        public int AutoNav { get; set; }
        public int? Pilot { get; set; }
        public int Sensor { get; set; }
        public int Cargo { get; set; }
        public int Load { get; set; }
        public string? Seating { get; set; }
        public string? Entry { get; set; }
        public string? Fuel { get; set; }
        public string? Economy { get; set; }
        public string? SetupBreakdownTime { get; set; }
        public string? LandingTakeoffProfile { get; set; }
        public string? ChassisType { get; set; }
        public int? Hull { get; set; }
        public int? Bulwark { get; set; }
    }

    public enum FuelCode
    {
        Diesel,
        ElectricBattery,
        ElectricFuelCell,
        Gasoline,
        JetTurbine,
        JetPropeller,
        Methane,
        RocketFuel,
    }
}
