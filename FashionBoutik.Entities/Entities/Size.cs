namespace FashionBoutik.Entities
{
    public class Size : BaseEntity<int>
    {
        //public string Name { get; set; }
        public SizeEnum Acronym { get; set; } = SizeEnum.S;
        public string Description { get; set; }
    }
}
