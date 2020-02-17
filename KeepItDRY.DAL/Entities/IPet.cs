namespace KeepItDRY.DAL.Entities
{
    public interface IPet : IEntity
    {
        public string Name { get; set; }
        public PetTypes PetType { get; set; }
        public Address Address { get; set; }
    }
}
