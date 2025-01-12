using BusinessObjects;
using DataAccessObjects;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountMember GetAccountById(string id)
        {
            return AccountDAO.GetAccountById(id);
        }
    }
}
