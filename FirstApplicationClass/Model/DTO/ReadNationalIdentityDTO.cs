namespace FirstApplicationClass.Model.DTO
{
    public class ReadNationalIdentityDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int NationalId { get; set; }
    }
}
