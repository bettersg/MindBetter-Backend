namespace MindBetter.API.Dtos
{
    public class NonProfitDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string WebsiteURL { get; set; }
        public ICollection<ServiceDto> Services { get; set; } = new List<ServiceDto>();
        public ICollection<MemberDto> Members { get; set; } = new List<MemberDto>();
    }

    public class ServiceDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
    }

    public class MemberDto : UserDto
    {
        public string Designation { get; set; }
        public string PermissionType { get; set; }
    }
}
