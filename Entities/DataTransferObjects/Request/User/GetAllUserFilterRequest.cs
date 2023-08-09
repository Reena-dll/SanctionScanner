using Entities.Enum;


namespace Entities.DataTransferObjects.Request.User
{
    public class GetAllUserFilterRequest
    {
        public GeneralEnum.RoleType RoleType { get; set; }
    }
}
