using System;

namespace Benergy.Modules.Subscription.Common
{
    /// <summary>
    /// Messages shown in the subscription module
    /// </summary>
    public static class SubscriptionMessages
    {
        // Users
        public const string UserAddedSuccess = "User Added Successfully";
        public const string UserUpdatedSuccess = "User Updated Successfully";
        public const string UserDeleteSuccess = "User Deleted Successfully";
        public const string UserPasswordUpdateSuccess = "User Password Updated Successfully";


         // UserSubscriptions
        public const string UserSubscriptionAddedSuccess = "User Subscription Added Successfully";
        public const string UserSubscriptionUpdatedSuccess = "User Subscription Updated Successfully";
        public const string UserSubscriptionDeleteSuccess = "User Subscription Deleted Successfully";
        public const string UserSubscriptionDeactivatedSuccess = "User Subscription Deactivated Successfully";
        public const string UserSubscriptionActivatedSuccess = "User Subscription Activated Successfully";


        //Email strings
        public const string EmailSenderAddress = "mailtoyared@gmail.com";
        public const string EmailSenderName = "Yared";
        public const string SignUpEmailBody = "Thanks for signing up with Benergy!";
        public const string SignUpEmailSubject = "Thanks for signing up with Benergy!";
    }
}