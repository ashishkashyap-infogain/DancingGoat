﻿using System;
using System.Collections.Generic;

using Business.Identity.Models;

namespace Business.Services.Model
{
    /// <summary>
    /// Custom mapper between Identity user models and custom user models.
    /// </summary>
    public interface IUserModelService : IService
    {
        /// <summary>
        /// Maps properties of a <see cref="DubaiCultureUser"/> object to properties with the same name and type in the <paramref name="targetModelType"/> object.
        /// </summary>
        /// <param name="user">The source user object.</param>
        /// <param name="targetModelType">The type of the output object.</param>
        /// <param name="customMappings">Custom mappings of properties with different names and/or types.</param>
        /// <returns>The <paramref name="targetModelType"/> object with mapped properties.</returns>
        object MapToCustomModel(DubaiCultureUser user, Type targetModelType, Dictionary<(string propertyName, Type propertyType), object> customMappings = null);

        /// <summary>
        /// Maps properties of the <paramref name="customModel"/> object to properties of the same name and type in the <see cref="DubaiCultureUser"/> object.
        /// </summary>
        /// <param name="customModel">The source model object.</param>
        /// <param name="userToMapTo">The target Identity user object.</param>
        /// <param name="customMappings">Custom mappings of properties with different names and/or types.</param>
        /// <returns>The mapped <see cref="DubaiCultureUser"/> object.</returns>
        DubaiCultureUser MapToDubaiCultureUser(object customModel, DubaiCultureUser userToMapTo, Dictionary<(string propertyName, Type propertyType), object> customMappings = null);
    }
}
