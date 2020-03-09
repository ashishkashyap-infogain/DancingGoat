using Business.DependencyInjection;
using Business.Identity;
using Business.Identity.Models;
using System;
using WebApi.Models;

namespace WebApi.Utils
{
    public abstract class BaseIdentityManager
    {
        public IDubaiCultureUserManager<DubaiCultureUser, int> UserManager { get; }

        public IBusinessDependencies Dependencies { get; }

        public BaseIdentityManager(
            IDubaiCultureUserManager<DubaiCultureUser, int> userManager,
            IBusinessDependencies dependencies)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            Dependencies = dependencies ?? throw new ArgumentNullException(nameof(dependencies));
        }

        /// <summary>
        /// Logs exceptions and gets a result object.
        /// </summary>
        /// <typeparam name="TResultState">Result states of the client code.</typeparam>
        /// <param name="methodName">Method name to log.</param>
        /// <param name="exception">An exception to log.</param>
        /// <param name="result">An operation result.</param>
        protected void HandleException<TResultState>(string methodName, Exception exception, ref IdentityManagerResult<TResultState> result)
            where TResultState : Enum
        {
            Dependencies.ErrorHelperService.LogException(GetType().Name, methodName, exception);
            result.Success = false;
            result.Errors.Add(exception.Message);
        }
    }
}