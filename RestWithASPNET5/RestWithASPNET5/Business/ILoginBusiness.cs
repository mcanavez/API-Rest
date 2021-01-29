using RestWithASPNETMesaRadionica.Data.VO;

namespace RestWithASPNETMesaRadionica.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);

        TokenVO ValidateCredentials(TokenVO token);

        bool RevokeToken(string userName);
    }
}
