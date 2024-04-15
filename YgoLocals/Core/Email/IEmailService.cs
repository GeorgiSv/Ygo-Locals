namespace YgoLocals.Core.Email
{
    public interface IEmailService
    {
        Task HandleForgotPasswordAsync(string mailTo, string callBackUrl);

        Task HandleEmailChangeAsync(string mailTo, string callBackUrl);

        Task HandleUserFormAsync(string mailTo);
    }
}
