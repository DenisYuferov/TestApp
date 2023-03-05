namespace TestApp.Domain.Model.Authorizations
{
    public class RoleLevelSets
    {
        public const string AdminLevel = $"{Roles.Admin}, {Roles.User}";
        public const string UserLevel = $"{Roles.User}";
    }
}
