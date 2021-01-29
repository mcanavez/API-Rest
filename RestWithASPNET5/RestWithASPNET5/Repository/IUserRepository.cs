using RestWithASPNETMesaRadionica.Data.VO;
using RestWithASPNETMesaRadionica.Model;

namespace RestWithASPNETMesaRadionica.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string username);

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);


    }
}
