using MarmeladeAPI.Models.enums;

namespace MarmeladeAPI.Models
{
    public class Status
    {
        public EStatus StatusEffect { get; set; }
        public int Duration { get; set; }
        public int Value { get; set; }      
    }
}