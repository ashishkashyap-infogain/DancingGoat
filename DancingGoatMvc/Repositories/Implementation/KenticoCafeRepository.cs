﻿using System;
using System.Collections.Generic;
using System.Linq;

using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DancingGoatMvc;
using CMS.SiteProvider;

namespace DancingGoat.Repositories.Implementation
{
    /// <summary>
    /// Represents a collection of cafes.
    /// </summary>
    public class KenticoCafeRepository : ICafeRepository
    {
        private readonly string mCultureName;
        private readonly bool mLatestVersionEnabled;


        /// <summary>
        /// Initializes a new instance of the <see cref="KenticoCafeRepository"/> class that returns cafes using the specified language.
        /// If the requested cafe doesn't exist in specified language then its default culture version is returned.
        /// </summary>
        /// <param name="cultureName">The name of a culture.</param>
        /// <param name="latestVersionEnabled">Indicates whether the repository will provide the most recent version of pages.</param>
        public KenticoCafeRepository(string cultureName, bool latestVersionEnabled)
        {
            mCultureName = cultureName;
            mLatestVersionEnabled = latestVersionEnabled;
        }


        /// <summary>
        /// Returns an enumerable collection of company cafes ordered by a position in the content tree.
        /// </summary>
        /// <param name="count">The number of cafes to return. Use 0 as value to return all records.</param>
        /// <returns>An enumerable collection that contains the specified number of cafes ordered by a position in the content tree.</returns>
        public IEnumerable<Cafe> GetCompanyCafes(int count = 0)
        {
            return GetBaseCafesQuery()
                .WhereTrue("CafeIsCompanyCafe")
                .TopN(count)
                .ToList();
        }


        /// <summary>
        /// Returns a single cafe for the given <paramref name="guid"/>.
        /// </summary>
        /// <param name="guid">Node Guid.</param>
        /// <returns>Returns a single cafe for the given <paramref name="guid"/>.</returns>
        public Cafe GetCafeByGuid(Guid guid)
        {
            return GetBaseCafesQuery()
                .WhereEquals("NodeGUID", guid)
                .TopN(1)
                .FirstOrDefault();
        }


        /// <summary>
        /// Returns an enumerable collection of partner cafes ordered by a position in the content tree.
        /// </summary>
        /// <returns>An enumerable collection of partner cafes ordered by a position in the content tree.</returns>
        public IEnumerable<Cafe> GetPartnerCafes()
        {
            return GetBaseCafesQuery()
                .WhereFalse("CafeIsCompanyCafe")
                .ToList();
        }


        /// <summary>
        /// Shared <see cref="DocumentQuery"/> for querying cafes.
        /// </summary>
        private DocumentQuery<Cafe> GetBaseCafesQuery()
        {
            return CafeProvider.GetCafes()
                .LatestVersion(mLatestVersionEnabled)
                .Published(!mLatestVersionEnabled)
                .OnSite(SiteContext.CurrentSiteName)
                .Culture(mCultureName)
                .CombineWithDefaultCulture()
                .OrderBy("NodeOrder");
        }
    }
}