namespace GraduationProject.Models.Contracts
{
    public interface IHasSoftDelete
    {
        bool IsNotDeleted { get; set; }
    }
}
