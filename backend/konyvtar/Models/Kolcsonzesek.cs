namespace konyvtar.Models
{
    public class Kolcsonzesek
    {
        public int Id { get; set; }
        public int KolcsonzokId { get; set; }
        public string? Iro { get; set; }
        public string? Mufaj { get; set; }
        public string? Cim { get; set; }
    }
}
