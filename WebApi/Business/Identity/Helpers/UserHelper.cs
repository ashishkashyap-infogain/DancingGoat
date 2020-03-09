using CMS.Membership;

using Business.Identity.Models;

namespace Business.Identity.Helpers
{
    public static class UserHelper
    {
        // Hotfix-independent variant (begin)
        /*
        /// <summary>
        /// Updates the custom fields of the <see cref="UserInfo"/> object with strongly-typed properties of the <see cref="DubaiCultureUser"/> object.
        /// </summary>
        /// <param name="userInfo">The object to update.</param>
        /// <param name="DubaiCultureUser">The input object.</param>
        /// <remarks>Omits properties that need special handling (e.g. <see cref="DubaiCultureUser.AvatarId"/>).</remarks>
        public static void UpdateUserInfo(ref UserInfo userInfo, DubaiCultureUser DubaiCultureUser)
        {
            userInfo.UserName = DubaiCultureUser.UserName;
            userInfo.FullName = UserInfoProvider.GetFullName(DubaiCultureUser.FirstName, null, DubaiCultureUser.LastName);
            userInfo.FirstName = DubaiCultureUser.FirstName;
            userInfo.LastName = DubaiCultureUser.LastName;
            userInfo.Email = DubaiCultureUser.Email;
            userInfo.Enabled = DubaiCultureUser.Enabled;
            userInfo.UserSecurityStamp = DubaiCultureUser.SecurityStamp;
            userInfo.UserNickName = userInfo.GetFormattedUserName(true);
            userInfo.SetValue("UserPassword", DubaiCultureUser.PasswordHash);

            userInfo.UserAvatarID = DubaiCultureUser.AvatarId;
            userInfo.UserSettings.UserDateOfBirth = DubaiCultureUser.DateOfBirth;
            userInfo.UserSettings.UserGender = (int)DubaiCultureUser.Gender;
            userInfo.UserSettings.UserPhone = DubaiCultureUser.Phone;
            userInfo.SetValue("City", DubaiCultureUser.City);
            userInfo.SetValue("Street", DubaiCultureUser.Street);
            userInfo.SetValue("Nationality", DubaiCultureUser.Nationality);
        }
        */
        // Hotfix-independent variant (end)
    }
}
