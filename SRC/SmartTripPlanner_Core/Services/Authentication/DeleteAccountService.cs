using System;
using Microsoft.AspNetCore.Identity;


public class DeleteAccountService(UserManager<ApplicationUser> _userManager):IDeleteAccountService
{
    public async Task<bool> DeleteAccountAsync(string ID)
    {
        var Account = await _userManager.FindByIdAsync(ID);
        if (Account != null)
        {
            await _userManager.DeleteAsync(Account);
            return true;
        }
        return false;
    }

}
