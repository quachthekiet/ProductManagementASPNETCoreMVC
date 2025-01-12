using BusinessObjects;

namespace DataAccessObjects
{
    public class AccountDAO
    {
        public static AccountMember GetAccountById(string accountId)
        {
            using var context = new MyStoreContext();
            return context.AccountMembers.FirstOrDefault(a => a.MemberId == accountId);
        }
    }
}
