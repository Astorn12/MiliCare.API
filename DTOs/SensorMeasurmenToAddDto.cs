namespace MiliCare.DTOs
{
    public class SensorMeasurmenToAddDto
    {
        public int UserId { get; set; }
        public int SensorId { get; set; }
        public double Value { get; set; }
    }
}