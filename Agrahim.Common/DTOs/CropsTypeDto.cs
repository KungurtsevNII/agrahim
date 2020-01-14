namespace Agrahim.Common.DTOs
{
    public class CropsTypeDto
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public decimal CoefficientN { get; set; }
        
        public decimal CoefficientP { get; set; }
        
        public decimal CoefficientK { get; set; }

        public bool IsRemoved { get; set; }
    }
}