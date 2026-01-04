namespace FirstApplicationClass.Model.DTO
{
    public class ReadNationalIdentityDTOv1
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int NationalId { get; set; }
    }
    public class ReadNationalIdentityDTOv2
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int NationalIdName { get; set; }
    }
}
