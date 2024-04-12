namespace YgoLocals.Infrastructure
{
    public static class Constants
    {
        public const string AdministratorRoleName = "Administrator";

        public const string AppConfig = "AppConfig";
        public const string InitCred = "InitCred";

        //public static readonly string[] AllowedExtensions = { ".png", ".img", ".jpg", ".jpeg" };
        //public const int MaxImageSize = 10 * 102 * 1024;
        //public const string ImagePath = "/uploads/{0}";
        //public const string ImageUploadsPath = "uploads";

        public const string DefaultAuthorPic = "DefaultCardPic.jpg";

        public static class Email
        {
            public const string EmailFormSubject = "YGO Locals website message";
            public const string EmailFormBody = @"
                    <!DOCTYPE html>
                    <html>
                    <head>
                      <title>Your Title Here</title>
                      <style>
                        /* Add your custom CSS styles here */
                        body {
                          font-family: Arial, sans-serif;
                          background-color: #f4f4f4;
                          color: #333;
                          margin: 0;
                          padding: 20px;
                        }
                        .container {
                          max-width: 600px;
                          margin: 0 auto;
                          background-color: #fff;
                          padding: 20px;
                          border-radius: 8px;
                          box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
                        }
                        h1 {
                          color: #007bff;
                        }
                        p {
                          line-height: 1.6;
                        }
                      </style>
                    </head>
                    <body>
                      <div class='container'>
                        <h1>Hello, User!</h1>
                        <p>This is an example email with HTML markup.</p>
                        
                        <p><strong>Here are some tips:</strong></p>
                        <ul>
                          <li>You can use HTML tags like &lt;p&gt;, &lt;h1&gt;, &lt;a&gt;, etc.</li>
                          <li>Inline styles are supported.</li>
                          <li>Don't forget to test your emails on different devices.</li>
                        </ul>
                        
                        <p>If you have any questions, feel free to <a href='mailto:your-email@example.com'>contact us</a>.</p>
                        
                        <p>Best regards,<br>Your Name</p>
                      </div>
                    </body>
                    </html>
                ";
            public const string EmailForgotPasswordSubject = "Reset Password Request YGO Locals";
            public const string EmailForgodPasswordBody = "Please reset your password by <a href='{0}'>clicking here</a>.";
            public const string EmailChangeSubject = "Confirm your email for YGO Locals";
            public const string EmailChangeBody = "Please confirm your account by <a href='{0}'>clicking here</a>.";
        }
    }
}
