using System;


public interface IDeleteAccountService
{
    public Task<bool> DeleteAccountAsync(string ID);
}
