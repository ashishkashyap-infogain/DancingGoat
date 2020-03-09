using System;
using System.Collections.Generic;

using CMS.Membership;

using Business.Identity.Models;
using Business.Identity.Helpers;

namespace Business.Identity.Extensions
{
    public static class UserExtensions
    {
        // Hotfix-independent variant (begin)
        /*
        /// <summary>
        /// Creates a <see cref="DubaiCultureUser"/> object out of a <see cref="UserInfo"/> one.
        /// </summary>
        /// <param name="userInfo">The original object.</param>
        /// <param name="siteContextService">Service that supplies the site name.</param>
        /// <returns>The <see cref="DubaiCultureUser"/> object.</returns>
        public static DubaiCultureUser ToDubaiCultureUser(this UserInfo userInfo) =>
            new DubaiCultureUser(UserInfoProvider.CheckUserBelongsToSite(userInfo, CMS.SiteProvider.SiteContext.CurrentSiteName));


        /// <summary>
        /// Creates a <see cref="UserInfo"/> out of a <see cref="DubaiCultureUser"/> one.
        /// </summary>
        /// <param name="DubaiCultureUser">The original <see cref="DubaiCultureUser"/> object.</param>
        /// <returns>The <see cref="UserInfo"/> object.</returns>
        public static UserInfo ToUserInfo(this DubaiCultureUser DubaiCultureUser)
        {
            var userInfo = new UserInfo();
            UserHelper.UpdateUserInfo(ref userInfo, DubaiCultureUser);

            return userInfo;
        }
        */
        // Hotfix-independent variant (end)

        /// <summary>
        /// Converts standard ASP.NET Identity <see cref="string"/> roles to <see cref="Roles"/>.
        /// </summary>
        /// <param name="roles">ASP.NET Identity roles.</param>
        /// <returns>Strongly-typed <see cref="Roles"/> roles.</returns>
        public static Roles ToDubaiCultureRoles(this IEnumerable<string> roles)
        {
            Roles foundRoles = Roles.None;

            if (roles != null)
            {
                foreach (var role in roles)
                {
                    if (Enum.TryParse(role, out Roles parsedRole))
                    {
                        foundRoles |= parsedRole;
                    }
                } 
            }

            return foundRoles;
        }
    }
}
