
using Entities.Enum;

namespace Entities.DataTransferObjects.Request.User
{
    public class GetUserListByTypeRequest
    {
        public GeneralEnum.RoleType Role { get; set; }
    }
}
