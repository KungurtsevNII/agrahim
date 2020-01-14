namespace Agrahim.Common.DTOs
{
    public class CropDto
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public string CropsTypeName { get; set; }
        
        public bool IsRemoved { get; set; }
    }
}