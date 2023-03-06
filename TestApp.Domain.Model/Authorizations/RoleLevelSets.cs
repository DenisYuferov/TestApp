namespace TestApp.Domain.Model.Authorizations
{
    public class RoleLevelSets
    {
        public const string AdminLevel = $"{Roles.Admin}";
        public const string UserLevel = $"{Roles.Admin}, {Roles.User}";
    }
}
