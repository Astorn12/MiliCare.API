namespace MiliCare.DTOs
{
    public class SensorMeasurmentToReturnDto
    {
        public int UserId { get; set; }
        public int SensorId { get; set; }
        public double Value { get; set; }
    }
}