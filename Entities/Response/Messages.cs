namespace Entities.Response
{
    public static class Messages
    {
        public static class Success
        {
            public const string Created = "Record created successfully";
            public const string Updated = "Record updated successfully";
            public const string Deleted = "Record deleted successfully";
            public const string Retrieved = "Record retrieved successfully";
            public const string Listed = "Records listed successfully";
            public const string PasswordChanged = "Password has been changed successfully";
            public const string PasswordReset = "Password reset email has been sent successfully";
            public const string LoginSuccess = "Login successful";
            public const string RegisterSuccess = "Registration completed successfully";
            public const string LogoutSuccess = "Logout successful";
            public const string TokenRefreshed = "Token refreshed successfully";
        }

        public static class Error
        {
            public const string NotFound = "Record not found";
            public const string AlreadyExists = "Record already exists";
            public const string ValidationError = "Validation error";
            public const string UnauthorizedAccess = "Unauthorized access";
            public const string ServerError = "Internal server error";
            public const string PasswordChangeFailed =
                "Failed to change password. Please try again";
            public const string PasswordResetFailed = "Failed to reset password. Please try again";
            public const string OldPasswordIncorrect = "Current password is incorrect";
            public const string InvalidCredentials = "Invalid username or password";
            public const string AccountLocked = "Account is locked. Please try again later";
            public const string AccountNotConfirmed = "Please confirm your email first";
            public const string RegisterFailed = "Registration failed";
            public const string TokenExpired = "Token has expired";
            public const string InvalidToken = "Invalid token";
            public const string UserNotFound = "User not found";
        }
    }
}
