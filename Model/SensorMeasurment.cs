using System;

namespace MiliCare.Model
{
    public class SensorMeasurment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }

    }
}